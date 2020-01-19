function initDataTable(
    modelId,
    source,
    defaultCount,
    columns,
    sorts,
    language) {

    if(typeof (window.tables) == 'undefined')
        window.tables = [];
    if (typeof (window.tables[modelId]) != 'undefined')
        return window.tables[modelId];

    // add the timezone to the source query because this is a common place for times to be displayed
    if (typeof (window.timezone) != 'undefined' &&
        // timezone is already set by the user
        window.timezone != 'set' && 
        // make sure the timezone property has loaded
        typeof (window.timezone.name) != 'undefined') {
        if (source.indexOf('?') > -1)
            source += '&tz=' + escape(window.timezone.name());
        // unlikely because it always contains epicTableId
        else
            source += '?tz=' + escape(window.timezone.name());
        window.timezone = 'set';
    }

    var oTable = $('#' + modelId).dataTable({
        "sPaginationType": "full_numbers",
        "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]],
        "iDisplayLength": defaultCount,
        "bProcessing": true,
        "bServerSide": true,
        "bAutoWidth": false,
        "sAjaxSource": source,
        "aoColumns": columns,
        "aaSorting": sorts,
        "oLanguage": language
    });

    window.tables[modelId] = oTable;
    
    // setup column header search toggles
    $('#' + modelId + '_wrapper').on('click', '.toggle', function (event) {
        var previousSearch = oTable.fnSettings().oPreviousSearch['sSearch'];
        if ($(this).is(':checked'))
            oTable.fnFilter(previousSearch.trim() + ' ' + $(this).attr('search'));
        else
            oTable.fnFilter(previousSearch.replace($(this).attr('search'), '').replace('  ', ' ').trim());
        event.stopImmediatePropagation();
    });

    // per column searching
    $("tfoot input").keyup(function () {
        /* Filter on the column (the index) of this element */
        oTable.fnFilter(this.value, $("tfoot input").index(this));
    });

    oTable.bind({
        'init': function (event, oSettings) {
            // highlight results
            jQuery.fn.dataTableExt.oApi.fnSearchHighlighting(oSettings);
            oTable.parent().find('.dataTables_filter input').autoGrowInput({
                comfortZone: 50,
                minWidth: 150,
                maxWidth: 240
            });
        },
        'filter': function (event, oSettings) {
            oTable.find('th input[type="checkbox"]').each(function () {
                if (oSettings.oPreviousSearch['sSearch'].indexOf($(this).attr('search')) > -1)
                    $(this).attr('checked', 'checked');
                else
                    $(this).removeAttr('checked');
            });
        },
        'draw': function () {
            $('body').layout().resizeAll();
        }
    });
    
    $(window).bind("hashchange", function (e) {
        var search = $.bbq.getState('#' + modelId + '_filter');
        if (typeof (search) != 'undefined' && oTable.fnSettings().oPreviousSearch['sSearch'] != search)
            oTable.fnFilter(search);
    });
    
    return oTable;
}

// Click handler for direct (immediate) actions. This function invokes and AJAX method,
// and does nothing else. Event parameters can specify "success" and/or "error" functions
// to be invoked on success or error of the AJAX call. These functions have the same
// signatures as the corresponding functions defined by the JQuery $.ajax function.

function actionClickHandler (event) {
    var that = $(this);
    
    // Stop event propagation.
    event.preventDefault();

    // Get URL from the target's href attribute.
    var url = that.attr("href");

    // Get function names from event data and create references. If not defined, the
    // references are null (no function will be invoked).
    var successFunc = event.data.successFunc ? window[event.data.successFunc] : null;
    var errorFunc = event.data.errorFunc ? window[event.data.errorFunc] : null;

    // Do the call to the server-side AJAX method.
    $.ajax({
        type: 'POST',
        url: url,
        success: function (data, textStatus, jqXHR) {
            $.bbq.removeState(event.data.bbqKey);
            successFunc(data, textStatus, jqXHR, $('#' + event.data.modelId));
        },
        error: function (jqXHR, textStatus, errorThrown) {
            $.bbq.removeState(event.data.bbqKey);
            errorFunc(jqXHR, textStatus, errorThrown, $('#' + event.data.modelId));
        }
    });

    // Indicate event is fully handled.
    return false;
}

function dialogPostLoadProcessor(modalDialog, autoHeight) {

    // This will be set to maximum height of the tallest <fieldset> or <div>
    // of the inner container.
    var maxHeight = 0;

    // make tabs out of fieldsets
    var container = $(modalDialog).closest('.ui-dialog');
    container.find('.ui-dialog-content ul.ui-tabs-nav').remove();
    var fieldset = $(modalDialog).find('fieldset');
    if (fieldset.length > 1) {
        var $jul = $('<ul></ul>').addClass('ui-tabs-nav');
        container.find('.ui-dialog-content').addClass('ui-tabs').prepend($jul);
        $(modalDialog).find('fieldset').each(function (i) {
            if ($(this).height() > maxHeight)
                maxHeight = $(this).height();
            var title = $(this).find('legend').text();
            $(this).find('legend').remove();
            var id = 'tab_' + i;
            $(this).attr('id', id);
            $jul.append('<li class="ui-state-default ui-corner-top"><a href="#' + id + '">' + title + '</a></li>');
        }).hide();

        // click event in tabs
        container.find('.ui-dialog-content .ui-tabs-nav a').click(function (evt) {
            $(this).parents('ul').find('li').removeClass('ui-tabs-selected ui-state-active');
            $(this).parent('li').addClass('ui-tabs-selected ui-state-active');
            $(this).closest('.ui-dialog-content').find('fieldset').each(function () { $(this).hide(); });
            $($(this).attr('href')).show();
            evt.preventDefault();
        });

        // select the first tab automatically
        container.find('.ui-dialog-content .ui-tabs-nav a').first().click();

        // Add height of the tab bar.
        maxHeight += $jul.outerHeight() + 3;

    } else if (fieldset.length == 1) {

        maxHeight = $(fieldset[0]).height();
        $(fieldset[0]).find('legend').remove();

    } else {

        // Assumes an inner containing <div>.
        maxHeight = $(modalDialog).children(":first").outerHeight();

    }

    // attach validation
    var info = $.validator.unobtrusive.parse(container.find('form'));
    if (info) {
        info.attachValidation();
    }

    // Set height of the dialog container if it should be auto-calculated.
    if (autoHeight)
    // Knocking off a few pixels improves the look a bit. IE needs a couple
    // more pixels than FF.
        $(modalDialog).height(Math.round(maxHeight - 4));

    // And re-center it.
    $(modalDialog).dialog("option", "position", ['center', 'center']);

}

function popDialogClickHandler(event) {
    event.preventDefault();
    var modelId = event.data.modelId;
    var dialogId = event.data.modelId + "_modalDialog";
    
    var url = $(this).attr("href");
    var buttons = [];
    if (event.data.editable) {
        buttons[0] = {
            text: typeof (event.data.saveText) != 'undefined' ? event.data.saveText : "Save",
            click: function () {
                var form = $('#' + dialogId + ' form');
                var method = form.attr("method");
                var action = form.attr("action");
                if(form.valid())
                {
                    $.ajax({
                        type: method,
                        url: action,
                        data: $(form).serialize(),
                        success: function () {
                            $.bbq.removeState(event.data.bbqKey);
                            // Close modal edit dialog, then reload grid.
                            $("#" + dialogId).dialog("close");
                            $('#' + modelId).dataTable().fnDraw();
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            if (this.dataTypes.indexOf('json') > -1) {
                                var error = JSON.parse(jqXHR.responseText);
                                var errorHtml = $('<span style="display:none;" class="ui-state-error ui-corner-all">' + error.Message + '</span>');
                                $("#" + dialogId).prepend(errorHtml);
                                errorHtml.show('fadeIn').delay(3000).hide('fadeOut');
                            } else {
                                // Scripts are not eval-ed when simply loaded into a container.
                                // So load the response (HTML) first, then append the scripts.
                                var response = $(jqXHR.responseText);
                                var tempScripts = $().append(response.find("script"));
                                $("#" + dialogId).html(response);
                                // Do post-load processing.
                                dialogPostLoadProcessor($("#" + dialogId));
                                $("#" + dialogId).append(tempScripts);
                                // This flag tells the custom global ajaxError event handler
                                // that the error has been handled already.
                            }
                            jqXHR.errorHandledLocally = true;
                        }
                    });
                }
            }
        };
        buttons[1] = {
            text: typeof (event.data.cancelText) != 'undefined' ? event.data.cancelText : "Cancel",
            click: function() {
                $.bbq.removeState(event.data.bbqKey);
                $("#" + dialogId).dialog("close");
            }
        };
    } else {
        buttons[0] = {
            text: typeof (event.data.closeText) != 'undefined' ? event.data.closeText : "Close",
            click: function() {
                $.bbq.removeState(event.data.bbqKey);
                $("#" + dialogId).dialog("close");
            }
        };
    }

    $("#" + dialogId).dialog({
        autoOpen: false,
        height: event.data.height === 0 ? 'auto' : event.data.height,
        width: event.data.width === 0 ? 'auto' : event.data.width,
        minWidth: 600,
        modal: true,
        title: event.data.title,
        buttons: buttons,
        open: function() {
            // The same dialog is used for multiple type of displays. When it loads, it
            // initially holds the content from the last use. Then the load occurs and
            // the content is replaced. This is visible to the user, especially if the
            // server is a bit slow. So place the dialog outside the browser window, load
            // it and then move it back. The final placement is done in the function
            // because it is called elsewhere too and needs to be done in all cases.
            $(this).closest(".ui-dialog").css("left", -5000);
            $(this).load(url, function() { dialogPostLoadProcessor(this, event.data.height === 0); });
        },
        close: function() {
            $("#" + dialogId).closest('.ui-dialog').find('.ui-dialog-content .ui-tabs-nav').remove();
        }
    });

    $("#" + dialogId).dialog("open");
    return false;
}

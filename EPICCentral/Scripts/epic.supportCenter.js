var refreshTimeout = null;
var main;
var first = true;
var drafting = false;
var draftingTimeout = null;

function LoadFolder(event) {
    event.preventDefault();
    var oTable = $('#Support-Message-Table').dataTable();
    var link = $(this).find('a').attr('href');
    var start = link.indexOf("folderPath");
    var title = link.substring(start + 11, link.length);
    $('#folder-title').html(unescape(title));
    var oSettings = oTable.fnSettings();
    oSettings.sAjaxSource = link;
    $('#support-message').html('');
    oTable.fnDraw();
}

function MessageError() {

}

function MessageDeleted() {
    $('#Support-Message-Table').dataTable().fnDraw();
}

function DeleteFailed() {

}

function Reply(event) {
    event.preventDefault();
    var newEvent = jQuery.Event();
    newEvent.data = $('#Support-Message-Table').data('addOptions');
    popDialogClickHandler.call($(this), newEvent);
}

function Display(event) {
    event.preventDefault();
    var link = $(this).find('.subject a').attr('href');
    if (typeof (link) != 'undefined' && link.indexOf('CurrentFolder=Drafts') > -1) {
        var newEvent = jQuery.Event();
        newEvent.data = $('#Support-Message-Table').data('addOptions');
        popDialogClickHandler.call($(this).find('.subject a'), newEvent);
    } else if (typeof (link) != 'undefined') {
    $('#support-message').load(link, function () {
        $('#Support-Folders-Table').dataTable().fnDraw();
        if (!first) {
            $('#support-message').layout().destroy();
            first = true;
        }
        $('#support-message').layout({
            north__paneSelector: '.message-heading',
            north__resizable: false,
            north__closable: false,
            north__spacing_open: 0,
            north__scacing_closed: 0,

            center__paneSelector: '.message-body'
        });
        // set up buttons 
        $('.message-heading a').on('click', Reply);
        first = false;
        $('#main').layout().resizeAll();
    });
    }
}

function initCompose(getTos, savingText) {
    var diagButtons = $('#Support-Message-Table_modalDialog').dialog('option', 'buttons');
    var blurFunc = function() {
        if ($("#compose-form:not(:hidden)").length == 0)
            return;
        var form = $("#compose-form");
        form.find('input[name="Send"]').remove();
        var method = $(form).attr("method");
        var action = $(form).attr("action");
        $('#Support-Message-Table_modalDialog ~ .ui-dialog-buttonpane button').attr('disabled', 'disabled');
        $.ajax({
            type: method,
            url: action,
            data: $(form).serialize(),
            timeout: 10000,
            success: function(data) {
                $('#Uid').val(data.Uid);
                drafting = false;
                $('#Support-Message-Table_modalDialog ~ .ui-dialog-buttonpane button').removeAttr('disabled');
            },
            error: function(jqXHR) {
                if (this.dataTypes.indexOf('json') > -1) {
                    var error = JSON.parse(jqXHR.responseText);
                    $('#Uid').val(error.Uid);
                    jqXHR.errorHandledLocally = true;
                }
                drafting = false;
                $('#Support-Message-Table_modalDialog ~ .ui-dialog-buttonpane button').removeAttr('disabled');
            }
        });
    };

    $('#compose input, #compose textarea').blur(function () {
        drafting = true;
        var errorHtml = $('<span style="display:none;" class="ui-state-highlight ui-corner-all">' + savingText + '</span>');
        $('#Support-Message-Table_modalDialog').prepend(errorHtml);
        errorHtml.show('fadeIn').delay(3000).hide('fadeOut');
        setTimeout(blurFunc, 200);
    });
    
    var saveFunc = diagButtons[0].click;
    diagButtons[0].click = function () {
        var save = function () {
            if (drafting) {
                if (draftingTimeout != null) {
                    clearTimeout(draftingTimeout);
                    draftingTimeout = null;
                }
                draftingTimeout = setTimeout(save, 100);
            } else {
                $("#compose-form").append($('<input type="hidden" name="Send" value="true" />'));
                saveFunc();
            }
        };
        save();
    };

    var closeFunc = diagButtons[1].click;
    diagButtons[1].click = function () {
        var close = function () {
            if (drafting) {
                if (draftingTimeout) {
                    clearTimeout(draftingTimeout);
                    draftingTimeout = null;
                }
                draftingTimeout = setTimeout(close, 100);
            } else {
                closeFunc();
                $('#Support-Message-Table').dataTable().fnDraw();
            }
        };
        close();
    };

    function split(val) {
        return val.split(/[,;\n]\s*/);
    }

    function extractLast(term) {
        return split(term).pop();
    }

    $('#To')
        // don't navigate away from the field on tab when selecting an item
        .bind("keydown", function(event) {
            if (event.keyCode === $.ui.keyCode.TAB &&
                $(this).data("autocomplete").menu.active) {
                event.preventDefault();
            }
        })
        .autocomplete({
            source: function(request, response) {
                $.getJSON(getTos, {
                    term: extractLast(request.term)
                }, response);
            },
            focus: function() {
                // prevent value inserted on focus
                return false;
            },
            select: function(event, ui) {
                var terms = split(this.value);
                // remove the current input
                terms.pop();
                // add the selected item
                terms.push(ui.item.value);
                // add placeholder to get the comma-and-space at the end
                terms.push("");
                this.value = terms.join(", ");
                return false;
            }
        });

}

function initMessages() {
    $('#Support-Message-Table').bind('processing', function () {
        if ($('#messages-north').length == 0) {
            $('#Support-Message-Table_wrapper').prepend('<div id="messages-north" /><div id="messages-center" /><div id="messages-south" />');
            $('#Support-Message-Table_length, #Support-Message-Table_filter').appendTo($('#messages-north'));
            $('#Support-Message-Table_info, #Support-Message-Table_paginate').appendTo($('#messages-south'));
            $('#Support-Message-Table').appendTo($('#messages-center'));

            $('#main').layout().resizeAll();

            $('.inner-north').layout({
                center__paneSelector: '#Support-Message-Table_wrapper',
                center__childOptions: {
                    north__paneSelector: '#messages-north',
                    north__resizable: false,
                    north__closable: false,
                    north__spacing_open: 0,
                    north__scacing_closed: 0,

                    south__paneSelector: '#messages-south',
                    south__resizable: false,
                    south__closable: false,
                    south__spacing_open: 0,
                    south__scacing_closed: 0,

                    center__paneSelector: '#messages-center'
                }
            });
        }
    });

    $('#main').layout({
        // all panes
        livePaneResizing: true,
        spacing_open: 8,  // ALL panes
        spacing_closed: 12, // ALL panes

        // title
        north__paneSelector: ".outer-north",
        north__resizable: false,
        north__closable: false,
        north__spacing_open: 0,
        north__scacing_closed: 0,

        // folder navigation
        west__paneSelector: ".outer-west",
        west__minSize: 200,

        // center panel
        center__paneSelector: ".outer-center",

        center__childOptions: {
            // message list
            north__paneSelector: ".inner-north",
            north__minSize: 200,

            // message body
            center__paneSelector: ".inner-center",
            spacing_open: 8,  // ALL panes
            spacing_closed: 12 // ALL panes
        }
    });

    $('#Support-Message-Table').on('click', 'tr', Display);

    $('#Support-Folders-Table').on('click', 'tr', LoadFolder);

    $('#compose-folders').click(function (event) {
        event.preventDefault();
        var newEvent = jQuery.Event();
        newEvent.data = $('#Support-Message-Table').data('addOptions');
        popDialogClickHandler.call($(this), newEvent);
    });
}

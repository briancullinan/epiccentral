var that = null;
var zoom = 1;
var clicked = null;
function InitializeTreatment(url, treatmentId, gender)
{
    $('.severity').hide();

    $('#treatment-menu a').click(function (event) {
        $('#treatment-menu li').removeClass('selected');
        $(this).parent().addClass('selected');
        $('#treatment-menu').removeClass('deselected');
        $('#treatment-organs').show();
        $('#treatment-questions').hide();
        $('.severity').hide();
        $('.organ-' + $(this).attr('id').substring(14, 15)).show();
        $('#body-view').attr('class', gender);
        $('#body-view').addClass($(this).attr('id'));
        event.preventDefault();
    });

    $('#treatment-organs a').click(function (event) {
        $('#finger-images-table a').remove();
        that = $(this);
        var sectorSplit = that.attr('id').substring(10).split('_');
        if (sectorSplit[0] != "") {
            var linkR1 = url
                    + '?fingerDesc=' + sectorSplit[0]
                        + '&treatmentId=' + treatmentId
                            + '&colored=' + ($('#colored:checked').length > 0)
                                + '&filtered=True';
            var linkR2 = url
                    + '?fingerDesc=' + sectorSplit[0]
                        + '&treatmentId=' + treatmentId
                            + '&colored=' + ($('#colored:checked').length > 0)
                                + '&filtered=False';
            $('#finger-images-table tbody td:eq(1)').append($('<a href="' + linkR1 + '" rel="lightbox[images]" title="'
                    + sectorSplit[0] + '"><img height="60" width="80" src="' + linkR1 + '" alt="' + sectorSplit[0] + '"/></a>'));
            $('#finger-images-table tbody td:eq(3)').append($('<a href="' + linkR2 + '" rel="lightbox[images]" title="'
                    + sectorSplit[0] + '"><img height="60" width="80" src="' + linkR2 + '" alt="' + sectorSplit[0] + '"/></a>'));
        }
        if (sectorSplit[1] != "") {
            var linkL1 = url
                    + '?fingerDesc=' + sectorSplit[1]
                        + '&treatmentId=' + treatmentId
                            + '&colored=' + ($('#colored:checked').length > 0)
                                + '&filtered=True';
            var linkL2 = url
                    + '?fingerDesc=' + sectorSplit[1]
                        + '&treatmentId=' + treatmentId
                            + '&colored=' + ($('#colored:checked').length > 0)
                                + '&filtered=False';
            $('#finger-images-table tbody td:eq(0)').append($('<a href="' + linkL1 + '" rel="lightbox[images]" title="'
                    + sectorSplit[1] + '"><img height="60" width="80" src="' + linkL1 + '" alt="' + sectorSplit[1] + '"/></a>'));
            $('#finger-images-table tbody td:eq(2)').append($('<a href="' + linkL2 + '" rel="lightbox[images]" title="'
                    + sectorSplit[1] + '"><img height="60" width="80" src="' + linkL2 + '" alt="' + sectorSplit[1] + '"/></a>'));
        }
        event.preventDefault();
    });

    $('#lb-outerContainer').css('min-height', 200);
    $('#lb-outerContainer').css('min-width', 200);

    $('#finger-images-table').on('click', 'a', function (event) {
        event.preventDefault();
        clicked = $(this).lightBox({ overlayBgColor: '#ffffff' }).click();
    });
    $('body').on('mousewheel', function (event, delta, deltaX, deltaY) {
        if (clicked == null || $('#jquery-lightbox').length == 0)
            return;
        zoom += deltaY;
        if (zoom > 5)
            zoom = 5;
        if (zoom < 1)
            zoom = 1;
        var objImagePreloader = new Image();
        objImagePreloader.onload = function () {
            $('#lightbox-container-image-box').css('height', objImagePreloader.height * zoom + (10 * 2));
            $('#lightbox-container-image-box').css('width', objImagePreloader.width * zoom + (10 * 2));
            $('#lightbox-container-image-data-box').css({ width: objImagePreloader.width * zoom });
            //	clear onLoad, IE behaves irratically with animated gifs otherwise
            objImagePreloader.onload = function () { };
        };
        objImagePreloader.src = clicked.attr('href');
    });

    $('#treatment-banner #colored').click(function () {
        if (that != null)
            that.trigger('click');
    });

    $('#treatment-banner #blackandwhite').click(function () {
        if (that != null)
            that.trigger('click');
    });
}

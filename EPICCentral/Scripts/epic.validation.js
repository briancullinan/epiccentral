// used to validate that the user has entered a property transfer quantity
jQuery.validator.unobtrusive.adapters.add(
    'transferquantity',
    ['min', 'otherproperty'],
    function (options) {
        options.rules['quantityGreaterThan'] = options.params;
        options.messages['quantityGreaterThan'] = function (params, element) {
            var myregexp = /\(([0-9]+)\)/;
            var match = myregexp.exec($('#' + params.otherproperty + ' option:selected').text());
            if (match != null) {
                return $.format(options.message, '', params.min, match[1]);
            } else {
            }
        };
    }
);
jQuery.validator.addMethod('quantityGreaterThan', function (value, element, params) {
    // get the number of scans available by looking in the parenthesis
    var myregexp = /\(([0-9]+)\)/;
    var match = myregexp.exec($('#' + params.otherproperty + ' option:selected').text());
    if (match != null) {
        return parseInt(value) >= parseInt(params.min) && parseInt(value) <= parseInt(match[1]);
    } else {
        return true;
    }
});

// used to validate that the selected devices are not equal
jQuery.validator.unobtrusive.adapters.add(
    'notequalto',
    ['other'],
    function (options) {
        options.rules['notEqualTo'] = options.params;
        options.messages['notEqualTo'] = options.message;
    }
);

    jQuery.validator.addMethod('notEqualTo', function (value, element, params) {
        return value != $('#' + params.other).val();
    });

jQuery.validator.unobtrusive.adapters.add(
    'requiredif',
    ['other', 'condition', 'value'],
    function (options) {
        options.rules['requiredIf'] = options.params;
        options.messages['requiredIf'] = options.message;
    }
);

    jQuery.validator.addMethod('requiredIf', function (value, element, params) {
        var passes = false;
        switch (params.condition) {
            case "EqualTo":
                passes = params.value == $('#' + params.other).val();
                break;
            case "NotEqualTo":
                passes = params.value != $('#' + params.other).val();
                break;
            default:
                throw new "";
        }
        
        if (passes)
            return value.match(/[^\s]/g);
        
        return true;
    });

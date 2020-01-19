if (typeof (EPIC) == "undefined") {
    EPIC = { };
}

if (typeof (EPIC.Username) == "undefined") {
    EPIC.Username = {

        _isValid: false,
        _$el: null,

        init: function ($el, url, $key) {

            this._$el = $el;

            var that = this;
            var divFeedback = $("<div></div>").attr("class", "editor-field-feedback").hide();
            $($el).after(divFeedback);
            $($el).on("input", function () {
                var username = $($el).val();
                var key = $( $key ).val();
                if (username.length > 0) {
                    $.get(url,
	                    { username: username, key: key },
	                    function (response) {
	                        that._isValid = response.isValid;
	                        divFeedback.text(response.feedback);
	                        divFeedback.fadeIn(500).css("display", "inline");
	                    },
	                    "json"
	                );
                } else {
                    divFeedback.fadeOut(500);
                }
            });

            $($el).trigger(new jQuery.Event("input"));

            return this;
        },

        isValid: function () {
            if (!this._isValid) {
                $(this._$el).addClass("input-validation-error");
            }
            return this._isValid;
        }
    };
}
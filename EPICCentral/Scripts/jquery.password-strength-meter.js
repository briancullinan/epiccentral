
(function ($, undefined) {

    $.widget("epic.passwordstrengthmeter", {
        options: {
            required: {
                minLength: 8,
                maxLength: 25,
                numLowers: 0,
                numUppers: 0,
                numDigits: 0,
                numSpecials: 0
            },
            recommended: {
                minLength: 8,
                maxLength: 25,
                numLowers: 1,
                numUppers: 1,
                numDigits: 1,
                numSpecials: 1
            },
            specials: '!@#$',
            showScore: false,
            showHint: true,
            policyUrl: 'PasswordPolicy.xml',
            policyDataType: "xml",
            metricsCalculator: null,
            metricsUrl: null,
            metricsUrlMethod: null,
            messages: {
                charactersNeeded: {
                    singular: "{0} more character",
                    plural: "{0} more characters"
                },
                digitsNeeded: {
                    singular: "{0} more number",
                    plural: "{0} more numbers"
                },
                specialsNeeded: {
                    singular: "{0} more symbol",
                    plural: "{0} more symbols"
                },
                uppersNeeded: {
                    singular: "{0} more uppercase letter",
                    plural: "{0} more uppercase letters"
                },
                lowersNeeded: {
                    singular: "{0} more lowercase letter",
                    plural: "{0} more lowercase letters"
                },
                noSpace: "No spaces!",
                tooLong: "Password too long!",
                invalidCharacter: "Invalid character: {0}",
                atLeast: "At least",
                makeStronger: "Make stronger...",
                strongPassword: "Strong password!",
                valid: "Valid.",
                invalid: "Invalid."
            }
        },

        _passwordValid: false,
        _passwordStrength: 0,
        _metricsCalculator: null,

        _create: function () {

            var psm = this;
            var o = this.options;

            var dataType = o.policyDataType.toLowerCase();
            if (dataType !== "json")
                dataType = "xml";

            var settingsProcessor = this._processXmlSettings;
            if (dataType === "json")
                settingsProcessor = this._processJsonSettings;

            // Get dynamic settings from server.
            $.ajax({
                type: "GET",
                url: o.policyUrl,
                dataType: dataType,
                success: function (data) {
                    settingsProcessor(data, psm);
                }
            });

        },

        _destroy: function () {

            // This method only invoked for jQuery UI v1.9 and above.
            this.divContainer.remove();

            this._unbindEvents();

            return this;
        },

        destroy: function () {

            var version = $.ui.version;
            if (version.indexOf("1.8") === 0) {

                this.divContainer.remove();

                this._unbindEvents();

                $.Widget.prototype.destroy.call(this);
            }

            return this;
        },

        _init: function () {
        },

        _setOption: function (key, value) {

            if (key === 'disabled') {
                if (value === 'true') {

                } else {

                }
            }

            $.Widget.prototype._setOption.apply(this, arguments);
        },

        isValid: function () {
            return this._passwordValid;
        },

        isStrong: function () {
            return !(this._passwordStrength < 1);
        },

        _processJsonSettings: function (json, psm) {

            var o = psm.options;

            var setPolicy = function (policy, optionSet) {

                if (policy.minLength !== "undefined") {
                    optionSet.minLength = policy.minLength;
                }
                if (policy.maxLength !== "undefined") {
                    optionSet.maxLength = policy.maxLength;
                }
                if (policy.numLowers !== "undefined") {
                    optionSet.numLowers = policy.numLowers;
                }
                if (policy.numUppers !== "undefined") {
                    optionSet.numUppers = policy.numUppers;
                }
                if (policy.numDigits !== "undefined") {
                    optionSet.numDigits = policy.numDigits;
                }
                if (policy.numSpecials !== "undefined") {
                    optionSet.numSpecials = policy.numSpecials;
                }

            };

            var setMessages = function (need, charType) {

                if (need.singular !== "undefined") {
                    charType.singular = need.singular;
                }
                if (need.plural !== "undefined") {
                    charType.plural = need.plural;
                }

            };

            $.each(json.policies, function () {
                if (this.type === "required") {
                    setPolicy(this, o.required);
                } else if (this.type === "recommended") {
                    setPolicy(this, o.recommended);
                }
            });

            if (json.messages) {

                var messages = json.messages;

                $.each(messages.needs, function () {
                    if (this.type === "characters") {
                        setMessages(this, o.messages.charactersNeeded);
                    } else if (this.type === "lowers") {
                        setMessages(this, o.messages.lowersNeeded);
                    } else if (this.type === "uppers") {
                        setMessages(this, o.messages.uppersNeeded);
                    } else if (this.type === "digits") {
                        setMessages(this, o.messages.digitsNeeded);
                    } else if (this.type === "specials") {
                        setMessages(this, o.messages.specialsNeeded);
                    }
                });

                if (messages.noSpace !== "undefined") {
                    o.messages.noSpace = messages.noSpace;
                }
                if (messages.tooLong !== "undefined") {
                    o.messages.tooLong = messages.tooLong;
                }
                if (messages.invalidCharacter !== "undefined") {
                    o.messages.invalidCharacter = messages.invalidCharacter;
                }
                if (messages.atLeast !== "undefined") {
                    o.messages.atLeast = messages.atLeast;
                }
                if (messages.makeStronger !== "undefined") {
                    o.messages.makeStronger = messages.makeStronger;
                }
                if (messages.strongPassword !== "undefined") {
                    o.messages.strongPassword = messages.strongPassword;
                }
                if (messages.valid !== "undefined") {
                    o.messages.valid = messages.valid;
                }
                if (messages.invalid !== "undefined") {
                    o.messages.invalid = messages.invalid;
                }

            }

            if (json.specials !== "undefined") {
                o.specials = json.specials;
            }
            if (json.showScore !== "undefined") {
                o.showScore = json.showScore;
            }
            if (json.showHint !== "undefined") {
                o.showHint = json.showHint;
            }
            if (json.metricsUrl !== "undefined") {
                o.metricsUrl = json.metricsUrl;
            }
            if (json.metricsUrlMethod !== "undefined") {
                o.metricsUrlMethod = json.metricsUrlMethod;
            }

            psm._setup();
        },

        _processXmlSettings: function (xml, psm) {

            var o = psm.options;

            var getSetting = function (parent, name) {
                var setting = $(parent).find(name);
                if (setting.length > 0) {
                    return setting.text();
                } else {
                    return null;
                }
            };

            $(xml).find("policy").each(function () {

                var setPolicy = function (policy, optionSet) {

                    var minLength = getSetting(policy, "minLength");
                    var maxLength = getSetting(policy, "maxLength");
                    var numLowers = getSetting(policy, "numLowers");
                    var numUppers = getSetting(policy, "numUppers");
                    var numDigits = getSetting(policy, "numDigits");
                    var numSpecials = getSetting(policy, "numSpecials");

                    // Set any options provided by server.
                    if (minLength !== null) {
                        optionSet.minLength = parseInt(minLength);
                    }
                    if (maxLength !== null) {
                        optionSet.maxLength = parseInt(maxLength);
                    }
                    if (numLowers !== null) {
                        optionSet.numLowers = parseInt(numLowers);
                    }
                    if (numUppers !== null) {
                        optionSet.numUppers = parseInt(numUppers);
                    }
                    if (numDigits !== null) {
                        optionSet.numDigits = parseInt(numDigits);
                    }
                    if (numSpecials !== null) {
                        optionSet.numSpecials = parseInt(numSpecials);
                    }

                };

                var type = $(this).attr("type");
                if (type) {
                    if (type.indexOf("required") !== -1) {
                        setPolicy(this, o.required);
                    }
                    if (type.indexOf("recommended") !== -1) {
                        setPolicy(this, o.recommended);
                    }
                }

            });

            var messages = $(xml).find("messages");
            if (messages !== null) {

                $(messages).find("need").each(function () {

                    var setMessages = function (need, charType) {

                        var singular = getSetting(need, "singular");
                        var plural = getSetting(need, "plural");

                        if (singular !== null) {
                            charType.singular = singular;
                        }
                        if (plural !== null) {
                            charType.plural = plural;
                        }
                    };

                    var type = $(this).attr("type");
                    if (type) {
                        if (type.indexOf("characters") !== -1) {
                            setMessages(this, o.messages.charactersNeeded);
                        }
                        if (type.indexOf("lowers") !== -1) {
                            setMessages(this, o.messages.lowersNeeded);
                        }
                        if (type.indexOf("uppers") !== -1) {
                            setMessages(this, o.messages.uppersNeeded);
                        }
                        if (type.indexOf("digits") !== -1) {
                            setMessages(this, o.messages.digitsNeeded);
                        }
                        if (type.indexOf("specials") !== -1) {
                            setMessages(this, o.messages.specialsNeeded);
                        }
                    }

                });

                var noSpace = getSetting(messages, "noSpace");
                var tooLong = getSetting(messages, "tooLong");
                var invalidCharacter = getSetting(messages, "invalidCharacter");
                var atLeast = getSetting(messages, "atLeast");
                var makeStronger = getSetting(messages, "makeStronger");
                var strongPassword = getSetting(messages, "strongPassword");
                var valid = getSetting(messages, "valid");
                var invalid = getSetting(messages, "invalid");

                if (noSpace !== null) {
                    o.messages.noSpace = noSpace;
                }
                if (tooLong !== null) {
                    o.messages.tooLong = tooLong;
                }
                if (invalidCharacter !== null) {
                    o.messages.invalidCharacter = invalidCharacter;
                }
                if (atLeast !== null) {
                    o.messages.atLeast = atLeast;
                }
                if (makeStronger !== null) {
                    o.messages.makeStronger = makeStronger;
                }
                if (strongPassword !== null) {
                    o.messages.strongPassword = strongPassword;
                }
                if (valid !== null) {
                    o.messages.valid = valid;
                }
                if (invalid !== null) {
                    o.messages.invalid = invalid;
                }
            }

            var specials = getSetting(xml, "specials");
            var showScore = getSetting(xml, "showScore");
            var showHint = getSetting(xml, "showHint");
            var metricsUrl = getSetting(xml, "metricsUrl");
            var metricsUrlMethod = getSetting(xml, "metricsUrlMethod");

            if (specials !== null) {
                o.specials = specials;
            }
            if (showScore !== null) {
                o.showScore = showScore.toLowerCase() === "true";
            }
            if (showHint !== null) {
                o.showHint = showHint.toLowerCase() === "true";
            }
            if (metricsUrl !== null && metricsUrl.length > 0) {
                o.metricsUrl = metricsUrl;
            }
            if (metricsUrlMethod !== null && metricsUrlMethod.length > 0) {
                o.metricsUrlMethod = metricsUrlMethod;
            }

            psm._setup();
        },

        _setup: function () {

            var o = this.options;

            if (o.metricsUrl === null) {
                this._metricsCalculator = this._clientCalculator;
                if (o.metricsCalculator !== null && typeof o.metricsCalculator === 'function') {
                    this._clientCalculatorPlugin = o.metricsCalculator;
                } else {
                    this._clientCalculatorPlugin = this._simpleMetrics;
                }
            } else {
                this._metricsCalculator = this._serverCalculator;
            }

            var container = (this.divContainer = $("<div></div>")).attr("class", "password-strength-meter");
            var iemask = $("<div></div>").attr("class", "password-strength-meter-iemask");
            var gradient = $("<div></div>").attr("class", "password-strength-meter-gradient");
            var overlay = (this.divOverlay = $("<div></div>")).attr("class", "password-strength-meter-overlay");
            var score = (this.divScore = $("<div></div>")).attr("class", "password-strength-meter-score");
            var hint = (this.divHint = $("<div></div>")).attr("class", "password-strength-meter-hint");

            // Hide score and/or hint if options say so.
            if (!o.showScore)
                score.hide();
            if (!o.showHint)
                hint.hide();

            // Add to DOM relative to password textbox.
            this.element.after(container);
            container.append(iemask);
            iemask.append(gradient);
            gradient.append(overlay);
            gradient.append(score);
            container.append(hint);

            // Get current CSS "display" value of container and save. It must be restored
            // when the container is made visible.
            // 
            // NOTE: This must be done AFTER the elements are added to the DOM; IE will
            // error out if not.
            //var allstyles = this._allCss(container);
            //this.containerDisplay = allstyles["display"];
            //this.containerDisplay = container.css('display');
            container.css("display", "none");

            // Bind necessary event handlers.
            this._bindEvents();

        },

        _bindEvents: function () {
            this.element.on("keyup", this._getKeyHandler());
        },

        _unbindEvents: function () {
            this.element.off("keyup", this._getKeyHandler());
        },

        _keyHandler: null,

        _getKeyHandler: function () {

            var self = this;

            if (this._keyHandler === null) {
                this._keyHandler = function () {
                    self._recalculate();
                };
            }

            return this._keyHandler;
        },

        _recalculate: function () {

            // Get current password entry.
            var password = this.element.val();

            // Assume password is not valid.
            this._passwordValid = false;

            if (password.length > 0) {

                this._metricsCalculator(password, this.options);

            } else {

                this._updateDisplay(null);

            }
        },

        _serverCalculator: function (password, opts) {

            var self = this;

            var method = opts.metricsUrlMethod;
            if (method === null) {
                method = "GET";
            }

            $.ajax({
                type: method,
                url: opts.metricsUrl,
                data: { "password": password },
                success: function (metrics) {
                    self._updateDisplay(metrics);
                }
            });
        },

        _clientCalculator: function (password, opts) {

            this._updateDisplay(this._clientCalculatorPlugin(password, $.extend(true, {}, opts)));

        },

        _updateDisplay: function (metrics) {

            if (metrics !== null) {

                this._passwordValid = metrics.isValid;

                var oldStrength = this._passwordStrength;
                var newStrength = metrics.strength;
                if (newStrength !== oldStrength) {
                    this._passwordStrength = newStrength;
                    oldStrength *= 100;
                    newStrength *= 100;
                    var change;
                    if (newStrength > oldStrength) {
                        change = "+=";
                    } else {
                        change = "-=";
                    }
                    var amount = Math.abs(newStrength - oldStrength);
                    change += amount + "%";
                    amount = 5000 / amount;
                    if (oldStrength === 0) {
                        var overlay = this.divOverlay;
                        this.divContainer.fadeIn(500, function () {
                            overlay.animate({ left: change }, amount);
                        }).css("display", '');
                    } else {
                        this.divOverlay.animate({ left: change }, amount);
                    }
                }

                this.divScore.text(metrics.score);
                this.divHint.text(metrics.message);

            } else {

                this._passwordValid = false;

                if (this.divContainer.css("display") !== "none") {
                    if (this._passwordStrength > 0) {
                        var score = this._passwordStrength * 100;
                        var time = 5000 / score;
                        var container = this.divContainer;
                        this.divOverlay.animate({ left: "-=" + score + "%" }, time, function () {
                            container.fadeOut(500);
                        });
                        this._passwordStrength = 0;
                    } else {
                        this.divContainer.fadeOut(500);
                    }
                }

            }

        },

        _simpleMetrics: function (password, opts) {

            // Hint message to display.
            var message;

            // Password passes required parameters.
            var passesReq = false;

            // Analyze password against required options and set analysis parameters.
            var analysis = this._analyzePassword(password, opts.required, opts);
            if (analysis.score >= opts.required.minLength) {
                passesReq = true;
                analysis = this._analyzePassword(password, opts.recommended, opts);
                message = this._getHint(analysis, opts.recommended, opts.messages);
            } else {
                message = this._getHint(analysis, opts.required, opts.messages);
                analysis = this._analyzePassword(password, opts.recommended, opts);
            }

            var strength = analysis.score / opts.recommended.minLength;
            if (strength > 1.0) {
                strength = 1.0;
            }

            var isValid = passesReq && !analysis.tooLong && analysis.invalidChars.length === 0;
            if (isValid) {
                if (opts.messages.valid && opts.messages.valid.length > 0) {
                    message = opts.messages.valid + ". " + message;
                }
            } else {
                if (opts.messages.invalid && opts.messages.invalid.length > 0) {
                    message = opts.messages.invalid + ". " + message;
                }
            }

            var metrics = new Object();

            metrics.score = analysis.score;
            metrics.strength = strength;
            metrics.isValid = isValid;
            metrics.message = message;

            return metrics;
        },

        _analyzePassword: function (password, params, opts) {

            var len = password.length;

            // Create allowed special character regex.
            var allowableSpecialChars = new RegExp("[" + opts.specials.replace(/\\/g, "\\\\").replace(/]/g, "\\]") + "]", "g");

            var spaceCount = this._countMatch(password, /\s/g);
            var digitCount = this._countMatch(password, /\d/g);
            var lowerCount = this._countMatch(password, /[a-z]/g);
            var upperCount = this._countMatch(password, /[A-Z]/g);
            var specialCount = this._countMatch(password, allowableSpecialChars);

            // Check for invalid characters.
            var inValidChars = "";
            inValidChars = password.replace(/[a-z]/gi, "") + inValidChars.replace(/\d/g, "");
            inValidChars = inValidChars.replace(/\d/g, "");
            inValidChars = inValidChars.replace(allowableSpecialChars, "");

            // Calculate score.
            var score;
            var lowersTogo = params.numLowers - lowerCount;
            if (lowersTogo < 0) {
                lowersTogo = 0;
            }
            var uppersTogo = params.numUppers - upperCount;
            if (uppersTogo < 0) {
                uppersTogo = 0;
            }
            var digitsTogo = params.numDigits - digitCount;
            if (digitsTogo < 0) {
                digitsTogo = 0;
            }
            var specialsTogo = params.numSpecials - specialCount;
            if (specialsTogo < 0) {
                specialsTogo = 0;
            }
            score = params.minLength - (lowersTogo + uppersTogo + digitsTogo + specialsTogo);
            if (len < score)
                score = len;

            // Build analysis object to return.
            var analysis = new Object();

            analysis.totalCount = len;
            analysis.spaceCount = spaceCount;
            analysis.digitCount = digitCount;
            analysis.lowerCount = lowerCount;
            analysis.upperCount = upperCount;
            analysis.specialCount = specialCount;
            analysis.invalidChars = inValidChars;
            analysis.score = score;
            analysis.tooLong = len > params.maxLength;

            return analysis;
        },

        _getHint: function (analysis, params, messages) {

            // Get analysis parameters.
            var specialCount = analysis.specialCount;
            var digitCount = analysis.digitCount;
            var upperCount = analysis.upperCount;
            var lowerCount = analysis.lowerCount;
            var invalidChars = analysis.invalidChars;
            var score = analysis.score;

            // Cannot contain spaces.
            if (analysis.spaceCount > 0) {
                return messages.noSpace;
            }

            // Cannot have invalid characters.
            if (invalidChars.length > 0) {
                return this._format(messages.invalidCharacter, invalidChars);
            }

            // Cannot be too long.
            if (analysis.tooLong) {
                return messages.tooLong;
            }

            // Have strong password?
            if (score >= params.minLength) {
                return messages.strongPassword;
            }

            var msg = "";

            // Calculate number of characters password has.
            var haveCount = lowerCount + upperCount + specialCount + digitCount;

            // Total characters needed.
            if (haveCount < params.minLength) {
                msg = this._appendHint(msg, messages.charactersNeeded.singular, messages.charactersNeeded.plural, params.minLength - haveCount);
            }

            var atLeast = "";

            // Digits needed?
            if (digitCount < params.numDigits) {
                atLeast = this._appendHint(atLeast, messages.digitsNeeded.singular, messages.digitsNeeded.plural, params.numDigits - digitCount);
            }

            // Special characters needed?
            if (specialCount < params.numSpecials) {
                atLeast = this._appendHint(atLeast, messages.specialsNeeded.singular, messages.specialsNeeded.plural, params.numSpecials - specialCount);
            }

            // Uppercase letters needed?
            if (upperCount < params.numUppers) {
                atLeast = this._appendHint(atLeast, messages.uppersNeeded.singular, messages.uppersNeeded.plural, params.numUppers - upperCount);
            }

            // Lowercase letters needed?
            if (lowerCount < params.numLowers) {
                atLeast = this._appendHint(atLeast, messages.lowersNeeded.singular, messages.lowersNeeded.plural, params.numLowers - lowerCount);
            }

            // Specific characters needed?
            if (atLeast.length > 0) {
                msg += " " + messages.atLeast + " " + atLeast + ".";
            }

            return messages.makeStronger + " " + msg;
        },

        _countMatch: function (password, regx) {
            var match = password.match(regx);
            return match ? match.length : 0;
        },

        _allCss: function (ele) {

            var css2Obj = function (css) {

                var s = {};
                if (!css) {
                    return s;
                }
                if (typeof css === "string") {
                    css = css.split("; ");
                    for (var j in css) {
                        var c = css[j].split(": ");
                        s[c[0].toLowerCase()] = c[1];
                    }
                }
                return s;
            };

            var styles = {};

            $.each(document.styleSheets, function (i, sheet) {
                $.each(sheet.cssRules || sheet.rules, function (j, rule) {
                    if (ele.is(rule.selectorText)) {
                        styles = $.extend(styles, css2Obj(rule.style.cssText), css2Obj(ele.attr("style")));
                    }
                });
            });

            return styles;
        },

        _format: function () {
            if (arguments.length === 0) {
                return "";
            }
            var args = Array.prototype.slice.call(arguments);
            var fmt = String(args.splice(0, 1));
            return fmt.replace(/{-?[0-9]+}/g, function (item) {
                var intVal = parseInt(item.substring(1, item.length - 1));
                var replace;
                if (intVal >= 0) {
                    replace = args[intVal];
                } else if (intVal === -1) {
                    replace = "{";
                } else if (intVal === -2) {
                    replace = "}";
                } else {
                    replace = "";
                }
                return replace;
            });
        },

        _appendHint: function (base, singular, plural, count) {
            if (base.length > 0)
                base += ", ";
            if (count !== undefined) {
                if (plural !== undefined) {
                    if (count === 1) {
                        base += this._format(singular, count);
                    } else {
                        base += this._format(plural, count);
                    }
                } else {
                    base += this._format(singular, count);
                }
            } else {
                base += singular;
            }
            return base;
        }

    });

} (jQuery));

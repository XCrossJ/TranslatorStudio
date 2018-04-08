//import proj = require("ProjectData");
//import * as ko from "knockout";
var TranslationData = /** @class */ (function () {
    // Constructor
    function TranslationData(projectData) {
        var _this = this;
        if (projectData == undefined)
            throw Error('Project Data is undefined');
        this._projectData = ko.observable(projectData);
        this._index = ko.observable(0);
        this.DefaultTranslationMode = ko.observable(true);
        this._maxIndex = ko.computed({
            owner: this,
            read: function () {
                return _this.ProjectLines().length - 1;
            }
        });
        this.NumberOfLines = ko.computed({
            owner: this,
            read: function () {
                return _this.ProjectLines().length;
            }
        });
        this.NumberOfCompletedLines = ko.computed({
            owner: this,
            read: function () {
                var result = 0;
                for (var i = 0; i < _this.ProjectLines().length; i++) {
                    if (_this.ProjectLines()[i]().Completed() == true) {
                        result++;
                    }
                }
                return result;
            }
        });
        this.CurrentProgress = ko.computed({
            owner: this,
            read: function () {
                return +(((_this.NumberOfCompletedLines() / _this.NumberOfLines()) * 100).toFixed(2));
            }
        });
        ko.applyBindings(this);
    }
    Object.defineProperty(TranslationData.prototype, "ProjectName", {
        // Properties
        get: function () {
            return this._projectData().projectName;
        },
        set: function (value) {
            this._projectData().projectName(value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "ProjectLines", {
        get: function () {
            return this._projectData().projectLines;
        },
        set: function (value) {
            this._projectData().projectLines(value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentIndex", {
        //Controls
        get: function () {
            if (this.DefaultTranslationMode()) {
                return this._index;
            }
            else {
                return this._subData.CurrentIndex;
            }
        },
        set: function (value) {
            if (this.DefaultTranslationMode()) {
                this._index(value());
            }
            else {
                this._subData.CurrentIndex(value());
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "MaxIndex", {
        get: function () {
            if (this.DefaultTranslationMode()) {
                return this._maxIndex;
            }
            else {
                return this._subData.MaxIndex;
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentLine", {
        get: function () {
            var index;
            if (this.DefaultTranslationMode()) {
                index = this.CurrentIndex();
            }
            else {
                index = this._subData.CurrentReference();
            }
            return this.ProjectLines()[index];
        },
        set: function (value) {
            var index;
            if (this.DefaultTranslationMode()) {
                index = this.CurrentIndex();
            }
            else {
                index = this._subData.CurrentReference();
            }
            this.ProjectLines()[index](value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentRaw", {
        get: function () {
            return this.CurrentLine().Raw;
        },
        set: function (value) {
            this.CurrentLine().Raw(value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentTranslation", {
        get: function () {
            return this.CurrentLine().Translation;
        },
        set: function (value) {
            this.CurrentLine().Translation(value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentCompletion", {
        get: function () {
            return this.CurrentLine().Completed;
        },
        set: function (value) {
            this.CurrentLine().Completed(value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentMarked", {
        get: function () {
            return this.CurrentLine().Marked;
        },
        set: function (value) {
            this.CurrentLine().Marked(value());
        },
        enumerable: true,
        configurable: true
    });
    // Methods
    TranslationData.prototype.IncrementIndex = function () {
        if (this.CurrentIndex() < this.MaxIndex()) {
            this.CurrentIndex(this.CurrentIndex() + 1);
        }
    };
    TranslationData.prototype.DecrementIndex = function () {
        if (this.CurrentIndex() > 0) {
            this.CurrentIndex(this.CurrentIndex() - 1);
        }
    };
    TranslationData.prototype.StartDefaultMode = function () {
        this.DefaultTranslationMode(true);
        this.CurrentIndex(0);
    };
    TranslationData.prototype.StartMarkedOnlyMode = function () {
        if (this.DefaultTranslationMode() == false) {
            this.StartDefaultMode();
        }
        var conditionList = [];
        for (var i = 0; i < this.ProjectLines().length; i++) {
            conditionList.push(this.ProjectLines()[i]().Marked());
        }
        try {
            this._subData = new SubTranslationData(conditionList);
            this.DefaultTranslationMode(false);
            this.CurrentIndex(0);
        }
        catch (e) {
            if (e.message == "Condition List returned no results. Cannot construct Sub Translation Data") {
                alert("No marked lines. Returning to Default Mode...");
            }
            else {
                alert("Something went wrong. Returning to Default Mode...");
            }
            this.StartDefaultMode();
            throw Error(e);
        }
    };
    TranslationData.prototype.StartIncompleteOnlyMode = function () {
        if (this.DefaultTranslationMode() == false) {
            this.StartDefaultMode();
        }
        var conditionList = [];
        for (var i = 0; i < this.ProjectLines().length; i++) {
            conditionList.push(!this.ProjectLines()[i]().Completed());
        }
        try {
            this._subData = new SubTranslationData(conditionList);
            this.DefaultTranslationMode(false);
            this.CurrentIndex(0);
        }
        catch (e) {
            if (e.message == "Condition List returned no results. Cannot construct Sub Translation Data") {
                alert("No incomplete lines. Returning to Default Mode...");
            }
            else {
                alert("Something went wrong. Returning to Default Mode...");
            }
            this.StartDefaultMode();
            throw Error(e);
        }
    };
    TranslationData.prototype.StartCompleteOnlyMode = function () {
        if (this.DefaultTranslationMode() == false) {
            this.StartDefaultMode();
        }
        var conditionList = [];
        for (var i = 0; i < this.ProjectLines().length; i++) {
            conditionList.push(this.ProjectLines()[i]().Completed());
        }
        try {
            this._subData = new SubTranslationData(conditionList);
            this.DefaultTranslationMode(false);
            this.CurrentIndex(0);
        }
        catch (e) {
            if (e.message == "Condition List returned no results. Cannot construct Sub Translation Data") {
                alert("No complete lines. Returning to Default Mode...");
            }
            else {
                alert("Something went wrong. Returning to Default Mode...");
            }
            this.StartDefaultMode();
            throw Error(e);
        }
    };
    TranslationData.prototype.GetSaveString = function () {
        var projectData = new ProjectData(this._projectData());
        return JSON.stringify({ data: projectData });
    };
    return TranslationData;
}());
//# sourceMappingURL=TranslationData.js.map
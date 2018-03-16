///// <reference path="../scripts/typings/knockout/index.d.ts" />
var TranslationData = /** @class */ (function () {
    // Constructor
    function TranslationData(projectData) {
        var _this = this;
        if (projectData == undefined)
            throw 'Project Data is undefined';
        this._projectData = ko.observable(projectData);
        this.currentIndex = ko.observable(0);
        this.maxIndex = ko.observable(projectData.rawLines().length - 1);
        this.defaultTranslationMode = true;
        this.NumberOfLines = ko.computed({
            owner: this,
            read: function () {
                return _this.RawLines().length;
            }
        });
        this.NumberOfCompletedLines = ko.computed({
            owner: this,
            read: function () {
                var result = 0;
                for (var i = 0; i < _this.CompletedLines().length; i++) {
                    if (_this.CompletedLines()[i]() == true) {
                        result++;
                    }
                }
                return result;
            }
        });
        this.currentProgress = ko.computed({
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
    Object.defineProperty(TranslationData.prototype, "RawLines", {
        get: function () {
            return this._projectData().rawLines;
        },
        set: function (value) {
            this._projectData().rawLines(value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "TranslatedLines", {
        get: function () {
            return this._projectData().translatedLines;
        },
        set: function (value) {
            this._projectData().translatedLines(value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "MarkedLines", {
        get: function () {
            return this._projectData().markedLines;
        },
        set: function (value) {
            this._projectData().markedLines(value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CompletedLines", {
        get: function () {
            return this._projectData().completedLines;
        },
        set: function (value) {
            this._projectData().completedLines(value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentRaw", {
        get: function () {
            return this.RawLines()[this.currentIndex()];
        },
        set: function (value) {
            this.RawLines()[this.currentIndex()](value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentTranslation", {
        get: function () {
            return this.TranslatedLines()[this.currentIndex()];
        },
        set: function (value) {
            this.TranslatedLines()[this.currentIndex()](value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentMarked", {
        get: function () {
            return this.MarkedLines()[this.currentIndex()];
        },
        set: function (value) {
            this.MarkedLines()[this.currentIndex()](value());
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentCompletion", {
        get: function () {
            return this.CompletedLines()[this.currentIndex()];
        },
        set: function (value) {
            this.CompletedLines()[this.currentIndex()](value());
        },
        enumerable: true,
        configurable: true
    });
    // Methods
    TranslationData.prototype.IncrementIndex = function () {
        if (this.currentIndex() < this.maxIndex()) {
            this.currentIndex(this.currentIndex() + 1);
        }
    };
    TranslationData.prototype.DecrementIndex = function () {
        if (this.currentIndex() > 0) {
            this.currentIndex(this.currentIndex() - 1);
        }
    };
    TranslationData.prototype.GetSaveString = function () {
        var projectData = new ProjectData(this._projectData());
        return JSON.stringify({ data: projectData });
    };
    return TranslationData;
}());
//# sourceMappingURL=TranslationData.js.map
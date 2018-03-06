//https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes
var TranslationData = /** @class */ (function () {
    // Constructor
    function TranslationData(projectData) {
        if (projectData == undefined)
            throw 'Project Data is undefined';
        this._projectData = projectData;
        this.currentIndex = 0;
        this.maxIndex = projectData.rawLines.length - 1;
        this.defaultTranslationMode = true;
    }
    Object.defineProperty(TranslationData.prototype, "ProjectName", {
        // Properties
        get: function () {
            return this._projectData.projectName;
        },
        set: function (value) {
            this._projectData.projectName = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "RawLines", {
        get: function () {
            return this._projectData.rawLines;
        },
        set: function (value) {
            this._projectData.rawLines = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "TranslatedLines", {
        get: function () {
            return this._projectData.translatedLines;
        },
        set: function (value) {
            this._projectData.translatedLines = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "MarkedLines", {
        get: function () {
            return this._projectData.markedLines;
        },
        set: function (value) {
            this._projectData.markedLines = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CompletedLines", {
        get: function () {
            return this._projectData.completedLines;
        },
        set: function (value) {
            this._projectData.completedLines = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentRaw", {
        get: function () {
            return this.RawLines[this.currentIndex];
        },
        set: function (value) {
            this.RawLines[this.currentIndex] = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentTranslation", {
        get: function () {
            return this.TranslatedLines[this.currentIndex];
        },
        set: function (value) {
            this.TranslatedLines[this.currentIndex] = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentMarked", {
        get: function () {
            return this.MarkedLines[this.currentIndex];
        },
        set: function (value) {
            this.MarkedLines[this.currentIndex] = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "CurrentCompletion", {
        get: function () {
            return this.CompletedLines[this.currentIndex];
        },
        set: function (value) {
            this.CompletedLines[this.currentIndex] = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "NumberOfLines", {
        get: function () {
            return this.RawLines.length;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationData.prototype, "NumberOfCompletedLines", {
        get: function () {
            var result = 0;
            for (var i = 0; i < this.CompletedLines.length; i++) {
                if (this.CompletedLines[i] == true) {
                    result++;
                }
            }
            return result;
        },
        enumerable: true,
        configurable: true
    });
    // Methods
    TranslationData.prototype.IncrementIndex = function () {
        if (this.currentIndex < this.maxIndex) {
            this.currentIndex++;
        }
    };
    TranslationData.prototype.DecrementIndex = function () {
        if (this.currentIndex > 0) {
            this.currentIndex--;
        }
    };
    TranslationData.prototype.GetSaveString = function () {
        return JSON.stringify({ data: this._projectData });
    };
    return TranslationData;
}());
//# sourceMappingURL=TranslationData.js.map
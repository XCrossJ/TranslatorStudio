///// <reference path="../scripts/typings/knockout/index.d.ts" />
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
//class TranslationDataViewModel {
//    private _projectData: proj.IProjectData;
//    currentIndex: KnockoutObservable<number>;
//    maxIndex: KnockoutObservable<number>;
//    defaultTranslationMode: boolean;
//    // Constructor
//    constructor(projectData: proj.IProjectData) {
//        if (projectData == undefined) throw 'Project Data is undefined';
//        this._projectData = projectData;
//        this.currentIndex = ko.observable(0);
//        this.maxIndex = ko.observable(projectData.rawLines.length - 1);
//        this.defaultTranslationMode = true;
//    }
//    // Properties
//    get ProjectName(): string {
//        return this._projectData.projectName;
//    }
//    set ProjectName(value: string) {
//        this._projectData.projectName = value;
//    }
//    get RawLines(): string[] {
//        return this._projectData.rawLines;
//    }
//    set RawLines(value: string[]) {
//        this._projectData.rawLines = value;
//    }
//    get TranslatedLines(): string[] {
//        return this._projectData.translatedLines;
//    }
//    set TranslatedLines(value: string[]) {
//        this._projectData.translatedLines = value;
//    }
//    get MarkedLines(): boolean[] {
//        return this._projectData.markedLines;
//    }
//    set MarkedLines(value: boolean[]) {
//        this._projectData.markedLines = value;
//    }
//    get CompletedLines(): boolean[] {
//        return this._projectData.completedLines;
//    }
//    set CompletedLines(value: boolean[]) {
//        this._projectData.completedLines = value;
//    }
//    get CurrentRaw(): string {
//        return this.RawLines[this.currentIndex()];
//    }
//    set CurrentRaw(value: string) {
//        this.RawLines[this.currentIndex()] = value;
//    }
//    get CurrentTranslation(): string {
//        return this.TranslatedLines[this.currentIndex()];
//    }
//    set CurrentTranslation(value: string) {
//        this.TranslatedLines[this.currentIndex()] = value;
//    }
//    get CurrentMarked(): boolean {
//        return this.MarkedLines[this.currentIndex()];
//    }
//    set CurrentMarked(value: boolean) {
//        this.MarkedLines[this.currentIndex()] = value;
//    }
//    get CurrentCompletion(): boolean {
//        return this.CompletedLines[this.currentIndex()];
//    }
//    set CurrentCompletion(value: boolean) {
//        this.CompletedLines[this.currentIndex()] = value;
//    }
//    get NumberOfLines(): number {
//        return this.RawLines.length;
//    }
//    get NumberOfCompletedLines(): number {
//        var result = 0;
//        for (var i = 0; i < this.CompletedLines.length; i++) {
//            if (this.CompletedLines[i] == true) {
//                result++;
//            }
//        }
//        return result;
//    }
//    // Methods
//    IncrementIndex() {
//        if (this.currentIndex() < this.maxIndex()) {
//            this.currentIndex(this.currentIndex() + 1);
//        }
//    }
//    DecrementIndex() {
//        if (this.currentIndex() > 0) {
//            this.currentIndex(this.currentIndex() - 1);
//        }
//    }
//    GetSaveString(): string {
//        return JSON.stringify({ data: this._projectData });
//    }
//}
//ko.applyBindings(new TranslationData()); 
//# sourceMappingURL=TranslationData.js.map
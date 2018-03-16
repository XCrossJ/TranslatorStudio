///// <reference path="../scripts/typings/knockout/index.d.ts" />

//import proj = require("ProjectData");
//import * as ko from "knockout";

//https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes

interface ITranslationData {
    currentIndex: KnockoutObservable<number>;
    maxIndex: KnockoutObservable<number>;

    ProjectName: KnockoutObservable<string>;
    RawLines: KnockoutObservableArray<KnockoutObservable<string>>;
    TranslatedLines: KnockoutObservableArray<KnockoutObservable<string>>;
    MarkedLines: KnockoutObservableArray<KnockoutObservable<boolean>>;
    CompletedLines: KnockoutObservableArray<KnockoutObservable<boolean>>;

    CurrentRaw: KnockoutObservable<string>;
    CurrentTranslation: KnockoutObservable<string>;
    CurrentMarked: KnockoutObservable<boolean>;
    CurrentCompletion: KnockoutObservable<boolean>;

    NumberOfLines: KnockoutComputed<number>;
    NumberOfCompletedLines: KnockoutComputed<number>;

    currentProgress: KnockoutComputed<number>;

    IncrementIndex: () => void;
    DecrementIndex: () => void;
    GetSaveString: () => string;
}

class TranslationData implements ITranslationData {
    private _projectData: KnockoutObservable<IProjectViewModel>;
    currentIndex: KnockoutObservable<number>;
    maxIndex: KnockoutObservable<number>;

    defaultTranslationMode: boolean;

    NumberOfLines: KnockoutComputed<number>;
    NumberOfCompletedLines: KnockoutComputed<number>;

    currentProgress: KnockoutComputed<number>;

    // Constructor
    constructor(projectData: IProjectViewModel) {
        if (projectData == undefined) throw 'Project Data is undefined';
        this._projectData = ko.observable(projectData);

        this.currentIndex = ko.observable(0);
        this.maxIndex = ko.observable(projectData.rawLines().length - 1);

        this.defaultTranslationMode = true;

        this.NumberOfLines = ko.computed({
            owner: this,
            read: () => {
                return this.RawLines().length;
            }
        });
        this.NumberOfCompletedLines = ko.computed({
            owner: this,
            read: () => {
                var result = 0;
                for (var i = 0; i < this.CompletedLines().length; i++) {
                    if (this.CompletedLines()[i]() == true) {
                        result++;
                    }
                }
                return result;
            }
        });

        this.currentProgress = ko.computed({
            owner: this,
            read: () => {
                return +(((this.NumberOfCompletedLines() / this.NumberOfLines()) * 100).toFixed(2));
            }
        });

        ko.applyBindings(this);
    }

    // Properties
    get ProjectName(): KnockoutObservable<string> {
        return this._projectData().projectName;
    }
    set ProjectName(value: KnockoutObservable<string>) {
        this._projectData().projectName(value());
    }

    get RawLines(): KnockoutObservableArray<KnockoutObservable<string>> {
        return this._projectData().rawLines;
    }
    set RawLines(value: KnockoutObservableArray<KnockoutObservable<string>>) {
        this._projectData().rawLines(value());
    }

    get TranslatedLines(): KnockoutObservableArray<KnockoutObservable<string>> {
        return this._projectData().translatedLines;
    }
    set TranslatedLines(value: KnockoutObservableArray<KnockoutObservable<string>>) {
        this._projectData().translatedLines(value());
    }

    get MarkedLines(): KnockoutObservableArray<KnockoutObservable<boolean>> {
        return this._projectData().markedLines;
    }
    set MarkedLines(value: KnockoutObservableArray<KnockoutObservable<boolean>>) {
        this._projectData().markedLines(value());
    }

    get CompletedLines(): KnockoutObservableArray<KnockoutObservable<boolean>> {
        return this._projectData().completedLines;
    }
    set CompletedLines(value: KnockoutObservableArray<KnockoutObservable<boolean>>) {
        this._projectData().completedLines(value());
    }

    get CurrentRaw(): KnockoutObservable<string> {
        return this.RawLines()[this.currentIndex()];
    }
    set CurrentRaw(value: KnockoutObservable<string>) {
        this.RawLines()[this.currentIndex()](value());
    }

    get CurrentTranslation(): KnockoutObservable<string> {
        return this.TranslatedLines()[this.currentIndex()];
    }
    set CurrentTranslation(value: KnockoutObservable<string>) {
        this.TranslatedLines()[this.currentIndex()](value());
    }

    get CurrentMarked(): KnockoutObservable<boolean> {
        return this.MarkedLines()[this.currentIndex()];
    }
    set CurrentMarked(value: KnockoutObservable<boolean>) {
        this.MarkedLines()[this.currentIndex()](value());
    }

    get CurrentCompletion(): KnockoutObservable<boolean> {
        return this.CompletedLines()[this.currentIndex()];
    }
    set CurrentCompletion(value: KnockoutObservable<boolean>) {
        this.CompletedLines()[this.currentIndex()](value());
    }
    


    // Methods
    IncrementIndex() {
        if (this.currentIndex() < this.maxIndex()) {
            this.currentIndex(this.currentIndex() + 1);
        }
    }

    DecrementIndex() {
        if (this.currentIndex() > 0) {
            this.currentIndex(this.currentIndex() - 1);
        }
    }

    GetSaveString(): string {
        var projectData: IProjectData = new ProjectData(this._projectData());
        return JSON.stringify({ data: projectData });
    }
}
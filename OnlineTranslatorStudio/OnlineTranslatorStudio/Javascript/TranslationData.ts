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
    MarkedLines: boolean[];
    CompletedLines: KnockoutObservableArray<KnockoutObservable<boolean>>;

    CurrentRaw: string;
    CurrentTranslation: string;
    CurrentMarked: boolean;
    CurrentCompletion: boolean;

    NumberOfLines: number;
    NumberOfCompletedLines: KnockoutObservable<number>;

    IncrementIndex: () => void;
    DecrementIndex: () => void;
    GetSaveString: () => string;
}

class TranslationData implements ITranslationData {
    private _projectData: KnockoutObservable<IProjectViewModel>;
    currentIndex: KnockoutObservable<number>;
    maxIndex: KnockoutObservable<number>;

    defaultTranslationMode: boolean;

    // Constructor
    constructor(projectData: IProjectViewModel) {
        if (projectData == undefined) throw 'Project Data is undefined';
        this._projectData = ko.observable(projectData);

        this.currentIndex = ko.observable(0);
        this.maxIndex = ko.observable(projectData.rawLines().length - 1);

        this.defaultTranslationMode = true;

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

    get MarkedLines(): boolean[] {
        return this._projectData().markedLines;
    }
    set MarkedLines(value: boolean[]) {
        this._projectData().markedLines = value;
    }

    get CompletedLines(): KnockoutObservableArray<KnockoutObservable<boolean>> {
        return this._projectData().completedLines;
    }
    set CompletedLines(value: KnockoutObservableArray<KnockoutObservable<boolean>>) {
        this._projectData().completedLines(value());
    }

    get CurrentRaw(): string {
        return this.RawLines()[this.currentIndex()]();
    }
    set CurrentRaw(value: string) {
        this.RawLines()[this.currentIndex()](value);
    }

    get CurrentTranslation(): string {
        return this.TranslatedLines[this.currentIndex()];
    }
    set CurrentTranslation(value: string) {
        this.TranslatedLines[this.currentIndex()] = value;
    }

    get CurrentMarked(): boolean {
        return this.MarkedLines[this.currentIndex()];
    }
    set CurrentMarked(value: boolean) {
        this.MarkedLines[this.currentIndex()] = value;
    }

    get CurrentCompletion(): boolean {
        return this.CompletedLines[this.currentIndex()];
    }
    set CurrentCompletion(value: boolean) {
        this.CompletedLines[this.currentIndex()] = value;
    }

    get NumberOfLines(): number {
        return this.RawLines.length;
    }

    get NumberOfCompletedLines(): KnockoutObservable<number> {
        var result = 0;
        for (var i = 0; i < this.CompletedLines.length; i++) {
            if (this.CompletedLines[i] == true) {
                result++;
            }
        }
        return ko.observable(result);
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
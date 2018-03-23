//import proj = require("ProjectData");
//import * as ko from "knockout";

//https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes

interface ITranslationData {
    DefaultTranslationMode: KnockoutObservable<boolean>;

    // Properties
    ProjectName: KnockoutObservable<string>;
    RawLines: KnockoutObservableArray<KnockoutObservable<string>>;
    TranslatedLines: KnockoutObservableArray<KnockoutObservable<string>>;
    MarkedLines: KnockoutObservableArray<KnockoutObservable<boolean>>;
    CompletedLines: KnockoutObservableArray<KnockoutObservable<boolean>>;

    // Controls
    CurrentIndex: KnockoutObservable<number>;
    MaxIndex: KnockoutComputed<number>;
    CurrentRaw: KnockoutObservable<string>;
    CurrentTranslation: KnockoutObservable<string>;
    CurrentMarked: KnockoutObservable<boolean>;
    CurrentCompletion: KnockoutObservable<boolean>;

    // Computed
    NumberOfLines: KnockoutComputed<number>;
    NumberOfCompletedLines: KnockoutComputed<number>;

    CurrentProgress: KnockoutComputed<number>;

    // Methods
    IncrementIndex: () => void;
    DecrementIndex: () => void;

    StartDefaultMode: () => void;
    StartMarkedOnlyMode: () => void;
    StartIncompleteOnlyMode: () => void;
    StartCompleteOnlyMode: () => void;

    GetSaveString: () => string;
}

class TranslationData implements ITranslationData {
    private _projectData: KnockoutObservable<IProjectViewModel>;
    private _subData: ISubTranslationData;
    private _index: KnockoutObservable<number>;
    private _maxIndex: KnockoutComputed<number>;

    DefaultTranslationMode: KnockoutObservable<boolean>;

    NumberOfLines: KnockoutComputed<number>;
    NumberOfCompletedLines: KnockoutComputed<number>;

    CurrentProgress: KnockoutComputed<number>;

    // Constructor
    constructor(projectData: IProjectViewModel) {
        if (projectData == undefined) throw Error('Project Data is undefined');
        this._projectData = ko.observable(projectData);

        this._index = ko.observable(0);

        this.DefaultTranslationMode = ko.observable(true);

        this._maxIndex = ko.computed({
            owner: this,
            read: () => {
                return this.RawLines().length - 1;
            }
        });
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

        this.CurrentProgress = ko.computed({
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

    //Controls
    get CurrentIndex(): KnockoutObservable<number> {
        if (this.DefaultTranslationMode()) {
            return this._index;
        }
        else {
            return this._subData.CurrentIndex;
        }
    }
    set CurrentIndex(value: KnockoutObservable<number>) {
        if (this.DefaultTranslationMode()) {
            this._index(value());
        }
        else {
            this._subData.CurrentIndex(value());
        }
    }

    get MaxIndex(): KnockoutComputed<number> {
        if (this.DefaultTranslationMode()) {
            return this._maxIndex;
        }
        else {
            return this._subData.MaxIndex;
        }
    }

    get CurrentRaw(): KnockoutObservable<string> {
        var index: number;
        if (this.DefaultTranslationMode()) {
            index = this.CurrentIndex();
        }
        else {
            index = this._subData.CurrentReference();
        }
        return this.RawLines()[index];
    }
    set CurrentRaw(value: KnockoutObservable<string>) {
        var index: number;
        if (this.DefaultTranslationMode()) {
            index = this.CurrentIndex();
        }
        else {
            index = this._subData.CurrentReference();
        }
        this.RawLines()[index](value());
    }

    get CurrentTranslation(): KnockoutObservable<string> {
        var index: number;
        if (this.DefaultTranslationMode()) {
            index = this.CurrentIndex();
        }
        else {
            index = this._subData.CurrentReference();
        }
        return this.TranslatedLines()[index];
    }
    set CurrentTranslation(value: KnockoutObservable<string>) {
        var index: number;
        if (this.DefaultTranslationMode()) {
            index = this.CurrentIndex();
        }
        else {
            index = this._subData.CurrentReference();
        }
        this.TranslatedLines()[index](value());
    }

    get CurrentMarked(): KnockoutObservable<boolean> {
        var index: number;
        if (this.DefaultTranslationMode()) {
            index = this.CurrentIndex();
        }
        else {
            index = this._subData.CurrentReference();
        }
        return this.MarkedLines()[index];
    }
    set CurrentMarked(value: KnockoutObservable<boolean>) {
        var index: number;
        if (this.DefaultTranslationMode()) {
            index = this.CurrentIndex();
        }
        else {
            index = this._subData.CurrentReference();
        }
        this.MarkedLines()[index](value());
    }

    get CurrentCompletion(): KnockoutObservable<boolean> {
        var index: number;
        if (this.DefaultTranslationMode()) {
            index = this.CurrentIndex();
        }
        else {
            index = this._subData.CurrentReference();
        }
        return this.CompletedLines()[index];
    }
    set CurrentCompletion(value: KnockoutObservable<boolean>) {
        var index: number;
        if (this.DefaultTranslationMode()) {
            index = this.CurrentIndex();
        }
        else {
            index = this._subData.CurrentReference();
        }
        this.CompletedLines()[index](value());
    }
    


    // Methods
    IncrementIndex(): void {
        if (this.CurrentIndex() < this.MaxIndex()) {
            this.CurrentIndex(this.CurrentIndex() + 1);
        }
    }

    DecrementIndex(): void {
        if (this.CurrentIndex() > 0) {
            this.CurrentIndex(this.CurrentIndex() - 1);
        }
    }


    StartDefaultMode(): void {
        this.DefaultTranslationMode(true);
        this.CurrentIndex(0);
    }

    StartMarkedOnlyMode(): void {
        if (this.DefaultTranslationMode() == false) {
            this.StartDefaultMode();
        }

        var conditionList: boolean[] = [];

        for (var i = 0; i < this.MarkedLines().length; i++) {
            conditionList.push(this.MarkedLines()[i]());
        }

        try {
            this._subData = new SubTranslationData(conditionList);

            this.DefaultTranslationMode(false);
            this.CurrentIndex(0);

        } catch (e) {
            if ((<Error>e).message == "Condition List returned no results. Cannot construct Sub Translation Data") {
                alert("No marked lines. Returning to Default Mode...");
            }
            else {
                alert("Something went wrong. Returning to Default Mode...");
            }
            this.StartDefaultMode();
            throw Error(e);
        }
    }

    StartIncompleteOnlyMode(): void {
        if (this.DefaultTranslationMode() == false) {
            this.StartDefaultMode();
        }

        var conditionList: boolean[] = [];

        for (var i = 0; i < this.CompletedLines().length; i++) {
            conditionList.push(!this.CompletedLines()[i]());
        }

        try {
            this._subData = new SubTranslationData(conditionList);

            this.DefaultTranslationMode(false);
            this.CurrentIndex(0);

        } catch (e) {
            if ((<Error>e).message == "Condition List returned no results. Cannot construct Sub Translation Data") {
                alert("No incomplete lines. Returning to Default Mode...");
            }
            else {
                alert("Something went wrong. Returning to Default Mode...");
            }
            this.StartDefaultMode();
            throw Error(e);
        }
    }

    StartCompleteOnlyMode(): void {
        if (this.DefaultTranslationMode() == false) {
            this.StartDefaultMode();
        }

        var conditionList: boolean[] = [];

        for (var i = 0; i < this.CompletedLines().length; i++) {
            conditionList.push(this.CompletedLines()[i]());
        }

        try {
            this._subData = new SubTranslationData(conditionList);

            this.DefaultTranslationMode(false);
            this.CurrentIndex(0);

        } catch (e) {
            if ((<Error>e).message == "Condition List returned no results. Cannot construct Sub Translation Data") {
                alert("No complete lines. Returning to Default Mode...");
            }
            else {
                alert("Something went wrong. Returning to Default Mode...");
            }
            this.StartDefaultMode();
            throw Error(e);
        }
    }


    GetSaveString(): string {
        var projectData: IProjectData = new ProjectData(this._projectData());
        return JSON.stringify({ data: projectData });
    }
}
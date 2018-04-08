//import proj = require("ProjectData");
//import * as ko from "knockout";

//https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes

interface ITranslationData {
    DefaultTranslationMode: KnockoutObservable<boolean>;

    // Properties
    ProjectName: KnockoutObservable<string>;
    ProjectLines: KnockoutObservableArray<KnockoutObservable<IProjectLineViewModel>>;

    // Controls
    CurrentIndex: KnockoutObservable<number>;
    MaxIndex: KnockoutComputed<number>;
    CurrentLine: KnockoutObservable<IProjectLineViewModel>;
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
                return this.ProjectLines().length - 1;
            }
        });
        this.NumberOfLines = ko.computed({
            owner: this,
            read: () => {
                return this.ProjectLines().length;
            }
        });
        this.NumberOfCompletedLines = ko.computed({
            owner: this,
            read: () => {
                var result = 0;
                for (var i = 0; i < this.ProjectLines().length; i++) {
                    if (this.ProjectLines()[i]().Completed() == true) {
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

    get ProjectLines(): KnockoutObservableArray<KnockoutObservable<IProjectLineViewModel>> {
        return this._projectData().projectLines;
    }

    set ProjectLines(value: KnockoutObservableArray<KnockoutObservable<IProjectLineViewModel>>) {
        this._projectData().projectLines(value());
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

    get CurrentLine(): KnockoutObservable<IProjectLineViewModel> {
        var index: number;
        if (this.DefaultTranslationMode()) {
            index = this.CurrentIndex();
        }
        else {
            index = this._subData.CurrentReference();
        }
        return this.ProjectLines()[index];
    }
    set CurrentLine(value: KnockoutObservable<IProjectLineViewModel>) {
        var index: number;
        if (this.DefaultTranslationMode()) {
            index = this.CurrentIndex();
        }
        else {
            index = this._subData.CurrentReference();
        }
        this.ProjectLines()[index](value());
    }

    get CurrentRaw(): KnockoutObservable<string> {
        return this.CurrentLine().Raw;
    }
    set CurrentRaw(value: KnockoutObservable<string>) {
        this.CurrentLine().Raw(value());
    }

    get CurrentTranslation(): KnockoutObservable<string> {
        return this.CurrentLine().Translation;
    }
    set CurrentTranslation(value: KnockoutObservable<string>) {
        this.CurrentLine().Translation(value());
    }

    get CurrentCompletion(): KnockoutObservable<boolean> {
        return this.CurrentLine().Completed;
    }
    set CurrentCompletion(value: KnockoutObservable<boolean>) {
        this.CurrentLine().Completed(value());
    }

    get CurrentMarked(): KnockoutObservable<boolean> {
        return this.CurrentLine().Marked;
    }
    set CurrentMarked(value: KnockoutObservable<boolean>) {
        this.CurrentLine().Marked(value());
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

        for (var i = 0; i < this.ProjectLines().length; i++) {
            conditionList.push(this.ProjectLines()[i]().Marked());
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

        for (var i = 0; i < this.ProjectLines().length; i++) {
            conditionList.push(!this.ProjectLines()[i]().Completed());
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

        for (var i = 0; i < this.ProjectLines().length; i++) {
            conditionList.push(this.ProjectLines()[i]().Completed());
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
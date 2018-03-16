interface IProjectViewModel {
    projectName: KnockoutObservable<string>;
    rawLines: KnockoutObservableArray<KnockoutObservable<string>>;
    translatedLines: KnockoutObservableArray<KnockoutObservable<string>>;
    completedLines: KnockoutObservableArray<KnockoutObservable<boolean>>;
    markedLines: KnockoutObservableArray<KnockoutObservable<boolean>>;
}

class ProjectViewModel implements IProjectViewModel {

    projectName: KnockoutObservable<string>;
    rawLines: KnockoutObservableArray<KnockoutObservable<string>>;
    translatedLines: KnockoutObservableArray<KnockoutObservable<string>>;
    completedLines: KnockoutObservableArray<KnockoutObservable<boolean>>;
    markedLines: KnockoutObservableArray<KnockoutObservable<boolean>>;

    constructor(data: IProjectData) {
        this.projectName = ko.observable(data.ProjectName);

        var newRaw: KnockoutObservable<string>[] = [];
        var newTranslation: KnockoutObservable<string>[] = [];
        var newCompletion: KnockoutObservable<boolean>[] = [];
        var newMarked: KnockoutObservable<boolean>[] = [];

        for (var i = 0; i < data.RawLines.length; i++) {
            newRaw.push(ko.observable(data.RawLines[i]));
            newTranslation.push(ko.observable(data.TranslatedLines[i]));
            newCompletion.push(ko.observable(data.CompletedLines[i]));
            newMarked.push(ko.observable(data.MarkedLines[i]));
        }

        this.rawLines = ko.observableArray(newRaw);
        this.translatedLines = ko.observableArray(newTranslation);
        this.completedLines = ko.observableArray(newCompletion);
        this.markedLines = ko.observableArray(newMarked);
    }
}

interface IProjectData {
    ProjectName: string;
    RawLines: string[];
    TranslatedLines: string[];
    CompletedLines: boolean[];
    MarkedLines: boolean[];
}

class ProjectData implements IProjectData {

    ProjectName: string;
    RawLines: string[];
    TranslatedLines: string[];
    CompletedLines: boolean[];
    MarkedLines: boolean[];

    constructor(data: IProjectViewModel) {
        this.ProjectName = data.projectName();

        var newRaw: string[] = [];
        var newTranslation: string[] = [];
        var newCompletion: boolean[] = [];
        var newMarked: boolean[] = [];

        for (var i = 0; i < data.rawLines().length; i++) {
            newRaw.push(data.rawLines()[i]());
            newTranslation.push(data.translatedLines()[i]());
            newCompletion.push(data.completedLines()[i]());
            newMarked.push(data.markedLines()[i]());
        }

        this.RawLines = newRaw;
        this.TranslatedLines = newTranslation;
        this.CompletedLines = newCompletion;
        this.MarkedLines = newMarked;
    }
}
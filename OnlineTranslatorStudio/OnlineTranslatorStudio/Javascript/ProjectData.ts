interface IProjectViewModel {
    projectName: KnockoutObservable<string>;
    rawLines: KnockoutObservableArray<KnockoutObservable<string>>;
    translatedLines: KnockoutObservableArray<KnockoutObservable<string>>;
    completedLines: KnockoutObservableArray<KnockoutObservable<boolean>>;
    markedLines: boolean[];
}

class ProjectViewModel implements IProjectViewModel {

    projectName: KnockoutObservable<string>;
    rawLines: KnockoutObservableArray<KnockoutObservable<string>>;
    translatedLines: KnockoutObservableArray<KnockoutObservable<string>>;
    completedLines: KnockoutObservableArray<KnockoutObservable<boolean>>;
    markedLines: boolean[];

    constructor(data: IProjectData) {
        this.projectName = ko.observable(data.ProjectName);

        var newRaw: KnockoutObservable<string>[] = [];
        for (var i = 0; i < data.RawLines.length; i++) {
            newRaw.push(
                ko.observable(data.RawLines[i])
            );
        }
        this.rawLines = ko.observableArray(newRaw);

        var newTranslation: KnockoutObservable<string>[] = [];
        for (var i = 0; i < data.TranslatedLines.length; i++) {
            newTranslation.push(
                ko.observable(data.TranslatedLines[i])
            );
        }
        this.translatedLines = ko.observableArray(newTranslation);

        var newCompletion: KnockoutObservable<boolean>[] = [];
        for (var i = 0; i < data.CompletedLines.length; i++) {
            newCompletion.push(
                ko.observable(data.CompletedLines[i])
            );
        }
        this.completedLines = ko.observableArray(newCompletion);
        this.markedLines = data.MarkedLines;
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
        for (var i = 0; i < data.rawLines().length; i++) {
            newRaw.push(
                data.rawLines()[i]()
            );
        }
        this.RawLines = newRaw;

        var newTranslation: string[] = [];
        for (var i = 0; i < data.translatedLines().length; i++) {
            newTranslation.push(
                data.translatedLines()[i]()
            );
        }
        this.TranslatedLines = newTranslation;

        var newCompletion: boolean[] = [];
        for (var i = 0; i < data.completedLines().length; i++) {
            newCompletion.push(
                data.completedLines()[i]()
            );
        }
        this.CompletedLines = newCompletion;
        this.MarkedLines = data.markedLines;
    }
}
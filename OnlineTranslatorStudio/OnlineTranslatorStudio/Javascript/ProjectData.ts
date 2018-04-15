//https://blog.johnnyreilly.com/2014/02/typescript-and-requirejs-keep-it-simple.html

interface IProjectViewModel {
    projectName: KnockoutObservable<string>;
    projectLines: KnockoutObservableArray<KnockoutObservable<IProjectLineViewModel>>;
}

class ProjectViewModel implements IProjectViewModel {

    projectName: KnockoutObservable<string>;
    projectLines: KnockoutObservableArray<KnockoutObservable<IProjectLineViewModel>>;

    constructor(data: IProjectData) {
        this.projectName = ko.observable(data.ProjectName);

        var newLines: KnockoutObservable<IProjectLineViewModel>[] = [];

        for (var i = 0; i < data.ProjectLines.length; i++) {
            var newLine: KnockoutObservable<IProjectLineViewModel>;
            newLine = ko.observable(new ProjectLineViewModel(data.ProjectLines[i]));
            newLines.push(newLine);
        }

        this.projectLines = ko.observableArray(newLines);
    }
}

interface IProjectData {
    ProjectName: string;
    ProjectLines: IProjectLine[];
}

class ProjectData implements IProjectData {

    ProjectName: string;
    ProjectLines: IProjectLine[];

    constructor(data: IProjectViewModel) {
        this.ProjectName = data.projectName();

        var newLines: IProjectLine[] = [];

        for (var i = 0; i < data.projectLines().length; i++) {
            var newLine: IProjectLine;
            newLine = new ProjectLine(data.projectLines()[i]());
            newLines.push(newLine);
        }

        this.ProjectLines = newLines;
    }
}
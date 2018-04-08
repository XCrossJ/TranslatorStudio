interface IProjectLineViewModel {
    Raw: KnockoutObservable<string>;
    Translation: KnockoutObservable<string>;
    Completed: KnockoutObservable<boolean>;
    Marked: KnockoutObservable<boolean>;
}

class ProjectLineViewModel implements IProjectLineViewModel {

    Raw: KnockoutObservable<string>;
    Translation: KnockoutObservable<string>;
    Completed: KnockoutObservable<boolean>;
    Marked: KnockoutObservable<boolean>;

    constructor(line: IProjectLine) {
        this.Raw = ko.observable(line.Raw);
        this.Translation = ko.observable(line.Translation);
        this.Completed = ko.observable(line.Completed);
        this.Marked = ko.observable(line.Marked);
    }
}

interface IProjectLine {
    Raw: string;
    Translation: string;
    Completed: boolean;
    Marked: boolean;
}

class ProjectLine implements IProjectLine {

    Raw: string;
    Translation: string;
    Completed: boolean;
    Marked: boolean;

    constructor(line: IProjectLineViewModel) {
        this.Raw = line.Raw();
        this.Translation = line.Translation();
        this.Completed = line.Completed();
        this.Marked = line.Marked();
    }
}
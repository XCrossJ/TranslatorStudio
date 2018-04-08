var ProjectLineViewModel = /** @class */ (function () {
    function ProjectLineViewModel(line) {
        this.Raw = ko.observable(line.Raw);
        this.Translation = ko.observable(line.Translation);
        this.Completed = ko.observable(line.Completed);
        this.Marked = ko.observable(line.Marked);
    }
    return ProjectLineViewModel;
}());
var ProjectLine = /** @class */ (function () {
    function ProjectLine(line) {
        this.Raw = line.Raw();
        this.Translation = line.Translation();
        this.Completed = line.Completed();
        this.Marked = line.Marked();
    }
    return ProjectLine;
}());
//# sourceMappingURL=ProjectLine.js.map
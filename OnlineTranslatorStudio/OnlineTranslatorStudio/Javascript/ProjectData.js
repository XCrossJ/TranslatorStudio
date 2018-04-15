//https://blog.johnnyreilly.com/2014/02/typescript-and-requirejs-keep-it-simple.html
var ProjectViewModel = /** @class */ (function () {
    function ProjectViewModel(data) {
        this.projectName = ko.observable(data.ProjectName);
        var newLines = [];
        for (var i = 0; i < data.ProjectLines.length; i++) {
            var newLine;
            newLine = ko.observable(new ProjectLineViewModel(data.ProjectLines[i]));
            newLines.push(newLine);
        }
        this.projectLines = ko.observableArray(newLines);
    }
    return ProjectViewModel;
}());
var ProjectData = /** @class */ (function () {
    function ProjectData(data) {
        this.ProjectName = data.projectName();
        var newLines = [];
        for (var i = 0; i < data.projectLines().length; i++) {
            var newLine;
            newLine = new ProjectLine(data.projectLines()[i]());
            newLines.push(newLine);
        }
        this.ProjectLines = newLines;
    }
    return ProjectData;
}());
//# sourceMappingURL=ProjectData.js.map
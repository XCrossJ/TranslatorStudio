//https://blog.johnnyreilly.com/2014/02/typescript-and-requirejs-keep-it-simple.html
var ProjectViewModel = /** @class */ (function () {
    function ProjectViewModel(data) {
        this.projectName = ko.observable(data.ProjectName);
        var newRaw = [];
        var newTranslation = [];
        var newCompletion = [];
        var newMarked = [];
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
    return ProjectViewModel;
}());
var ProjectData = /** @class */ (function () {
    function ProjectData(data) {
        this.ProjectName = data.projectName();
        var newRaw = [];
        var newTranslation = [];
        var newCompletion = [];
        var newMarked = [];
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
    return ProjectData;
}());
//# sourceMappingURL=ProjectData.js.map
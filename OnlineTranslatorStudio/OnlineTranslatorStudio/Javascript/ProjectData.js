var ProjectViewModel = /** @class */ (function () {
    function ProjectViewModel(data) {
        this.projectName = ko.observable(data.ProjectName);
        var newRaw = [];
        for (var i = 0; i < data.RawLines.length; i++) {
            newRaw.push(ko.observable(data.RawLines[i]));
        }
        this.rawLines = ko.observableArray(newRaw);
        var newTranslation = [];
        for (var i = 0; i < data.TranslatedLines.length; i++) {
            newTranslation.push(ko.observable(data.TranslatedLines[i]));
        }
        this.translatedLines = ko.observableArray(newTranslation);
        var newCompletion = [];
        for (var i = 0; i < data.CompletedLines.length; i++) {
            newCompletion.push(ko.observable(data.CompletedLines[i]));
        }
        this.completedLines = ko.observableArray(newCompletion);
        this.markedLines = data.MarkedLines;
    }
    return ProjectViewModel;
}());
var ProjectData = /** @class */ (function () {
    function ProjectData(data) {
        this.ProjectName = data.projectName();
        var newRaw = [];
        for (var i = 0; i < data.rawLines().length; i++) {
            newRaw.push(data.rawLines()[i]());
        }
        this.RawLines = newRaw;
        var newTranslation = [];
        for (var i = 0; i < data.translatedLines().length; i++) {
            newTranslation.push(data.translatedLines()[i]());
        }
        this.TranslatedLines = newTranslation;
        var newCompletion = [];
        for (var i = 0; i < data.completedLines().length; i++) {
            newCompletion.push(data.completedLines()[i]());
        }
        this.CompletedLines = newCompletion;
        this.MarkedLines = data.markedLines;
    }
    return ProjectData;
}());
//# sourceMappingURL=ProjectData.js.map
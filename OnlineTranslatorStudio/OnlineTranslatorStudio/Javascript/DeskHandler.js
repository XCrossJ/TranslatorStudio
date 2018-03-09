/// <reference path="../scripts/typings/jquery/jquery.d.ts" />
//https://jsfiddle.net/5o1wf1bn/1/
$(document).keydown(function (event) {
    // Key Code Right Arrow = 39
    //if ((event.which === 39) && (event.altKey === true) && (event.ctrlKey === true)) {
    if ((event.which === 39) && (event.ctrlKey === true)) {
        handler.incrementIndex();
    }
    // Key Code Left Arrow = 37
    //if ((event.which === 37) && (event.altKey === true) && (event.ctrlKey === true)) {
    if ((event.which === 37) && (event.ctrlKey === true)) {
        handler.decrementIndex();
    }
    // Key Code M = 77
    if ((event.which === 77) && (event.altKey === true) && (event.ctrlKey === true)) {
        var checkBox = $("#CurrentMarked");
        checkBox.prop('checked', !checkBox.prop('checked'));
    }
    // Key Code Enter = 13
    //if ((event.which === 13) && (event.altKey === true) && (event.ctrlKey === true)) {
    if ((event.which === 13) && (event.ctrlKey === true)) {
        var checkBox = $("#CurrentCompletion");
        checkBox.prop('checked', !checkBox.prop('checked'));
    }
    // Key Code S = 83
    if ((event.which === 83) && (event.altKey === true) && (event.ctrlKey === true)) {
        //if ((event.which === 78) && (event.altKey === true) && (event.ctrlKey === true)) {
        $.ajax({
            url: "/Studio/ExportProject",
            type: "POST",
            contentType: "application/json",
            data: translationData.GetSaveString(),
            dataType: "json",
            success: function (data) {
                //$.unblockUI();
                if (data.fileName != "") {
                    window.location.href = "/Studio/DownloadProject/?file=" + data.fileName;
                }
            } // get your response here
        });
    }
});
var DeskHandler = /** @class */ (function () {
    function DeskHandler(data, selectors) {
        this.translationData = data;
        //this.loadData();
        console.log(this.translationData);
        this.nameSelector = selectors.nameSelector;
        this.indexSelector = selectors.indexSelector;
        this.linesSelector = selectors.linesSelector;
        this.rawSelector = selectors.rawSelector;
        this.translationSelector = selectors.translationSelector;
        this.markedSelector = selectors.markedSelector;
        this.completionSelector = selectors.completionSelector;
    }
    DeskHandler.prototype.loadData = function () {
        var testTranslation;
        $.ajax({
            url: "/Studio/OpenProject",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                console.log(data);
                var testProject = new ProjectData(data);
                console.log(testProject);
                var tData = new TranslationData(testProject);
                console.log(tData);
                testTranslation = tData;
            } // get your response here
        });
        debugger;
        this.translationData = testTranslation;
    };
    DeskHandler.prototype.updateDesk = function () {
        this.translationData.ProjectName = $(this.nameSelector).val();
        this.translationData.CurrentRaw = $(this.rawSelector).val();
        this.translationData.CurrentTranslation = $(this.translationSelector).val();
        this.translationData.CurrentMarked = $(this.markedSelector).prop('checked');
        this.translationData.CurrentCompletion = $(this.completionSelector).prop('checked');
    };
    DeskHandler.prototype.reloadDesk = function () {
        $(this.nameSelector).val(this.translationData.ProjectName);
        $(this.indexSelector).text(this.translationData.currentIndex + 1);
        $(this.linesSelector).text(this.translationData.NumberOfLines);
        $(this.rawSelector).val(this.translationData.CurrentRaw);
        $(this.translationSelector).val(this.translationData.CurrentTranslation);
        $(this.markedSelector).prop('checked', this.translationData.CurrentMarked);
        $(this.completionSelector).prop('checked', this.translationData.CurrentCompletion);
    };
    DeskHandler.prototype.incrementIndex = function () {
        this.updateDesk();
        this.translationData.IncrementIndex();
        this.reloadDesk();
    };
    DeskHandler.prototype.decrementIndex = function () {
        this.updateDesk();
        this.translationData.DecrementIndex();
        this.reloadDesk();
    };
    DeskHandler.prototype.updateProjectName = function (name) {
        this.translationData.ProjectName = name;
    };
    DeskHandler.prototype.updateCurrentRaw = function (raw) {
        this.translationData.CurrentRaw = raw;
    };
    DeskHandler.prototype.updateCurrentTranslation = function (translation) {
        this.translationData.CurrentTranslation = translation;
    };
    DeskHandler.prototype.updateCurrentMarked = function (marked) {
        this.translationData.CurrentMarked = marked;
    };
    DeskHandler.prototype.updateCurrentCompletion = function (completion) {
        this.translationData.CurrentCompletion = completion;
    };
    return DeskHandler;
}());
//var nameSelector = "#ProjectName";
//var indexSelector = "#CurrentIndex";
//var linesSelector = ".NumberOfLines";
//var rawSelector = "#CurrentRaw";
//var translationSelector = "#CurrentTranslation";
//var markedSelector = "#CurrentMarked";
//var completionSelector = "#CurrentCompletion";
//function incrementIndex(data: ITranslationData) {
//    updateDesk(data);
//    data.IncrementIndex();
//    reloadDesk(data);
//}
//function decrementIndex(data: ITranslationData) {
//    updateDesk(data);
//    data.DecrementIndex();
//    reloadDesk(data);
//}
//function updateDesk(data: ITranslationData) {
//    data.ProjectName = $(nameSelector).val();
//    data.CurrentRaw = $(rawSelector).val();
//    data.CurrentTranslation = $(translationSelector).val();
//    data.CurrentMarked = $(markedSelector).prop('checked');
//    data.CurrentCompletion = $(completionSelector).prop('checked');
//}
//function reloadDesk(data: ITranslationData) {
//    $(nameSelector).val(data.ProjectName);
//    $(indexSelector).text(data.currentIndex + 1);
//    $(linesSelector).text(data.NumberOfLines);
//    $(rawSelector).val(data.CurrentRaw);
//    $(translationSelector).val(data.CurrentTranslation);
//    $(markedSelector).prop('checked', data.CurrentMarked);
//    $(completionSelector).prop('checked', data.CurrentCompletion);
//}
//function updateProjectName(data: ITranslationData, name: string) {
//    data.ProjectName = name;
//}
//function updateCurrentRaw(data, raw) {
//    data.CurrentRaw = raw;
//}
//function updateCurrentTranslation(data: ITranslationData, translation: string) {
//    data.CurrentTranslation = translation;
//}
//function updateCurrentMarked(data: ITranslationData, marked: boolean) {
//    data.CurrentMarked = marked;
//}
//function updateCurrentCompletion(data: ITranslationData, completion: boolean) {
//    data.CurrentCompletion = completion;
//}
//# sourceMappingURL=DeskHandler.js.map
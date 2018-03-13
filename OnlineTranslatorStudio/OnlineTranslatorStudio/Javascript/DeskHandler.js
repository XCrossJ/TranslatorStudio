//https://jsfiddle.net/5o1wf1bn/1/
var DeskHandler = /** @class */ (function () {
    function DeskHandler(data) {
        this.translationData = data;
        console.log(this.translationData);
        this.nameSelector = "#ProjectName";
        this.indexSelector = "#CurrentIndex";
        this.linesSelector = ".NumberOfLines";
        this.rawSelector = "#CurrentRaw";
        this.translationSelector = "#CurrentTranslation";
        this.markedSelector = "#CurrentMarked";
        this.completionSelector = "#CurrentCompletion";
    }
    DeskHandler.prototype.processEvent = function (event) {
        // Key Code Right Arrow = 39
        //if ((event.which === 39) && (event.altKey === true) && (event.ctrlKey === true)) {
        if ((event.which === 39) && (event.ctrlKey === true)) {
            this.incrementIndex();
        }
        // Key Code Left Arrow = 37
        //if ((event.which === 37) && (event.altKey === true) && (event.ctrlKey === true)) {
        if ((event.which === 37) && (event.ctrlKey === true)) {
            this.decrementIndex();
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
                data: this.translationData.GetSaveString(),
                dataType: "json",
                success: function (data) {
                    //$.unblockUI();
                    if (data.fileName != "") {
                        window.location.href = "/Studio/DownloadProject/?file=" + data.fileName;
                    }
                } // get your response here
            });
        }
    };
    DeskHandler.prototype.updateDesk = function () {
        //this.translationData.ProjectName = $(this.nameSelector).val();
        //this.translationData.CurrentRaw = $(this.rawSelector).val();
        //this.translationData.CurrentTranslation = $(this.translationSelector).val();
        this.translationData.CurrentMarked = $(this.markedSelector).prop('checked');
        //this.translationData.CurrentCompletion = $(this.completionSelector).prop('checked');
    };
    DeskHandler.prototype.reloadDesk = function () {
        //$(this.nameSelector).val(this.translationData.ProjectName);
        //$(this.indexSelector).text(this.translationData.currentIndex() + 1);
        //$(this.linesSelector).text(this.translationData.NumberOfLines);
        //$(this.rawSelector).val(this.translationData.CurrentRaw);
        //$(this.translationSelector).val(this.translationData.CurrentTranslation);
        $(this.markedSelector).prop('checked', this.translationData.CurrentMarked);
        //$(this.completionSelector).prop('checked', this.translationData.CurrentCompletion);
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
    //updateProjectName(name: string) {
    //    this.translationData.ProjectName = name;
    //}
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
//# sourceMappingURL=DeskHandler.js.map
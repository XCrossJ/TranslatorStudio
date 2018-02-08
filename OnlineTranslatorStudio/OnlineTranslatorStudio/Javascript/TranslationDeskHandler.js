//https://jsfiddle.net/5o1wf1bn/1/

var nameSelector = "#ProjectName";

var indexSelector = "#CurrentIndex";
var linesSelector = ".NumberOfLines";

var rawSelector = "#CurrentRaw";
var translationSelector = "#CurrentTranslation";
var markedSelector = "#CurrentMarked";
var completionSelector = "#CurrentCompletion";



$(document).keydown(function () {
    // Key Code Right Arrow = 39
    //if ((event.which === 39) & (event.altKey === true) & (event.ctrlKey === true)) {
    if ((event.which === 39) & (event.ctrlKey === true)) {
        incrementIndex(translationData);
    }

    // Key Code Left Arrow = 37
    //if ((event.which === 37) & (event.altKey === true) & (event.ctrlKey === true)) {
    if ((event.which === 37) & (event.ctrlKey === true)) {
        decrementIndex(translationData);
    }

    // Key Code M = 77
    if ((event.which === 77) & (event.altKey === true) & (event.ctrlKey === true)) {
        var checkBox = $("#CurrentMarked");
        checkBox.prop('checked', !checkBox.prop('checked'));
    }

    // Key Code Enter = 13
    //if ((event.which === 13) & (event.altKey === true) & (event.ctrlKey === true)) {
    if ((event.which === 13) & (event.ctrlKey === true)) {
        var checkBox = $("#CurrentCompletion");
        checkBox.prop('checked', !checkBox.prop('checked'));
    }

    // Key Code S = 83
    if ((event.which === 83) & (event.altKey === true) & (event.ctrlKey === true)) {
        //if ((event.which === 78) & (event.altKey === true) & (event.ctrlKey === true)) {
        $.ajax({
            url: "/Studio/ExportProject",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ data: translationData.projectData }),
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

function incrementIndex(data) {
    updateDesk(data);
    data.IncrementIndex();
    reloadDesk(data);
}

function decrementIndex(data) {
    updateDesk(data);
    data.DecrementIndex();
    reloadDesk(data);
}

function updateDesk(data) {
    data.ProjectName = $(nameSelector).val();

    data.CurrentRaw = $(rawSelector).val();
    data.CurrentTranslation = $(translationSelector).val();
    data.CurrentMarked = $(markedSelector).prop('checked');
    data.CurrentCompletion = $(completionSelector).prop('checked');
}

function reloadDesk(data) {
    $(nameSelector).val(data.ProjectName);

    $(indexSelector).text(data.currentIndex + 1);
    $(linesSelector).text(data.NumberOfLines);
    
    $(rawSelector).val(data.CurrentRaw);
    $(translationSelector).val(data.CurrentTranslation);
    $(markedSelector).prop('checked', data.CurrentMarked);
    $(completionSelector).prop('checked', data.CurrentCompletion);
}

function updateProjectName(data, name) {
    data.ProjectName = name;
}

function updateCurrentRaw(data, raw) {
    data.CurrentRaw = raw;
}

function updateCurrentTranslation(data, translation) {
    data.CurrentTranslation = translation;
}

function updateCurrentMarked(data, marked) {
    data.CurrentMarked = marked;
}

function updateCurrentCompletion(data, completion) {
    data.CurrentCompletion = completion;
}

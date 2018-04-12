var translationData: ITranslationData;
var handler: DeskHandler;

$.ajax({
    url: "/Studio/OpenProject",
    type: "POST",
    contentType: "application/json",
    dataType: "json",
    success: function (data) {
        console.log(data);
        var projectData = new ProjectViewModel(data);
        translationData = new TranslationData(projectData);
        handler = new DeskHandler(translationData);
        translationData.CurrentIndex(0);
    }
});

$(document).keydown(function (event: KeyboardEvent) {
    handler.processEvent(event);
});

$(document).ready(function () {

    $("#editMode").change(function () {
        handler.processEditMode(this);
    });

    $("#saveProject").click(function () {
        handler.saveProject();
    });

    $("#downloadProject").click(function () {
        handler.downloadProject();
    });

    $("#exportProject").click(function () {
        handler.exportProject();
    });
});


//Context menu
//https://swisnl.github.io/jQuery-contextMenu/demo.html
//https://stackoverflow.com/questions/4495626/making-custom-right-click-context-menus-for-my-web-app
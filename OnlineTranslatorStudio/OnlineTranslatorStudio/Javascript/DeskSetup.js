var translationData;
var handler;
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
    }
});
$(document).keydown(function (event) {
    handler.processEvent(event);
});
$(document).ready(function () {
    $("#decrementIndex").click(function () {
        translationData.DecrementIndex();
    });
    $("#incrementIndex").click(function () {
        translationData.IncrementIndex();
    });
    $("#editMode").change(function () {
        handler.processEditMode(this);
    });
});
//Context menu
//https://swisnl.github.io/jQuery-contextMenu/demo.html
//https://stackoverflow.com/questions/4495626/making-custom-right-click-context-menus-for-my-web-app 
//# sourceMappingURL=DeskSetup.js.map
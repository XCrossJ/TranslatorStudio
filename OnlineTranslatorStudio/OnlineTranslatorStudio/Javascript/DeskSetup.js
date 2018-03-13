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
//# sourceMappingURL=DeskSetup.js.map
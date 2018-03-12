/// <reference path="../scripts/typings/jquery/jquery.d.ts" />

var translationData: ITranslationData;
var handler: DeskHandler;

$.ajax({
    url: "/Studio/OpenProject",
    type: "POST",
    contentType: "application/json",
    dataType: "json",
    success: function (data) {
        console.log(data);
        var projectData = new ProjectData(data);
        translationData = new TranslationData(projectData);

        handler = new DeskHandler(translationData);
    }
});

$(document).keydown(function (event: KeyboardEvent) {
    handler.processEvent(event);
});
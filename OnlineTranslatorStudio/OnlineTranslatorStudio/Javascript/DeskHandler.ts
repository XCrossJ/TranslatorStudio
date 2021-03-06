﻿//https://jsfiddle.net/5o1wf1bn/1/

class DeskHandler {
    private translationData: ITranslationData;

    constructor(data: ITranslationData) {
        this.translationData = data;
    }

    processEvent(event: KeyboardEvent) {
        // Key Code Right Arrow = 39
        //if ((event.which === 39) && (event.altKey === true) && (event.ctrlKey === true)) {
        if ((event.which === 39) && (event.ctrlKey === true)) {
            this.translationData.IncrementIndex();
        }

        // Key Code Left Arrow = 37
        //if ((event.which === 37) && (event.altKey === true) && (event.ctrlKey === true)) {
        if ((event.which === 37) && (event.ctrlKey === true)) {
            this.translationData.DecrementIndex();
        }

        // Key Code M = 77
        if ((event.which === 77) && (event.altKey === true) && (event.ctrlKey === true)) {
            this.translationData.CurrentMarked(!this.translationData.CurrentMarked());
        }

        // Key Code Enter = 13
        //if ((event.which === 13) && (event.altKey === true) && (event.ctrlKey === true)) {
        if ((event.which === 13) && (event.ctrlKey === true)) {
            this.translationData.CurrentCompletion(!this.translationData.CurrentCompletion());
        }

        // Key Code S = 83
        if ((event.which === 83) && (event.altKey === true) && (event.ctrlKey === true)) {
        //if ((event.which === 83) && (event.altKey === true) && (event.ctrlKey === true)) {
            this.saveProject();
        }

        // Key Code E = 69
        if ((event.which === 69) && (event.altKey === true) && (event.ctrlKey === true)) {
            this.exportProject();
        }
    }

    processEditMode(element: HTMLSelectElement) {
        try {
            switch (element.value) {
                case "Marked":
                    this.translationData.StartMarkedOnlyMode();
                    break;
                case "Incomplete":
                    this.translationData.StartIncompleteOnlyMode();
                    break;
                case "Complete":
                    this.translationData.StartCompleteOnlyMode();
                    break;
                case "Default":
                default:
                    this.translationData.StartDefaultMode();
                    break;
            }
        } catch (e) {
            element.value = "Default";
        }
    }

    saveProject() {
        $.ajax({
            url: "/Studio/SaveProject",
            type: "POST",
            contentType: "application/json",
            data: this.translationData.GetSaveString(),
            dataType: "json",
            success: function (data) {
                if (data.errorMessage != "") {
                    alert("Save failed: " + data.errorMessage);
                }
                else {
                    if (data.success === true) {
                        alert("Project Saved");
                    }
                    else {
                        alert("Project not saved");
                    }
                }
            } // get your response here
        });
    }

    exportProject() {
        $.ajax({
            url: "/Studio/CreateExportFile",
            type: "POST",
            contentType: "application/json",
            data: this.translationData.GetSaveString(),
            dataType: "json",
            success: function (data) {
                if (data.errorMessage != "") {
                    alert("Download failed: " + data.errorMessage);
                }
                else {
                    if (data.fileName != "") {
                        window.location.href = "/Studio/DownloadFile/?file=" + data.fileName;
                    }
                    else {
                        alert("Download failed: Unable to find file name.");
                    }
                }
            } // get your response here
        });
    }

    downloadProject() {
        $.ajax({
            url: "/Studio/CreateProjectFile",
            type: "POST",
            contentType: "application/json",
            data: this.translationData.GetSaveString(),
            dataType: "json",
            success: function (data) {
                if (data.errorMessage != "") {
                    alert("Download failed: " + data.errorMessage);
                }
                else {
                    if (data.fileName != "") {
                        window.location.href = "/Studio/DownloadFile/?file=" + data.fileName;
                    }
                    else {
                        alert("Download failed: Unable to find file name.");
                    }
                }
            } // get your response here
        });
    }
}
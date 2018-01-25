//https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes

class ProjectData {
    constructor(name, raw, translated, marked, completed) {
        this.projectName = name;
        this.rawLines = raw;
        this.translatedLines = translated;
        this.markedLines = marked;
        this.completedLines = completed;
    }
}

class TranslationData {

    // Constructor
    constructor(data) {
        this.projectData = data;
        
        this.currentIndex = 0;
        this.maxIndex = data.rawLines.length - 1;

        this.defaultTranslationMode = true;
    }

    // Get Properties
    get ProjectName() {
        return this.projectData.projectName;
    }

    set ProjectName(value) {
        this.projectData.projectName = value;
    }

    get RawLines() {
        return this.projectData.rawLines;
    }

    set RawLines(value) {
        this.projectData.rawLines = value;
    }

    get TranslatedLines() {
        return this.projectData.translatedLines;
    }

    set TranslatedLines(value) {
        this.projectData.translatedLines = value;
    }

    get MarkedLines() {
        return this.projectData.markedLines;
    }

    set MarkedLines(value) {
        this.projectData.markedLines = value;
    }

    get CompletedLines() {
        return this.projectData.completedLines;
    }

    set CompletedLines(value) {
        this.projectData.completedLines = value;
    }

    get CurrentRaw() {
        return this.RawLines[this.currentIndex];
    }

    set CurrentRaw(value) {
        this.RawLines[this.currentIndex] = value;
    }

    get CurrentTranslation() {
        return this.TranslatedLines[this.currentIndex];
    }

    set CurrentTranslation(value) {
        this.TranslatedLines[this.currentIndex] = value;
    }

    get CurrentMarked() {
        return this.MarkedLines[this.currentIndex];
    }

    set CurrentMarked(value) {
        this.MarkedLines[this.currentIndex] = value;
    }

    get CurrentCompletion() {
        return this.CompletedLines[this.currentIndex];
    }

    set CurrentCompletion(value) {
        this.CompletedLines[this.currentIndex] = value;
    }

    get NumberOfLines() {
        return this.RawLines.length;
    }

    get NumberOfCompletedLines() {
        //return this.DetermineCompletedLines(this.CompletedLines);
        var result = 0;
        for (var i = 0; i < completedLines.length; i++) {
            if (completedLines[i] == true) {
                result++;
            }
        }
        return result;
    }

    // Methods
    IncrementIndex() {
        if (this.currentIndex < this.maxIndex) {
            this.currentIndex++;
        }
    }

    DecrementIndex() {
        if (this.currentIndex > 0) {
            this.currentIndex--;
        }
    }

    //DetermineCompletedLines(completedLines) {
    //    var result = 0;
    //    for (var i = 0; i < completedLines.length; i++) {
    //        if (completedLines[i] == true) {
    //            result++;
    //        }
    //    }
    //    return result;
    //}
}

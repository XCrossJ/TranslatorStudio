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

    get RawLines() {
        return this.projectData.rawLines;
    }

    get TranslatedLines() {
        return this.projectData.translatedLines;
    }

    get MarkedLines() {
        return this.projectData.markedLines;
    }

    get CompletedLines() {
        return this.projectData.completedLines;
    }

    get CurrentRaw() {
        return this.RawLines[this.currentIndex];
    }

    get CurrentTranslation() {
        return this.TranslatedLines[this.currentIndex];
    }

    get CurrentMarked() {
        return this.MarkedLines[this.currentIndex];
    }

    get CurrentCompletion() {
        return this.CompletedLines[this.currentIndex];
    }

    get NumberOfLines() {
        return this.RawLines.length;
    }

    get NumberOfCompletedLines() {
        return DetermineCompletedLines(this.CompletedLines);
    }

    // Methods
    IncrementIndex() {
        if (translationData.currentIndex < translationData.maxIndex) {
            translationData.currentIndex++;
        }
    }

    DecrementIndex() {
        if (translationData.currentIndex > 0) {
            translationData.currentIndex--;
        }
    }

    DetermineCompletedLines(completedLines) {
        var result = 0;
        for (var i = 0; i < completedLines.length; i++) {
            if (completedLines[i] == true) {
                result++;
            }
        }
        return result;
    }
}

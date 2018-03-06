//https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes
namespace TranslationData {

}

interface ITranslationData {
    currentIndex: number;
    maxIndex: number;

    ProjectName: string;
    RawLines: string[];
    TranslatedLines: string[];
    MarkedLines: boolean[];
    CompletedLines: boolean[];

    CurrentRaw: string;
    CurrentTranslation: string;
    CurrentMarked: boolean;
    CurrentCompletion: boolean;

    NumberOfLines: number;
    NumberOfCompletedLines: number;

    IncrementIndex: () => void;
    DecrementIndex: () => void;
    GetSaveString: () => string;
}

class TranslationData implements ITranslationData {
    private _projectData: IProjectData;
    currentIndex: number;
    maxIndex: number;

    defaultTranslationMode: boolean;

    // Constructor
    constructor(projectData: IProjectData) {
        if (projectData == undefined) throw 'Project Data is undefined';
        this._projectData = projectData;

        this.currentIndex = 0;
        this.maxIndex = projectData.rawLines.length - 1;

        this.defaultTranslationMode = true;
    }

    // Properties
    get ProjectName(): string {
        return this._projectData.projectName;
    }
    set ProjectName(value: string) {
        this._projectData.projectName = value;
    }

    get RawLines(): string[] {
        return this._projectData.rawLines;
    }
    set RawLines(value: string[]) {
        this._projectData.rawLines = value;
    }

    get TranslatedLines(): string[] {
        return this._projectData.translatedLines;
    }
    set TranslatedLines(value: string[]) {
        this._projectData.translatedLines = value;
    }

    get MarkedLines(): boolean[] {
        return this._projectData.markedLines;
    }
    set MarkedLines(value: boolean[]) {
        this._projectData.markedLines = value;
    }

    get CompletedLines(): boolean[] {
        return this._projectData.completedLines;
    }
    set CompletedLines(value: boolean[]) {
        this._projectData.completedLines = value;
    }

    get CurrentRaw(): string {
        return this.RawLines[this.currentIndex];
    }
    set CurrentRaw(value: string) {
        this.RawLines[this.currentIndex] = value;
    }

    get CurrentTranslation(): string {
        return this.TranslatedLines[this.currentIndex];
    }
    set CurrentTranslation(value: string) {
        this.TranslatedLines[this.currentIndex] = value;
    }

    get CurrentMarked(): boolean {
        return this.MarkedLines[this.currentIndex];
    }
    set CurrentMarked(value: boolean) {
        this.MarkedLines[this.currentIndex] = value;
    }

    get CurrentCompletion(): boolean {
        return this.CompletedLines[this.currentIndex];
    }
    set CurrentCompletion(value: boolean) {
        this.CompletedLines[this.currentIndex] = value;
    }

    get NumberOfLines(): number {
        return this.RawLines.length;
    }

    get NumberOfCompletedLines(): number {
        var result = 0;
        for (var i = 0; i < this.CompletedLines.length; i++) {
            if (this.CompletedLines[i] == true) {
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

    GetSaveString(): string {
        return JSON.stringify({ data: this._projectData });
    }
}

interface IProjectParameters {
    ProjectName: string;
    RawLines: string[];
    TranslatedLines: string[];
    CompletedLines: boolean[];
    MarkedLines: boolean[];
}

interface IProjectData {
    projectName: string;
    rawLines: string[];
    translatedLines: string[];
    markedLines: boolean[];
    completedLines: boolean[];
}

class ProjectData implements IProjectData {

    projectName: string;
    rawLines: string[];
    translatedLines: string[];
    markedLines: boolean[];
    completedLines: boolean[];

    constructor(data: IProjectParameters) {
        this.projectName = data.ProjectName;
        this.rawLines = data.RawLines;
        this.translatedLines = data.TranslatedLines;
        this.markedLines = data.CompletedLines;
        this.completedLines = data.MarkedLines;
    }
}


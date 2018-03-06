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

    constructor(name: string, raw: string[], translated: string[], marked: boolean[], completed: boolean[]) {
        this.projectName = name;
        this.rawLines = raw;
        this.translatedLines = translated;
        this.markedLines = marked;
        this.completedLines = completed;
    }
}

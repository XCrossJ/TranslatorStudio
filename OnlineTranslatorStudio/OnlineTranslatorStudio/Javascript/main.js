define(["require", "exports", "ProjectData", "TranslationData"], function (require, exports, proj, trans) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var raw = ["raw1", "raw2"];
    var translation = ["trans1", "trans2"];
    var marked = [true, false];
    var completed = [true, false];
    var test = new proj.ProjectData("test", raw, translation, marked, completed);
    console.log(test);
    var test1 = new trans.TranslationData(test);
    console.log(test1);
});
//# sourceMappingURL=main.js.map
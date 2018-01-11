using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Class
{
    public class ProjectData : IProjectData
    {
        public string ProjectName { get; set; }
        public List<string> RawLines { get; set; }
        public string[] TranslatedLines { get; set; }
        public bool[] CompletedLines { get; set; }
        public bool[] MarkedLines { get; set; }

        public ProjectData()
        {

        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as ProjectData;
            if (toCompareWith == null)
            {
                return false;
            }
            else
            {
                if (ProjectName != toCompareWith.ProjectName) 
                    return false;
                //return
                //    ProjectName == toCompareWith.ProjectName &&
                //    RawLines == toCompareWith.RawLines &&
                //    TranslatedLines == toCompareWith.TranslatedLines &&
                //    CompletedLines == toCompareWith.CompletedLines &&
                //    MarkedLines == toCompareWith.MarkedLines;
                return true;
            }
        }
    }
}

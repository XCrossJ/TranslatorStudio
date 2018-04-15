using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;

namespace OnlineTranslatorStudio.Models
{
    public class OnlineProjectData
    {
        public string ProjectName { get; set; }
        public List<ProjectLine> ProjectLines { get; set; }

        public IProjectData MapToProjectData()
        {
            IProjectData data;

            data = new ProjectData
            {
                ProjectName = ProjectName,
                ProjectLines = ProjectLines.Select(x => x).ToList<IProjectLine>()
            };
            return data;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorStudioClassLibrary.Interface
{
    public interface IProjectData
    {
        string ProjectName { get; set; }
        List<string> RawLines { get; set; }
        string[] TranslatedLines { get; set; }
        bool[] CompletedLines { get; set; }
        bool[] MarkedLines { get; set; }
    }
}

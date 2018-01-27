using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudio.Interfaces
{
    public interface INewConsumer
    {
        IProjectData CreateNewProjectFromRaw(DialogResult dialogResult, string fileName, string[] rawLines);
    }
}

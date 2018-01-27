using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslatorStudio.Interfaces;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;

namespace TranslatorStudio.Consumers
{
    public class NewConsumer : INewConsumer
    {
        private readonly IProjectDataRepository projectDataRepository;

        public NewConsumer()
        {
            projectDataRepository = new ProjectDataRepository();
        }

        public NewConsumer(IProjectDataRepository newProjectDataRepository)
        {
            projectDataRepository = newProjectDataRepository;
        }

        public IProjectData CreateNewProjectFromRaw(DialogResult dialogResult, string fileName, string[] rawLines)
        {
            IProjectData result = null;
            if (rawLines != null && rawLines.Length != 0)
            {
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        result = projectDataRepository.CreateProjectDataFromArray(fileName, rawLines);
                        break;
                    case DialogResult.No:
                    case DialogResult.Cancel:
                    default:
                        break;
                }
            }

            return result;
        }
    }
}

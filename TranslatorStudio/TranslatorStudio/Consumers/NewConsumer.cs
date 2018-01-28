using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudio.Interfaces;
using TranslatorStudio.Utilities;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;

namespace TranslatorStudio.Consumers
{
    public class NewConsumer : INewConsumer
    {
        #region Properties
        private readonly IProjectDataRepository projectDataRepository;
        private readonly ITranslationDataRepository translationDataRepository;
        public frmNew New { get; set; }
        #endregion

        #region Constructors
        public NewConsumer(frmNew frmNew)
        {
            New = frmNew;
            projectDataRepository = new ProjectDataRepository();
            translationDataRepository = new TranslationDataRepository();
        }

        public NewConsumer(frmNew frmNew, IProjectDataRepository newProjectDataRepository, ITranslationDataRepository newTranslationDataRepository)
        {
            New = frmNew;
            projectDataRepository = newProjectDataRepository;
            translationDataRepository = newTranslationDataRepository;
        }
        #endregion

        #region Public Methods
        public bool CreateNewProject()
        {
            string fileName = !string.IsNullOrEmpty(New.ProjectName) ? New.ProjectName : "";
            string[] rawLines = New.RawLines.Any() ? New.RawLines : null;
            DialogResult dialogResult = ApplicationData.MsgBox_NewProject_Confirmation(New);

            var projectData = CreateNewProjectFromRaw(dialogResult, fileName, rawLines);

            if (projectData != null)
                return CreateProject(projectData);
            else
                MessageBox.Show("Raw is Empty or Null. Please provide Raw Text To Translate.");
            return false;
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
        
        public bool QuitNew()
        {
            New.Close();
            return true;
        }

        public bool ProcessShortcuts(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.Enter):
                    CreateNewProject();
                    return true;
                case (Keys.Control | Keys.Escape):
                    QuitNew();
                    return true;
                default:
                    return false;
            }
        }
        #endregion

        #region Private Methods
        private bool CreateProject(IProjectData projectData)
        {
            ITranslationData translationData = translationDataRepository.CreateTranslationDataFromProject(projectData);
            if (New.Hub != null)
            {
                New.Hub.SetDesk(translationData);
                New.Close();
                New.Hub.OpenDesk();
                return true;
            }
            if (New.Desk != null)
            {
                New.Desk.ResetTranslationProject(translationData);
                New.Close();
                return true;
            }
            return false;
        }
        #endregion
    }
}

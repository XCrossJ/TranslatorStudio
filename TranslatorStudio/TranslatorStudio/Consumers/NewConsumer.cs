using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudio.Interfaces;
using TranslatorStudio.Utilities;
using TranslatorStudioClassLibrary.Exception;
using TranslatorStudioClassLibrary.Factory;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;

namespace TranslatorStudio.Consumers
{
    public class NewConsumer : INewConsumer
    {
        #region Properties

        private readonly ITranslationDataFactory translationDataFactory;

        public frmNew New { get; set; }

        #endregion


        #region Constructors

        public NewConsumer(frmNew frmNew)
        {
            New = frmNew ?? throw new ArgumentNullException(nameof(frmNew));
            IProjectDataFactory projectFactory = new ProjectDataFactory();
            ISubTranslationDataFactory subFactory = new SubTranslationDataFactory();
            translationDataFactory = new TranslationDataFactory(projectFactory, subFactory);
        }

        public NewConsumer(frmNew frmNew, ITranslationDataFactory newTranslationDataRepository)
        {
            New = frmNew ?? throw new ArgumentNullException(nameof(frmNew));
            translationDataFactory = newTranslationDataRepository ?? throw new ArgumentNullException(nameof(newTranslationDataRepository));
        }

        #endregion


        #region Public Methods

        public bool CreateNewProject()
        {
            try
            {
                string fileName = !string.IsNullOrEmpty(New.ProjectName) ? New.ProjectName : "";
                string[] rawLines = New.RawLines.Any() ? New.RawLines : null;
                DialogResult dialogResult = ApplicationData.MsgBox_NewProject_Confirmation(New);

                var translationData = CreateNewTranslationFromRaw(dialogResult, fileName, rawLines);

                if (translationData != null)
                    return CreateTranslationProject(translationData);
                else
                    return false;
            }
            catch (EmptyRawException)
            {
                ApplicationData.MsgBox_EmptyRawException(New);
                return false;
            }
        }

        public ITranslationData CreateNewTranslationFromRaw(DialogResult dialogResult, string fileName, string[] rawLines)
        {
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    return translationDataFactory.CreateTranslationDataFromArray(fileName, rawLines);
                case DialogResult.No:
                case DialogResult.Cancel:
                default:
                    return null;
            }
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

        private bool CreateTranslationProject(ITranslationData translationData)
        {
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

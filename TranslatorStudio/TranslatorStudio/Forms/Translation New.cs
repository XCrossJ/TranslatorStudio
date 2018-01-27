using System;
using System.Windows.Forms;
using TranslatorStudio.Consumers;
using TranslatorStudio.Interfaces;
using TranslatorStudio.Utilities;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;

namespace TranslatorStudio.Forms
{
    public partial class frmNew : Form
    {
        #region Constructor
        private FrmHub _hub;
        private FrmDesk _desk;
        private readonly ITranslationDataRepository translationDataRepository;
        private readonly INewConsumer consumer;

        public frmNew()
        {
            InitializeComponent();
            translationDataRepository = new TranslationDataRepository();
            consumer = new NewConsumer();
        }

        public frmNew(FrmHub hub) : this()
        {
            _hub = hub;
        }

        public frmNew(FrmDesk desk) : this()
        {
            _desk = desk;
        }
        #endregion

        #region Control Events
        private void btnQuit_Click(object sender, EventArgs e)
        {
            QuitNew();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateNewProject();
        }
        #endregion

        #region Methods
        private void CreateNewProject()
        {
            string fileName = !string.IsNullOrEmpty(txtProjectName.Text) ? txtProjectName.Text : "";
            string[] rawLines = !string.IsNullOrEmpty(rtbRAW.Text) ? rtbRAW.Lines : null;
            DialogResult dialogResult = ApplicationData.MsgBox_NewProject_Confirmation(this);

            var projectData = consumer.CreateNewProjectFromRaw(dialogResult, fileName, rawLines);

            if (projectData != null)
                CreateProject(projectData);
            else
                MessageBox.Show("Raw is Empty or Null. Please provide Raw Text To Translate.");
        }

        private void CreateProject(IProjectData _data)
        {
            ITranslationData data = translationDataRepository.CreateTranslationDataFromProject(_data);
            if (_hub != null)
            {
                _hub.SetDesk(data);
                Close();
                _hub.OpenDesk();
            }
            if (_desk != null)
            {
                _desk.ResetTranslationProject(data);
                Close();
            }
        }

        private void QuitNew()
        {
            Close();
        }
        #endregion

        #region Overrides
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
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
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        #endregion
    }
}
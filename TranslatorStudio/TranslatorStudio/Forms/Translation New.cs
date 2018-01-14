using System;
using System.Windows.Forms;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;

namespace TranslatorStudio.Forms
{
    public partial class frmNew : Form
    {
        #region Constructor
        private FrmHub _hub;
        private FrmDesk _desk;
        
        public frmNew(FrmHub hub)
        {
            InitializeComponent();
            _hub = hub;
        }
        public frmNew(FrmDesk desk)
        {
            InitializeComponent();
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

        #region Action Methods
        private void CreateNewProject()
        {
            string fileName = !string.IsNullOrEmpty(txtProjectName.Text) ? txtProjectName.Text : "";
            string[] rawLines = !string.IsNullOrEmpty(rtbRAW.Text) ? rtbRAW.Lines : null;

            if (rawLines != null || rawLines.Length != 0)
            {
                switch (MessageBox.Show(this, "Load this raw text into the new project?", "Confirm Text", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        CreateProject(new ProjectDataRepository().CreateProjectDataFromArray(fileName, rawLines));
                        break;
                    case DialogResult.No:
                    case DialogResult.Cancel:
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Raw is Empty or Null. Please enter raw.");
            }
        }

        private void QuitNew()
        {
            Close();
        }
        #endregion

        #region Methods
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

        private void CreateProject(IProjectData _data)
        {
            ITranslationData data = new TranslationData(_data);
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
        #endregion
    }
}
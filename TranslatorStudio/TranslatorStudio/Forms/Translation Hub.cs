using System;
using System.IO;
using System.Windows.Forms;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudio.Forms
{
    public partial class FrmHub : Form
    {
        private FrmDesk _desk;
        private frmNew _new;

        public FrmHub()
        {
            InitializeComponent();
        }

        #region Control Events
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDesk_Click(object sender, EventArgs e)
        {
            var openRawFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = $@"Source and Project files (*.txt;*.docx;*.tsp)|*.txt;*.docx;*.tsp|All files (*.*)|*.*",
                Title = "Open Project or Raw Source File"
            };

            if (openRawFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileExt = Path.GetExtension(openRawFileDialog.FileName);
                var filePath = openRawFileDialog.FileName;
                var fileName = Path.GetFileNameWithoutExtension(openRawFileDialog.SafeFileName);
                OpenFile(fileExt, filePath, fileName);
            }

        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            _new = new frmNew(this);
            _new.ShowDialog();
        }
        #endregion

        #region Methods
        private void OpenFile(string fileExt, string path, string fileName)
        {
            var openData = FileHelper.OpenHandler(fileExt, path, fileName);
            ITranslationData data = openData.Item1;
            string previousSavePath = openData.Item2;
            _desk = new FrmDesk(data, previousSavePath, this);
            OpenDesk();
        }
        public void SetDesk(ITranslationData data)
        {
            _desk = new FrmDesk(data, this);
        }
        public void OpenDesk()
        {
            _desk.Show();
            Hide();
        }
        #endregion

        #region Overrides
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.O):
                    btnDesk_Click(this, new EventArgs());
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        #endregion

    }
}

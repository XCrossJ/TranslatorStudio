using System;
using System.Windows.Forms;
using TranslatorStudio.Consumers;
using TranslatorStudio.Interfaces;

namespace TranslatorStudio.Forms
{
    public partial class frmNew : Form
    {
        #region Properties

        private readonly INewConsumer consumer;

        public FrmHub Hub { get; set; }
        public FrmDesk Desk { get; set; }

        public string ProjectName { get => txtProjectName.Text; }
        public string[] RawLines { get => rtbRAW.Lines; }

        #endregion


        #region Constructor

        public frmNew()
        {
            consumer = new NewConsumer(this);
            InitializeComponent();
        }

        public frmNew(FrmHub hub) : this()
        {
            Hub = hub ?? throw new ArgumentNullException(nameof(hub));
        }

        public frmNew(FrmDesk desk) : this()
        {
            Desk = desk ?? throw new ArgumentNullException(nameof(desk));
        }

        #endregion


        #region Control Events

        private void btnQuit_Click(object sender, EventArgs e)
        {
            consumer.QuitNew();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            consumer.CreateNewProject();
        }

        #endregion
        
        #region Overrides

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var isShortcut = consumer.ProcessShortcuts(keyData);
            if (isShortcut)
                return isShortcut;
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
    }
}
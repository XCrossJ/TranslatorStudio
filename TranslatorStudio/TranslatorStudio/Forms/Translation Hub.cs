using System;
using System.IO;
using System.Windows.Forms;
using TranslatorStudio.Consumers;
using TranslatorStudio.Interfaces;
using TranslatorStudio.Utilities;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudio.Forms
{
    public partial class FrmHub : Form
    {
        public FrmDesk Desk { get; set; }
        public frmNew New { get; set; }

        private readonly IHubConsumer consumer;

        public FrmHub()
        {
            InitializeComponent();
            consumer = new HubConsumer(this);
        }

        public FrmHub(IHubConsumer hubConsumer)
        {
            InitializeComponent();
            consumer = hubConsumer;
        }

        #region Control Events
        private void btnQuit_Click(object sender, EventArgs e)
        {
            consumer.Quit();
        }

        private void btnDesk_Click(object sender, EventArgs e)
        {
            consumer.OpenFile();
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            consumer.OpenNewFile();
        }
        #endregion

        #region Methods
        public void SetDesk(ITranslationData data)
        {
            consumer.SetDesk(data);
        }
        public void OpenDesk()
        {
            consumer.OpenDesk();
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

using System;
using System.Windows.Forms;
using TranslatorStudio.Consumers;
using TranslatorStudio.Interfaces;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudio.Forms
{
    public partial class FrmHub : Form
    {
        #region Properties

        private readonly IHubConsumer consumer;

        public FrmDesk Desk { get; set; }
        public frmNew New { get; set; }

        #endregion


        #region Constructors

        public FrmHub()
        {
            InitializeComponent();
            consumer = new HubConsumer(this);
        }

        public FrmHub(IHubConsumer hubConsumer)
        {
            InitializeComponent();
            consumer = hubConsumer ?? throw new ArgumentNullException(nameof(hubConsumer));
        }

        #endregion


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

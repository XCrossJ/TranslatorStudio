using System;
using System.Windows.Forms;
using TranslatorStudio.Consumers;
using TranslatorStudio.Interfaces;

namespace TranslatorStudio.Forms
{
    public partial class FrmShortcuts : Form
    {
        #region Properties

        private readonly IShortcutsConsumer consumer;

        #endregion

        #region Constructors

        public FrmShortcuts()
        {
            consumer = new ShortcutsConsumer(this);
            InitializeComponent();
            consumer.LoadShortcutList(lstShortcut);
        }

        #endregion

        #region Methods

        private void FrmShortcuts_Load(object sender, EventArgs e)
        {

        }

        #endregion

    }
}

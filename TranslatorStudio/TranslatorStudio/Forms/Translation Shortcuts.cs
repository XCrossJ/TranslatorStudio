using System;
using System.Windows.Forms;
using TranslatorStudio.Consumers;
using TranslatorStudio.Interfaces;

namespace TranslatorStudio.Forms
{
    public partial class FrmShortcuts : Form
    {
        private readonly IShortcutsConsumer consumer;
        public FrmShortcuts()
        {
            consumer = new ShortcutsConsumer(this);
            InitializeComponent();
            consumer.LoadShortcutList(lstShortcut);
        }

        private void FrmShortcuts_Load(object sender, EventArgs e)
        {

        }

    }
}

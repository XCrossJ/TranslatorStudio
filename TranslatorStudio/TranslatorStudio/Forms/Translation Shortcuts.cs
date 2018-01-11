using System;
using System.Windows.Forms;
using TranslatorStudio.Utilities;

namespace TranslatorStudio.Forms
{
    public partial class FrmShortcuts : Form
    {
        public FrmShortcuts()
        {
            InitializeComponent();
            LoadShortcutList();
        }

        private void FrmShortcuts_Load(object sender, EventArgs e)
        {

        }

        private void LoadShortcutList()
        {
            lstShortcut.View = View.Details;

            foreach (var item in ApplicationData.Shortcuts)
            {
                lstShortcut.Items.Add(new ListViewItem(item));
            }

            lstShortcut.GridLines = true;
            lstShortcut.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

    }
}

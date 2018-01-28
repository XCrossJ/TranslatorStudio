using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudio.Interfaces;
using TranslatorStudio.Utilities;

namespace TranslatorStudio.Consumers
{
    public class ShortcutsConsumer : IShortcutsConsumer
    {
        public FrmShortcuts Shortcuts { get; set; }

        public ShortcutsConsumer(FrmShortcuts newFrmShortcuts)
        {
            Shortcuts = newFrmShortcuts;
        }

        public bool LoadShortcutList(ListView listView)
        {
            listView.View = View.Details;
            listView.GridLines = true;

            foreach (var item in ApplicationData.Shortcuts)
            {
                listView.Items.Add(new ListViewItem(item));
            }

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            return true;
        }
    }
}

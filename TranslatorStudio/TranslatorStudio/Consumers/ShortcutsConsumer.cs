using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudio.Interfaces;
using TranslatorStudio.Utilities;

namespace TranslatorStudio.Consumers
{
    public class ShortcutsConsumer : IShortcutsConsumer
    {
        #region Properties
        public FrmShortcuts Shortcuts { get; set; }
        #endregion


        #region Constructors
        public ShortcutsConsumer(FrmShortcuts newFrmShortcuts)
        {
            Shortcuts = newFrmShortcuts ?? throw new System.ArgumentNullException(nameof(newFrmShortcuts));
        }
        #endregion


        #region Methods
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
        #endregion
    }
}

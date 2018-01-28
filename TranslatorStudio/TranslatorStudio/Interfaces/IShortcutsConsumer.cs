using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslatorStudio.Forms;

namespace TranslatorStudio.Interfaces
{
    public interface IShortcutsConsumer
    {
        #region Properties
        FrmShortcuts Shortcuts { get; set; }
        #endregion

        #region MyRegion
        bool LoadShortcutList(ListView listView);
        #endregion
    }
}

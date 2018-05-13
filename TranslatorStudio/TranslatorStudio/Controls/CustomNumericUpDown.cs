using System;
using System.Windows.Forms;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudio.Controls
{
    public partial class CustomNumericUpDown : NumericUpDown
    {
        private ITranslationData translationData;
        public CustomNumericUpDown() : base()
        {
            InitializeComponent();
        }

        public void LoadTranslationData(ITranslationData translationData)
        {
            this.translationData = translationData ?? throw new ArgumentNullException(nameof(translationData));
            this.Maximum = translationData.NumberOfLines;
        }

        public override void UpButton()
        {
            translationData.IncrementCurrentLine();
            base.UpButton();
        }
        public override void DownButton()
        {
            translationData.DecrementCurrentLine();
            base.DownButton();
        }

        #region Scroll Increment Workaround
        #region Constants
        protected const String UpKey = "{UP}";
        protected const String DownKey = "{DOWN}";
        #endregion

        #region Base Class Overrides
        protected override void OnMouseWheel(MouseEventArgs e_)
        {
            String key = GetKey(e_.Delta);
            SendKeys.Send(key);
        }
        #endregion

        #region Protected Methods
        protected static String GetKey(int delta_)
        {
            String key = (delta_ < 0) ? DownKey : UpKey;
            return key;
        }
        #endregion
        #endregion
    }
}

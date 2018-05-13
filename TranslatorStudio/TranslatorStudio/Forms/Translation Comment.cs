using System;
using System.Windows.Forms;
using TranslatorStudio.Consumers;
using TranslatorStudio.Interfaces;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudio.Forms
{
    public partial class FrmComment : Form
    {
        #region Properties
        private readonly ICommentConsumer consumer;

        public ITranslationData Data { get; set; }
        #endregion

        #region Public Controls
        public RichTextBox RtbComment => rtbComment;
        #endregion


        #region Constructors
        public FrmComment()
        {
            consumer = new CommentConsumer(this);
            InitializeComponent();
        }

        public FrmComment(ITranslationData translationData) : this()
        {
            Data = translationData ?? throw new ArgumentNullException(nameof(translationData));
        }
        #endregion


        #region Control Events
        private void FrmComment_Load(object sender, EventArgs e)
        {
            rtbComment.Text = Data.CurrentComment;
        }

        private void rtbComment_TextChanged(object sender, EventArgs e)
        {
            consumer.ProcessComment(rtbComment.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            consumer.UpdateComment(rtbComment.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            consumer.ClearComment();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            consumer.CloseComment();
        }
        #endregion

        #region Other Events
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            consumer.ConfirmSave(e);
        }

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

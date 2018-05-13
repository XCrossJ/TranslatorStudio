using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudio.Interfaces;
using TranslatorStudio.Utilities;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudio.Consumers
{
    public class CommentConsumer : ICommentConsumer
    {
        #region Properties
        public FrmComment FrmComment;

        public ITranslationData Data { get => FrmComment.Data; set => FrmComment.Data = value; }

        public bool CommentChanged { get; set; }
        #endregion

        #region Constructors
        public CommentConsumer(FrmComment frmComment)
        {
            FrmComment = frmComment ?? throw new ArgumentNullException(nameof(frmComment));
        }
        #endregion

        #region Public Methods
        public bool ProcessComment(string newComment)
        {
            CommentChanged = Data.CurrentComment != newComment;
            return true;
        }

        public bool UpdateComment(string newComment)
        {
            Data.CurrentComment = newComment;
            return ProcessComment(newComment);
        }

        public bool ClearComment()
        {
            FrmComment.RtbComment.Clear();
            return true;
        }

        public bool ProcessShortcuts(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.S):
                    UpdateComment(FrmComment.RtbComment.Text);
                    return true;
                case (Keys.Control | Keys.Alt | Keys.C):
                    ClearComment();
                    return true;
                default:
                    return false;
            }
        }
        public bool ConfirmSave(FormClosingEventArgs e)
        {
            // Confirm user wants to close
            if (CommentChanged)
            {
                switch (ApplicationData.MsgBox_CloseComment_Confirmation(FrmComment))
                {
                    case DialogResult.Yes:
                        UpdateComment(FrmComment.RtbComment.Text);
                        FrmComment.Close();
                        return true;
                    case DialogResult.No:
                        FrmComment.Close();
                        return true;
                    case DialogResult.Cancel:
                    default:
                        e.Cancel = true;
                        return true;
                }
            }
            return true;
        }

        public bool CloseComment()
        {
            FrmComment.Close();
            return true;
        }
        #endregion
    }
}

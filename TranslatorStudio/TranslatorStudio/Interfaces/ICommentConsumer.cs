using System.Windows.Forms;

namespace TranslatorStudio.Interfaces
{
    public interface ICommentConsumer
    {
        bool ProcessComment(string newComment);
        bool UpdateComment(string newComment);
        bool ClearComment();

        bool ProcessShortcuts(Keys keyData);
        bool ConfirmSave(FormClosingEventArgs e);

        bool CloseComment();
    }
}

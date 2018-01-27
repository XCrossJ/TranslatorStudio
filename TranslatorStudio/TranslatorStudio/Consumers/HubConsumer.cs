using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudio.Interfaces;
using TranslatorStudio.Utilities;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudio.Consumers
{
    public class HubConsumer : IHubConsumer
    {
        public FrmHub FrmHub { get; set; }
        public HubConsumer()
        {

        }
        public HubConsumer(FrmHub frmHub)
        {
            FrmHub = frmHub;
        }

        public void Quit()
        {
            Application.Exit();
        }

        public bool OpenFile()
        {
            var openFileDialog = ApplicationData.OpenProjectDialog();
            FrmHub.Desk = CreateDeskFromOpenFile(openFileDialog);
            return OpenDesk();
        }

        public FrmDesk CreateDeskFromOpenFile(OpenFileDialog dialog)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var fileExt = Path.GetExtension(dialog.FileName);
                var filePath = dialog.FileName;
                var fileName = Path.GetFileNameWithoutExtension(dialog.SafeFileName);

                var openData = FileHelper.OpenHandler(fileExt, filePath, fileName);
                ITranslationData data = openData.Item1;
                string previousSavePath = openData.Item2;

                return new FrmDesk(data, previousSavePath, FrmHub);
            }
            else
                throw new Exception("Open File Operation Cancelled.");
        }

        public bool OpenDesk()
        {
            FrmHub.Desk.Show();
            FrmHub.Hide();
            return true;
        }

        public bool OpenNewFile()
        {
            FrmHub.New = new frmNew(FrmHub);
            FrmHub.New.ShowDialog();
            return true;
        }

        public bool SetDesk(ITranslationData data)
        {
            FrmHub.Desk = new FrmDesk(data, FrmHub);
            return true;
        }

        public bool ProcessShortcuts(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.O):
                    OpenFile();
                    return true;
                default:
                    return false;
            }
        }
    }
}

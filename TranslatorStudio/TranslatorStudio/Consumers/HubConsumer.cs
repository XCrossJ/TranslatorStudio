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
        public FrmHub Hub { get; set; }
        public HubConsumer()
        {

        }
        public HubConsumer(FrmHub frmHub)
        {
            Hub = frmHub;
        }

        public void Quit()
        {
            Application.Exit();
        }

        public bool OpenFile()
        {
            var openFileDialog = ApplicationData.OpenProjectDialog();
            Hub.Desk = CreateDeskFromOpenFile(openFileDialog);
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

                return new FrmDesk(data, previousSavePath, Hub);
            }
            else
                throw new Exception("Open File Operation Cancelled.");
        }

        public bool OpenDesk()
        {
            Hub.Desk.Show();
            Hub.Hide();
            return true;
        }

        public bool OpenNewFile()
        {
            Hub.New = new frmNew(Hub);
            Hub.New.ShowDialog();
            return true;
        }

        public bool SetDesk(ITranslationData data)
        {
            Hub.Desk = new FrmDesk(data, Hub);
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

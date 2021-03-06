﻿using System;
using System.IO;
using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudio.Interfaces;
using TranslatorStudio.Utilities;
using TranslatorStudioClassLibrary.Exception;
using TranslatorStudioClassLibrary.Factory;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;

namespace TranslatorStudio.Consumers
{
    public class HubConsumer : IHubConsumer
    {
        #region Properties

        private readonly IFileRepository fileRepository;

        public FrmHub Hub { get; set; }

        #endregion

        #region Constructors

        public HubConsumer(FrmHub frmHub)
        {
            Hub = frmHub ?? throw new ArgumentNullException(nameof(frmHub));
            IProjectDataFactory projectFactory = new ProjectDataFactory();
            ISubTranslationDataFactory subFactory = new SubTranslationDataFactory();
            ITranslationDataFactory translationFactory = new TranslationDataFactory(projectFactory, subFactory);
            fileRepository = new FileRepository(translationFactory);
        }

        #endregion

        #region Methods

        public void Quit()
        {
            Application.Exit();
        }

        public bool OpenFile()
        {
            try
            {
                var openFileDialog = ApplicationData.OpenProjectDialog();
                var desk = CreateDeskFromOpenFile(openFileDialog);
                if (desk != null)
                {
                    Hub.Desk = desk;
                    return OpenDesk();
                }
                else
                    return false;
            }
            catch (EmptyRawException)
            {
                ApplicationData.MsgBox_EmptyRawException(Hub);
                return false;
            }
        }

        public FrmDesk CreateDeskFromOpenFile(OpenFileDialog dialog)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var fileExt = Path.GetExtension(dialog.FileName);
                var filePath = dialog.FileName;
                var fileName = Path.GetFileNameWithoutExtension(dialog.SafeFileName);

                var openData = fileRepository.OpenFile(fileExt, filePath, fileName);
                ITranslationData data = openData.Item1;
                string previousSavePath = openData.Item2;

                return new FrmDesk(data, previousSavePath, Hub);
            }
            else
                return null;
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

        #endregion
    }
}

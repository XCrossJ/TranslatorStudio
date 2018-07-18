using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using TranslatorStudioClassLibrary.Contracts.Roles;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibrary.Repositories.FileStore
{
    /// <summary>
    /// Class the writes project to file on disk.
    /// </summary>
    public class FileWriter : IProjectWriter
    {
        #region Fields
        /// <summary>
        /// File Information used to write to disk.
        /// </summary>
        private readonly FileInfo fileInfo;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates File Writer.
        /// </summary>
        /// <param name="fileInfo">File Information used to write to disk.</param>
        public FileWriter(FileInfo fileInfo)
        {
            this.fileInfo = fileInfo ?? throw new ArgumentNullException(nameof(fileInfo));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Writes Project Data to file store.
        /// </summary>
        /// <param name="projectData">Project Data to write to file store.</param>
        public void Write(IProjectDataType projectData)
        {
            switch (fileInfo.Extension)
            {
                case ".tsproj":
                    SaveProject(projectData);
                    break;
                case ".txt":
                    ExportTranslation(projectData);
                    break;
                default:
                    throw new Exception("File Type Not Handled.");
            }
        }

        /// <summary>
        /// Saves Project Data to file store.
        /// </summary>
        /// <param name="saveData">Project Data to write to file store.</param>
        private void SaveProject(IProjectSaveable saveData)
        {
            var json = JObject.Parse(saveData.GetSaveString());
            File.WriteAllText(fileInfo.FullName, json.ToString());
        }

        /// <summary>
        /// Exports Translation in Project Data to file store.
        /// </summary>
        /// <param name="projectData">Project Data to export to file store.</param>
        private void ExportTranslation(IProjectDataType projectData)
        {
            var contents = projectData.ProjectLines.Select(x => x.Translation);
            File.WriteAllLines(fileInfo.FullName, contents);
        }
        #endregion
    }
}
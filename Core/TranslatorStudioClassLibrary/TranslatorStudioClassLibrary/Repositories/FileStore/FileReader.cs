using System;
using System.IO;
using TranslatorStudioClassLibrary.Contracts.Roles;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Factories;

namespace TranslatorStudioClassLibrary.Repositories.FileStore
{
    /// <summary>
    /// Class the reads project from file on disk.
    /// </summary>
    public class FileReader : IProjectReader
    {
        #region Field
        /// <summary>
        /// File Information used to read from disk.
        /// </summary>
        private readonly FileInfo fileInfo;
        /// <summary>
        /// Project Factory used to build project.
        /// </summary>
        private readonly IProjectFactory projectFactory;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates File Reader.
        /// </summary>
        /// <param name="fileInfo">File Information used to read from disk.</param>
        /// <param name="projectFactory">Project Builder used to build project.</param>
        public FileReader(FileInfo fileInfo, IProjectFactory projectFactory)
        {
            this.fileInfo = fileInfo ?? throw new ArgumentNullException(nameof(fileInfo));

            this.projectFactory = projectFactory ?? throw new ArgumentNullException(nameof(projectFactory));
        }
        /// <summary>
        /// Creates File Reader.
        /// </summary>
        /// <param name="fileInfo">File Information used to read from disk.</param>
        public FileReader(FileInfo fileInfo)
            : this(fileInfo: fileInfo, projectFactory: new ProjectFactory())
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Reads Project Data from file store.
        /// </summary>
        /// <returns>Project Data read from file store.</returns>
        public IProjectDataType Read()
        {
            if (!fileInfo.Exists)
                throw new Exception();

            switch (fileInfo.Extension)
            {
                case ".tsproj":
                    return ImportProject();
                case ".doc":
                case ".docx":
                    return ImportDocument();
                case ".txt":
                    return ImportText();
                default:
                    throw new Exception("File Type Not Handled.");
            }
        }

        /// <summary>
        /// Imports translation project file to load Project Data.
        /// </summary>
        /// <returns>Project Data read from file store.</returns>
        private IProjectDataType ImportProject()
        {
            var output = File.ReadAllText(fileInfo.FullName);
            var projectData = projectFactory.BuildProject(output);
            return projectData;
        }
        /// <summary>
        /// Imports text file to create new Project Data.
        /// </summary>
        /// <returns>Project Data imported from text file.</returns>
        private IProjectDataType ImportText()
        {
            var output = File.ReadAllLines(fileInfo.FullName);
            var projectData = projectFactory.BuildNewProject(output, fileInfo.Name, fileInfo.FullName);
            return projectData;
        }
        /// <summary>
        /// Imports word document to create new Project Data.
        /// </summary>
        /// <returns>Project Data imported from word document.</returns>
        private IProjectDataType ImportDocument()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
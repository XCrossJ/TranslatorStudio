using System;
using System.IO;
using TranslatorStudioClassLibrary.Contracts.Roles;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Repositories.FileStore;

namespace TranslatorStudioClassLibrary.Repositories
{
    /// <summary>
    /// Class that Reads and Writes Project.
    /// </summary>
    public class ProjectRepository : IProjectReader, IProjectWriter
    {
        #region Fields
        /// <summary>
        /// Reader that reads project from store.
        /// </summary>
        private readonly IProjectReader projectReader;
        /// <summary>
        /// Writer that writes project to store.
        /// </summary>
        private readonly IProjectWriter projectWriter;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates Project Repository.
        /// </summary>
        /// <param name="projectReader">Reader that reads project from file.</param>
        /// <param name="projectWriter"></param>
        public ProjectRepository(IProjectReader projectReader, IProjectWriter projectWriter)
        {
            this.projectReader = projectReader ?? throw new ArgumentNullException(nameof(projectReader));
            this.projectWriter = projectWriter ?? throw new ArgumentNullException(nameof(projectWriter));
        }
        /// <summary>
        /// Creates Project Repository that engages project from File.
        /// </summary>
        /// <param name="fileInfo"></param>
        public ProjectRepository(FileInfo fileInfo)
        {
            if (fileInfo == null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            this.projectReader = new FileReader(fileInfo);
            this.projectWriter = new FileWriter(fileInfo);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Reads Project Data from store.
        /// </summary>
        /// <returns>Project Data read from store.</returns>
        public IProjectDataType Read()
        {
            return projectReader.Read();
        }

        /// <summary>
        /// Writes Project Data to store.
        /// </summary>
        /// <param name="projectData">Project Data to write to store.</param>
        public void Write(IProjectDataType projectData)
        {
            projectWriter.Write(projectData);
        }
        #endregion
    }
}
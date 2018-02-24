using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibrary.Repository
{
    /// <summary>
    /// Class that contains the properties and method relevant for Project Data Repository.
    /// Implements Project Data Repository Interface.
    /// </summary>
    public class ProjectDataRepository : IProjectDataRepository
    {
        #region Public Methods
        /// <summary>
        /// Creates project data from array.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="rawLines">Array of strings that holds the raw lines.</param>
        /// <exception cref="Exception.EmptyRawException">Thrown when provided raw lines are empty.</exception>
        /// <returns>Object that implements Project Data Interface.</returns>
        public IProjectData CreateProjectDataFromArray(string fileName, string[] rawLines)
        {
            var newRawLines = rawLines.ToList();

            return ConstructProjectData(fileName, newRawLines);
        }

        /// <summary>
        /// Creates project data from stream reader.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="sr">The stream reader used to read the file.</param>
        /// <exception cref="Exception.EmptyRawException">Thrown when provided raw lines are empty.</exception>
        /// <returns>Object that implements Project Data Interface.</returns>
        public IProjectData CreateProjectDataFromStream(string fileName, StreamReader sr)
        {
            var newRawLines = new List<string>();
            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    newRawLines.Add(line);
                }
            }

            return ConstructProjectData(fileName, newRawLines);
        }

        /// <summary>
        /// Creates project data from word document.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="document">The document that will be used in the conversion.</param>
        /// <exception cref="Exception.EmptyRawException">Thrown when provided raw lines are empty.</exception>
        /// <returns>Object that implements Project Data Interface.</returns>
        public IProjectData CreateProjectDataFromDocument(string fileName, Document document)
        {
            var newRawLines = new List<string>();

            for (int i = 0; i < document.Paragraphs.Count; i++) // May need to get rid of this.
            {
                if (!(i == 0 && document.Paragraphs[i + 1].Range.Text == "\r"))
                    newRawLines.Add(document.Paragraphs[i + 1].Range.Text);
            }

            return ConstructProjectData(fileName, newRawLines);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Private method that constructs project data. Used by other creation methods.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="newRawLines">The raw lines used to construct the project.</param>
        /// <exception cref="Exception.EmptyRawException">Thrown when provided raw lines are empty.</exception>
        /// <returns>Object that implements Project Data Interface.</returns>
        private IProjectData ConstructProjectData(string fileName, List<string> newRawLines)
        {
            if (!newRawLines.Any())
                throw ExceptionHelper.NewEmptyRawException();

            var numberOfItems = newRawLines.Count;
            var newTranslatedLines = new string[numberOfItems].ToList();
            var newCompletedLines = new bool[numberOfItems].ToList();
            var newMarkedLines = new bool[numberOfItems].ToList();

            IProjectData project = new ProjectData
            {
                ProjectName = fileName,
                RawLines = newRawLines,
                TranslatedLines = newTranslatedLines,
                CompletedLines = newCompletedLines,
                MarkedLines = newMarkedLines
            };

            return project;
        }
        #endregion

    }
}

using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Repository
{
    /// <summary>
    /// Class that contains the properties and method relevant for Project Data Repository.
    /// Implements Project Data Repository Interface.
    /// </summary>
    public class ProjectDataRepository : IProjectDataRepository
    {
        /// <summary>
        /// Create Project Data From Array:
        ///     creates project data from array.
        /// </summary>
        /// <param name="fileName">string: the name of the file.</param>
        /// <param name="rawLines">string[]: array of strings that holds the raw lines.</param>
        /// <returns>IProjectData: object that implements Project Data Interface.</returns>
        public IProjectData CreateProjectDataFromArray(string fileName, string[] rawLines)
        {
            try
            {
                var newRawLines = rawLines.ToList();
                
                return ConstructProjectData(fileName, newRawLines);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Create Project Data From Stream:
        ///     creates project data from stream reader.
        /// </summary>
        /// <param name="fileName">string: the name of the file.</param>
        /// <param name="sr">StreamReader: the stream reader used to read the file.</param>
        /// <returns>IProjectData: object that implements Project Data Interface.</returns>
        public IProjectData CreateProjectDataFromStream(string fileName, StreamReader sr)
        {
            try
            {
                var newRawLines = new List<string>();
                using (sr)
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (line.Any())
                            newRawLines.Add(line);
                    }
                }

                return ConstructProjectData(fileName, newRawLines);
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Create Project Data From Document:
        ///     creates project data from document.
        /// </summary>
        /// <param name="fileName">string: the name of the file.</param>
        /// <param name="document">Document: the document that will be used in the conversion.</param>
        /// <returns>IProjectData: object that implements Project Data Interface.</returns>
        public IProjectData CreateProjectDataFromDocument(string fileName, Document document)
        {
            try
            {
                var newRawLines = new List<string>();

                for (int i = 0; i < document.Paragraphs.Count; i++) // May need to get rid of this.
                {
                    if (!(i == 0 && document.Paragraphs[i + 1].Range.Text == "\r"))
                        newRawLines.Add(document.Paragraphs[i + 1].Range.Text);
                }

                return ConstructProjectData(fileName, newRawLines);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Construct Project Data:
        ///     private method that constructs project data. Used by other creation methods.
        /// </summary>
        /// <param name="fileName">string: the name of the file.</param>
        /// <param name="newRawLines">List<string>: the raw lines used to construct the project.</param>
        /// <returns>IProjectData: object that implements Project Data Interface.</returns>
        private IProjectData ConstructProjectData(string fileName, List<string> newRawLines)
        {
            try
            {
                if (!newRawLines.Any())
                    throw new System.Exception("No Raw Lines were submitted into the project.");

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
            catch (System.Exception e)
            {
                throw e;
            }
        }

    }
}

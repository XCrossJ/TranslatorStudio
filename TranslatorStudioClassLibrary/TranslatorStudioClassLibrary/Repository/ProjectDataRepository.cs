using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.IO;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Repository
{
    public class ProjectDataRepository : IProjectDataRepository
    {
        public IProjectData CreateProjectDataFromArray(string fileName, string[] rawLines)
        {
            var newRawLines = new List<string>();
            foreach (var item in rawLines)
            {
                newRawLines.Add(item);
            }

            return ConstructProjectData(fileName, newRawLines);
        }

        public IProjectData CreateProjectDataFromStream(string fileName, StreamReader sr)
        {
            var newRawLines = new List<string>();
            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    newRawLines.Add(sr.ReadLine());
                }
            }

            return ConstructProjectData(fileName, newRawLines);
        }

        public IProjectData CreateProjectDataFromDocument(string fileName, Document document)
        {
            var newRawLines = new List<string>();

            for (int i = 0; i < document.Paragraphs.Count; i++)
            {
                newRawLines.Add(document.Paragraphs[i + 1].Range.Text);
            }

            return ConstructProjectData(fileName, newRawLines);
        }


        private IProjectData ConstructProjectData(string fileName, List<string> newRawLines)
        {
            var newTranslatedLines = new string[newRawLines.Count];
            var newCompletedLines = new bool[newRawLines.Count];
            var newMarkedLines = new bool[newRawLines.Count];

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

    }
}

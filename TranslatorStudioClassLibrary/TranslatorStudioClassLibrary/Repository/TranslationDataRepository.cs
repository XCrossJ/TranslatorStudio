using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Repository
{
    public class TranslationDataRepository: ITranslationDataRepository
    {
        public TranslationData CreateTranslationDataFromDocument(string fileName, Document document)
        {
            var project = new ProjectDataRepository().CreateProjectDataFromDocument(fileName, document);

            return new TranslationData(project);
        }

        public TranslationData CreateTranslationDataFromProject(IProjectData project)
        {
            return new TranslationData(project);
        }

        public TranslationData CreateTranslationDataFromStream(string fileName, StreamReader sr)
        {
            var project = new ProjectDataRepository().CreateProjectDataFromStream(fileName, sr);

            return new TranslationData(project);
        }
        
    }
}

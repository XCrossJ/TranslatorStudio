namespace TranslatorStudioClassLibrary.Interface
{
    using System;

    /// <summary>
    /// Interface that defines the public properties and methods required to interact with Files.
    /// </summary>
    public interface IFileRepository
    {
        /// <summary>
        /// Opens translation data from text file.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        ITranslationData OpenTextFile(string path, string fileName);
        /// <summary>
        /// Opens translation data from word document.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        ITranslationData OpenDocFile(string path, string fileName);
        /// <summary>
        /// Opens translation data from translation studio project file.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        ITranslationData OpenTSPFile(string path, string fileName);
        /// <summary>
        /// Handler that returns Translation Data and Previous Save Path from parameters.
        /// </summary>
        /// <param name="fileExt">Extension of the file.</param>
        /// <param name="path">Path of the file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>An object that implements Translation Data Interface and the previous save path.</returns>
        Tuple<ITranslationData, string> OpenFile(string fileExt, string path, string fileName);
        /// <summary>
        /// Saves translation project data to file.
        /// </summary>
        /// <param name="data">Translation data to save.</param>
        /// <param name="path">Path of the file.</param>
        /// <returns>The result of the save.</returns>
        bool SaveProject(ITranslationData data, string path);
        /// <summary>
        /// Exports translated lines in translation project to file.
        /// </summary>
        /// <param name="data">Translation data to save.</param>
        /// <param name="path">Path of the file.</param>
        /// <returns>The result of the export.</returns>
        bool ExportTranslation(ITranslationData data, string path);
    }
}

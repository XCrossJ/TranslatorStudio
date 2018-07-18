namespace TranslatorStudioClassLibrary.Contracts.Types
{
    /// <summary>
    /// Describes a Line in the Translation Project.
    /// </summary>
    public interface IProjectLineType
    {
        /// <summary>
        /// The Raw to be translated.
        /// </summary>
        string Raw { get; set; }
        /// <summary>
        /// The Translation of the provided raw.
        /// </summary>
        string Translation { get; set; }
        /// <summary>
        /// A Comment about the current line.
        /// </summary>
        string Comment { get; set; }
        /// <summary>
        /// The flag describing whether the line has been marked as Completed.
        /// </summary>
        bool Completed { get; set; }
        /// <summary>
        /// The flag describing whether the line has been Marked for attention.
        /// </summary>
        bool Marked { get; set; }
    }
}

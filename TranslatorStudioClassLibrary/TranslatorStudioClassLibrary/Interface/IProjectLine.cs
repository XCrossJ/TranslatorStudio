namespace TranslatorStudioClassLibrary.Interface
{
    /// <summary>
    /// Interface that defines the public properties and methods required to store Project Line.
    /// </summary>
    public interface IProjectLine
    {
        #region Properties
        /// <summary>
        /// The Raw String of the Project Line.
        /// </summary>
        string Raw { get; set; }
        /// <summary>
        /// The Translation String of the Project Line.
        /// </summary>
        string Translation { get; set; }
        /// <summary>
        /// The Comment String of the Project Line.
        /// </summary>
        string Comment { get; set; }
        /// <summary>
        /// The Completion Status of the Project Line.
        /// </summary>
        bool Completed { get; set; }
        /// <summary>
        /// The Marked Status of the Project Line.
        /// </summary>
        bool Marked { get; set; }
        #endregion
    }
}

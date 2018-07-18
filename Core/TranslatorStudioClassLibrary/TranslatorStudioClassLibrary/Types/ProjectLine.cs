using System;
using TranslatorStudioClassLibrary.Contracts.Types;

namespace TranslatorStudioClassLibrary.Types
{
    /// <summary>
    /// Describes a Line in the Translation Project.
    /// </summary>
    public class ProjectLine : IProjectLineType, IEquatable<ProjectLine>
    {
        #region Constructors
        /// <summary>
        /// Creates Project Line.
        /// </summary>
        public ProjectLine() : this(raw: "", translation: "", comment: "", isCompleted: false, isMarked: false)
        {

        }
        /// <summary>
        /// Creates Project Line.
        /// </summary>
        /// <param name="raw">Raw Line</param>
        public ProjectLine(string raw) : this(raw: raw, translation: "", comment: "", isCompleted: false, isMarked: false)
        {

        }
        /// <summary>
        /// Creates Project Line.
        /// </summary>
        /// <param name="raw">Raw Line</param>
        /// <param name="translation">Translation Line</param>
        /// <param name="comment">Comment Line</param>
        /// <param name="isCompleted">Line Is Completed Status</param>
        /// <param name="isMarked">Line is Marked Status</param>
        public ProjectLine(string raw, string translation, string comment, bool isCompleted, bool isMarked)
        {
            Raw = raw ?? throw new ArgumentNullException(nameof(raw));
            Translation = translation ?? throw new ArgumentNullException(nameof(translation));
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
            Completed = isCompleted;
            Marked = isMarked;
        }
        #endregion

        #region Properties
        /// <summary>
        /// The Raw to be translated.
        /// </summary>
        public string Raw { get; set; }
        /// <summary>
        /// The Translation of the provided raw.
        /// </summary>
        public string Translation { get; set; }
        /// <summary>
        /// A Comment about the current line.
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// The flag describing whether the line has been marked as Completed.
        /// </summary>
        public bool Completed { get; set; }
        /// <summary>
        /// The flag describing whether the line has been Marked for attention.
        /// </summary>
        public bool Marked { get; set; }
        #endregion

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(ProjectLine other)
        {
            return other != null &&
                   Raw == other.Raw &&
                   Translation == other.Translation &&
                   Comment == other.Comment &&
                   Completed == other.Completed &&
                   Marked == other.Marked;
        }
    }
}

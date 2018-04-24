namespace TranslatorStudioClassLibrary.Class
{
    using System;
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Class that contains the properties and method relevant for Project Line.
    /// Implements Project Line Interface.
    /// </summary>
    public class ProjectLine : IProjectLine, IEquatable<ProjectLine>
    {
        #region Properties
        /// <summary>
        /// The Raw String of the Project Line.
        /// </summary>
        public string Raw { get; set; } = "";
        /// <summary>
        /// The Translation String of the Project Line.
        /// </summary>
        public string Translation { get; set; } = "";
        /// <summary>
        /// The Comment String of the Project Line.
        /// </summary>
        public string Comment { get; set; } = "";
        /// <summary>
        /// The Completion Status of the Project Line.
        /// </summary>
        public bool Completed { get; set; } = false;
        /// <summary>
        /// The Marked Status of the Project Line.
        /// </summary>
        public bool Marked { get; set; } = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates empty Project Line.
        /// </summary>
        public ProjectLine()
        {
        }
        #endregion

        public bool Equals(ProjectLine other)
        {
            return other != null &&
                   Raw == other.Raw &&
                   Translation == other.Translation &&
                   Completed == other.Completed &&
                   Marked == other.Marked;
        }

        public override int GetHashCode()
        {
            var hashCode = 1676529432;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Raw);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Translation);
            hashCode = hashCode * -1521134295 + Completed.GetHashCode();
            hashCode = hashCode * -1521134295 + Marked.GetHashCode();
            return hashCode;
        }
    }
}

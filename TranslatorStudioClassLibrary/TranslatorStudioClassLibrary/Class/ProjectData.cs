using System.Collections.Generic;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibrary.Class
{
    /// <summary>
    /// Class that contains the properties and method relevant for Project Data.
    /// Implements Project Data Interface.
    /// </summary>
    public class ProjectData : IProjectData
    {
        #region Properties
        /// <summary>
        /// Project Name:
        ///     property that contains the name of the project.
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// Raw Lines:
        ///     property that contains all of the raw lines in the project.
        /// </summary>
        public List<string> RawLines { get; set; }
        /// <summary>
        /// Translated Lines:
        ///     property that contains all of the translated lines in the project.
        /// </summary>
        public List<string> TranslatedLines { get; set; }
        /// <summary>
        /// Completed Lines:
        ///     property that contains the completion status of each line in the project.
        /// </summary>
        public List<bool> CompletedLines { get; set; }
        /// <summary>
        /// Marked Lines:
        ///     property that contains the marked status of each line in the project.
        /// </summary>
        public List<bool> MarkedLines { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Project Data Default Constructor:
        ///     Creates empty Project Data.
        /// </summary>
        public ProjectData()
        {

        }
        #endregion

        #region Methods
        public string GetSaveString()
        {
            return this.ToJSONString();
        }
        #endregion

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as ProjectData;
            if (toCompareWith == null)
            {
                return false;
            }
            else
            {
                if (ProjectName != toCompareWith.ProjectName) 
                    return false;
                //return
                //    ProjectName == toCompareWith.ProjectName &&
                //    RawLines == toCompareWith.RawLines &&
                //    TranslatedLines == toCompareWith.TranslatedLines &&
                //    CompletedLines == toCompareWith.CompletedLines &&
                //    MarkedLines == toCompareWith.MarkedLines;
                return true;
            }
        }
        
    }
}

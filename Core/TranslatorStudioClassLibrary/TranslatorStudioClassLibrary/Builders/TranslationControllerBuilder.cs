using TranslatorStudioClassLibrary.Controllers;

namespace TranslatorStudioClassLibrary.Builders
{
    /// <summary>
    /// Class dedicated to building the Translation Controller.
    /// </summary>
    public class TranslationControllerBuilder
    {
        #region Constructors
        /// <summary>
        /// Creates Translation Controller Builder without params.
        /// </summary>
        public TranslationControllerBuilder()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Builds the Project Controller.
        /// </summary>
        /// <returns>Project Controller.</returns>
        public TranslationController Build()
        {
            var translationcontroller = new TranslationController();

            return translationcontroller;
        }
        #endregion
    }
}

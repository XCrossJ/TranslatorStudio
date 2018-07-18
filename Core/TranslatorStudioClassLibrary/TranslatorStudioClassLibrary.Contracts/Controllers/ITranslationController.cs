using TranslatorStudioClassLibrary.Contracts.Enums;

namespace TranslatorStudioClassLibrary.Contracts.Controllers
{
    /// <summary>
    /// Describes the properties and methods used to control the Translation Project.
    /// </summary>
    public interface ITranslationController
    {
        /// <summary>
        /// Determines the Translation Mode.
        /// </summary>
        TranslationModeEnum TranslationMode { get; }
        /// <summary>
        /// Determines whether Auto Translation Mode is turned on or not.
        /// </summary>
        bool AutoTranslationMode { get; }

        ///// <summary>
        ///// Determines whether changes have been made to Translation Data.
        ///// </summary>
        //bool DataChanged { get; set; }


        /// <summary>
        /// Toggles auto translation mode. (Removes empty lines.)
        /// </summary>
        /// <param name="autoOn">Whether or not auto mode should be turned on or not.</param>
        void ToggleAutoMode(bool autoOn);

        /// <summary>
        /// Changes translation mode.
        /// </summary>
        /// <param name="newTranslationMode">The Translation Mode to change to.</param>
        void ChangeTranslationMode(TranslationModeEnum newTranslationMode);
    }
}

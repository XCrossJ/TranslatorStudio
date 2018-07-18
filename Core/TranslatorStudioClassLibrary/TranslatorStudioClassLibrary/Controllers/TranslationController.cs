using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TranslatorStudioClassLibrary.Contracts.Controllers;
using TranslatorStudioClassLibrary.Contracts.Enums;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibrary.Controllers
{
    public class TranslationController : ITranslationController
    {
        #region Constructor
        public TranslationController()
        {
            TranslationMode = TranslationModeEnum.Default;
            AutoTranslationMode = false;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Determines the Translation Mode.
        /// </summary>
        public TranslationModeEnum TranslationMode { get; private set; }
        /// <summary>
        /// Determines whether Auto Translation Mode is turned on or not.
        /// </summary>
        public bool AutoTranslationMode { get; private set; }
        #endregion

        #region Methods
        #region Commands
        /// <summary>
        /// Changes translation mode.
        /// </summary>
        /// <param name="newTranslationMode">The Translation Mode to change to.</param>
        public void ChangeTranslationMode(TranslationModeEnum newTranslationMode)
        {
            TranslationMode = newTranslationMode;
        }

        /// <summary>
        /// Toggles auto translation mode. (Removes empty lines.)
        /// </summary>
        /// <param name="autoOn">Whether or not auto mode should be turned on or not.</param>
        public void ToggleAutoMode(bool autoOn)
        {
            AutoTranslationMode = autoOn;
        }
        #endregion
        #endregion
    }
}

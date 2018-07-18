namespace TranslatorStudioClassLibrary.Contracts.Enums
{
    /// <summary>
    /// Indicates the Translation Mode used to control what lines are viewed by the project
    /// </summary>
    public enum TranslationModeEnum
    {
        /// <summary>
        /// Default Translation Mode (everything is seen)
        /// </summary>
        Default = 0,
        /// <summary>
        /// Marked Only Translation Mode (only lines marked for attention are seen)
        /// </summary>
        Marked,
        /// <summary>
        /// Incomplete Only Translation Mode (only incomplete lines are seen)
        /// </summary>
        Incomplete,
        /// <summary>
        /// Complete Only Translation Mode (only complete lines are seen)
        /// </summary>
        Complete
    }
}

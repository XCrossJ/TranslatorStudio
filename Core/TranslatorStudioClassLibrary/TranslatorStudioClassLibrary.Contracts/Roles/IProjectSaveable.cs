namespace TranslatorStudioClassLibrary.Contracts.Roles
{
    /// <summary>
    /// Describes whether object is saveable.
    /// </summary>
    public interface IProjectSaveable
    {
        /// <summary>
        /// Gets JSON save string of the object used for saving.
        /// </summary>
        /// <returns>JSON string of object.</returns>
        string GetSaveString();
    }
}
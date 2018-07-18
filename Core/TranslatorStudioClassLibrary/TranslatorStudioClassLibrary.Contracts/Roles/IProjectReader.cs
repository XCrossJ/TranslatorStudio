using TranslatorStudioClassLibrary.Contracts.Types;

namespace TranslatorStudioClassLibrary.Contracts.Roles
{
    /// <summary>
    /// Module that retrieves Project Data from store.
    /// </summary>
    public interface IProjectReader
    {
        /// <summary>
        /// Reads Project Data from store.
        /// </summary>
        /// <returns>Project Data read from store.</returns>
        IProjectDataType Read();
    }
}
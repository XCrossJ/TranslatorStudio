using TranslatorStudioClassLibrary.Contracts.Types;

namespace TranslatorStudioClassLibrary.Contracts.Roles
{
    /// <summary>
    /// Module that records Project Data to store.
    /// </summary>
    public interface IProjectWriter
    {
        /// <summary>
        /// Writes Project Data to store.
        /// </summary>
        /// <param name="projectData">Project Data to write to store.</param>
        void Write(IProjectDataType projectData);
    }
}
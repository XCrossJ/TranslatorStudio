using Moq;
using System;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;
using Xunit;

namespace TranslatorStudioClassLibraryTest.Repository
{
    [Collection("File Repository Test")]
    /// <summary>
    /// Contains tests to run against File Repository class.
    /// </summary>
    public class FileRepositoryTest
    {
        /// <summary>
        /// Contains tests to run against File Repository constructors.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "File Repository")]
        public class Constructors
        {
            /// <summary>
            /// Mock of Translation Data Factory.
            /// </summary>
            private readonly Mock<ITranslationDataFactory> mockTranslationDataFactory;

            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Constructors()
            {
                mockTranslationDataFactory = new Mock<ITranslationDataFactory>();
            }

            #region Constructor Tests

            /// <summary>
            /// Given that File Repository is invoked, Default Constructor returns valid File Repository.
            /// </summary>
            [Fact]
            public void FileRepository_DefaultConstructor_Test()
            {
                //Arrange
                var expected = new FileRepository(mockTranslationDataFactory.Object);

                //Act
                var actual = new FileRepository(mockTranslationDataFactory.Object);

                //Assert
                Assert.IsType<FileRepository>(actual);
                Assert.IsAssignableFrom<IFileRepository>(actual);
                Assert.NotStrictEqual(expected, actual);
            }

            #endregion
        }


    }
}

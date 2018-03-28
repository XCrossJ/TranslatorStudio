using Microsoft.Office.Interop.Word;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;
using TranslatorStudioClassLibrary.Utilities;
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

            /// <summary>
            /// Given that Translation Data Factoryt is null, Default Constructor throws Argument Null Exception.
            /// </summary>
            [Fact]
            [Trait("Category", "Exception")]
            [Trait("Exception", "ArgumentNullException")]
            public void FileRepository_DefaultConstructor_NullTranslationDataFactory_Test()
            {
                //Arrange
                ITranslationDataFactory nullTranslationDataFactory = null;
                
                //Act, Assert
                Assert.Throws<ArgumentNullException>("translationDataFactory", () => new FileRepository(nullTranslationDataFactory));
            }

            #endregion
        }

        /// <summary>
        /// Contains tests to run against File Repository methods that read from file.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "File Repository")]
        public class ReadMethods
        {
            /// <summary>
            /// Mock of Project Data;
            /// </summary>
            private readonly Mock<IProjectData> mockProjectData;
            /// <summary>
            /// Mock of Translation Data.
            /// </summary>
            private readonly Mock<ITranslationData> mockTranslationData;

            /// <summary>
            /// Mock of Translation Data Factory.
            /// </summary>
            private readonly Mock<ITranslationDataFactory> mockTranslationDataFactory;
            /// <summary>
            /// File Repository under test.
            /// </summary>
            private readonly IFileRepository fileRepository;

            /// <summary>
            /// Full path of files created for cleanup.
            /// </summary>
            private string fullPath;

            public ReadMethods()
            {
                mockProjectData = new Mock<IProjectData>();
                mockProjectData.SetupAllProperties();

                mockTranslationData = new Mock<ITranslationData>();
                mockTranslationData.SetupAllProperties();
                mockTranslationData.Setup(
                    x => x.GetProjectSaveString())
                    .Returns(mockProjectData.Object.ToJSONString());

                mockTranslationDataFactory = new Mock<ITranslationDataFactory>();
                mockTranslationDataFactory.SetupAllProperties();
                fileRepository = new FileRepository(mockTranslationDataFactory.Object);
            }

            public void Dispose()
            {
                File.Delete(fullPath);
            }

            /// <summary>
            /// Given that path is valid, Open Text File returns Translation Data.
            /// </summary>
            [Fact]
            public void FileRepository_OpenTextFile_Test()
            {
                //Arrange
                var fileText = new List<string>
                {
                    "Line 1",
                    "Line 2",
                    "Line 3"
                };

                var filePath = Path.GetTempPath();
                var fileName = "FileRepository_OpenTextFile_Test.txt";

                fullPath = Path.Combine(filePath, fileName);
                File.WriteAllLines(fullPath, fileText);

                var expected = mockTranslationData.Object;

                #region Mock Translation Data Factory
                mockTranslationDataFactory.Setup(
                    x => x.CreateTranslationDataFromStream(It.IsAny<string>(), It.IsAny<StreamReader>()))
                    .Returns(expected);
                #endregion

                //Act
                var actual = fileRepository.OpenTextFile(fullPath, fileName);

                //Assert
                Assert.NotNull(actual);
                Assert.IsAssignableFrom<ITranslationData>(actual);
                Assert.Equal(expected, actual);

                Dispose();
            }

            /// <summary>
            /// Given that path is valid, Open TSP File returns Translation Data.
            /// </summary>
            [Fact]
            public void FileRepository_OpenTSPFile_Test()
            {
                //Arrange
                var saveData = mockTranslationData.Object;
                var filePath = Path.GetTempPath();
                var fileName = "FileRepository_OpenTSPFile_Test.tsp";

                fullPath = Path.Combine(filePath, fileName);

                var json = JObject.Parse(saveData.GetProjectSaveString());
                File.WriteAllText(fullPath, json.ToString());

                var expected = mockTranslationData.Object;

                #region Mock Translation Data Factory
                mockTranslationDataFactory.Setup(
                    x => x.CreateTranslationDataFromProject(It.IsAny<IProjectData>()))
                    .Returns(expected);
                #endregion

                //Act
                var actual = fileRepository.OpenTSPFile(fullPath, fileName);

                //Assert
                Assert.NotNull(actual);
                Assert.IsAssignableFrom<ITranslationData>(actual);
                Assert.Equal(expected, actual);

                Dispose();
            }

            /// <summary>
            /// Given that path is valid, Open Doc File returns Translation Data.
            /// </summary>
            [Fact]
            public void FileRepository_OpenDocFile_Test()
            {
                //Arrange
                var fileText = new List<string>
                {
                    "Line 1",
                    "Line 2",
                    "Line 3"
                };

                var filePath = Path.GetTempPath();
                var fileName = "FileRepository_OpenDocFile_Test.doc";

                fullPath = Path.Combine(filePath, fileName);
                File.WriteAllLines(fullPath, fileText);

                var expected = mockTranslationData.Object;

                #region Mock Translation Data Factory
                mockTranslationDataFactory.Setup(
                    x => x.CreateTranslationDataFromDocument(It.IsAny<string>(), It.IsAny<Document>()))
                    .Returns(expected);
                #endregion

                //Act
                var actual = fileRepository.OpenDocFile(fullPath, fileName);

                //Assert
                Assert.NotNull(actual);
                Assert.IsAssignableFrom<ITranslationData>(actual);
                Assert.Equal(expected, actual);

                Dispose();
            }

            [Theory]
            [InlineData("FileRepository_OpenFile_Text_Test", ".txt")]
            [InlineData("FileRepository_OpenFile_TSP_Test", ".tsp")]
            [InlineData("FileRepository_OpenFile_Doc_Test", ".doc")]
            public void FileRepository_OpenFile_Test(string fileName, string fileExtension)
            {
                //Arrange
                var saveData = mockTranslationData.Object;

                var filePath = Path.GetTempPath();
                var fullFileName = Path.ChangeExtension(fileName, fileExtension);

                fullPath = Path.Combine(filePath, fullFileName);

                var json = JObject.Parse(saveData.GetProjectSaveString());
                File.WriteAllText(fullPath, json.ToString());

                var expected = mockTranslationData.Object;

                #region Mock Translation Data Factory
                mockTranslationDataFactory.Setup(
                    x => x.CreateTranslationDataFromStream(It.IsAny<string>(), It.IsAny<StreamReader>()))
                    .Returns(expected);

                mockTranslationDataFactory.Setup(
                    x => x.CreateTranslationDataFromProject(It.IsAny<IProjectData>()))
                    .Returns(expected);

                mockTranslationDataFactory.Setup(
                    x => x.CreateTranslationDataFromDocument(It.IsAny<string>(), It.IsAny<Document>()))
                    .Returns(expected);
                #endregion

                //Act
                var result = fileRepository.OpenFile(fileExtension, fullPath, fileName);
                var actual = result.Item1;
                var prevSavePath = result.Item2;

                //Assert
                Assert.NotNull(actual);
                Assert.IsAssignableFrom<ITranslationData>(actual);
                Assert.Equal(expected, actual);

                Dispose();
            }
        }

        /// <summary>
        /// Contains tests to run against File Repository methods that write to file.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "File Repository")]
        public class WriteMethods
        {
            /// <summary>
            /// Mock of Project Data;
            /// </summary>
            private readonly Mock<IProjectData> mockProjectData;
            /// <summary>
            /// Mock of Translation Data.
            /// </summary>
            private readonly Mock<ITranslationData> mockTranslationData;

            /// <summary>
            /// Mock of Translation Data Factory.
            /// </summary>
            private readonly Mock<ITranslationDataFactory> mockTranslationDataFactory;
            /// <summary>
            /// File Repository under test.
            /// </summary>
            private readonly IFileRepository fileRepository;

            /// <summary>
            /// Full path of files created for cleanup.
            /// </summary>
            private string fullPath;

            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public WriteMethods()
            {
                mockProjectData = new Mock<IProjectData>();
                mockProjectData.SetupAllProperties();

                mockTranslationData = new Mock<ITranslationData>();
                mockTranslationData.SetupAllProperties();
                mockTranslationData.Object.ProjectName = "TestProjectName";
                mockTranslationData.Setup(
                    x => x.GetProjectSaveString())
                    .Returns(mockProjectData.Object.ToJSONString());

                mockTranslationData.Setup(
                    x => x.TranslatedLines)
                    .Returns(new List<string> { "Line 1", "Line 2", "Line 3" });


                mockTranslationDataFactory = new Mock<ITranslationDataFactory>();
                mockTranslationDataFactory.SetupAllProperties();
                fileRepository = new FileRepository(mockTranslationDataFactory.Object);
            }

            public void Dispose()
            {
                File.Delete(fullPath);
            }

            /// <summary>
            /// Given that Translation Data and Path is valid, Save Project creates a file.
            /// </summary>
            [Fact]
            public void FileRepository_SaveProject_Test()
            {
                //Arrange
                var saveData = mockTranslationData.Object;
                var filePath = Path.GetTempPath();
                var fileName = "FileRepository_SaveProject_Test.txt";

                fullPath = Path.Combine(filePath, fileName);
                var expected = saveData.GetProjectSaveString().Replace(" ", string.Empty);

                //Act
                var result = fileRepository.SaveProject(saveData, fullPath);
                var actual = File.ReadAllText(fullPath).Replace("\r\n", string.Empty).Replace(" ", string.Empty);

                //Assert
                Assert.IsType<bool>(result);
                Assert.True(result);

                Assert.NotNull(actual);
                Assert.Equal(expected, actual);

                Dispose();
            }

            /// <summary>
            /// Given that Translation Data and Path is valid, Export Project creates a file.
            /// </summary>
            [Fact]
            public void FileRepository_ExportProject_Test()
            {
                //Arrange
                var saveData = mockTranslationData.Object;
                var filePath = Path.GetTempPath();
                var fileName = "FileRepository_ExportProject_Test.txt";

                fullPath = Path.Combine(filePath, fileName);
                var expected = "";
                for (int i = 0; i < saveData.TranslatedLines.Count; i++)
                {
                    expected += saveData.TranslatedLines[i];
                    expected += (i < saveData.TranslatedLines.Count) ? Environment.NewLine : string.Empty;
                }

                //Act
                var result = fileRepository.ExportTranslation(saveData, fullPath);
                var actual = File.ReadAllText(fullPath);

                //Assert
                Assert.IsType<bool>(result);
                Assert.True(result);

                Assert.NotNull(actual);
                Assert.Equal(expected, actual);

                Dispose();
            }
        }
    }
}

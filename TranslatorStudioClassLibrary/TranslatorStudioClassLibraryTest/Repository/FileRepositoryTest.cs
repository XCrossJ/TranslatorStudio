using Microsoft.Office.Interop.Word;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using TranslatorStudioClassLibrary.Class;
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
            /// Mock of Project Data.
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
            /// Member Data for OpenTSPFile Test. Contains objects that use legacy project data schemas.
            /// </summary>
            /// <returns></returns>
            public static IEnumerable<object[]> GetOpenTSPFileTestData()
            {
                // Legacy Project Data
                yield return new object[]
                {
                    new
                    {
                        ProjectName = "Legacy Test",
                        RawLines = new List<string>(),
                        TranslatedLines = new List<string>(),
                        CompletedLines = new List<bool>(),
                        MarkedLines = new List<bool>(),
                    }
                };

                // Legacy Project Data Version 1
                yield return new object[]
                {
                    new
                    {
                        ProjectName = "Legacy Version 1 Test",
                        ProjectLines = new List<ProjectLine>()
                    }
                };
            }

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

            #region Read Methods Tests

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
                mockTranslationDataFactory.Verify(x => x.CreateTranslationDataFromStream(It.IsAny<string>(), It.IsAny<StreamReader>()), Times.Once);

                Assert.NotNull(actual);
                Assert.IsAssignableFrom<ITranslationData>(actual);
                Assert.Equal(expected, actual);

                Dispose();
            }

            /// <summary>
            /// Given that path is valid, Open TSP File returns Translation Data.
            /// </summary>
            /// <param name="legacyProjectData">Object with Legacy Project Data schema.</param>
            [Theory]
            [MemberData(nameof(GetOpenTSPFileTestData))]
            public void FileRepository_OpenTSPFile_Test(object legacyProjectData)
            {
                //Arrange
                var saveData = mockTranslationData.Object;
                var filePath = Path.GetTempPath();
                var fileName = "FileRepository_OpenTSPFile_Test.tsp";

                fullPath = Path.Combine(filePath, fileName);

                mockTranslationData.Setup(
                    x => x.GetProjectSaveString())
                    .Returns(legacyProjectData.ToJSONString());

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
                mockTranslationDataFactory.Verify(x => x.CreateTranslationDataFromProject(It.IsAny<IProjectData>()), Times.Once);

                Assert.NotNull(actual);
                Assert.IsAssignableFrom<ITranslationData>(actual);
                Assert.Equal(expected, actual);

                Dispose();
            }

            /// <summary>
            /// Given that path is valid, Open TSProj File returns Translation Data.
            /// </summary>
            [Fact]
            public void FileRepository_OpenTSProjFile_Test()
            {
                //Arrange
                var saveData = mockTranslationData.Object;
                var filePath = Path.GetTempPath();
                var fileName = "FileRepository_OpenTSPFile_Test.tsproj";

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
                var actual = fileRepository.OpenTSProjFile(fullPath, fileName);

                //Assert
                mockTranslationDataFactory.Verify(x => x.CreateTranslationDataFromProject(It.IsAny<IProjectData>()), Times.Once);

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
                mockTranslationDataFactory.Verify(x => x.CreateTranslationDataFromDocument(It.IsAny<string>(), It.IsAny<Document>()), Times.Once);

                Assert.NotNull(actual);
                Assert.IsAssignableFrom<ITranslationData>(actual);
                Assert.Equal(expected, actual);

                Dispose();
            }

            [Theory]
            [InlineData("FileRepository_OpenFile_Text_Test", ".txt")]
            [InlineData("FileRepository_OpenFile_TSP_Test", ".tsp")]
            [InlineData("FileRepository_OpenFile_TSProj_Test", ".tsproj")]
            [InlineData("FileRepository_OpenFile_Doc_Test", ".doc")]
            public void FileRepository_OpenFile_Test(string fileName, string fileExtension)
            {
                //Arrange
                var saveData = mockTranslationData.Object;

                var filePath = Path.GetTempPath();
                var fullFileName = Path.ChangeExtension(fileName, fileExtension);

                fullPath = Path.Combine(filePath, fullFileName);

                if (fileExtension == ".tsp")
                {
                    var legacyProjectData = new
                    {
                        ProjectName = "Legacy Test",
                        RawLines = new List<string>(),
                        TranslatedLines = new List<string>(),
                        CompletedLines = new List<bool>(),
                        MarkedLines = new List<bool>(),
                    };
                    mockTranslationData.Setup(
                        x => x.GetProjectSaveString())
                        .Returns(legacyProjectData.ToJSONString());
                }

                var json = JObject.Parse(saveData.GetProjectSaveString());
                File.WriteAllText(fullPath, json.ToString());

                var expected = mockTranslationData.Object;
                var expectedPrevSavePath = (fileExtension == ".tsp" || fileExtension == ".tsproj") ? fullPath : "";

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
                var actualPrevSavePath = result.Item2;

                //Assert
                mockTranslationDataFactory.Verify(x => x.CreateTranslationDataFromStream(It.IsAny<string>(), It.IsAny<StreamReader>()), Times.AtMostOnce);
                mockTranslationDataFactory.Verify(x => x.CreateTranslationDataFromProject(It.IsAny<IProjectData>()), Times.AtMostOnce);
                mockTranslationDataFactory.Verify(x => x.CreateTranslationDataFromDocument(It.IsAny<string>(), It.IsAny<Document>()), Times.AtMostOnce);

                Assert.NotNull(actual);
                Assert.IsAssignableFrom<ITranslationData>(actual);
                Assert.Equal(expected, actual);
                Assert.Equal(expectedPrevSavePath, actualPrevSavePath);

                Dispose();
            }

            #endregion
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
            /// Mock of Project lines.
            /// </summary>
            private readonly List<IProjectLine> mockProjectLines;

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

                mockProjectLines = new List<IProjectLine>
                {
                    new ProjectLine { Raw = "Raw Line 1",   Translation = "Translated Line 1",      Completed = false,  Marked = true },
                    new ProjectLine { Raw = "Raw Line 2",   Translation = "Translated Line 2",      Completed = false,  Marked = false },
                    new ProjectLine { Raw = "Raw Line 3",   Translation = "Translated Line 3",      Completed = true,   Marked = true },
                    new ProjectLine { Raw = "Raw Line 4",   Translation = "Translated Line 4",      Completed = false,  Marked = false },
                    new ProjectLine { Raw = "Raw Line 5",   Translation = "Translated Line 5",      Completed = true,   Marked = false },
                    new ProjectLine { Raw = "Raw Line 6",   Translation = "Translated Line 6",      Completed = true,   Marked = true },
                    new ProjectLine { Raw = "Raw Line 7",   Translation = "Translated Line 7",      Completed = true,   Marked = false },
                    new ProjectLine { Raw = "Raw Line 8",   Translation = "Translated Line 8",      Completed = false,  Marked = true },
                    new ProjectLine { Raw = "Raw Line 9",   Translation = "Translated Line 9",      Completed = true,   Marked = true },
                    new ProjectLine { Raw = "Raw Line 10",  Translation = "Translated Line 10",     Completed = false,  Marked = false }
                };

                mockTranslationData.Setup(
                    x => x.ProjectLines)
                    .Returns(mockProjectLines);


                mockTranslationDataFactory = new Mock<ITranslationDataFactory>();
                mockTranslationDataFactory.SetupAllProperties();
                fileRepository = new FileRepository(mockTranslationDataFactory.Object);
            }

            public void Dispose()
            {
                File.Delete(fullPath);
            }

            #region Write Methods Tests

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
                for (int i = 0; i < saveData.ProjectLines.Count; i++)
                {
                    expected += saveData.ProjectLines[i].Translation;
                    expected += (i < saveData.ProjectLines.Count) ? Environment.NewLine : string.Empty;
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

            #endregion
        }
    }
}

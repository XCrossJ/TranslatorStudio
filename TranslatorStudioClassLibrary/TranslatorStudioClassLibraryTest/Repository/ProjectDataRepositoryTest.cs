using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Word;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;

namespace TranslatorStudioClassLibraryTest.Repository
{
    [TestClass]
    [TestCategory("Project Data Repository Test")]
    public class ProjectDataRepositoryTest
    {
        private readonly string mockProjectName;
        private readonly List<string> mockRawLines;
        private readonly List<string> mockTranslatedLines;
        private readonly List<bool> mockMarkedLines;
        private readonly List<bool> mockCompleteLines;

        private readonly IProjectDataRepository projectDataRepository;

        public ProjectDataRepositoryTest()
        {
            mockProjectName = "Mock Test Project Name";

            mockRawLines = new List<string>
            {
                "Raw Line 1",
                "Raw Line 2",
                "Raw Line 3",
                "Raw Line 4",
                "Raw Line 5",
                "Raw Line 6",
                "Raw Line 7",
                "Raw Line 8",
                "Raw Line 9",
                "Raw Line 10"
            };

            mockTranslatedLines = new List<string>
            {
                "Translated Line 1",
                "Translated Line 2",
                "Translated Line 3",
                "Translated Line 4",
                "Translated Line 5",
                "Translated Line 6",
                "Translated Line 7",
                "Translated Line 8",
                "Translated Line 9",
                "Translated Line 10"
            };

            mockMarkedLines = new List<bool>
            {
                true,
                false,
                true,
                false,
                false,
                true,
                false,
                true,
                true,
                false
            };

            mockCompleteLines = new List<bool>
            {
                false,
                false,
                true,
                false,
                true,
                true,
                true,
                false,
                true,
                false
            };

            projectDataRepository = new ProjectDataRepository();
        }

        [TestMethod]
        public void CreateProjectDataFromArray_Test()
        {
            //Arrange
            var expected = new ProjectData()
            {
                ProjectName = mockProjectName,
                RawLines = mockRawLines
            };

            //Act
            var actual = projectDataRepository.CreateProjectDataFromArray(mockProjectName, mockRawLines.ToArray());

            //Assert
            Assert.AreEqual(expected, actual); // Is not a true equals. Need to develop more.
            CollectionAssert.AreEqual(expected.RawLines, actual.RawLines);
        }

        [TestMethod]
        public void CreateProjectDataFromStream_Test()
        {
            // Arrange
            var expectedName = mockProjectName;
            var expectedRaw = mockRawLines;
            var writeStream = new MemoryStream();

            using (StreamWriter writer = new StreamWriter(writeStream))
            {
                foreach (var line in expectedRaw)
                {
                    writer.WriteLine(line);
                }
                writer.Flush();
            }

            var readStream = new MemoryStream(writeStream.ToArray());
            var reader = new StreamReader(readStream);

            // Act
            var projectData = projectDataRepository.CreateProjectDataFromStream(expectedName, reader);
            var actualName = projectData.ProjectName;
            var actualRaw = projectData.RawLines;

            // Assert
            Assert.AreEqual(expectedName, actualName);
            CollectionAssert.AreEqual(expectedRaw, actualRaw);
        }

        [TestMethod]
        [TestCategory("Not Implemented Correctly")]
        public void CreateProjectDataFromDocument_Test()
        {
            // Arrange
            var expectedName = mockProjectName;
            var expectedRaw = mockRawLines;
            var document = new Mock<Document>();

            var paragraphs = new Mock<Paragraphs>();

            paragraphs.Setup(
                    x => x.Count)
                .Returns(expectedRaw.Count);

            for (int i = 0; i < expectedRaw.Count; i++)
            {
                paragraphs.Setup(x => x[It.Is<int>(n => n == i)].Range.Text).Returns(expectedRaw[i]);
            }

            document.Setup(
                    x => x.Paragraphs)
                .Returns(paragraphs.Object);


            // Act
            var projectData = projectDataRepository.CreateProjectDataFromDocument(expectedName, document.Object);
            var actualName = projectData.ProjectName;
            var actualRaw = projectData.RawLines;

            // Assert
            Assert.AreEqual(expectedName, actualName);
            //CollectionAssert.AreEqual(expected, actual);
            Assert.AreEqual(expectedRaw.Count, actualRaw.Count); // Not a true assert. Need to redo this test.

        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("Exception Test")]
        public void GivenEmptyArrayRaiseException()
        {
            // Arrange
            var emptyArray= new string[0];

            // Act
            var actual = projectDataRepository.CreateProjectDataFromArray(mockProjectName, emptyArray);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("Exception Test")]
        public void GivenEmptyStreamRaiseException()
        {
            // Arrange
            var emptyStream = new StreamReader(new MemoryStream());

            // Act
            var actual = projectDataRepository.CreateProjectDataFromStream(mockProjectName, emptyStream);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("Not Implemented Correctly")]
        [TestCategory("Exception Test")]
        public void GivenEmptyDocumentRaiseException()
        {
            // Arrange
            var emptyDocument = new Document();

            // Act
            var actual = projectDataRepository.CreateProjectDataFromDocument(mockProjectName, emptyDocument);

            // Assert

        }
    }
}

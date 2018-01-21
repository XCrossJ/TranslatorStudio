using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibraryTest.Class
{
    [TestClass]
    [TestCategory("Translation Data Test")]
    public class TranslationDataTest
    {
        private readonly Mock<IProjectData> mockProjectData;
        private readonly string mockProjectName;
        private readonly List<string> mockRawLines;
        private readonly List<string> mockTranslatedLines;
        private readonly List<bool> mockMarkedLines;
        private readonly List<bool> mockCompleteLines;
        
        public TranslationDataTest()
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

            mockProjectData = new Mock<IProjectData>();

            mockProjectData.Setup(
                    x => x.ProjectName)
                .Returns(mockProjectName);

            mockProjectData.Setup(
                    x => x.RawLines)
                .Returns(mockRawLines);

            mockProjectData.Setup(
                    x => x.TranslatedLines)
                .Returns(mockTranslatedLines);

            mockProjectData.Setup(
                    x => x.MarkedLines)
                .Returns(mockMarkedLines);

            mockProjectData.Setup(
                    x => x.CompletedLines)
                .Returns(mockCompleteLines);
        }

        #region Properties Tests

        #region Project Data Tests

        [TestMethod]
        public void DefaultTranslationMode_Test()
        {
            //Arrange
            var translationData = new TranslationData(mockProjectData.Object);

            var expected = true;
            //Act
            var actual = translationData.DefaultTranslationMode;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProjectName_Test()
        {
            //Arrange
            var expected = mockProjectName;
            
            var translationData = new TranslationData(mockProjectData.Object);

            //Act
            var actual = translationData.ProjectName;

            //Assert
            mockProjectData.Verify(
                    x => x.ProjectName,
                Times.Once);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RawLines_Test()
        {
            //Arrange
            var expected = mockRawLines;

            var translationData = new TranslationData(mockProjectData.Object);

            //Act
            var actual = translationData.RawLines;

            //Assert
            mockProjectData.Verify(
                    x => x.RawLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TranslatedLines_Test()
        {
            //Arrange
            var expected = mockTranslatedLines;

            var translationData = new TranslationData(mockProjectData.Object);

            //Act
            var actual = translationData.TranslatedLines;

            //Assert
            mockProjectData.Verify(
                    x => x.TranslatedLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompletedLines_Test()
        {
            //Arrange
            var expected = mockCompleteLines;

            var translationData = new TranslationData(mockProjectData.Object);

            //Act
            var actual = translationData.CompletedLines;

            //Assert
            mockProjectData.Verify(
                    x => x.CompletedLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MarkedLines_Test()
        {
            //Arrange
            var expected = mockMarkedLines;

            var translationData = new TranslationData(mockProjectData.Object);

            //Act
            var actual = translationData.MarkedLines;

            //Assert
            mockProjectData.Verify(
                    x => x.MarkedLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region Project Controls Tests

        [TestMethod]
        public void CurrentRaw_Test()
        {
            //Arrange
            var currentIndex = 1;

            var translationData = new TranslationData(mockProjectData.Object)
            {
                CurrentIndex = currentIndex
            };

            var expected = mockRawLines[currentIndex];

            //Act
            var actual = translationData.CurrentRaw;

            //Assert
            mockProjectData.Verify(
                    x => x.RawLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CurrentTranslation_Test()
        {
            //Arrange
            var currentIndex = 1;

            var translationData = new TranslationData(mockProjectData.Object)
            {
                CurrentIndex = currentIndex
            };

            var expected = mockTranslatedLines[currentIndex];

            //Act
            var actual = translationData.CurrentTranslation;

            //Assert
            mockProjectData.Verify(
                    x => x.TranslatedLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CurrentCompletion_Test()
        {
            //Arrange
            var currentIndex = 1;

            var translationData = new TranslationData(mockProjectData.Object)
            {
                CurrentIndex = currentIndex
            };

            var expected = mockCompleteLines[currentIndex];

            //Act
            var actual = translationData.CurrentCompletion;

            //Assert
            mockProjectData.Verify(
                x => x.CompletedLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CurrentMarked_Test()
        {
            //Arrange
            var currentIndex = 1;

            var translationData = new TranslationData(mockProjectData.Object)
            {
                CurrentIndex = currentIndex
            };

            var expected = mockMarkedLines[currentIndex];

            //Act
            var actual = translationData.CurrentMarked;

            //Assert
            mockProjectData.Verify(
                x => x.MarkedLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MaxIndex_Test()
        {
            //Arrange
            var translationData = new TranslationData(mockProjectData.Object);

            var expected = mockRawLines.Count - 1;

            //Act
            var actual = translationData.MaxIndex;

            //Assert
            mockProjectData.Verify(
                    x => x.RawLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberOfLines_Test()
        {
            //Arrange
            var translationData = new TranslationData(mockProjectData.Object);

            var expected = mockRawLines.Count - 1;
            //Act
            var actual = translationData.MaxIndex;
            //Assert
            mockProjectData.Verify(
                x => x.RawLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberOfCompletedLines_Test()
        {
            //Arrange
            var translationData = new TranslationData(mockProjectData.Object);

            var expected = mockCompleteLines.Where(c => c).Count();

            //Act
            var actual = translationData.NumberOfCompletedLines;

            //Assert
            mockProjectData.Verify(
                    x => x.CompletedLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #endregion

        #region Constructor
        [TestMethod]
        public void TranslationData_ProjectDataConstructorTest()
        {
            // Arrange
            var expected = new TranslationData(mockProjectData.Object);

            // Act
            var actual = new TranslationData(mockProjectData.Object);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Methods Tests

        [TestMethod]
        public void IncrementCurrentLine_Test()
        {
            //Arrange
            var translationData = new TranslationData(mockProjectData.Object)
            {
                CurrentIndex = 5
            };

            var expectedIndex = 6;

            //Act
            translationData.IncrementCurrentLine();

            //Assert
            Assert.AreEqual(expectedIndex, translationData.CurrentIndex);
        }

        [TestMethod]
        public void DecrementCurrentLine_Test()
        {
            //Arrange
            var translationData = new TranslationData(mockProjectData.Object)
            {
                CurrentIndex = 5
            };

            var expectedIndex = 4;

            //Act
            translationData.DecrementCurrentLine();

            //Assert
            Assert.AreEqual(expectedIndex, translationData.CurrentIndex);
        }


        [TestMethod]
        public void IncrementCurrentLine_At_Max_Index_Test()
        {
            //Arrange
            var expectedIndex = mockRawLines.Count() - 1;

            var translationData = new TranslationData(mockProjectData.Object)
            {
                CurrentIndex = expectedIndex
            };
            
            //Act
            translationData.IncrementCurrentLine();

            //Assert
            Assert.AreEqual(expectedIndex, translationData.CurrentIndex);
        }

        [TestMethod]
        public void DecrementCurrentLine_At_Min_Index_Test()
        {
            //Arrange
            var expectedIndex = 0;

            var translationData = new TranslationData(mockProjectData.Object)
            {
                CurrentIndex = expectedIndex
            };

            //Act
            translationData.DecrementCurrentLine();

            //Assert
            Assert.AreEqual(expectedIndex, translationData.CurrentIndex);
        }

        [TestMethod]
        public void GetSaveString_Test()
        {
            //Arrange
            var translationData = new TranslationData(mockProjectData.Object);

            var expectedSaveString = mockProjectData.Object.ToJSONString();

            //Act
            var actualSaveString = translationData.GetSaveString();

            //Assert
            Assert.AreEqual(expectedSaveString, actualSaveString);
        }

        [TestMethod]
        public void StartDefaultMode()
        {
            //Arrange
            var translationData = new TranslationData(mockProjectData.Object)
            {
                DefaultTranslationMode = false
            };

            var expected = true;
            var expectedIndex = 0;

            //Act
            translationData.StartDefaultMode();
            var actual = translationData.DefaultTranslationMode;

            //Assert
            Assert.AreEqual(expected, actual);

            Assert.AreEqual(mockRawLines[expectedIndex], translationData.CurrentRaw);
            Assert.AreEqual(mockTranslatedLines[expectedIndex], translationData.CurrentTranslation);
            Assert.AreEqual(mockMarkedLines[expectedIndex], translationData.CurrentMarked);
            Assert.AreEqual(mockCompleteLines[expectedIndex], translationData.CurrentCompletion);

        }

        [TestMethod]
        public void StartMarkedOnlyMode_Test()
        {
            //Arrange
            var translationData = new TranslationData(mockProjectData.Object);

            var expected = mockMarkedLines.Where(m => m).Count() - 1;
            var expectedIndex = mockMarkedLines.IndexOf(true);
            
            //Act
            translationData.StartMarkedOnlyMode();
            var actual = translationData.MaxIndex;

            //Assert
            mockProjectData.Verify(
                    x => x.MarkedLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
            Assert.IsFalse(translationData.DefaultTranslationMode);

            Assert.AreEqual(mockRawLines[expectedIndex], translationData.CurrentRaw);
            Assert.AreEqual(mockTranslatedLines[expectedIndex], translationData.CurrentTranslation);
            Assert.AreEqual(mockMarkedLines[expectedIndex], translationData.CurrentMarked);
            Assert.AreEqual(mockCompleteLines[expectedIndex], translationData.CurrentCompletion);
        }

        [TestMethod]
        public void StartIncompleteOnlyMode_Test()
        {
            //Arrange
            var translationData = new TranslationData(mockProjectData.Object);

            var expected = mockCompleteLines.Where(i => !i).Count() - 1;
            var expectedIndex = mockCompleteLines.IndexOf(false);

            //Act
            translationData.StartIncompleteOnlyMode();
            var actual = translationData.MaxIndex;

            //Assert
            mockProjectData.Verify(
                    x => x.CompletedLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
            Assert.IsFalse(translationData.DefaultTranslationMode);

            Assert.AreEqual(mockRawLines[expectedIndex], translationData.CurrentRaw);
            Assert.AreEqual(mockTranslatedLines[expectedIndex], translationData.CurrentTranslation);
            Assert.AreEqual(mockMarkedLines[expectedIndex], translationData.CurrentMarked);
            Assert.AreEqual(mockCompleteLines[expectedIndex], translationData.CurrentCompletion);
        }

        [TestMethod]
        public void StartCompleteOnlyMode_Test()
        {
            //Arrange
            var translationData = new TranslationData(mockProjectData.Object);

            var expected = mockCompleteLines.Where(c => c).Count() - 1;
            var expectedIndex = mockCompleteLines.IndexOf(true);

            //Act
            translationData.StartCompleteOnlyMode();
            var actual = translationData.MaxIndex;

            //Assert
            mockProjectData.Verify(
                    x => x.CompletedLines,
                Times.Once);

            Assert.AreEqual(expected, actual);
            Assert.IsFalse(translationData.DefaultTranslationMode);

            Assert.AreEqual(mockRawLines[expectedIndex], translationData.CurrentRaw);
            Assert.AreEqual(mockTranslatedLines[expectedIndex], translationData.CurrentTranslation);
            Assert.AreEqual(mockMarkedLines[expectedIndex], translationData.CurrentMarked);
            Assert.AreEqual(mockCompleteLines[expectedIndex], translationData.CurrentCompletion);
        }

        [TestMethod]
        public void GetProjectData_Test()
        {
            //Arrange
            var translationData = new TranslationData(mockProjectData.Object);

            var expectedProjectData = mockProjectData.Object;

            //Act
            var actualProjectData = translationData.GetProjectData();

            //Assert
            Assert.AreEqual(expectedProjectData, actualProjectData);
        }

        #endregion

    }
}
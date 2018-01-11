using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibraryTest.Class
{
    [TestClass]
    public class TranslationDataTest
    {
        [TestMethod]
        public void IncrementCurrentLine()
        {
            //Arrange
            Mock<IProjectData> mockProjectData = new Mock<IProjectData>();
            mockProjectData.Setup(
                x => x.RawLines)
                .Returns(new List<string>() { "", "", "" });

            var translationData = new TranslationData(mockProjectData.Object);
            translationData.CurrentIndex = 1;

            var expectedIndex = 2;

            //Act
            translationData.IncrementCurrentLine();

            //Assert
            Assert.AreEqual(expectedIndex, translationData.CurrentIndex);
        }

        [TestMethod]
        public void DecrementCurrentLine()
        {
            //Arrange
            Mock<IProjectData> mockProjectData = new Mock<IProjectData>();
            mockProjectData.Setup(
                x => x.RawLines)
                .Returns(new List<string>() { "", "", "" });

            var translationData = new TranslationData(mockProjectData.Object);
            translationData.CurrentIndex = 2;

            var expectedIndex = 1;

            //Act
            translationData.DecrementCurrentLine();

            //Assert
            Assert.AreEqual(expectedIndex, translationData.CurrentIndex);
        }


        [TestMethod]
        public void IncrementCurrentLine_At_Max_Index()
        {
            //Arrange
            Mock<IProjectData> mockProjectData = new Mock<IProjectData>();
            mockProjectData.Setup(
                x => x.RawLines)
                .Returns(new List<string>() { "", "", "" });

            var translationData = new TranslationData(mockProjectData.Object);
            translationData.CurrentIndex = 2;

            var expectedIndex = 2;

            //Act
            translationData.IncrementCurrentLine();

            //Assert
            Assert.AreEqual(expectedIndex, translationData.CurrentIndex);
        }

        [TestMethod]
        public void DecrementCurrentLine_At_Min_Index()
        {
            //Arrange
            Mock<IProjectData> mockProjectData = new Mock<IProjectData>();
            mockProjectData.Setup(
                x => x.RawLines)
                .Returns(new List<string>() { "", "", "" });

            var translationData = new TranslationData(mockProjectData.Object);
            translationData.CurrentIndex = 0;

            var expectedIndex = 0;

            //Act
            translationData.DecrementCurrentLine();

            //Assert
            Assert.AreEqual(expectedIndex, translationData.CurrentIndex);
        }

        [TestMethod]
        public void GetSaveString()
        {
            //Arrange
            Mock<IProjectData> mockProjectData = new Mock<IProjectData>();

            var translationData = new TranslationData(mockProjectData.Object);

            var expectedSaveString = mockProjectData.Object.ToJSONString();
            //Act
            var actualSaveString = translationData.GetSaveString();

            //Assert
            Assert.AreEqual(expectedSaveString, actualSaveString);
        }

        //[TestMethod]
        //public void StartMarkedOnlyMode()
        //{
        //    //Arrange
        //    Mock<IProjectData> mockProjectData = new Mock<IProjectData>();


        //    var translationData = new TranslationData(mockProjectData.Object);

        //    var expectedSaveString = mockProjectData.Object.ToJSONString();
        //    //Act
        //    var actualSaveString = translationData.GetSaveString();

        //    //Assert
        //    Assert.AreEqual(expectedSaveString, actualSaveString);
        //}

        [TestMethod]
        public void GetProjectData()
        {
            //Arrange
            Mock<IProjectData> mockProjectData = new Mock<IProjectData>();

            var translationData = new TranslationData(mockProjectData.Object);

            var expectedProjectData = mockProjectData.Object;
            //Act
            var actualProjectData = translationData.GetProjectData();

            //Assert
            Assert.AreEqual(expectedProjectData, actualProjectData);
        }
    }
}

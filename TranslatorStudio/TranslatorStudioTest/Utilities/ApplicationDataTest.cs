using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatorStudio.Utilities;

namespace TranslatorStudioTest.Utilities
{
    [TestClass]
    [TestCategory("Application Data Test")]
    public class ApplicationDataTest
    {
        #region Applications Tests
        [TestMethod]
        public void GoogleTranslate_Test()
        {
            //Arrange
            var expectedType = typeof(string);

            //Act
            var actual = ApplicationData.GoogleTranslate;

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
            Assert.IsNotNull(actual);

        }

        [TestMethod]
        public void Weblio_Test()
        {
            //Arrange
            var expectedType = typeof(string);

            //Act
            var actual = ApplicationData.Weblio;

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
            Assert.IsNotNull(actual);

        }
        #endregion

        #region Shortcuts Tests
        [TestMethod]
        public void Shortcuts_Test()
        {
            //Arrange
            var expectedType = typeof(List<string[]>);

            //Act
            var actual = ApplicationData.Shortcuts;

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
            Assert.IsNotNull(actual);

        }
        #endregion

        #region Cell Styles Tests
        [TestMethod]
        public void CompletedCellStyle_Test()
        {
            //Arrange
            var expectedType = typeof(DataGridViewCellStyle);

            //Act
            var actual = ApplicationData.CompletedCellStyle;

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
            Assert.IsNotNull(actual);

        }

        [TestMethod]
        public void MarkedCellStyle_Test()
        {
            //Arrange
            var expectedType = typeof(DataGridViewCellStyle);

            //Act
            var actual = ApplicationData.MarkedCellStyle;

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
            Assert.IsNotNull(actual);

        }

        [TestMethod]
        public void DefaultCellStyle_Test()
        {
            //Arrange
            var expectedType = typeof(DataGridViewCellStyle);

            //Act
            var actual = ApplicationData.DefaultCellStyle;

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
            Assert.IsNotNull(actual);

        }
        #endregion

        #region Information
        [TestMethod]
        public void About_Test()
        {
            //Arrange
            var expectedType = typeof(string);

            //Act
            var actual = ApplicationData.About;

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
            Assert.IsNotNull(actual);

        }
        #endregion

        #region File Dialogs
        [TestMethod]
        public void OpenProjectDialog_Test()
        {
            //Arrange
            var expectedType = typeof(OpenFileDialog);

            //Act
            var actual = ApplicationData.OpenProjectDialog();

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
            Assert.IsNotNull(actual);

        }

        [TestMethod]
        public void SaveProjectDialog_Test()
        {
            //Arrange
            var expectedType = typeof(SaveFileDialog);
            var expectedFileName = "";

            //Act
            var actual = ApplicationData.SaveProjectDialog(expectedFileName);
            var actualFileName = actual.FileName;

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedFileName, actualFileName);

        }

        [TestMethod]
        public void ExportProjectDialog_Test()
        {
            //Arrange
            var expectedType = typeof(SaveFileDialog);
            var expectedFileName = "";

            //Act
            var actual = ApplicationData.ExportProjectDialog(expectedFileName);
            var actualFileName = actual.FileName;

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedFileName, actualFileName);

        }
        #endregion

    }
}

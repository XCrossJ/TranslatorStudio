using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TranslatorStudio.Utilities;
using Xunit;

namespace TranslatorStudioTest.Utilities
{
    [Collection("Application Data Test")]
    public class ApplicationDataTest
    {
        [Trait("Category", "Application Data Test")]
        [Trait("Category", "Applications Test")]
        public class ApplicationsTests
        {
            #region Applications Tests

            [Fact]
            public void GoogleTranslate_Test()
            {
                var expectedType = typeof(string);

                //Act
                var actual = ApplicationData.GoogleTranslate;

                //Assert
                Assert.IsType<string>(actual);
                Assert.NotNull(actual);
            }

            [Fact]
            public void Weblio_Test()
            {
                //Arrange

                //Act
                var actual = ApplicationData.Weblio;

                //Assert
                Assert.IsType<string>(actual);
                Assert.NotNull(actual);
            }

            #endregion
        }

        [Trait("Category", "Application Data Test")]
        [Trait("Category", "Shortcuts Test")]
        public class ShortcutsTests
        {

            #region Shortcuts Tests

            [Fact]
            public void Shortcuts_Test()
            {
                //Arrange
 
                //Act
                var actual = ApplicationData.Shortcuts;

                //Assert
                Assert.IsType<List<string[]>>(actual);
                Assert.NotNull(actual);
            }

            #endregion
        }

        [Trait("Category", "Application Data Test")]
        [Trait("Category", "Cell Styles Test")]
        public class CellStylesTests
        {

            #region Cell Styles Tests

            [Fact]
            public void CompletedCellStyle_Test()
            {
                //Arrange

                //Act
                var actual = ApplicationData.CompletedCellStyle;

                //Assert
                Assert.IsType<DataGridViewCellStyle>(actual);
                Assert.NotNull(actual);
            }

            [Fact]
            public void MarkedCellStyle_Test()
            {
                //Arrange

                //Act
                var actual = ApplicationData.MarkedCellStyle;

                //Assert
                Assert.IsType<DataGridViewCellStyle>(actual);
                Assert.NotNull(actual);
            }

            [Fact]
            public void DefaultCellStyle_Test()
            {
                //Arrange

                //Act
                var actual = ApplicationData.DefaultCellStyle;

                //Assert
                Assert.IsType<DataGridViewCellStyle>(actual);
                Assert.NotNull(actual);
            }

            #endregion

        }

        [Trait("Category", "Application Data Test")]
        [Trait("Category", "Information Test")]
        public class InformationTests
        {

            #region Information

            [Fact]
            public void About_Test()
            {
                //Arrange

                //Act
                var actual = ApplicationData.About;

                //Assert
                Assert.IsType<string>(actual);
                Assert.NotNull(actual);
            }

            #endregion

        }

        [Trait("Category", "Application Data Test")]
        [Trait("Category", "File Dialog Test")]
        public class FileDialogsTests
        {

            #region File Dialogs

            [Fact]
            public void OpenProjectDialog_Test()
            {
                //Arrange

                //Act
                var actual = ApplicationData.OpenProjectDialog();

                //Assert
                Assert.IsType<OpenFileDialog>(actual);
                Assert.NotNull(actual);
            }

            [Fact]
            public void SaveProjectDialog_Test()
            {
                //Arrange
                var expectedFileName = "";

                //Act
                var actual = ApplicationData.SaveProjectDialog(expectedFileName);
                var actualFileName = actual.FileName;

                //Assert
                Assert.IsType<SaveFileDialog>(actual);
                Assert.NotNull(actual);
                Assert.Equal(expectedFileName, actualFileName);
            }

            [Fact]
            public void ExportProjectDialog_Test()
            {
                //Arrange
                var expectedFileName = "";

                //Act
                var actual = ApplicationData.ExportProjectDialog(expectedFileName);
                var actualFileName = actual.FileName;

                //Assert
                Assert.IsType<SaveFileDialog>(actual);
                Assert.NotNull(actual);
                Assert.Equal(expectedFileName, actualFileName);
            }

            #endregion

        }
    }
}

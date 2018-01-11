using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Repository;
using TranslatorStudioClassLibrary.Utilities;


namespace TranslatorStudioClassLibraryTest.Utilities
{
    [TestClass]
    public class ExtensionHelperTest
    {
        [TestMethod]
        public void ToJsonStringTest()
        {
            //Arrange
            ProjectData project = new ProjectDataRepository().CreateProjectDataFromArray("test", new string[] { "test" });
            string expected = "{\"ProjectName\":\"test\",\"RawLines\":[\"test\"],\"TranslatedLines\":[null],\"CompletedLines\":[false],\"MarkedLines\":[false]}";
            string actual;

            //Act
            actual = project.ToJSONString();

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetNumberFormatTest()
        {
            //Arrange
            string actual;
            var expected = "0000";

            //Act
            actual = 1000.GetNumberFormat();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

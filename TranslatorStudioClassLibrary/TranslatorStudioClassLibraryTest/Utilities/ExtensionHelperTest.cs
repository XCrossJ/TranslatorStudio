using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;
using TranslatorStudioClassLibrary.Utilities;


namespace TranslatorStudioClassLibraryTest.Utilities
{
    [TestClass]
    [TestCategory("Extension Helper Test")]
    public class ExtensionHelperTest
    {
        [TestMethod]
        public void ToJSONStringTest()
        {
            //Arrange
            IProjectData project = new ProjectDataRepository().CreateProjectDataFromArray("test", new string[] { "test" });
            string expected = JsonConvert.SerializeObject(project);
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

using AutoFixture.Xunit2;
using Newtonsoft.Json;
using TranslatorStudioClassLibrary.Utilities;
using Xunit;

namespace TranslatorStudioClassLibrary.Tests.Utilities
{
    public class ExtensionHelperTests
    {
        [Trait("Extension Helper", "Method Test")]
        [Trait("Category", "Unit")]
        public class Method
        {
            [Theory(DisplayName = "Extension Helper: To JSON String")]
            [AutoData]
            public void ToJSONString(object sut)
            {
                // Arrange
                var expected = JsonConvert.SerializeObject(sut);

                // Act
                var actual = sut.ToJSONString();

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory(DisplayName = "Extension Helper: Is Not White Space")]
            [InlineAutoData(null, false)]
            [InlineAutoData("", false)]
            [InlineAutoData(" ", false)]
            [InlineAutoData("Test", true)]
            public void IsNotWhiteSpace(string sut, bool expectedResult)
            {
                // Arrange
                var expected = expectedResult;

                // Act
                var actual = sut.IsNotWhiteSpace();

                // Assert
                Assert.Equal(expected, actual);
            }
        }
    }
}

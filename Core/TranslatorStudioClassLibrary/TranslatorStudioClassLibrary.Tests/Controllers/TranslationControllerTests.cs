using AutoFixture;
using AutoFixture.Xunit2;
using TranslatorStudioClassLibrary.Contracts.Controllers;
using TranslatorStudioClassLibrary.Contracts.Enums;
using TranslatorStudioClassLibrary.Controllers;
using TranslatorStudioClassLibrary.Tests.TestSetup.Builders;
using Xunit;

namespace TranslatorStudioClassLibrary.Tests.Controllers
{
    public class TranslationControllerTests
    {
        [Trait("Translation Controller", "Constructor Test")]
        [Trait("Category", "Unit")]
        public class Constructor
        {
            [Fact(DisplayName = "Translation Controller: Default Constructor")]
            public void DefaultConstructor()
            {
                // Arrange
                
                // Act
                var actual = new TranslationController();

                // Assert
                Assert.IsType<TranslationController>(actual);
                Assert.IsAssignableFrom<ITranslationController>(actual);
            }
        }

        [Trait("Translation Controller", "Property Test")]
        [Trait("Category", "Unit")]
        public class Property
        {
            private readonly TranslationController sut;

            private readonly IFixture fixture;

            public Property()
            {
                fixture = new FixtureBuilder().Build();

                sut = fixture.Create<TranslationController>();
            }

            #region Translation Mode
            [Fact(DisplayName = "Translation Controller: Get Translation Mode")]
            public void GetTranslationMode()
            {
                // Arrange
                var expected = TranslationModeEnum.Default;

                // Act
                var actual = sut.TranslationMode;

                // Assert
                Assert.Equal(expected, actual);
            }
            #endregion

            #region Auto Translation Mode
            [Fact(DisplayName = "Translation Controller: Get Auto Translation Mode")]
            public void GetAutoTranslationMode()
            {
                // Arrange
                var expected = false;

                // Act
                var actual = sut.AutoTranslationMode;

                // Assert
                Assert.Equal(expected, actual);
            }
            #endregion
        }

        [Trait("Translation Controller", "Method Test")]
        [Trait("Category", "Unit")]
        public class Method
        {
            private readonly TranslationController sut;

            private readonly IFixture fixture;

            public Method()
            {
                fixture = new FixtureBuilder().Build();

                sut = fixture.Create<TranslationController>();
            }

            [Theory(DisplayName = "Translation Controller: Change Translation Mode")]
            [AutoData]
            public void ChangeTranslationMode(TranslationModeEnum newTranslationMode)
            {
                // Arrange
                var expected = newTranslationMode;

                // Act
                sut.ChangeTranslationMode(newTranslationMode);
                var actual = sut.TranslationMode;

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory(DisplayName = "Translation Controller: Toggle Auto Mode")]
            [AutoData]
            public void ToggleAutoMode(bool autoModeOn)
            {
                // Arrange
                var expected = autoModeOn;

                // Act
                sut.ToggleAutoMode(autoModeOn);
                var actual = sut.AutoTranslationMode;

                // Assert
                Assert.Equal(expected, actual);
            }
        }
    }
}

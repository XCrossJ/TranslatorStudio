using AutoFixture.Xunit2;
using System;
using TranslatorStudioClassLibrary.Types;
using Xunit;

namespace TranslatorStudioClassLibrary.Tests
{
    public class ProjectLineTests
    {
        [Trait("Project Line", "Constructor Test")]
        [Trait("Category", "Unit")]
        public class Constructor
        {
            [Fact(DisplayName = "Project Line: Default Constructor")]
            public void DefaultConstructor()
            {
                // Arrange
                var expected = new ProjectLine
                {
                    Raw = "",
                    Translation = "",
                    Comment = "",
                    Completed = false,
                    Marked = false
                };

                // Act
                var actual = new ProjectLine();

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory(DisplayName = "Project Line: Raw Constructor")]
            [AutoData]
            public void RawConstructor(string raw)
            {
                // Arrange
                var expected = new ProjectLine
                {
                    Raw = raw,
                    Translation = "",
                    Comment = "",
                    Completed = false,
                    Marked = false
                };

                // Act
                var actual = new ProjectLine(raw);

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory(DisplayName = "Project Line: Full Constructor")]
            [AutoData]
            public void FullConstructor(
                string raw,
                string translation,
                string comment,
                bool isCompleted,
                bool isMarked
                )
            {
                // Arrange
                var expected = new ProjectLine
                {
                    Raw = raw,
                    Translation = translation,
                    Comment = comment,
                    Completed = isCompleted,
                    Marked = isMarked
                };

                // Act
                var actual = new ProjectLine(raw, translation, comment, isCompleted, isMarked);

                // Assert
                Assert.Equal(expected, actual);
            }

            [Trait("Exception Test", "Argument Null Exception")]
            [Theory(DisplayName = "Project Line: Throws Exception with Illegal Parameters")]
            [AutoData]
            public void IllegalParams_Throws_Exception(
                string raw,
                string translation,
                string comment,
                bool isCompleted,
                bool isMarked
                )
            {
                // Arrange
                string invalidRaw = null;
                string invalidTranslation = null;
                string invalidComment = null;

                // Act, Assert
                Assert.Throws<ArgumentNullException>("raw", () => new ProjectLine(invalidRaw));
                Assert.Throws<ArgumentNullException>("raw", () => new ProjectLine(invalidRaw, translation, comment, isCompleted, isMarked));
                Assert.Throws<ArgumentNullException>("translation", () => new ProjectLine(raw, invalidTranslation, comment, isCompleted, isMarked));
                Assert.Throws<ArgumentNullException>("comment", () => new ProjectLine(raw, translation, invalidComment, isCompleted, isMarked));
            }
        }
    }
}

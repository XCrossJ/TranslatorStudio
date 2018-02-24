using System;
using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using Xunit;

namespace TranslatorStudioClassLibraryTest.Class
{
    /// <summary>
    /// Contains tests that are run against Sub Translation Data class.
    /// </summary>
    [Collection("Sub Translation Data Test")]
    [Trait("Category", "Unit")]
    [Trait("Class", "Sub Translation Data")]
    public class SubTranslationDataTest
    {
        /// <summary>
        /// Mock of Sub Translation Data.
        /// </summary>
        private readonly ISubTranslationData mockSubTranslationData;
        /// <summary>
        /// Mock of Condition List.
        /// </summary>
        private readonly bool[] mockConditionList;
        /// <summary>
        /// Mock of Index Reference.
        /// </summary>
        private readonly List<int> mockIndexReference;

        /// <summary>
        /// Constructor to set up test code.
        /// </summary>
        public SubTranslationDataTest()
        {
            mockConditionList = new bool[]
            {
                true, false, true, true, false, false
            };

            mockIndexReference = new List<int>();

            for (int i = 0; i < mockConditionList.Length; i++)
            {
                if (mockConditionList[i])
                {
                    mockIndexReference.Add(i);
                }
            }

            mockSubTranslationData = new SubTranslationData()
            {
                IndexReference = mockIndexReference,
                CurrentIndex = mockIndexReference.First(),
            };
        }

        #region Properties Tests

        /// <summary>
        /// Given that Index Reference is assigned a valid list of integers, value of Index Reference is changed.
        /// </summary>
        [Fact]
        public void SubTranslationData_IndexReference_Test()
        {
            //Arrange
            var expected = mockIndexReference;

            //Act
            var actual = mockSubTranslationData.IndexReference = expected;

            //Assert
            Assert.IsType<List<int>>(actual);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Given that Current Index is assigned a valid integer, the value of Current Reference is changed.
        /// </summary>
        /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
        [Theory]
        [InlineData(2)]
        public void SubTranslationData_CurrentReference_Test(int currentIndex)
        {
            //Arrange
            var expected = mockIndexReference[currentIndex];
            mockSubTranslationData.CurrentIndex = currentIndex;

            //Act
            var actual = mockSubTranslationData.CurrentReference;

            //Assert
            Assert.IsType<int>(actual);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Given that Current Index is assigned a valid integer, the value of Current Index is changed.
        /// </summary>
        /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
        [Theory]
        [InlineData(2)]
        public void SubTranslationData_CurrentIndex_Test(int currentIndex)
        {
            //Arrange
            var expected = currentIndex;

            //Act
            mockSubTranslationData.CurrentIndex = expected;
            var actual = mockSubTranslationData.CurrentIndex;

            //Assert
            Assert.IsType<int>(actual);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Given that Size of Index Reference is not 0, the value of Max Index should be a valid integer greater than or equal to 0.
        /// </summary>
        [Fact]
        public void SubTranslationData_MaxIndex_Test()
        {
            //Arrange
            var expected = mockIndexReference.Count - 1;

            //Act
            var actual = mockSubTranslationData.MaxIndex;

            //Assert
            Assert.IsType<int>(actual);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Given that Size of Index Reference is not 0, the value of Number of Lines should be a valid integer greater than 0.
        /// </summary>
        [Fact]
        public void SubTranslationData_NumberOfLines_Test()
        {
            //Arrange
            var expected = mockIndexReference.Count;

            //Act
            var actual = mockSubTranslationData.NumberOfLines;

            //Assert
            Assert.IsType<int>(actual);
            Assert.Equal(expected, actual);
        }

        #endregion

        #region Constructor Tests

        /// <summary>
        /// Given that Sub Translation Data is invoked, Default Constructor returns valid Sub Translation Data.
        /// </summary>
        [Fact]
        public void SubTranslationData_DefaultConstructor_Test()
        {
            //Arrange
            var expected = new SubTranslationData();

            //Act
            var actual = new SubTranslationData();

            //Assert
            Assert.IsType<SubTranslationData>(actual);
            Assert.IsAssignableFrom<ISubTranslationData>(actual);
            Assert.NotStrictEqual(expected, actual);
        }

        #endregion
    }
}

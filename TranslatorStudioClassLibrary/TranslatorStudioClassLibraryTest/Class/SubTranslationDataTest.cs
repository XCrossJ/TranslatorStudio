using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibraryTest.Class
{
    [TestClass]
    [TestCategory("Sub Translation Data Test")]
    public class SubTranslationDataTest
    {
        private readonly ISubTranslationData mockSubTranslationData;
        private readonly bool[] mockConditionList;
        private readonly List<int> mockIndexReference;

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

            mockSubTranslationData = new SubTranslationData(mockConditionList);
        }

        #region Properties Tests
        [TestMethod]
        public void IndexReference_Test()
        {
            //Arrange
            var expected = mockIndexReference;

            //Act
            var actual = mockSubTranslationData.IndexReference;

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CurrentReference_Test()
        {
            //Arrange
            var currentIndex = 2;
            var expected = mockIndexReference[currentIndex];
            mockSubTranslationData.CurrentIndex = currentIndex;

            //Act
            var actual = mockSubTranslationData.CurrentReference;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CurrentIndex_Test()
        {
            //Arrange
            var expected = 2;

            //Act
            mockSubTranslationData.CurrentIndex = expected;
            var actual = mockSubTranslationData.CurrentIndex;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MaxIndex_Test()
        {
            //Arrange
            var expected = mockIndexReference.Count - 1;

            //Act
            var actual = mockSubTranslationData.MaxIndex;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberOfLines_Test()
        {
            //Arrange
            var expected = mockIndexReference.Count;

            //Act
            var actual = mockSubTranslationData.NumberOfLines;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}

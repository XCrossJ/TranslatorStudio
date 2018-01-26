﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;

namespace TranslatorStudioClassLibraryTest.Repository
{
    [TestClass]
    [TestCategory("Sub Translation Data Repository Test")]
    public class SubTranslationDataRepositoryTest
    {
        private readonly List<bool> mockConditionList;

        public SubTranslationDataRepositoryTest()
        {
            mockConditionList = new List<bool>
            {
                true,
                false,
                true,
                false,
                false,
                true,
                false,
                true,
                true,
                false
            };
        }

        [TestMethod]
        public void GetSubData_Test()
        {
            //Arrange
            var conditionList = mockConditionList;
            var expected = new List<int>();

            for (int i = 0; i < conditionList.Count; i++)
            {
                var line = conditionList[i];
                if (line == true)
                    expected.Add(i);
            }

            //Act
            var SubData = new SubTranslationDataRepository().GetSubData(conditionList);
            var actual = SubData.IndexReference;

            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("Exception Test")]
        public void GivenEmptyConditionListRaiseException()
        {
            //Arrange
            var conditionList = new List<bool>();

            //Act
            var SubData = new SubTranslationDataRepository().GetSubData(conditionList);

            //Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("Exception Test")]
        public void GivenFalseConditionListRaiseException()
        {
            //Arrange
            var conditionList = Enumerable.Repeat(false, 10).ToList();

            //Act
            var SubData = new SubTranslationDataRepository().GetSubData(conditionList);

            //Assert

        }
    }
}

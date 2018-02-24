using System;
using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;
using Xunit;

namespace TranslatorStudioClassLibraryTest.Repository
{
    /// <summary>
    /// Contains tests that are run against Sub Translation Data Repository class.
    /// </summary>
    [Collection("Sub Translation Data Repository Test")]
    [Trait("Category", "Unit")]
    [Trait("Class", "Sub Translation Data Repository")]
    public class SubTranslationDataRepositoryTest
    {
        /// <summary>
        /// Mock of Condition List.
        /// </summary>
        private readonly List<bool> mockConditionList;

        /// <summary>
        /// Sub Translation Data Repository under test.
        /// </summary>
        private readonly ISubTranslationDataRepository subTranslationDataRepository;

        /// <summary>
        /// Constructor to set up test code.
        /// </summary>
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

            subTranslationDataRepository = new SubTranslationDataRepository();
        }

        #region Constructor Tests

        /// <summary>
        /// Given that Sub Translation Data Repository is invoked, Default Constructor returns valid Sub Translation Data Repository.
        /// </summary>
        [Fact]
        public void SubTranslationDataRepository_DefaultConstructor_Test()
        {
            //Arrange
            var expected = subTranslationDataRepository;

            //Act
            var actual = new SubTranslationDataRepository();

            //Assert
            Assert.IsType<SubTranslationDataRepository>(actual);
            Assert.IsAssignableFrom<ISubTranslationDataRepository>(actual);
            Assert.NotStrictEqual(expected, actual);
        }

        #endregion

        #region Methods Tests

        /// <summary>
        /// Given that Condition List passed is valid, Get Sub Data returns valid Sub Translation Data.
        /// </summary>
        [Fact]
        public void GetSubData_Test()
        {
            //Arrange
            var conditionList = mockConditionList;
            var expectedReferenceList = new List<int>();

            for (int i = 0; i < conditionList.Count; i++)
            {
                var line = conditionList[i];
                if (line == true)
                    expectedReferenceList.Add(i);
            }

            var expected = new SubTranslationData
            {
                IndexReference = expectedReferenceList
            };

            //Act
            var actual = subTranslationDataRepository.GetSubData(conditionList);
            var actualReferenceList = actual.IndexReference;

            //Assert
            Assert.IsType<SubTranslationData>(actual);
            Assert.IsAssignableFrom<ISubTranslationData>(actual);
            Assert.NotStrictEqual(expected, actual);
            Assert.IsType<List<int>>(actualReferenceList);
            Assert.Equal(expectedReferenceList, actualReferenceList);
        }

        #endregion

        #region Exception Tests

        /// <summary>
        /// Given that Condition List passed is empty, Get Sub Data will throw Exception.
        /// </summary>
        [Fact]
        [Trait("Category", "Exception")]
        public void GivenEmptyConditionListRaiseException()
        {
            //Arrange
            var conditionList = new List<bool>();

            var expectedMessage = "Passed Condition List is Empty.";
            var expected = new Exception(expectedMessage);

            //Act
            var actual = Record.Exception(() => subTranslationDataRepository.GetSubData(conditionList));
            var actualMessage = actual.Message;

            //Assert
            Assert.IsType<Exception>(actual);
            Assert.NotStrictEqual(expected, actual);
            Assert.Equal(expectedMessage, actualMessage);
        }

        /// <summary>
        /// Given that Passed Condition List is completely false, Get Sub Data will throw Exception.
        /// </summary>
        [Fact]
        [Trait("Category", "Exception")]
        public void GivenFalseConditionListRaiseException()
        {
            //Arrange
            var conditionList = Enumerable.Repeat(false, 10).ToList();

            var expectedMessage = "Condition list retrieved no indices.";
            var expected = new Exception(expectedMessage);

            //Act
            var actual = Record.Exception(() => subTranslationDataRepository.GetSubData(conditionList));
            var actualMessage = actual.Message;

            //Assert
            Assert.IsType<Exception>(actual);
            Assert.NotStrictEqual(expected, actual);
            Assert.Equal(expectedMessage, actualMessage);
        }

        #endregion

    }
}

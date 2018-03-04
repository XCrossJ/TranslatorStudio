using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Exception;
using TranslatorStudioClassLibrary.Factory;
using TranslatorStudioClassLibrary.Interface;
using Xunit;

namespace TranslatorStudioClassLibraryTest.Factory
{
    /// <summary>
    /// Contains tests to run against Sub Translation Data Factory class.
    /// </summary>
    [Collection("Sub Translation Data Factory Test")]
    public class SubTranslationDataFactoryTest
    {
        /// <summary>
        /// Contains tests to run against Sub Translation Data Factory constructors.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Sub Translation Data Factory")]
        public class Constructors
        {
            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Constructors()
            {

            }

            #region Constructor Tests

            /// <summary>
            /// Given that Sub Translation Data Factory is invoked, Default Constructor returns valid Sub Translation Data Factory.
            /// </summary>
            [Fact]
            public void SubTranslationDataFactory_DefaultConstructor_Test()
            {
                //Arrange
                var expected = new SubTranslationDataFactory();

                //Act
                var actual = new SubTranslationDataFactory();

                //Assert
                Assert.IsType<SubTranslationDataFactory>(actual);
                Assert.IsAssignableFrom<ISubTranslationDataFactory>(actual);
                Assert.NotStrictEqual(expected, actual);
            }

            #endregion
        }

        /// <summary>
        /// Contains tests to run against Sub Translation Data Factory methods.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Sub Translation Data Factory")]
        public class Methods
        {
            /// <summary>
            /// Mock of Condition List.
            /// </summary>
            private readonly List<bool> mockConditionList;

            /// <summary>
            /// Sub Translation Data Factory under test.
            /// </summary>
            private readonly ISubTranslationDataFactory subTranslationDataFactory;

            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Methods()
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

                subTranslationDataFactory = new SubTranslationDataFactory();
            }

            #region Methods Tests

            /// <summary>
            /// Given that Condition List passed is valid, Get Sub Data returns valid Sub Translation Data.
            /// </summary>
            [Fact]
            public void SubTranslationDataFactory_GetSubData_Test()
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
                var actual = subTranslationDataFactory.GetSubData(conditionList);
                var actualReferenceList = actual.IndexReference;

                //Assert
                Assert.IsType<SubTranslationData>(actual);
                Assert.IsAssignableFrom<ISubTranslationData>(actual);
                Assert.NotStrictEqual(expected, actual);
                Assert.IsType<List<int>>(actualReferenceList);
                Assert.Equal(expectedReferenceList, actualReferenceList);
            }

            #endregion
        }

        /// <summary>
        /// Contains tests to run against Sub Translation Data Factory methods that can throw expected exceptions.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Sub Translation Data Factory")]
        [Trait("Category", "Exception")]
        public class Exceptions
        {
            /// <summary>
            /// Mock of Condition List.
            /// </summary>
            private readonly List<bool> mockConditionList;

            /// <summary>
            /// Sub Translation Data Factory under test.
            /// </summary>
            private readonly ISubTranslationDataFactory subTranslationDataFactory;

            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Exceptions()
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

                subTranslationDataFactory = new SubTranslationDataFactory();
            }

            #region Exception Tests

            /// <summary>
            /// Given that Condition List passed is empty, Get Sub Data will throw Exception.
            /// </summary>
            [Fact]
            [Trait("Exception", "InvalidConditionListException")]
            public void SubTranslationDataFactory_GivenEmptyConditionListRaiseException()
            {
                //Arrange
                var conditionList = new List<bool>();

                var expectedMessage = "Passed Condition List is Empty.";
                var expected = new InvalidConditionListException(expectedMessage);

                //Act
                var actual = Record.Exception(() => subTranslationDataFactory.GetSubData(conditionList));
                var actualMessage = actual.Message;

                //Assert
                Assert.IsType<InvalidConditionListException>(actual);
                Assert.NotStrictEqual(expected, actual);
                Assert.Equal(expectedMessage, actualMessage);
            }

            /// <summary>
            /// Given that Passed Condition List is completely false, Get Sub Data will throw Exception.
            /// </summary>
            [Fact]
            [Trait("Exception", "InvalidConditionListException")]
            public void SubTranslationDataFactory_GivenFalseConditionListRaiseException()
            {
                //Arrange
                var conditionList = Enumerable.Repeat(false, 10).ToList();

                var expectedMessage = "Condition list retrieved no indices.";
                var expected = new InvalidConditionListException(expectedMessage);

                //Act
                var actual = Record.Exception(() => subTranslationDataFactory.GetSubData(conditionList));
                var actualMessage = actual.Message;

                //Assert
                Assert.IsType<InvalidConditionListException>(actual);
                Assert.NotStrictEqual(expected, actual);
                Assert.Equal(expectedMessage, actualMessage);
            }

            #endregion
        }

    }
}

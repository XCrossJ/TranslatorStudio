using AutoFixture;
using AutoFixture.AutoMoq;
using System;

namespace TranslatorStudioClassLibrary.Tests.TestSetup.Builders
{
    public class FixtureBuilder
    {
        public FixtureBuilder()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = true });
        }

        private IFixture Fixture { get; set; }

        public FixtureBuilder With(IFixture fixture)
        {
            Fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

            return this;
        }

        public IFixture Build()
        {
            return Fixture;
        }
    }
}

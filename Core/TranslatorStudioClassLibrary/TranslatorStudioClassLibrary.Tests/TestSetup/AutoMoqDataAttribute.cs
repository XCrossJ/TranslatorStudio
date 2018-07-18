﻿using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace TranslatorStudioClassLibrary.Tests.TestSetup
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(new Fixture()
                  .Customize(new AutoMoqCustomization { ConfigureMembers = true }))
        {

        }
    }
}

﻿using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.ShouldBe
{
    public class EqualsShouldBeCalledOnExpectedScenario : ShouldlyShouldTestScenario
    {
        protected override void ShouldThrowAWobbly()
        {
            new BaseClass().ShouldBe(new SubclassWithStubbedEquals {EqualsResult = false});
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get
            {
                return "new BaseClass() should be Shouldly.Tests.ShouldBe.SubclassWithStubbedEquals but was Shouldly.Tests.ShouldBe.BaseClass";
            }
        }

        protected override void ShouldPass()
        {
            new BaseClass().ShouldBe(new SubclassWithStubbedEquals {EqualsResult = true});
        }
    }

    public class BaseClass
    {
    }

    public class SubclassWithStubbedEquals : BaseClass
    {
        public bool EqualsResult { private get; set; }

        // ReSharper disable once CSharpWarnings::CS0659
        public override bool Equals(object obj)
        {
            return EqualsResult;
        }
    }
}
using System;

namespace ConstructorTester
{
    public class MissingCtorTester<T> : Tester<T>
    {

        public override Tester<T> Fail(object[] args, Type exceptionType, string failMessage)
        {
            return this;
        }

        public override Tester<T> Succeed(object[] args, string failMessage)
        {
            return this;
        }

        public override void Assert()
        {
            NUnit.Framework.Assert.Fail("Missing constructor.");
        }

    }
}

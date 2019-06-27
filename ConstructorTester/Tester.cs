using System;

namespace ConstructorTester
{
    public abstract class Tester<T>
    {
        public abstract Tester<T> Fail(object[] args, Type exceptionType, string failMessage);
        public abstract Tester<T> Succeed(object[] args, string failMessage);
        public abstract void Assert();
    }
}

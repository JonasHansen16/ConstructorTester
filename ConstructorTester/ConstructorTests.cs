using System;
using System.Reflection;

/// <summary>
/// Helper class for compactly unit testing constructor validation logic.
/// Source http://codinghelmet.com/articles/constructor-tests
/// </summary>
namespace ConstructorTester
{
    public static class ConstructorTests<T>
    {
        public static Tester<T> For(params Type[] argTypes)
        {

            ConstructorInfo ctor = typeof(T).GetConstructor(argTypes);

            if (ctor == null)
                return new MissingCtorTester<T>();

            return new CtorTester<T>(ctor);

        }
    }
}

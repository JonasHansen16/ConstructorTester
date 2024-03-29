﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConstructorTester
{
    public class CtorTester<T> : Tester<T>
    {
        private ConstructorInfo constructor;
        private IList<TestCase<T>> testCases = new List<TestCase<T>>();

        public CtorTester(ConstructorInfo ctor)
        {
            this.constructor = ctor;
        }

        public override Tester<T> Fail(object[] args, Type exceptionType, string failMessage)
        {
            TestCase<T> testCase = new FailTest<T>(this.constructor, args, exceptionType, failMessage);
            testCases.Add(testCase);
            return this;
        }

        public override Tester<T> Succeed(object[] args, string failMessage)
        {
            TestCase<T> testCase = new SuccessTest<T>(this.constructor, args, failMessage);
            testCases.Add(testCase);
            return this;
        }

        public override void Assert()
        {
            List<string> errors = new List<string>();
            ExecuteTestCases(errors);
            Assert(errors);
        }

        private void ExecuteTestCases(List<string> errors)
        {
            foreach (TestCase<T> testCase in this.testCases)
                ExecuteTestCase(errors, testCase);
        }

        private void ExecuteTestCase(List<string> errors, TestCase<T> testCase)
        {
            string error = testCase.Execute();
            if (!string.IsNullOrEmpty(error))
                errors.Add("    ----> " + error);
        }

        private void Assert(List<string> errors)
        {
            if (errors.Count > 0)
            {
                string error = string.Format("{0} error(s) occurred:\n{1}",
                                             errors.Count,
                                             string.Join("\n", errors.ToArray()));
                NUnit.Framework.Assert.Fail(error);
            }
        }

    }
}

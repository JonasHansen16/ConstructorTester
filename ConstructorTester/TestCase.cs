using System.Reflection;

namespace ConstructorTester
{
    public abstract class TestCase<T>
    {
        private ConstructorInfo constructor;
        private object[] arguments;
        private string failMessage;

        public TestCase(ConstructorInfo ctor, object[] args, string failMessage)
        {
            this.constructor = ctor;
            this.arguments = args;
            this.failMessage = failMessage;
        }

        protected T InvokeConstructor()
        {
            try
            {
                return (T)this.constructor.Invoke(this.arguments);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

        protected string Fail(string msg)
        {
            return string.Format("Test failed ({0}): {1}", this.failMessage, msg);
        }

        protected string Success()
        {
            return string.Empty;
        }

        public abstract string Execute();

    }
}

using System;

namespace LC_LocalAutomation
{
    public class LocalAutomationException : Exception
    {
        public Type Class { get; set; }
        public string MethodName { get; set; }

        public LocalAutomationException(Type _class, string methodName, string message) : base(message)
        {
            this.Class = _class;
            this.MethodName = methodName;
        }
    }
}

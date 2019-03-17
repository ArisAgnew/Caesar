using OpenQA.Selenium;

using System;

namespace SeleniumCore.Functions.JavaScript
{
    public sealed class EvaluateJavaScript : IFunc<IWebDriver, Object>
    {
        private readonly string _script = default;
        private readonly object[] _parameters = default;

        public string Script { get => _script; set => value = _script; }
        public object[] Parameters { get => _parameters; set => value = _parameters; }

        //todo: Ought to be created an instance directly or create method within. 
        //The problem is how to tie up Func with this.instance...

        public object Apply(IWebDriver webDriver)
        {
            Type driverType = webDriver.GetType();

            if (!typeof(IJavaScriptExecutor).IsAssignableFrom(driverType))
                throw new NotSupportedException($"{driverType} does not implement " +
                    $"{typeof(IJavaScriptExecutor).FullName}. The script {_script} might not be evaluated.");

            var executor = webDriver as IJavaScriptExecutor;
            return executor.ExecuteScript(_script, _parameters);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Caesar.AlternativeStuff;

namespace Caesar
{
    internal class StepAction<T> //: Action<T>
    {
        private readonly string description;
        private readonly Action<T> action;
        private bool IsComplex;

        StepAction() { }

        public string Description => description.RequireNonNull("Description should not be empty");
        public Action<T> Action => action.RequireNonNull("Consumer should be defined");


    }
}

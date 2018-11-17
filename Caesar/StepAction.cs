using System;
using Caesar.AlternativeStuff;
using Caesar.FactoryAssembly;
using JetBrains.Annotations;

using static System.String;

namespace Caesar
{
    public class StepAction<T>
    {
        private const string before_action_commentary = "before-action";
        private const string after_action_commentary = "before-action";

        private static readonly string comment = "It seems given consumer doesn't describe any before-action. Use method " +
                        "StoryWriter.action to describe the {0} or override the toString method";

        public void Deconstruct(out string description, out Action<T> action, out bool isComplex)
        {
            description = Description;
            action = Action;
            isComplex = IsComplex;
        }

        [NotNull]
        public string Description { get; set; }

        [NotNull]
        public Action<T> Action { get; set; }

        [NotNull]
        public bool IsComplex { get; private set; }

        private static StepAction<T> GetSequentialDescribedAction(Action<T> before, Action<T> after)
        {
            before.RequireNonNull(Format(comment, before_action_commentary));
            after.RequireNonNull(Format(comment, before_action_commentary));

            return new StepAction<T>()
            {
                Description = $"{before}.\n\t And then {after}",
                Action = t =>
                {
                    before?.ForwardCompose<T>(after)?.Invoke(t); //todo?
                },
                IsComplex = !default(bool)
            };
        }

        public void Accept(T type)
        {
            //todo
            Action?.Invoke(type);
        }

        //public Action<T> ForwardCompose(Action<T> afterAction) => GetSequentialDescribedAction(?, afterAction); //todo
        
        public override string ToString() => Description;
    }
}

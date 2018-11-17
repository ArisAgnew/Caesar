using System;

using static System.Int32;

namespace Caesar.Utilities
{
    public static class VerifyDescribedUtility
    {
        private static bool IsDescribed(this object toBeDescribed)
        {
            string stringDescription = Convert.ToString(toBeDescribed);

            if (toBeDescribed == default)
                return default;            

            return !string.IsNullOrEmpty(stringDescription) && 
                !stringDescription.Equals($"{toBeDescribed.GetType().Name} | {Parse(stringDescription).ToString("X8")}");
        }

        public static bool IsDescribed<T>(this Action<T> toBeDescribed) => toBeDescribed.IsDescribed();   
        public static bool IsDescribed<T>(this Func<T, T> toBeDescribed) => toBeDescribed.IsDescribed();
        public static bool IsDescribed<T>(this Predicate<T> toBeDescribed) => toBeDescribed.IsDescribed();

        public static (bool, bool) IsDescribedAsWellAs<T>(this Action<T> firstToBeDescribed, Action<T> secondToBeDescribed) =>
            (firstToBeDescribed.IsDescribed(), secondToBeDescribed.IsDescribed());

        public static (bool, bool) IsDescribedAsWellAs<T>(this Func<T, T> firstToBeDescribed, Func<T, T> secondToBeDescribed) =>
            (firstToBeDescribed.IsDescribed(), secondToBeDescribed.IsDescribed());

        public static (bool, bool) IsDescribedAsWellAs<T>(this Predicate<T> firstToBeDescribed, Predicate<T> secondToBeDescribed) =>
            (firstToBeDescribed.IsDescribed(), secondToBeDescribed.IsDescribed());
    }
}

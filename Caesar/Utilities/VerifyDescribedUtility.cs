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

            return !string.IsNullOrEmpty(stringDescription) 
                && !stringDescription.Equals($"{toBeDescribed.GetType().Name} | {Parse(stringDescription).ToString("X8")}");
        }

        public static bool IsDescribed(this Action<dynamic> toBeDescribed) => toBeDescribed.IsDescribed();
        public static bool IsDescribed(this Func<dynamic, dynamic> toBeDescribed) => toBeDescribed.IsDescribed();
        public static bool IsDescribed(this Predicate<dynamic> toBeDescribed) => toBeDescribed.IsDescribed();
    }
}

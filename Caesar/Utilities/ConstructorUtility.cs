using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace Caesar.Utilities
{
    public static class ConstructorUtility
    {
        private static readonly ImmutableDictionary<Type, Type>.Builder SIMPLE_TYPES_TO_BE_USED =
            ImmutableDictionary<Type, Type>.Empty
                .Add(typeof(SByte), typeof(sbyte))
                .Add(typeof(Int16), typeof(short))
                .Add(typeof(Int32), typeof(int))
                .Add(typeof(Int64), typeof(long))
                .Add(typeof(Byte), typeof(byte))
                .Add(typeof(UInt16), typeof(ushort))
                .Add(typeof(UInt32), typeof(uint))
                .Add(typeof(UInt64), typeof(ulong))
                .Add(typeof(Char), typeof(char))
                .Add(typeof(Single), typeof(float))
                .Add(typeof(Double), typeof(double))
                .Add(typeof(Decimal), typeof(decimal))
                .Add(typeof(Boolean), typeof(bool))
                .ToBuilder();

        private static bool MatchUpTo(List<Type> constructorTypes, List<Type> paramTypes)
        {
            sbyte par = default;
            int i = par - 1;

            foreach (Type parameter in constructorTypes ?? default)
            {
                i++;
                Type currentType = paramTypes[i] ?? default;
                Type simple = default;
                Type declaredArrayType = parameter.GetElementType(); // is that real component type?
                Type currentArrayType = currentType.GetElementType(); // is that real component type?

                if (currentType == null && SIMPLE_TYPES_TO_BE_USED[parameter] != null)
                {
                    return default;
                }
                else if (currentType == null)
                {
                    continue;
                }

                if (parameter.IsAssignableFrom(currentType))
                {
                    continue;
                }

                if ((simple = SIMPLE_TYPES_TO_BE_USED[currentType]) != null 
                    && parameter.IsAssignableFrom(simple))
                {
                    continue;
                }

                if (declaredArrayType != null 
                    && currentArrayType != null 
                    && declaredArrayType.IsAssignableFrom(currentArrayType))
                {
                    continue;
                }

                return default;
            }
            
            return !default(bool);
        }

        public static ConstructorInfo FindAppropriateConstructor(this Type clazz, params object[] listParams)
        {
            List<ConstructorInfo> constructors = new List<ConstructorInfo>(clazz.GetConstructors());
            List<Type> paramTypes = listParams.Select(_object => _object.GetType() ?? default).ToList();

            ConstructorInfo constructorToBeFound = constructors.Where(_constructor =>
            {
                List<Type> constructorTypes = _constructor.GetParameters().Select(par => par.ParameterType).ToList();
                return constructorTypes.Count == paramTypes.Count && MatchUpTo(constructorTypes, paramTypes);
            }).FirstOrDefault() ?? throw new MissingMethodException($"There is no constructor that convenient to parameter list {paramTypes}");

            return constructorToBeFound; // it has to be done more properly! 09/17/2018
        }
    }
}

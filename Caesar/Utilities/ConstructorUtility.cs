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
                .Add(typeof(sbyte), typeof(sbyte))
                .Add(typeof(short), typeof(short))
                .Add(typeof(int), typeof(int))
                .Add(typeof(long), typeof(long))
                .Add(typeof(byte), typeof(byte))
                .Add(typeof(ushort), typeof(ushort))
                .Add(typeof(uint), typeof(uint))
                .Add(typeof(ulong), typeof(ulong))
                .Add(typeof(char), typeof(char))
                .Add(typeof(float), typeof(float))
                .Add(typeof(double), typeof(double))
                .Add(typeof(decimal), typeof(decimal))
                .Add(typeof(bool), typeof(bool))
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
            }).First() ?? throw new MissingMethodException($"There is no constructor that convenient to parameter list {paramTypes}");

            return constructorToBeFound; // it has to be done more properly! 09/17/2018
        }
    }
}

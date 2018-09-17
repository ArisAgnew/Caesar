using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace Caesar.Utilities
{
    public static class ConstructorUtility
    {
        private static bool MatchUpTo(List<Type> constructorTypes, List<Type> paramTypes)
        {
            sbyte par = default;
            int i = par - 1;

            foreach (Type parameter in constructorTypes ?? default)
            {
                i++;

                Type currentType = paramTypes[i] ?? default;
                Type declaredArrayType = parameter.GetElementType(); // is that real component type?
                Type currentArrayType = currentType.GetElementType(); // is that real component type?

                if (currentType == null)
                {
                    return default;
                }

                if (parameter.IsAssignableFrom(currentType))
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

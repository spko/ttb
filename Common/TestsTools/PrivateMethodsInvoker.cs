using System;
using System.Reflection;

namespace Spo.ToolsTestsBenchmarks.Common.TestsTools
{
    public static class PrivateMethodsInvoker
    {
        private static readonly BindingFlags PrivateFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        private static readonly BindingFlags PrivateStaticFlags = BindingFlags.Static | BindingFlags.NonPublic;

        /// <summary>
        /// Invokes a non-public method specified by <paramref name="methodNameEnum"/> casting the return value into specified <see cref="TResult"/> type
        /// </summary>
        /// <typeparam name="TResult">Type of the the expected return value</typeparam>
        /// <typeparam name="TInstance">Type of the object containing the method to invoke</typeparam>
        /// <param name="instance">Current instance of the object, containing the method <paramref name="methodNameEnum"/></param>
        /// <param name="methodNameEnum">The name of the method to invoke</param>
        /// <param name="args">Potential input arguments of the method to invoke</param>
        /// <returns>The result object obtained from the invoked method. Can be null</returns>
        public static TResult InvokeNonPublic<TResult, TInstance>(TInstance instance, Enum methodNameEnum, params object[] args)
            where TInstance : class
            where TResult : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            string methodName = methodNameEnum.ToString();
            object result = Invoke<TInstance>(instance, PrivateFlags, methodName, args);

            return result as TResult;
        }

        /// <summary>
        /// Invokes a non-public void method specified by <paramref name="methodNameEnum"/>
        /// </summary>
        /// <typeparam name="TInstance">Type of the the expected return value</typeparam>
        /// <param name="instance">Current instance of the object, containing the method <paramref name="methodNameEnum"/></param>
        /// <param name="methodNameEnum">The name of the method to invoke</param>
        /// <param name="args">Potential input arguments of the method to invoke</param>
        public static void InvokeNonPublicVoid<TInstance>(TInstance instance, Enum methodNameEnum, params object[] args)
            where TInstance : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            string methodName = methodNameEnum.ToString();

            Invoke<TInstance>(instance, PrivateFlags, methodName, args);
        }

        /// <summary>
        /// Invokes a non-public static method specified by <paramref name="methodNameEnum"/> casting the return value into specified <see cref="TResult"/> type
        /// </summary>
        /// <typeparam name="TResult">Type of the the expected return value</typeparam>
        /// <typeparam name="TInstance">Type of the object containing the method to invoke</typeparam>
        /// <param name="instance">Current instance of the object, containing the method <paramref name="methodNameEnum"/></param>
        /// <param name="methodNameEnum"></param>
        /// <param name="args">Potential input arguments of the method to invoke</param>
        /// <returns>The result object obtained from the invoked method. Can be null</returns>
        public static TResult InvokeNonPublicStatic<TResult, TInstance>(TInstance instance, Enum methodNameEnum, params object[] args)
            where TInstance : class
            where TResult : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            string methodName = methodNameEnum.ToString();

            object result = Invoke<TInstance>(instance, PrivateStaticFlags, methodName, args);

            return result as TResult;
        }

        /// <summary>
        /// Invokes a non-public static void method specified by <paramref name="methodNameEnum"/>
        /// </summary>
        /// <typeparam name="TInstance">Type of the object containing the method to invoke</typeparam>
        /// <param name="instance">Current instance of the object, containing the method <paramref name="methodNameEnum"/></param>
        /// <param name="methodNameEnum">The name of the method to invoke</param>
        /// <param name="args">Potential input arguments of the method to invoke</param>
        public static void InvokeNonPublicStaticVoid<TInstance>(TInstance instance, Enum methodNameEnum, params object[] args)
            where TInstance : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            string methodName = methodNameEnum.ToString();

            Invoke<TInstance>(instance, PrivateStaticFlags, methodName, args);
        }

        /// <summary>
        /// Access and return the value of the field specified by <paramref name="fieldNameEnum"/>.
        /// </summary>
        /// <typeparam name="TResult">Expected type of the field</typeparam>
        /// <typeparam name="TInstance">Type of the object holding the field <paramref name="fieldNameEnum"/></typeparam>
        /// <param name="instance">The actual instance of the object holding the field</param>
        /// <param name="fieldNameEnum">The name of the field to retrieve</param>
        /// <returns>The value of the field. Can be null</returns>
        public static TResult GetNonPublicField<TResult, TInstance>(TInstance instance, Enum fieldNameEnum)
            where TInstance : class
            where TResult : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            string fieldName = fieldNameEnum.ToString();
            FieldInfo fieldInfo;
            if (TryGetFieldInfo<TInstance>(PrivateFlags, fieldName, out fieldInfo))
            {
                TResult fieldValue;
                if (TryGetValue<TResult, TInstance>(instance, fieldInfo, out fieldValue))
                {
                    return fieldValue;
                }
            }

            return default(TResult);
        }

        /// <summary>
        /// Access and return the value of the non-public static field specified by <paramref name="fieldNameEnum"/>.
        /// </summary>
        /// <typeparam name="TResult">Expected type of the field</typeparam>
        /// <typeparam name="TInstance">Type of the object holding the field <paramref name="fieldNameEnum"/></typeparam>
        /// <param name="instance">The actual instance of the object holding the field</param>
        /// <param name="fieldNameEnum">The name of the field to retrieve</param>
        /// <returns>The value of the field. Can be null</returns>
        public static TResult GetNonPublicStaticField<TResult, TInstance>(TInstance instance, Enum fieldNameEnum)
            where TInstance : class
            where TResult : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            string fieldName = fieldNameEnum.ToString();
            FieldInfo fieldInfo;
            if (TryGetFieldInfo<TInstance>(PrivateStaticFlags, fieldName, out fieldInfo))
            {
                TResult fieldValue;
                if (TryGetValue<TResult, TInstance>(instance, fieldInfo, out fieldValue))
                {
                    return fieldValue;
                }
            }

            return default(TResult);
        }

        /// <summary>
        /// Setter method to apply to the specified non-public <paramref name="fieldNameEnum"/> its new value, beholded by <paramref name="newValue"/>
        /// </summary>
        /// <typeparam name="TField">Type of the object contained in the field</typeparam>
        /// <typeparam name="TInstance">Type of the object containing the field</typeparam>
        /// <param name="instance">The actual instance of the object holding the field</param>
        /// <param name="fieldNameEnum">The name of the field to retrieve</param>
        /// <param name="newValue">The actual new value for the field. Can be null</param>
        /// <returns><c>True</c> if operation succeed, <c>False</c> otherwise</returns>
        public static bool SetNonPublicField<TField, TInstance>(TInstance instance, Enum fieldNameEnum, TField newValue)
            where TInstance : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            string fieldName = fieldNameEnum.ToString();
            FieldInfo fieldInfo;
            if (TryGetFieldInfo<TInstance>(PrivateFlags, fieldName, out fieldInfo))
            {
                return TrySetValue<TField, TInstance>(instance, fieldInfo, newValue);
            }

            return false;
        }

        /// <summary>
        /// Setter method to apply to the specified non-public static <paramref name="fieldNameEnum"/> its new value, beholded by <paramref name="newValue"/>
        /// </summary>
        /// <typeparam name="TField">Type of the object contained in the field</typeparam>
        /// <typeparam name="TInstance">Type of the object containing the field</typeparam>
        /// <param name="instance">The actual instance of the object holding the field</param>
        /// <param name="fieldNameEnum">The name of the field to retrieve</param>
        /// <param name="newValue">The actual new value for the field. Can be null</param>
        /// <returns><c>True</c> if operation succeed, <c>False</c> otherwise</returns>
        public static bool SetNonPublicStaticField<TField, TInstance>(TInstance instance, Enum fieldNameEnum, TField newValue)
            where TInstance : class
            where TField : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            string fieldName = fieldNameEnum.ToString();
            FieldInfo fieldInfo;
            if (TryGetFieldInfo<TInstance>(PrivateStaticFlags, fieldName, out fieldInfo))
            {
                return TrySetValue<TField, TInstance>(instance, fieldInfo, newValue);
            }

            return false;
        }

        #region Private Methods

        private static object Invoke<TInstance>(TInstance instance, BindingFlags bindingFlags, string methodName, params object[] args)
        {
            MethodInfo methodInfo;
            if (TryGetMethodInfo<TInstance>(bindingFlags, methodName, out methodInfo))
            {
                object result;
                if (TryInvoke<TInstance>(instance, methodInfo, out result, args))
                {
                    return result;
                }
            }

            return null;
        }

        private static bool TryGetMethodInfo<TInstance>(BindingFlags bindingFlags, string methodName, out MethodInfo methodInfo)
        {
            Type instanceType = typeof(TInstance);
            try
            {
                methodInfo = instanceType.GetMethod(methodName, bindingFlags);
            }
            catch (AmbiguousMatchException e)
            {
                Console.WriteLine(e);
                methodInfo = null;

                return false;
            }

            return methodInfo != null;
        }

        private static bool TryGetFieldInfo<TInstance>(BindingFlags bindingFlags, string fieldName, out FieldInfo fieldInfo)
        {
            Type instanceType = typeof(TInstance);
            try
            {
                fieldInfo = instanceType.GetField(fieldName, bindingFlags);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
                fieldInfo = null;

                return false;
            }

            return fieldInfo != null;
        }

        private static bool TryInvoke<TInstance>(TInstance instance, MethodInfo method, out object result, params object[] args)
        {
            try
            {
                result = method.Invoke(instance, args);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                result = null;

                return false;
            }
        }

        private static bool TryGetValue<TResult, TInstance>(TInstance instance, FieldInfo fieldInfo, out TResult fieldValue)
            where TResult : class
        {
            try
            {
                fieldValue = fieldInfo.GetValue(instance) as TResult;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                fieldValue = default(TResult);

                return false;
            }
        }

        private static bool TrySetValue<TField, TInstance>(TInstance instance, FieldInfo fieldInfo, TField newFieldValue)
        {
            try
            {
                fieldInfo.SetValue(instance, newFieldValue);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return false;
            }
        }

        #endregion
    }
}

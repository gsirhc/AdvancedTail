namespace Tail.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extensions methods for IDictionary
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Convenience extension method that gets the value or default.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The value if exists, or the default</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            // This makes it REALLY convenient, however, may mask issues with the dictionary being unexpectedly null.
            if (dictionary == null)
            {
                return defaultValue;
            }

            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

        public static IDictionary<string, TValue> EnumKeyToString<TKeyOld, TValue>(this IDictionary<TKeyOld, TValue> dictionary)
        {
            return dictionary?.ToDictionary(kvp => Enum.GetName(typeof (TKeyOld), kvp.Key), kvp => kvp.Value);
        }

        public static IDictionary<TEnum, TValue> StringKeyToEnum<TEnum, TValue>(this IDictionary<string, TValue> dictionary) where TEnum : struct, IConvertible
        {
            return dictionary?.ToDictionary(kvp => (TEnum)Enum.Parse(typeof(TEnum), kvp.Key), kvp => kvp.Value);
        }
    }
}

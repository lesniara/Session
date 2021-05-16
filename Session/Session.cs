using System.Collections.Generic;


namespace Lesniarasoft.Client
{
    /// <summary>
    /// ClientSession class is public, static ,and reachable from anywhere in code.
    /// </summary>
    public static class Session
    {
        private static Dictionary<string, object> _Bag = new Dictionary<string, object>();
        private static object _lock = new object();

        /// <summary>
        /// Internal backing Dictionary variable
        /// </summary>
        public static Dictionary<string, object> Bag {
            get{
                lock (_lock)
                {
                    return _Bag;
                }
            }
        }

        /// <summary>
        /// Locate or initialize and set the key/value pair
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="key">Session value lookup unique key</param>
        /// <param name="value">Session variable value</param>
        public static void TrySet<T>(string key, T value)
        {
            lock (_lock)
            {
                if (!_Bag.ContainsKey(key))
                {
                    _Bag.Add(key, null);
                }

                _Bag[key] = value;
            }
        }

        /// <summary>
        /// Retrieve an existing 
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="key">Key to retrieve the associated session value</param>
        /// <param name="value">Session value</param>
        public static void TryGet<T>(string key, out T value)
        {
            lock (_lock)
            {
                if (_Bag.ContainsKey(key))
                {
                    value = (T)_Bag[key];
                }
                else
                {
                    value = default;
                }
            }
        }
        /// <summary>
        /// Determines whether the key exists
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool ContainsKey(string key)
        {
            lock (_lock)
            {
                return _Bag.ContainsKey(key);
            }
        }
    }
}

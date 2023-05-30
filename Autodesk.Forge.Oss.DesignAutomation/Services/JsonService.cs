using Newtonsoft.Json;
using Autodesk.Forge.Oss.DesignAutomation.Services;
using System;

namespace Autodesk.Forge.Oss.DesignAutomation.Services
{
    /// <summary>
    /// JsonService
    /// </summary>
    public class JsonService : IJsonService
    {
        /// <summary>
        /// Instance
        /// </summary>
        public static IJsonService Instance { get; set; } = new JsonService();

        #region Method
        /// <summary>
        /// Serialize <paramref name="value"/> to json string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Serialize(object value)
        {
            if (value is string valueString) return valueString;
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// Deserialize <paramref name="value"/> to <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Deserialize<T>(string value)
        {
            if (value is T valueString) return valueString;
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// Deserialize <paramref name="value"/> to <paramref name="type"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Deserialize(string value, Type type)
        {
            if (type == typeof(string)) return value;
            return JsonConvert.DeserializeObject(value, type);
        }
        #endregion
    }
}

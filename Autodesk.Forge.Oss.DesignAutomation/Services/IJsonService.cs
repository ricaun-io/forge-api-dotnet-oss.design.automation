using System;

namespace Autodesk.Forge.Oss.DesignAutomation.Services
{
    /// <summary>
    /// IJsonService
    /// </summary>
    public interface IJsonService
    {
        /// <summary>
        /// Serialize <paramref name="value"/> to json string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Serialize(object value);
        /// <summary>
        /// Serialize <paramref name="value"/> to json string and mask sensitive data
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SerializeMasked(object value);
        /// <summary>
        /// Deserialize <paramref name="value"/> to <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Deserialize<T>(string value);
        /// <summary>
        /// Deserialize <paramref name="value"/> to <paramref name="type"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Deserialize(string value, Type type);
    }
}

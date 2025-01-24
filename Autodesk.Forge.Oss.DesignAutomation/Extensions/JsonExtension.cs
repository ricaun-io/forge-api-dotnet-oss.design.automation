using Autodesk.Forge.Oss.DesignAutomation.Services;
using System;

namespace Autodesk.Forge.Oss.DesignAutomation.Extensions
{
    /// <summary>
    /// JsonExtension
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// ToJson using <see cref="JsonService.Instance"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJson(this object value)
        {
            return JsonService.Instance.Serialize(value);
        }

        /// <summary>
        /// ToJsonMasked using <see cref="JsonService.Instance"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJsonMasked(this object value)
        {
            return JsonService.Instance.SerializeMasked(value);
        }

        /// <summary>
        /// FromJson using <see cref="JsonService.Instance"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromJson(this string value, Type type)
        {
            return JsonService.Instance.Deserialize(value, type);
        }

        /// <summary>
        /// FromJson using <see cref="JsonService.Instance"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string value)
        {
            return JsonService.Instance.Deserialize<T>(value);
        }
    }
}

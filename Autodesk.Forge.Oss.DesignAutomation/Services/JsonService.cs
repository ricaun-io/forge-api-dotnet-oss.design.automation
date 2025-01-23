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
        /// Serialize <paramref name="value"/> to json string and mask sensitive data
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SerializeMasked(object value)
        {
            return JsonConvert.SerializeObject(value, new JsonSerializerSettings
            {
                Converters = new[] { new MaskedTokenConverter() }
            });
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

        internal class MaskedTokenConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(string);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (value is string token)
                {
                    var propertyName = writer.Path;
                    if (propertyName.Contains("token", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var maskedValue = "Masked:token";
                        writer.WriteValue(maskedValue);
                        return;
                    }

                    writer.WriteValue(token);
                    return;
                }
                writer.WriteNull();
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return reader.Value?.ToString();
            }
        }
    }
}

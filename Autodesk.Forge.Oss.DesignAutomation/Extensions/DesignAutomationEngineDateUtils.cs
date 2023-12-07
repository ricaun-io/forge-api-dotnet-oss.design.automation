using Autodesk.Forge.Core;
using Autodesk.Forge.DesignAutomation;
using Autodesk.Forge.DesignAutomation.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Extensions
{
    /// <summary>
    /// ForgeServiceUtils
    /// </summary>
    public static class DesignAutomationEngineDateUtils
    {
        /// <summary>
        /// EngineDate
        /// </summary>
        public class EngineDate : Engine
        {
            /// <summary>
            /// The deprecation date of the engine.
            /// </summary>
            [DataMember(Name = "deprecationDate", EmitDefaultValue = false)]
            public DateOnly DeprecationDate { get; set; }
        }

        /// <summary>
        /// Check if the <paramref name="engine"/> is deprecated base on the <see cref="EngineDate.DeprecationDate"/>.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="addDayOffset"></param>
        /// <returns></returns>
        public static bool IsDeprecated(this EngineDate engine, int addDayOffset = 1)
        {
            if (engine.DeprecationDate == default) return false;

            var dateOnlyNow = DateOnly.FromDateTime(DateTime.UtcNow.Date)
                .AddDays(addDayOffset);

            return engine.DeprecationDate <= dateOnlyNow;
        }

        /// <summary>
        /// GetEngineDateAsync
        /// </summary>
        /// <param name="designAutomationClient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<EngineDate> GetEngineDateAsync(
            this DesignAutomationClient designAutomationClient,
            string id)
        {
            return await designAutomationClient.Service.GetEngineDateAsync(id);
        }

        /// <summary>
        /// GetEngineDateAsync
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<EngineDate> GetEngineDateAsync(
            this ForgeService service,
            string id)
        {
            var result = await GetAsync<EngineDate>(service, "/v3/engines/{id}", new Dictionary<string, object> { { "id", id } });
            return result.Content;
        }

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service"></param>
        /// <param name="relativePath"></param>
        /// <param name="routeParameters"></param>
        /// <param name="queryParameters"></param>
        /// <param name="scopes"></param>
        /// <param name="headers"></param>
        /// <param name="throwOnError"></param>
        /// <returns></returns>
        public static async Task<ApiResponse<T>> GetAsync<T>(
            this ForgeService service,
            string relativePath,
            Dictionary<string, object> routeParameters = null,
            Dictionary<string, object> queryParameters = null,
            string scopes = null,
            IDictionary<string, string> headers = null,
            bool throwOnError = true)
        {
            using (var request = new HttpRequestMessage())
            {
                request.RequestUri =
                    Marshalling.BuildRequestUri(relativePath,
                        routeParameters: routeParameters ?? new Dictionary<string, object>(),
                        queryParameters: queryParameters ?? new Dictionary<string, object>()
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }

                // tell the underlying pipeline what scope we'd like to use
                if (scopes == null)
                {
                    request.Options.Set(ForgeConfiguration.ScopeKey, "code:all");
                }
                else
                {
                    request.Options.Set(ForgeConfiguration.ScopeKey, scopes);
                }

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await service.Client.SendAsync(request);

                if (throwOnError)
                {
                    await response.EnsureSuccessStatusCodeAsync();
                }
                else if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse<T>(response, default(T));
                }

                return new ApiResponse<T>(response, await Marshalling.DeserializeAsync<T>(response.Content));

            } // using
        }
    }
}
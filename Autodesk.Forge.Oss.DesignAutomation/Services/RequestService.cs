using Autodesk.Forge.Oss.DesignAutomation.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Services
{
    /// <summary>
    /// RequestService
    /// </summary>
    public class RequestService : IRequestService
    {
        /// <summary>
        /// Instance
        /// </summary>
        public static IRequestService Instance { get; set; } = new RequestService();

        #region Methods
        /// <summary>
        /// GetJsonAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async Task<T> GetJsonAsync<T>(string requestUri)
        {
            var json = await GetStringAsync(requestUri);
            return json.FromJson<T>();
        }

        /// <summary>
        /// GetJsonAsync
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<object> GetJsonAsync(string requestUri, Type type)
        {
            var json = await GetStringAsync(requestUri);
            return json.FromJson(type);
        }
        /// <summary>
        /// GetStringAsync
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async Task<string> GetStringAsync(string requestUri)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(requestUri);
            }
        }

        /// <summary>
        /// GetFileAsync
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> GetFileAsync(string requestUri, string fileName = null)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                fileName = Path.GetFileName(requestUri);

            if (File.Exists(fileName))
                File.Delete(fileName);

            using (HttpClient client = new HttpClient())
            {
                using (var s = await client.GetStreamAsync(requestUri))
                {
                    using (var fs = new FileStream(fileName, FileMode.CreateNew))
                    {
                        await s.CopyToAsync(fs);
                        return fs.Name;
                    }
                }
            }
        }

        /// <summary>
        /// Asynchronously retrieves a stream from the specified request URI.
        /// </summary>
        /// <param name="requestUri">The URI from which to retrieve the stream.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the stream retrieved from the request URI.</returns>
        public async Task<Stream> GetStreamAsync(string requestUri)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStreamAsync(requestUri);
            }
        }

        /// <summary>
        /// Asynchronously uploads form data to the specified request URI.
        /// </summary>
        /// <param name="requestUri">The URI to which the form data will be sent.</param>
        /// <param name="formData">A dictionary containing the form data to send. The key is the name of the form field and the value is the field value.</param>
        /// <param name="filePath">The file path of the file to include in the form data.</param>
        public async Task UploadFormDataAsync(string requestUri, Dictionary<string, string> formData, string filePath)
        {
            using (HttpClient client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    foreach (KeyValuePair<string, string> vp in formData)
                    {
                        content.Add(new StringContent(vp.Value), vp.Key);
                    }

                    var streamContent = new StreamContent(new FileStream(filePath, FileMode.Open));
                    content.Add(streamContent, "file", Path.GetFileName(filePath));

                    var response = await client.PostAsync(requestUri, content);
                    response.EnsureSuccessStatusCode();
                    var responseContent = await response.Content.ReadAsStringAsync();
                }
            }
        }

        #endregion
    }
}

using System;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Services
{
    /// <summary>
    /// IRequestService
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// GetJsonAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public Task<T> GetJsonAsync<T>(string requestUri);

        /// <summary>
        /// GetJsonAsync
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Task<object> GetJsonAsync(string requestUri, Type type);
        /// <summary>
        /// GetStringAsync
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public Task<string> GetStringAsync(string requestUri);

        /// <summary>
        /// GetFileAsync
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<string> GetFileAsync(string requestUri, string fileName = null);
    }
}

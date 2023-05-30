using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Services
{
    /// <summary>
    /// IOssService
    /// </summary>
    public interface IOssService
    {
        /// <summary>
        /// UploadFileAsync
        /// </summary>
        /// <param name="localFullName"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<string> UploadFileAsync(string localFullName, string fileName);
        /// <summary>
        /// CreateUrlReadWriteAsync
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<string> CreateUrlReadWriteAsync(string fileName);
    }
}
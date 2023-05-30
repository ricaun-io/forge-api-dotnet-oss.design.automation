using System;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation
{
    /// <summary>
    /// IDesignAutomationService
    /// </summary>
    public interface IDesignAutomationService
    {
        /// <summary>
        /// CoreEngineVersions
        /// </summary>
        /// <returns></returns>
        public string[] CoreEngineVersions();
        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="packagePath"></param>
        /// <returns></returns>
        public Task Initialize(string packagePath);
        /// <summary>
        /// Delete
        /// </summary>
        /// <returns></returns>
        public Task Delete();
        /// <summary>
        /// Run
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="engine"></param>
        /// <returns></returns>
        public Task<bool> Run<T>(string engine = null) where T : class;
        /// <summary>
        /// Run
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <param name="engine"></param>
        /// <returns></returns>
        public Task<bool> Run<T>(Action<T> options, string engine = null) where T : class;
        /// <summary>
        /// Run
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <param name="engine"></param>
        /// <returns></returns>
        public Task<bool> Run<T>(T options, string engine = null) where T : class;
    }
}
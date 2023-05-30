using Autodesk.Forge.Core;

namespace Autodesk.Forge.Oss.DesignAutomation.Services
{
    /// <summary>
    /// MaxDesignAutomationService
    /// </summary>
    public class MaxDesignAutomationService : DesignAutomationService
    {
        /// <summary>
        /// MaxDesignAutomationService
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="forgeConfiguration"></param>
        public MaxDesignAutomationService(string appName, ForgeConfiguration forgeConfiguration = null) :
            base(appName, forgeConfiguration)
        {
        }

        /// <summary>
        /// EngineVersions
        /// </summary>
        public string[] EngineVersions { get; init; }

        /// <summary>
        /// CoreEngineVersions
        /// </summary>
        /// <returns></returns>
        public override string[] CoreEngineVersions()
        {
            return EngineVersions;
        }

        /// <summary>
        /// CoreConsoleExe
        /// </summary>
        /// <returns></returns>
        public override string CoreConsoleExe()
        {
            return DefineDesignAutomation.Max.Core;
        }

        /// <summary>
        /// CoreEngine
        /// </summary>
        /// <returns></returns>
        public override string CoreEngine()
        {
            return DefineDesignAutomation.Max.Engine;
        }
    }
}
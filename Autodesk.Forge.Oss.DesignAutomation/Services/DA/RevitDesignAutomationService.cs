using Autodesk.Forge.Core;
using Autodesk.Forge.Oss.DesignAutomation.Services;

namespace Autodesk.Forge.Oss.DesignAutomation.Services
{
    /// <summary>
    /// RevitDesignAutomationService
    /// </summary>
    public class RevitDesignAutomationService : DesignAutomationService
    {
        /// <summary>
        /// RevitDesignAutomationService
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="forgeConfiguration"></param>
        public RevitDesignAutomationService(string appName, ForgeConfiguration forgeConfiguration = null) : base(appName, forgeConfiguration)
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
            return DefineDesignAutomation.Revit.Core;
        }

        /// <summary>
        /// CoreEngine
        /// </summary>
        /// <returns></returns>
        public override string CoreEngine()
        {
            return DefineDesignAutomation.Revit.Engine;
        }
    }
}
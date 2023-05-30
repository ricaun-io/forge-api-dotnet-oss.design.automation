using Autodesk.Forge.Core;
using Autodesk.Forge.Oss.DesignAutomation.Services;

namespace Autodesk.Forge.Oss.DesignAutomation.Services
{
    /// <summary>
    /// AutoCADDesignAutomationService
    /// </summary>
    public class AutoCADDesignAutomationService : DesignAutomationService
    {
        /// <summary>
        /// AutoCADDesignAutomationService
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="forgeConfiguration"></param>
        public AutoCADDesignAutomationService(string appName, ForgeConfiguration forgeConfiguration = null) : base(appName, forgeConfiguration)
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
            return DefineDesignAutomation.AutoCAD.Core;
        }

        /// <summary>
        /// CoreEngine
        /// </summary>
        /// <returns></returns>
        public override string CoreEngine()
        {
            return DefineDesignAutomation.AutoCAD.Engine;
        }
    }
}
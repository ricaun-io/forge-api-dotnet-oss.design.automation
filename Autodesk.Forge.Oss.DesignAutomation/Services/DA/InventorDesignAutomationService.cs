using Autodesk.Forge.Core;

namespace Autodesk.Forge.Oss.DesignAutomation.Services
{
    /// <summary>
    /// InventorDesignAutomationService
    /// </summary>
    public class InventorDesignAutomationService : DesignAutomationService
    {
        /// <summary>
        /// InventorDesignAutomationService
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="forgeConfiguration"></param>
        public InventorDesignAutomationService(string appName, ForgeConfiguration forgeConfiguration = null) :
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
            return DefineDesignAutomation.Inventor.Core;
        }

        /// <summary>
        /// CoreEngine
        /// </summary>
        /// <returns></returns>
        public override string CoreEngine()
        {
            return DefineDesignAutomation.Inventor.Engine;
        }
    }
}
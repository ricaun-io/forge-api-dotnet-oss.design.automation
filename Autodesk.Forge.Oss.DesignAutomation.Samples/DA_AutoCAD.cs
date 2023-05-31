using Autodesk.Forge.Oss.DesignAutomation.Samples.Models;
using Autodesk.Forge.Oss.DesignAutomation.Services;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Samples
{
    public class DA_AutoCAD
    {
        public static async Task<bool> Test()
        {
            IDesignAutomationService service = new AutoCADDesignAutomationService("ListLayers")
            {
                EngineVersions = new[] { "24" },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
                EnableReportConsoleLogger = true,
            };
            await service.Initialize(@".\DA\DA4ACAD\ListLayers.zip");
            var result = await service.Run<AutoCADParameterOptions>(options =>
            {
                options.InputDwg = @".\DA\DA4ACAD\ListLayers.dwg";
                options.Script = "(command \"LISTLAYERS\")\n";
            });
            await service.Delete();

            return result;
        }
    }
}
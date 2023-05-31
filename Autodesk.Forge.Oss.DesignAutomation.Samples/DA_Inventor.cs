using Autodesk.Forge.Oss.DesignAutomation.Samples.Models;
using Autodesk.Forge.Oss.DesignAutomation.Services;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Samples
{
    public class DA_Inventor
    {
        public static async Task<bool> Test()
        {
            IDesignAutomationService service = new InventorDesignAutomationService("ChangeParam")
            {
                EngineVersions = new[] { "2021" },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
                EnableReportConsoleLogger = true,
            };
            await service.Initialize(@".\DA\DA4Inventor\samplePlugin.bundle.zip");
            var result = await service.Run<InventorParameterOptions>(options =>
            {
                options.InventorDoc = @".\DA\DA4Inventor\box.ipt";
                options.InventorParams = new()
                {
                    height = "16 in",
                    width = "10 in"
                };
            });
            await service.Delete();

            return result;
        }
    }
}
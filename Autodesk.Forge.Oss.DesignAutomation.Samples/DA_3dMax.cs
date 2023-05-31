using Autodesk.Forge.Oss.DesignAutomation.Samples.Models;
using Autodesk.Forge.Oss.DesignAutomation.Services;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Samples
{
    public class DA_3dMax
    {
        public static async Task<bool> Test()
        {
            IDesignAutomationService service = new MaxDesignAutomationService("ExecuteMaxscript")
            {
                EngineVersions = new[] { "2021" },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
                EnableReportConsoleLogger = true,
            };
            var result = await service.Run<MaxParameterOptions>(options =>
            {
                options.InputMaxScene = @".\DA\DA43dsMax\input.zip";
                options.MaxscriptToExecute = @".\DA\DA43dsMax\TwistIt.ms";
            });
            await service.Delete();

            return result;
        }
    }
}
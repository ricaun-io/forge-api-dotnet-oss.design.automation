using Autodesk.Forge.Core;
using Autodesk.Forge.Oss.DesignAutomation.Samples;
using Autodesk.Forge.Oss.DesignAutomation.Samples.Models;
using Autodesk.Forge.Oss.DesignAutomation.Services;
using System;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Test();
            if (false)
            {
                await DA_Revit.Test();
                await DA_Inventor.Test();
                await DA_3dMax.Test();
                await DA_Revit.AllEngines_Test();
            }
        }

        public static async Task Test()
        {
            var Engine = "2021";
            var forgeConfiguration = new ForgeConfiguration()
            {
                ClientId = Environment.GetEnvironmentVariable("FORGE_CLIENT_ID"),
                ClientSecret = Environment.GetEnvironmentVariable("FORGE_CLIENT_SECRET"),
            };

            var service = new RevitDesignAutomationService("Test", forgeConfiguration)
            {
                EngineVersions = new[] { Engine },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
                EnableReportConsoleLogger = true,
                RunTimeOutMinutes = 1,
            };

            await service.Initialize(@".\DA\DA4Revit\DeleteWalls.zip");

            var result = await service.Run<RevitParameterOptions>(options =>
            {
                options.RvtFile = @$".\DA\DA4Revit\DeleteWalls{Engine}.rvt";
                options.Result = @$"Result{Engine}.rvt";
            });

            await service.Delete();
        }
    }
}


using Autodesk.Forge.Oss.DesignAutomation.Samples.Models;
using Autodesk.Forge.Oss.DesignAutomation.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Samples
{
    public class DA_Revit
    {
        public static async Task<bool> Test()
        {
            IDesignAutomationService service = new RevitDesignAutomationService("DeleteWalls")
            {
                EngineVersions = new[] { "2021" },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
            };

            await service.Initialize(@".\DA\DA4Revit\DeleteWalls.zip");
            var result = await service.Run<RevitParameterOptions>(options =>
            {
                options.RvtFile = @".\DA\DA4Revit\DeleteWalls2021.rvt";
                options.Result = @"Result2021.rvt";
            });

            await service.Delete();

            return result;
        }

        public static async Task<bool> AllEngines_Test()
        {
            IDesignAutomationService service = new RevitDesignAutomationService("DeleteWalls")
            {
                EngineVersions = new[] { "2021", "2022", "2023", "2024" },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
            };

            await service.Initialize(@".\DA\DA4Revit\DeleteWalls.zip");

            var tasks = new List<Task<bool>>();
            foreach (var version in service.CoreEngineVersions())
            {
                var task = service.Run<RevitParameterOptions>(options =>
                {
                    options.RvtFile = $@".\DA\DA4Revit\DeleteWalls{version}.rvt";
                    options.Result = $@"Result{version}.rvt";
                }, version);
                tasks.Add(task);
            }

            var results = await Task.WhenAll(tasks);

            await service.Delete();

            return !results.Contains(false);
        }

    }
}
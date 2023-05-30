using Autodesk.Forge.Oss.DesignAutomation.Services;
using Autodesk.Forge.Oss.DesignAutomation.Tests.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Tests
{
    public class DA_Revit_Test
    {
        [Test]
        public async Task DA_Test()
        {
            IDesignAutomationService service = new RevitDesignAutomationService("DeleteWalls")
            {
                EngineVersions = new[] { "2021", "2022", "2023", "2024" },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
            };

            await service.Initialize(@".\DA\DA4Revit\DeleteWalls.zip");
            var result = await service.Run<RevitParameterOptions>(options =>
            {
                options.RvtFile = @".\DA\DA4Revit\DeleteWalls2021.rvt";
                options.Result = @"Result2021.rvt";
            }, "2021");

            await service.Delete();

            Assert.IsTrue(result);
        }

        [Test]
        [Explicit]
        public async Task DA_WhenAll_Test()
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

            Assert.IsFalse(results.Contains(false));
        }

    }
}
using Autodesk.Forge.Oss.DesignAutomation.Services;
using Autodesk.Forge.Oss.DesignAutomation.Tests.Models;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Tests
{
    public class DA_AutoCAD_Test
    {
        [Test]
        public async Task DA_Test()
        {
            IDesignAutomationService service = new AutoCADDesignAutomationService("ListLayers")
            {
                EngineVersions = new[] { "24" },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
            };
            await service.Initialize(@".\DA\DA4ACAD\ListLayers.zip");
            var result = await service.Run<AutoCADParameterOptions>(options =>
            {
                options.InputDwg = @".\DA\DA4ACAD\ListLayers.dwg";
                options.Script = "(command \"LISTLAYERS\")\n";
            });
            await service.Delete();

            Assert.IsTrue(result);
        }
    }
}
using Autodesk.Forge.Oss.DesignAutomation.Services;
using Autodesk.Forge.Oss.DesignAutomation.Tests.Models;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Tests
{
    public class DA_3dMax_Test
    {
        [Test]
        public async Task DA_Test()
        {
            IDesignAutomationService service = new MaxDesignAutomationService("ExecuteMaxscript")
            {
                EngineVersions = new[] { "2021" },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
            };
            var result = await service.Run<MaxParameterOptions>(options =>
            {
                options.InputMaxScene = @".\DA\DA43dsMax\input.zip";
                options.MaxscriptToExecute = @".\DA\DA43dsMax\TwistIt.ms";
            });
            await service.Delete();

            Assert.IsTrue(result);
        }
    }
}
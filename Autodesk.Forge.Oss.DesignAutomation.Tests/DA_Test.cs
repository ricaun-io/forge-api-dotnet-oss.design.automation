using Autodesk.Forge.Core;
using Autodesk.Forge.Oss.DesignAutomation.Extensions;
using Autodesk.Forge.Oss.DesignAutomation.Samples.Models;
using Autodesk.Forge.Oss.DesignAutomation.Services;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Tests
{
    public class DA_Test
    {
        RevitDesignAutomationService service;
        ForgeConfiguration forgeConfiguration;
        string Engine;
        public DA_Test()
        {
            Engine = "2023";
            forgeConfiguration = new ForgeConfiguration()
            {
                ClientId = Environment.GetEnvironmentVariable("FORGE_CLIENT_ID"),
                ClientSecret = Environment.GetEnvironmentVariable("FORGE_CLIENT_SECRET"),
            };
            service = new RevitDesignAutomationService("Test", forgeConfiguration)
            {
                EngineVersions = new[] { Engine },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
                EnableReportConsoleLogger = true,
                RunTimeOutMinutes = 0.1,
            };
        }

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            await service.Initialize(@".\DA\DA4Revit\DeleteWalls.zip");
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await service.Delete();
        }

        [Test]
        public async Task GetNicknameTest()
        {
            Console.WriteLine(await service.GetNicknameAsync());
        }

        [Test(ExpectedResult = false)]
        public async Task<bool> Run_ShouldTimeOut()
        {
            var result = await service.Run<RevitParameterOptions>(options =>
            {
                options.RvtFile = @$".\DA\DA4Revit\DeleteWalls{Engine}.rvt";
                options.Result = @$"Result{Engine}.rvt";
            });
            return result;
        }

        [Explicit]
        [Test]
        public async Task GetEngines()
        {
            var engines = await PageUtils.GetAllItems(service.DesignAutomationClient.GetEnginesAsync);
            foreach (var engine in engines.OrderBy(e => e))
            {
                //Console.WriteLine(engine);
                var engineModel = await service.DesignAutomationClient.GetEngineAsync(engine);
                Console.WriteLine(engineModel.ToJson());
            }
        }
    }
}
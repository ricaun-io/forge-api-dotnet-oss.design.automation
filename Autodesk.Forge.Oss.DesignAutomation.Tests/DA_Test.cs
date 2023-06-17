using Autodesk.Forge.Core;
using Autodesk.Forge.Oss.DesignAutomation.Samples.Models;
using Autodesk.Forge.Oss.DesignAutomation.Services;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Tests
{
    public class DA_Test
    {
        RevitDesignAutomationService service;
        ForgeConfiguration forgeConfiguration;

        public DA_Test()
        {
            forgeConfiguration = new ForgeConfiguration()
            {
                ClientId = Environment.GetEnvironmentVariable("FORGE_CLIENT_ID"),
                ClientSecret = Environment.GetEnvironmentVariable("FORGE_CLIENT_SECRET"),
            };
            service = new RevitDesignAutomationService("Test", forgeConfiguration)
            {
                EngineVersions = new[] { "2021" },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
                EnableReportConsoleLogger = true,
                RunTimeOutMinutes = 0.2
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
                options.RvtFile = @".\DA\DA4Revit\DeleteWalls2021.rvt";
                options.Result = @"Result2021.rvt";
            });
            return result;
        }
    }
}
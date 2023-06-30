using Autodesk.Forge.Core;
using Autodesk.Forge.Oss.DesignAutomation.Samples.Models;
using Autodesk.Forge.Oss.DesignAutomation.Services;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Tests
{
    public class DA_Custom_Test
    {
        ForgeConfiguration forgeConfiguration;
        string Engine;
        public DA_Custom_Test()
        {
            Engine = "2020";
            forgeConfiguration = new ForgeConfiguration()
            {
                ClientId = Environment.GetEnvironmentVariable("FORGE_CLIENT_ID"),
                ClientSecret = Environment.GetEnvironmentVariable("FORGE_CLIENT_SECRET"),
            };
        }

        [Test]
        public void InitializeTest_ShouldFail_DeprecatedEngine()
        {
            var service = new RevitDesignAutomationService("Test_Custom", forgeConfiguration)
            {
                EngineVersions = new[] { Engine },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
                EnableReportConsoleLogger = true,
                RunTimeOutMinutes = 2.0,
                CustomHeaderValue = "x-custom-header: engine value is {0}",
            };

            Assert.CatchAsync<System.Net.Http.HttpRequestException>(async () =>
            {
                await service.Initialize(@".\DA\DA4Revit\DeleteWalls.zip");
            });
        }

        [Explicit]
        [Test]
        public async Task InitializeTest_EnvironmentVariable()
        {
            var service = new RevitDesignAutomationService("Test_Custom", forgeConfiguration)
            {
                EngineVersions = new[] { Engine },
                EnableConsoleLogger = true,
                EnableParameterConsoleLogger = true,
                EnableReportConsoleLogger = true,
                RunTimeOutMinutes = 2.0,
                // CustomHeaderValue = Environment.GetEnvironmentVariable("FORGE_CLIENT_CUSTOM_HEADER_VALUE"),
            };

            await service.Initialize(@".\DA\DA4Revit\DeleteWalls.zip");
            await service.Delete();
        }
    }
}
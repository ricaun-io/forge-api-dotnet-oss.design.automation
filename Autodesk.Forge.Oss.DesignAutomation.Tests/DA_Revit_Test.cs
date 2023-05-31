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
            var result = await Samples.DA_Revit.Test();
            Assert.IsTrue(result);
        }

        [Test]
        [Explicit]
        public async Task DA_WhenAll_Test()
        {
            var result = await Samples.DA_Revit.AllEngines_Test();
            Assert.IsTrue(result);
        }

    }
}
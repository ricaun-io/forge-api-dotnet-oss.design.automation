using NUnit.Framework;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Tests
{
    public class DA_AutoCAD_Test
    {
        [Test]
        public async Task DA_Test()
        {
            var result = await Samples.DA_AutoCAD.Test();
            Assert.IsTrue(result);
        }
    }
}
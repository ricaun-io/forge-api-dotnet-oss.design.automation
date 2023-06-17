using NUnit.Framework;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Tests.SampleTests
{
    public class DA_3dMax_Test
    {
        [Test]
        public async Task DA_Test()
        {
            var result = await Samples.DA_3dMax.Test();
            Assert.IsTrue(result);
        }
    }
}
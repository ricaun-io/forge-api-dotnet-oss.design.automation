using NUnit.Framework;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Tests.SampleTests
{
    public class DA_Inventor_Test
    {
        [Test]
        public async Task DA_Test()
        {
            var result = await Samples.DA_Inventor.Test();
            Assert.IsTrue(result);
        }
    }
}
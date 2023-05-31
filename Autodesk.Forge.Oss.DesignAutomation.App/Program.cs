using Autodesk.Forge.Oss.DesignAutomation.Samples;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await DA_AutoCAD.Test();
            if (false)
            {
                await DA_Revit.Test();
                await DA_Inventor.Test();
                await DA_3dMax.Test();
                await DA_Revit.AllEngines_Test();
            }
        }
    }
}


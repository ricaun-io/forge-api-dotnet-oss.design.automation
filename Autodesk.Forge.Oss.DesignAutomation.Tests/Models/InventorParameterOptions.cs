using Autodesk.Forge.Oss.DesignAutomation.Attributes;

namespace Autodesk.Forge.Oss.DesignAutomation.Tests.Models
{
    public class InventorParameterOptions
    {
        [ParameterActivityInputOpen]
        [ParameterInput("Input.ipt", Required = true)]
        public string InventorDoc { get; set; }
        [ParameterActivityInputArgument]
        [ParameterInput("params.json")]
        public InventorModel InventorParams { get; set; }

        [ParameterOutput("ResultSmall.ipt", DownloadFile = true)]
        public string OutputIpt { get; set; }
        [ParameterOutput("ResultSmall.bmp", DownloadFile = true)]
        public string OutputBmp { get; set; }

        public class InventorModel
        {
            public string height { get; set; }
            public string width { get; set; }
        }
    }

}
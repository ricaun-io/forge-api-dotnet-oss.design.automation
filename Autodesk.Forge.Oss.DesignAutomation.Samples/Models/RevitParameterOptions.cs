﻿using Autodesk.Forge.Oss.DesignAutomation.Attributes;

namespace Autodesk.Forge.Oss.DesignAutomation.Samples.Models
{
    public class RevitParameterOptions
    {
        [ParameterActivityInputOpen]
        [ParameterInput("input.rvt", Required = true)]
        public string RvtFile { get; set; }

        [ParameterOutput("result.rvt", DownloadFile = true)]
        public string Result { get; set; }

        [ParameterWorkItem3LeggedToken]
        string AccessToken { get; set; } = "";
    }
}
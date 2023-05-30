using System;

namespace Autodesk.Forge.Oss.DesignAutomation.Attributes
{
    /// <summary>
    /// ParameterOutputAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ParameterOutputAttribute : Attribute
    {
        /// <summary>
        /// ParameterOutputAttribute
        /// </summary>
        /// <param name="localName"></param>
        public ParameterOutputAttribute(string localName)
        {
            LocalName = localName;
        }
        /// <summary>
        /// Local Name
        /// </summary>
        public string LocalName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Force to Download File
        /// </summary>
        public bool DownloadFile { get; set; } = false;
        /// <summary>
        /// Zip
        /// </summary>
        public bool Zip { get; set; } = false;
    }
}
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
        /// Local Name (Activity)
        /// </summary>
        public string LocalName { get; set; }
        /// <summary>
        /// Description (Activity)
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Force to Download File (WorkItem)
        /// </summary>
        public bool DownloadFile { get; set; } = false;
        /// <summary>
        /// Zip (Activity)
        /// </summary>
        public bool Zip { get; set; } = false;
        /// <summary>
        /// Ondemand (Activity)
        /// </summary>
        public bool Ondemand { get; set; } = false;
    }
}
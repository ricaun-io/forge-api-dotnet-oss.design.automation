using System;

namespace Autodesk.Forge.Oss.DesignAutomation.Attributes
{
    /// <summary>
    /// ParameterInputAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ParameterInputAttribute : Attribute
    {
        /// <summary>
        /// ParameterInputAttribute
        /// </summary>
        /// <param name="localName"></param>
        public ParameterInputAttribute(string localName)
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
        /// Required (Activity)
        /// </summary>
        public bool Required { get; set; } = false;
        /// <summary>
        /// UploadFile
        /// </summary>
        public bool UploadFile { get; set; } = false;
        /// <summary>
        /// Relative File Path inside Zip (WorkItem)
        /// </summary>
        public string ZipPath { get; set; }
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
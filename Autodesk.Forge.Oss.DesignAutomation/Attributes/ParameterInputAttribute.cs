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
        /// Local Name
        /// </summary>
        public string LocalName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Required
        /// </summary>
        public bool Required { get; set; } = false;
        /// <summary>
        /// UploadFile
        /// </summary>
        public bool UploadFile { get; set; } = false;
        /// <summary>
        /// Relative File Path inside Zip 
        /// </summary>
        public string ZipPath { get; set; }
    }
}
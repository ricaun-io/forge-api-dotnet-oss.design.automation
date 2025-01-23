using Autodesk.Forge.DesignAutomation.Model;
using Autodesk.Forge.Oss.DesignAutomation.Extensions;
using System.Runtime.Serialization;

namespace Autodesk.Forge.Oss.DesignAutomation.Attributes
{
    /// <summary>
    /// ParameterWorkItem3LeggedTokenAttribute
    /// </summary>
    /// <remarks>This Attribute is used to add the 'adsk3LeggedToken' in the WorkItem to support Revit Cloud Model.
    /// <code>
    /// This sign the user in to the DA4R using the 3-legged token. (scope=code:all)
    /// https://aps.autodesk.com/blog/design-automation-api-supports-revit-cloud-model
    /// https://aps.autodesk.com/blog/design-automation-api-enforcing-oauth-scope
    /// </code>
    /// </remarks>
    public class ParameterWorkItem3LeggedTokenAttribute : ParameterWorkItemAttribute
    {
        private const string Adsk3LeggedToken = "adsk3LeggedToken";
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workItem"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override WorkItem Update(WorkItem workItem, string name, object value)
        {
            if (value is string valueString && !string.IsNullOrEmpty(valueString))
            {
                workItem.Arguments[Adsk3LeggedToken] = new StringArgument() { Value = valueString };
            }

            return workItem;
        }
    }
}
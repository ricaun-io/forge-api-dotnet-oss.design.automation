using Autodesk.Forge.DesignAutomation.Model;

namespace Autodesk.Forge.Oss.DesignAutomation.Attributes
{
    /// <summary>
    /// ParameterWorkItemStringAttribute
    /// </summary>
    public class ParameterWorkItemStringAttribute : ParameterWorkItemAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterWorkItemStringAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the argument.</param>
        public ParameterWorkItemStringAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workItem"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override WorkItem Update(WorkItem workItem, string name, object value)
        {
            if (value is not null)
            {
                workItem.Arguments[Name] = new StringArgument() { Value = value.ToString() };
            }
            return workItem;
        }
    }
}
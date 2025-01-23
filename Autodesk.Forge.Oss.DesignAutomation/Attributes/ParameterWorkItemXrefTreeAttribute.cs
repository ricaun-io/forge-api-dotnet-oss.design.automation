using Autodesk.Forge.DesignAutomation.Model;

namespace Autodesk.Forge.Oss.DesignAutomation.Attributes
{
    /// <summary>
    /// ParameterWorkItemXrefTreeAttribute
    /// </summary>
    public class ParameterWorkItemXrefTreeAttribute : ParameterWorkItemAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterWorkItemXrefTreeAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the argument.</param>
        public ParameterWorkItemXrefTreeAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Request method (default: Verb.Post)
        /// </summary>
        public Verb Verb { get; set; } = Verb.Post;

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
                workItem.Arguments[Name] = new XrefTreeArgument()
                {
                    Url = value.ToString(),
                    Verb = Verb
                };
            }
            return workItem;
        }
    }
}
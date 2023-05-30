using Autodesk.Forge.DesignAutomation.Model;

namespace Autodesk.Forge.Oss.DesignAutomation.Attributes
{
    /// <summary>
    /// ParameterActivityInputAttribute
    /// </summary>
    public class ParameterActivityInputAttribute : ParameterActivityAttribute
    {
        private readonly string command;

        /// <summary>
        /// ParameterActivityInputAttribute
        /// </summary>
        /// <param name="command"></param>
        public ParameterActivityInputAttribute(string command)
        {
            this.command = command;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override Activity Update(Activity activity, string name, object value)
        {
            var commandLine = $"{command} \"$(args[{name}].path)\"";
            activity.CommandLine.Add(commandLine.Trim());

            return activity;
        }
    }
}
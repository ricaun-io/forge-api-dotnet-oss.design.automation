using Autodesk.Forge.DesignAutomation.Model;

namespace Autodesk.Forge.Oss.DesignAutomation.Attributes
{
    /// <summary>
    /// ParameterActivityLanguageAttribute
    /// </summary>
    public class ParameterActivityLanguageAttribute : ParameterActivityAttribute
    {
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override Activity Update(Activity activity, string name, object value)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return activity;

            var commandLine = $"/l {value}";
            activity.CommandLine.Add(commandLine);

            return activity;
        }
    }
}
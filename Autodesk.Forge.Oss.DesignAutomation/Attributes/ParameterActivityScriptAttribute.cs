using Autodesk.Forge.DesignAutomation.Model;

namespace Autodesk.Forge.Oss.DesignAutomation.Attributes
{
    /// <summary>
    /// ParameterActivityScriptAttribute
    /// </summary>
    public class ParameterActivityScriptAttribute : ParameterActivityAttribute
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
            var commandLine = $"/s \"$(settings[{name}].path)\"";
            activity.CommandLine.Add(commandLine);
            activity.Settings[name] = new StringSetting() { Value = value.ToString() };

            return activity;
        }
    }
}
using Autodesk.Forge.DesignAutomation.Model;
using System.Linq;

namespace Autodesk.Forge.Oss.DesignAutomation.Attributes
{
    /// <summary>
    /// ParameterActivityClearBundleAttribute
    /// </summary>
    public class ParameterActivityClearBundleAttribute : ParameterActivityAttribute
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
            var commandLine = "/al";
            if (activity.CommandLine.Remove(activity.CommandLine.FirstOrDefault(e => e.StartsWith(commandLine))))
            {
                activity.Appbundles.Clear();
            }
            return activity;
        }
    }
}
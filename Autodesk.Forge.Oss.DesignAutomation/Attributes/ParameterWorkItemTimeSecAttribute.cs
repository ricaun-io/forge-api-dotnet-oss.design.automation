using Autodesk.Forge.DesignAutomation.Model;

namespace Autodesk.Forge.Oss.DesignAutomation.Attributes
{
    /// <summary>
    /// ParameterWorkItemTimeSecAttribute
    /// </summary>
    public class ParameterWorkItemTimeSecAttribute : ParameterWorkItemAttribute
    {
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workItem"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override WorkItem Update(WorkItem workItem, string name, object value)
        {
            if (value is int valueInt)
                workItem.LimitProcessingTimeSec = valueInt;

            return workItem;
        }
    }
}
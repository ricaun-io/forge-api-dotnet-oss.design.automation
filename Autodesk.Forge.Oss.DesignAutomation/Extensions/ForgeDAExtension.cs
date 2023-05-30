using Autodesk.Forge.DesignAutomation.Model;
using System;

namespace Autodesk.Forge.Oss.DesignAutomation.Extensions
{
    /// <summary>
    /// ForgeDAExtension
    /// </summary>
    public static class ForgeDAExtension
    {
        /// <summary>
        /// Estimate the costs of a <see cref="WorkItemStatus"/> and update the <see cref="WorkItemStatus.Progress"/> property with the result.
        /// </summary>
        /// <param name="workItemStatus">The work item status to estimate costs for and update.</param>
        /// <returns>The updated <paramref name="workItemStatus"/> with the estimated costs included in the <see cref="WorkItemStatus.Progress"/> property.</returns>
        public static WorkItemStatus ProgressEstimateCosts(this WorkItemStatus workItemStatus)
        {
            workItemStatus.Progress =
                $"EstimateTime: {workItemStatus.EstimateTime()}{Environment.NewLine}" +
                $"EstimateCosts: {workItemStatus.EstimateCosts()}";

            return workItemStatus;
        }

        /// <summary>
        /// Estimate the costs of a <see cref="WorkItemStatus"/> using the provided cost multiplier.
        /// </summary>
        /// <param name="workItemStatus">The work item status to estimate costs for.</param>
        /// <param name="costMultiplier">A multiplier to apply to the calculated costs. The default value is 2.0.</param>
        /// <returns>The estimated costs for the <paramref name="workItemStatus"/>.</returns>
        public static double EstimateCosts(this WorkItemStatus workItemStatus, double costMultiplier = 2.0)
        {
            var costs = workItemStatus.EstimateTime().TotalHours;
            return costs * costMultiplier;
        }

        /// <summary>
        /// EstimateTime
        /// </summary>
        /// <param name="workItemStatus"></param>
        /// <returns></returns>
        public static TimeSpan EstimateTime(this WorkItemStatus workItemStatus)
        {
            if (workItemStatus.Stats is Statistics statistics)
            {
                if (statistics.TimeDownloadStarted is DateTime started)
                {
                    if (statistics.TimeUploadEnded is DateTime ended)
                    {
                        return ended - started;
                    }
                }
            }
            return TimeSpan.Zero;
        }

        /// <summary>
        /// Get Time based in the TimeDownloadStarted
        /// </summary>
        /// <param name="workItemStatus"></param>
        /// <returns></returns>
        public static DateTime GetTimeStarted(this WorkItemStatus workItemStatus)
        {
            if (workItemStatus.Stats is Statistics statistics)
            {
                if (statistics.TimeDownloadStarted is DateTime started)
                {
                    return started;
                }
            }
            return DateTime.MinValue;
        }
    }
}

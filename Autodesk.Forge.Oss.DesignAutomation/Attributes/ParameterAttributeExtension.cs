using Autodesk.Forge.DesignAutomation.Model;

namespace Autodesk.Forge.Oss.DesignAutomation.Attributes
{
    /// <summary>
    /// ParameterAttributeExtension
    /// </summary>
    public static class ParameterAttributeExtension
    {
        /// <summary>
        /// ToParameter
        /// </summary>
        /// <param name="parameterInput"></param>
        /// <returns></returns>
        public static Parameter ToParameter(this ParameterInputAttribute parameterInput)
        {
            return new Parameter()
            {
                LocalName = parameterInput.LocalName,
                Description = parameterInput.Description,
                Verb = Verb.Get,
                Required = parameterInput.Required,
                Zip = parameterInput.Zip,
            };
        }

        /// <summary>
        /// ToParameter
        /// </summary>
        /// <param name="parameterOutput"></param>
        /// <returns></returns>
        public static Parameter ToParameter(this ParameterOutputAttribute parameterOutput)
        {
            return new Parameter()
            {
                LocalName = parameterOutput.LocalName,
                Description = parameterOutput.Description,
                Verb = Verb.Put,
                Zip = parameterOutput.Zip,
            };
        }
    }
}
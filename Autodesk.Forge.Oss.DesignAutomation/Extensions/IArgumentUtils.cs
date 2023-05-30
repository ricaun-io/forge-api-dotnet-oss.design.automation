using Autodesk.Forge.DesignAutomation.Model;

namespace Autodesk.Forge.Oss.DesignAutomation.Extensions
{
    /// <summary>
    /// IArgumentUtils
    /// </summary>
    public static class IArgumentUtils
    {
        /// <summary>
        /// Create a Get Json Argument
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static IArgument ToJsonArgument(string json)
        {
            var argument = new XrefTreeArgument();
            argument.Url = $"data:application/json,{json}";
            argument.Verb = Verb.Get;
            return argument;
        }

        /// <summary>
        /// /// Create a Get Json Argument
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IArgument ToJsonArgument<T>(T value)
        {
            var argument = ToJsonArgument(value.ToJson());
            return argument;
        }

        /// <summary>
        /// Create a Get <paramref name="filePathUrl"/> Argument
        /// </summary>
        /// <param name="filePathUrl"></param>
        /// <returns></returns>
        public static IArgument ToFileArgument(string filePathUrl)
        {
            var argument = new XrefTreeArgument();
            argument.Url = filePathUrl;
            argument.Verb = Verb.Get;
            return argument;
        }

        /// <summary>
        /// Create a <paramref name="verb"/> to <paramref name="urlCallback"/> Argument
        /// </summary>
        /// <param name="urlCallback"></param>
        /// <param name="verb"></param>
        /// <returns></returns>
        public static IArgument ToCallbackArgument(string urlCallback, Verb verb = Verb.Put)
        {
            var argument = new XrefTreeArgument();
            argument.Url = urlCallback;
            argument.Verb = verb;
            return argument;
        }
    }
}
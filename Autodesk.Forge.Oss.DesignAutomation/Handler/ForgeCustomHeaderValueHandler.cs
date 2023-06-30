using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Handler
{
    /// <summary>
    /// ForgeCustomHeaderValueHandler
    /// </summary>
    public class ForgeCustomHeaderValueHandler : DelegatingHandler
    {
        private readonly Func<string> customHeaderValue;
        /// <summary>
        /// ForgeCustomHeaderValueHandler
        /// </summary>
        /// <param name="customHeaderValue"></param>
        public ForgeCustomHeaderValueHandler(Func<string> customHeaderValue = null)
        {
            this.customHeaderValue = customHeaderValue;
        }

        /// <summary>
        /// SendAsync
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (customHeaderValue is not null)
            {
                var headerValue = customHeaderValue();
                if (string.IsNullOrEmpty(headerValue) == false)
                {
                    var values = headerValue.Split(':');
                    if (values.Length == 2)
                    {
                        var header = values[0].Trim();
                        var value = values[1].Trim();
                        request.Headers.Add(header, value);
                    }
                }
            }

            return base.SendAsync(request, cancellationToken);
        }

    }
}
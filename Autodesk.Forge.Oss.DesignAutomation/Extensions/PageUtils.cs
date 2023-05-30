using Autodesk.Forge.DesignAutomation.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autodesk.Forge.Oss.DesignAutomation.Extensions
{
    /// <summary>
    /// PageUtils
    /// </summary>
    public static class PageUtils
    {
        /// <summary>
        /// Asynchronously retrieves a list of all items of type <typeparamref name="T"/> using the specified page getter function.
        /// </summary>
        /// <typeparam name="T">The type of the items to retrieve.</typeparam>
        /// <param name="pageGetter">A function that retrieves a page of items of type <typeparamref name="T"/> given a pagination token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of all items of type <typeparamref name="T"/>.</returns>
        public static async Task<List<T>> GetAllItems<T>(Func<string, Task<Page<T>>> pageGetter)
        {
            var ret = new List<T>();
            string paginationToken = null;
            do
            {
                var resp = await pageGetter(paginationToken);
                paginationToken = resp.PaginationToken;
                ret.AddRange(resp.Data);
            }
            while (paginationToken != null);
            return ret;
        }

        /// <summary>
        /// Asynchronously retrieves a list of all items of type <typeparamref name="T"/> using the specified page getter function and parameter.
        /// </summary>
        /// <typeparam name="T">The type of the items to retrieve.</typeparam>
        /// <typeparam name="P">The type of the parameter to pass to the page getter function.</typeparam>
        /// <param name="pageGetter">A function that retrieves a page of items of type <typeparamref name="T"/> given a parameter of type <typeparamref name="P"/> and a pagination token.</param>
        /// <param name="parameter">The parameter to pass to the page getter function.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of all items of type <typeparamref name="T"/>.</returns>
        public static async Task<List<T>> GetAllItems<T, P>(Func<P, string, Task<Page<T>>> pageGetter, P parameter)
        {
            return await GetAllItems(async page => await pageGetter(parameter, page));
        }
    }
}
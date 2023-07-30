/**************************************************************************
 **
 ** SPDX-FileCopyrightText: © 2016-2023 Jürgen Mülbert
 **
 ** SPDX-License-Identifier: EUPL-1.2
 **
 *************************************************************************/

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Filters
{
	/// <summary>
	/// Async page filter.
	/// </summary>
	public class AsyncPageFilter : IAsyncPageFilter
	{
		/// <summary>
		/// The logger.
		/// </summary>
		private readonly ILogger _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:JMBde.Filters.AsyncPageFilter"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		public AsyncPageFilter(ILogger logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Ons the page handler selection async.
		/// </summary>
		/// <returns>The page handler selection async.</returns>
		/// <param name="context">Context.</param>
		public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
		{
			_logger.LogDebug("Global OnPageHandlerSelectionAsync called.");
			await Task.CompletedTask.ConfigureAwait(false);
		}

		/// <summary>
		/// Ons the page handler execution async.
		/// </summary>
		/// <returns>The page handler execution async.</returns>
		/// <param name="context">Context.</param>
		/// <param name="next">Next.</param>
		public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
													  PageHandlerExecutionDelegate next)
		{
			_logger.LogDebug("Global OnPageHandlerExecutionAsync called.");
			await next.Invoke().ConfigureAwait(false);
		}
	}
}
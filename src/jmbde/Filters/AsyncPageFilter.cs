/**************************************************************************
 **
 ** Copyright (c) 2016-2019 Jürgen Mülbert. All rights reserved.
 **
 ** This file is part of jmbde
 **
 ** Licensed under the EUPL, Version 1.2 or – as soon they
 ** will be approved by the European Commission - subsequent
 ** versions of the EUPL (the "Licence");
 ** You may not use this work except in compliance with the
 ** Licence.
 ** You may obtain a copy of the Licence at:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Unless required by applicable law or agreed to in
 ** writing, software distributed under the Licence is
 ** distributed on an "AS IS" basis,
 ** WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 ** express or implied.
 ** See the Licence for the specific language governing
 ** permissions and limitations under the Licence.
 **
 ** Lizenziert unter der EUPL, Version 1.2 oder - sobald
 **  diese von der Europäischen Kommission genehmigt wurden -
 ** Folgeversionen der EUPL ("Lizenz");
 ** Sie dürfen dieses Werk ausschließlich gemäß
 ** dieser Lizenz nutzen.
 ** Eine Kopie der Lizenz finden Sie hier:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Sofern nicht durch anwendbare Rechtsvorschriften
 ** gefordert oder in schriftlicher Form vereinbart, wird
 ** die unter der Lizenz verbreitete Software "so wie sie
 ** ist", OHNE JEGLICHE GEWÄHRLEISTUNG ODER BEDINGUNGEN -
 ** ausdrücklich oder stillschweigend - verbreitet.
 ** Die sprachspezifischen Genehmigungen und Beschränkungen
 ** unter der Lizenz sind dem Lizenztext zu entnehmen.
 **
 **************************************************************************/

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Filters {
    /// <summary>
    /// Async page filter.
    /// </summary>
    public class AsyncPageFilter : IAsyncPageFilter {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMBde.Filters.AsyncPageFilter"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        public AsyncPageFilter (ILogger logger) {
            _logger = logger;
        }

        /// <summary>
        /// Ons the page handler selection async.
        /// </summary>
        /// <returns>The page handler selection async.</returns>
        /// <param name="context">Context.</param>
        public async Task OnPageHandlerSelectionAsync (
            PageHandlerSelectedContext context) {
            _logger.LogDebug ("Global OnPageHandlerSelectionAsync called.");
            await Task.CompletedTask.ConfigureAwait (false);
        }

        /// <summary>
        /// Ons the page handler execution async.
        /// </summary>
        /// <returns>The page handler execution async.</returns>
        /// <param name="context">Context.</param>
        /// <param name="next">Next.</param>
        public async Task OnPageHandlerExecutionAsync (
            PageHandlerExecutingContext context,
            PageHandlerExecutionDelegate next) {
            _logger.LogDebug ("Global OnPageHandlerExecutionAsync called.");
            await next.Invoke ().ConfigureAwait (false);
        }
    }
}

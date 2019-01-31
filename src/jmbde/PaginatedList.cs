/**************************************************************************
 **
 ** Copyright (c) 2016-2018 Jürgen Mülbert. All rights reserved.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JMuelbert.BDE {
    /// <summary>
    /// Paginated list.
    /// </summary>
    public class PaginatedList<T> : List<T> {

        /// <summary>
        /// Gets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        public int PageIndex { get; private set; }

        /// <summary>
        /// Gets the total pages.
        /// </summary>
        /// <value>The total pages.</value>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMBde.PaginatedList`1"/> class.
        /// </summary>
        /// <param name="items">Items.</param>
        /// <param name="count">Count.</param>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        public PaginatedList (List<T> items, int count, int pageIndex, int pageSize) {
            PageIndex = pageIndex;
            TotalPages = (int) Math.Ceiling (count / (double) pageSize);

            this.AddRange (items);
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:JMBde.PaginatedList`1"/> has previous page.
        /// </summary>
        /// <value><c>true</c> if has previous page; otherwise, <c>false</c>.</value>
        public bool HasPreviousPage {
            get {
                return (PageIndex > 1);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:JMBde.PaginatedList`1"/> has next page.
        /// </summary>
        /// <value><c>true</c> if has next page; otherwise, <c>false</c>.</value>
        public bool HasNextPage {
            get {
                return (PageIndex < TotalPages);
            }
        }

        /// <summary>
        /// Creates the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="source">Source.</param>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        public static async Task<PaginatedList<T>> CreateAsync (
            IQueryable<T> source, int pageIndex, int pageSize) {
            var count = await source.CountAsync ();
            var items = await source.Skip (
                    (pageIndex - 1) * pageSize)
                .Take (pageSize).ToListAsync ();
            return new PaginatedList<T> (items, count, pageIndex, pageSize);
        }
    }
}

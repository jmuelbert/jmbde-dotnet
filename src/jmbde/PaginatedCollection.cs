/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
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
  public class PaginatedCollection<T> : List<T> {
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
    /// Initializes a new instance of the <see cref="T:JMBde.PaginatedCollection`1"/> class.
    /// </summary>
    /// <param name="items">Items.</param>
    /// <param name="count">Count.</param>
    /// <param name="pageIndex">Page index.</param>
    /// <param name="pageSize">Page size.</param>
    public PaginatedCollection(List<T> items, int count, int pageIndex, int pageSize) {
      PageIndex = pageIndex;
      TotalPages = (int)Math.Ceiling(count / (double)pageSize);

      this.AddRange(items);
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:JMBde.PaginatedCollection`1"/> has
    /// previous page.
    /// </summary>
    /// <value><c>true</c> if has previous page; otherwise, <c>false</c>.</value>
    public bool HasPreviousPage {
      get { return (PageIndex > 1); }
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:JMBde.PaginatedCollection`1"/> has next
    /// page.
    /// </summary>
    /// <value><c>true</c> if has next page; otherwise, <c>false</c>.</value>
    public bool HasNextPage {
      get { return (PageIndex < TotalPages); }
    }

    /// <summary>
    /// Creates the async.
    /// </summary>
    /// <returns>The async.</returns>
    /// <param name="source">Source.</param>
    /// <param name="pageIndex">Page index.</param>
    /// <param name="pageSize">Page size.</param>
    public static async Task<PaginatedCollection<T>> CreateAsync(IQueryable<T> source,
                                                                 int pageIndex, int pageSize) {
      var count = await source.CountAsync().ConfigureAwait(false);
      var items = await source.Skip((pageIndex - 1) * pageSize)
                      .Take(pageSize)
                      .ToListAsync()
                      .ConfigureAwait(false);
      return new PaginatedCollection<T>(items, count, pageIndex, pageSize);
    }
  }
}

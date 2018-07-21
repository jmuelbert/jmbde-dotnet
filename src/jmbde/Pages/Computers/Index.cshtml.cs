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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Models;

namespace jmbde.Pages.Computers
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Models.JMBDEContext _context;

        public IndexModel(jmbde.Models.JMBDEContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string ActiveSort { get; set; }
        public string ReplaceSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Computer> Computer { get;set; }

        public async Task OnGetAsync(string sortOrder, 
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
            ReplaceSort = sortOrder == "Replace" ? "replace_desc" : "Replace";
            LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_sort" : "LastUpdate";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Computer> computerIQ = from c in _context.Computer
                            select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                computerIQ = computerIQ.Where(comp => comp.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    computerIQ = computerIQ.OrderByDescending(c => c.Name);
                    break;

               case "Active":
                    computerIQ = computerIQ.OrderBy(c => c.Active);
                    break;

               case "active_desc":
                    computerIQ = computerIQ.OrderByDescending(c => c.Active);
                    break;

               case "Replace":
                    computerIQ = computerIQ.OrderBy(c => c.Replace);
                    break;

               case "replace_desc":
                    computerIQ = computerIQ.OrderByDescending(c => c.Replace);
                    break;

               case "LastUpdate":
                    computerIQ = computerIQ.OrderBy(c => c.LastUpdate);
                    break;

               case "lastupdate_desc":
                    computerIQ = computerIQ.OrderByDescending(c => c.LastUpdate);
                    break;

                default:
                    computerIQ = computerIQ.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 10;
            Computer = await PaginatedList<Computer>.CreateAsync(
                computerIQ.AsNoTracking(), pageIndex ?? 1, pageSize
            );
        }
    }
}

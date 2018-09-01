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
using jmbdeData.Models;

namespace jmbde.Pages.Faxes
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public string NumberSort { get; set; }
        public string ActiveSort { get; set; }
        public string ReplaceSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Fax> Fax { get;set; }

           public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
            {
            CurrentSort = sortOrder;
            NumberSort = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
            ReplaceSort = sortOrder == "Replace" ? "replace_desc" : "Replace";
            LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_desc" : "LastUpdate";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Fax> faxIQ = from f in _context.Fax
                    select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                faxIQ = faxIQ.Where(fax => fax.Number.Contains(searchString));
            }

           switch (sortOrder)
           {
                case "number_desc":
                    faxIQ = faxIQ.OrderByDescending(f => f.Number);
                    break;

                case "Active":
                    faxIQ = faxIQ.OrderBy(f => f.Active);
                    break;

                case "active_desc":
                    faxIQ = faxIQ.OrderByDescending(f => f.Active);
                    break;

                case "Replace":
                    faxIQ = faxIQ.OrderBy(f => f.Replace);
                    break;

                case "replace_desc":
                    faxIQ = faxIQ.OrderByDescending(f => f.Replace);
                    break;
                    
                case "LastUpdate":
                    faxIQ = faxIQ.OrderBy(f => f.LastUpdate);
                    break;
                case "lastupdate_desc":
                    faxIQ = faxIQ.OrderByDescending(f => f.LastUpdate);
                    break;

                default:
                    faxIQ = faxIQ.OrderBy(d => d.Number);
                    break;
           }

           int pageSize = 10;
           Fax = await PaginatedList<Fax>.CreateAsync(
               faxIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        }
    }
}

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

namespace jmbde.Pages.Inventories
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Models.JMBDEContext _context;

        public IndexModel(jmbde.Models.JMBDEContext context)
        {
            _context = context;
        }

        public string IdentifierSort { get; set; }
        public string DescriptionSort { get; set; }

        public string ActiveSort { get; set; }        
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Inventory> Inventory { get;set; }

        public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            IdentifierSort = String.IsNullOrEmpty(sortOrder) ? "identifier_desc" : "";
            DescriptionSort = sortOrder == "Description" ? "description_desc" : "Description";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
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

            IQueryable<Inventory> inventoryIQ = from i in _context.Inventory
                        select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                inventoryIQ = inventoryIQ.Where(inv => inv.Identifier.Contains(searchString));
            }

         switch (sortOrder)
           {
                case "identifier_desc":
                    inventoryIQ = inventoryIQ.OrderByDescending(i => i.Identifier);
                    break;

                case "Description":
                    inventoryIQ = inventoryIQ.OrderBy(i => i.Description);
                    break;

                case "description_desc":
                    inventoryIQ = inventoryIQ.OrderByDescending(i => i.Description);
                    break;

                case "Active":
                    inventoryIQ = inventoryIQ.OrderBy(i => i.Active);
                    break;

                case "active_desc":
                    inventoryIQ = inventoryIQ.OrderByDescending(i => i.Active);
                    break;
                    
                case "LastUpdate":
                    inventoryIQ = inventoryIQ.OrderBy(i => i.LastUpdate);
                    break;
                case "lastupdate_desc":
                    inventoryIQ = inventoryIQ.OrderByDescending(i => i.LastUpdate);
                    break;

                default:
                    inventoryIQ = inventoryIQ.OrderBy(i => i.Identifier);
                    break;
           }
 
           int pageSize = 10;
           Inventory = await PaginatedList<Inventory>.CreateAsync(
                inventoryIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        }
    }
}

/**************************************************************************
 **
 ** Copyright (c) 2016-2020 Jürgen Mülbert. All rights reserved.
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
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

// TODO: Change the use of SystemAccount

namespace JMuelbert.BDE.Shared.Models {
  /// <summary>
  /// Employee.
  /// </summary>
  public partial class Employee : Person {
    /// <summary>
    /// Gets or sets the employee identifier.
    /// </summary>
    /// <value>The employee identifier.</value>
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets the employee ident.
    /// </summary>
    /// <value>The employee ident.</value>
    public string EmployeeIdent { get; set; }

    /// <summary>
    /// Gets or sets the job title.
    /// </summary>
    /// <value>The job title.</value>
    public JobTitle JobTitle { get; set; }

    /// <summary>
    /// Gets or sets the business mail address.
    /// </summary>
    /// <value>The business mail address.</value>
    [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                  MinimumLength = 5)]
    [DataType(DataType.EmailAddress)]
    public string BusinessMailAddress {
      get; set;
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see
    /// cref="T:JMuelbert.BDE.Shared.Models.Employee"/> data care.
    /// </summary>
    /// <value><c>true</c> if data care; otherwise, <c>false</c>.</value>
    public bool DataCare { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see
    /// cref="T:JMuelbert.BDE.Shared.Models.Employee"/> is active.
    /// </summary>
    /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
    [Display(Name = "Active")]
    public bool IsActive {
      get; set;
    }

    /// <summary>
    /// Gets or sets the notes.
    /// </summary>
    /// <value>The notes.</value>
    [DataType(DataType.MultilineText)]
    public string Notes {
      get; set;
    }

    /// <summary>
    /// Gets or sets the hire date.
    /// </summary>
    /// <value>The hire date.</value>
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Hire Date")]
    public DateTime HireDate {
      get; set;
    }

    /// <summary>
    /// Gets or sets the end date.
    /// </summary>
    /// <value>The end date.</value>
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "End Date")]
    public DateTime EndDate {
      get; set;
    }

    /// <summary>
    /// Gets or sets the department.
    /// </summary>
    /// <value>The department.</value>
    public Department Department { get; set; }

    /// <summary>
    /// Gets or sets the function.
    /// </summary>
    /// <value>The function.</value>
    public ICollection<WorkFunction> WorkFunction { get; set; }

    /// <summary>
    /// Gets or sets the computer.
    /// </summary>
    /// <value>The computer.</value>
    public ICollection<Computer> Computer { get; set; }

    /// <summary>
    /// Gets or sets the printer.
    /// </summary>
    /// <value>The printer.</value>
    public ICollection<Printer> Printer { get; set; }

    /// <summary>
    /// Gets or sets the phone.
    /// </summary>
    /// <value>The phone.</value>
    public Phone Phone { get; set; }

    /// <summary>
    /// Gets or sets the mobile.
    /// </summary>
    /// <value>The mobile.</value>
    public Mobile Mobile { get; set; }

    /// <summary>
    /// Gets or sets the fax.
    /// </summary>
    /// <value>The fax.</value>
    public Fax Fax { get; set; }

    /// <summary>
    /// Gets or sets the system account.
    /// </summary>
    /// <value>The system account.</value>
    public ICollection<SystemAccount> SystemAccount { get; set; }

    /// <summary>
    /// Gets or sets the document.
    /// </summary>
    /// <value>The document.</value>
    public ICollection<Document> Document { get; set; }

    /// <summary>
    /// Gets or sets the chip card.
    /// </summary>
    /// <value>The chip card.</value>
    public ChipCard ChipCard { get; set; }

    /// <summary>
    /// Gets or sets the last update.
    /// </summary>
    /// <value>The last update.</value>
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Last Update")]
    public DateTime LastUpdate {
      get; set;
    }

    [Display(Name = "Full Name")]
    public string FullName {
      get { return LastName + ", " + FirstName; }
    }

    public string DumpAsJson() {
      var jsonString = JsonSerializer.Serialize<Employee>(this);
      return jsonString;
    }
  }
}

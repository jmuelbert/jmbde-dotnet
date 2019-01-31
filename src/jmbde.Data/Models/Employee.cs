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
using System.ComponentModel.DataAnnotations;

// TODO: Change the use of SystemAccount

namespace JMuelbert.BDE.Data.Models
{
    /// <summary>
    /// Gender.
    /// </summary>
    public enum Gender {
        F,
        M
    }

    /// <summary>
    /// Employee.
    /// </summary>
    public partial class Employee {

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the employee ident.
        /// </summary>
        /// <value>The employee ident.</value>
        public string EmployeeIdent { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>The job title.</value>
        public JobTitle JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [StringLength (50, ErrorMessage = "Firstname cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Required]
        [StringLength (50, ErrorMessage = "Lastname cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birth day.
        /// </summary>
        /// <value>The birth day.</value>
        [DataType (DataType.Date)]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        [Required]
        [StringLength (50, ErrorMessage = "Street cannot be longer than 50 characters.")]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        public ZipCode ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the home phone.
        /// </summary>
        /// <value>The home phone.</value>
        [StringLength (50, ErrorMessage = "Phone Number cannot be longer than 50 characters.")]
        [DataType (DataType.PhoneNumber)]
        public string HomePhone { get; set; }

        /// <summary>
        /// Gets or sets the home mobile.
        /// </summary>
        /// <value>The home mobile.</value>
        [StringLength (50, ErrorMessage = "Mobile Number cannot be longer than 50 characters.")]
        [DataType (DataType.PhoneNumber)]
        public string HomeMobile { get; set; }

        /// <summary>
        /// Gets or sets the home mail address.
        /// </summary>
        /// <value>The home mail address.</value>
        [StringLength (50, ErrorMessage = "Mail Address cannot be longer than 50 characters.")]
        [DataType (DataType.EmailAddress)]
        public string HomeMailAddress { get; set; }

        /// <summary>
        /// Gets or sets the business mail address.
        /// </summary>
        /// <value>The business mail address.</value>
        [StringLength (50, ErrorMessage = "Mail Address cannot be longer than 50 characters.")]
        [DataType (DataType.EmailAddress)]
        public string BusinessMailAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:JMuelbert.BDE.Data.Models.Employee"/> data care.
        /// </summary>
        /// <value><c>true</c> if data care; otherwise, <c>false</c>.</value>
        public bool DataCare { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:JMuelbert.BDE.Data.Models.Employee"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        /// <value>The photo.</value>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [DataType (DataType.MultilineText)]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the hire date.
        /// </summary>
        /// <value>The hire date.</value>
        [DataType (DataType.Date)]
        public DateTime HireDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        [DataType (DataType.Date)]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        public Department Department { get; set; }

        /// <summary>
        /// Gets or sets the function.
        /// </summary>
        /// <value>The function.</value>
        public ICollection<Function> Function { get; set; }

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
        [DataType (DataType.DateTime)]
        public DateTime LastUpdate { get; set; }

    }
}

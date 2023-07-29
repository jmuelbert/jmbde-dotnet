/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using JMuelbert.BDE.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace JMuelbert.BDE.Shared.Data
{
	/// <summary>
	/// JMBDEContext.
	/// </summary>
	public class BDEContext : DbContext
	{
		/// <summary>
		/// Gets or sets the chip card.
		/// </summary>
		/// <value>The chip card.</value>
		public virtual DbSet<ChipCard> ChipCard { get; set; }

		/// <summary>
		/// Gets or sets the chip card door.
		/// </summary>
		/// <value>The chip card door.</value>
		public virtual DbSet<ChipCardDoor> ChipCardDoor { get; set; }

		/// <summary>
		/// Gets or sets the chip card profile.
		/// </summary>
		/// <value>The chip card profile.</value>
		public virtual DbSet<ChipCardProfile> ChipCardProfile { get; set; }

		/// <summary>
		/// Gets or sets the name of the city.
		/// </summary>
		/// <value>The name of the city.</value>
		public virtual DbSet<CityName> CityName { get; set; }

		/// <summary>
		/// Gets or sets the company.
		/// </summary>
		/// <value>The company.</value>
		public virtual DbSet<Company> Company { get; set; }

		/// <summary>
		/// Gets or sets the computer.
		/// </summary>
		/// <value>The computer.</value>
		public virtual DbSet<Computer> Computer { get; set; }

		/// <summary>
		/// Gets or sets the department.
		/// </summary>
		/// <value>The department.</value>
		public virtual DbSet<Department> Department { get; set; }

		/// <summary>
		/// Gets or sets the name of the device.
		/// </summary>
		/// <value>The name of the device.</value>
		public virtual DbSet<DeviceName> DeviceName { get; set; }

		/// <summary>
		/// Gets or sets the type of the device.
		/// </summary>
		/// <value>The type of the device.</value>
		public virtual DbSet<DeviceType> DeviceType { get; set; }

		/// <summary>
		/// Gets or sets the document.
		/// </summary>
		/// <value>The document.</value>
		public virtual DbSet<Document> Document { get; set; }

		/// <summary>
		/// Gets or sets the employee.
		/// </summary>
		/// <value>The employee.</value>
		public virtual DbSet<Employee> Employee { get; set; }

		/// <summary>
		/// Gets or sets the fax.
		/// </summary>
		/// <value>The fax.</value>
		public virtual DbSet<Fax> Fax { get; set; }

		/// <summary>
		/// Gets or sets the function.
		/// </summary>
		/// <value>The function.</value>
		public virtual DbSet<WorkFunction> WorkFunction { get; set; }

		/// <summary>
		/// Gets or sets the inventory.
		/// </summary>
		/// <value>The inventory.</value>
		public virtual DbSet<Inventory> Inventory { get; set; }

		/// <summary>
		/// Gets or sets the manufacturer.
		/// </summary>
		/// <value>The manufacturer.</value>
		public virtual DbSet<Manufacturer> Manufacturer { get; set; }

		/// <summary>
		/// Gets or sets the mobile.
		/// </summary>
		/// <value>The mobile.</value>
		public virtual DbSet<Mobile> Mobile { get; set; }

		/// <summary>
		/// Gets or sets the phone.
		/// </summary>
		/// <value>The phone.</value>
		public virtual DbSet<Phone> Phone { get; set; }

		/// <summary>
		/// Gets or sets the place.
		/// </summary>
		/// <value>The place.</value>
		public virtual DbSet<Place> Place { get; set; }

		/// <summary>
		/// Gets or sets the printer.
		/// </summary>
		/// <value>The printer.</value>
		public virtual DbSet<Printer> Printer { get; set; }

		/// <summary>
		/// Gets or sets the processor.
		/// </summary>
		/// <value>The processor.</value>
		public virtual DbSet<Processor> Processor { get; set; }

		/// <summary>
		/// Gets or sets the software.
		/// </summary>
		/// <value>The software.</value>
		public virtual DbSet<Software> Software { get; set; }

		/// <summary>
		/// Gets or sets the system account.
		/// </summary>
		/// <value>The system account.</value>
		public virtual DbSet<SystemAccount> SystemAccount { get; set; }

		/// <summary>
		/// Gets or sets the system data.
		/// </summary>
		/// <value>The system data.</value>
		public virtual DbSet<SystemData> SystemData { get; set; }

		/// <summary>
		/// Gets or sets the job title.
		/// </summary>
		/// <value>The job title.</value>
		public virtual DbSet<JobTitle> JobTitle { get; set; }

		/// <summary>
		/// Gets or sets the zip code.
		/// </summary>
		/// <value>The zip code.</value>
		public virtual DbSet<ZipCode> ZipCode { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:BDEContext"/> class.
		/// </summary>
		/// <param name="options">Options.</param>
		public BDEContext(DbContextOptions<BDEContext> options) : base(options) { }

		/// <summary>
		/// Ons the configuring.
		/// </summary>
		/// <param name="optionsBuilder">Options builder.</param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// if (!optionsBuilder.IsConfigured) {
			//     optionsBuilder.UseInMemoryDatabase("BDEdb");
			// }
		}
	}
}

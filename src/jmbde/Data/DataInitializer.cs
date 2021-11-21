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
using System.Linq;
using Bogus;
using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;

namespace JMuelbert.BDE.Shared.Data
{
	public static class DataInitializer
	{
		public static void Initialize(BDEContext bdeContext)
		{
			Randomizer.Seed = new Random(867530);

			if (bdeContext.Employee.Count() == 0)
			{
				// Create text data
				var testEmployees = new Faker<Employee>()
					.RuleFor(e => e.FirstName, (e, f) => f.FirstName)
					//Optional: After all rules are applied finish with the following action
					.FinishWith((e, f) =>
					{
						Console.WriteLine("User Created! Id={0}", f.ID);
					});

				var employee = testEmployees.Generate();
				Console.WriteLine(employee.DumpAsJson());
			}

		}

		public static void CreatePathForDB()
		{

		}
	}
}

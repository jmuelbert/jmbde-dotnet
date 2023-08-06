/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System;
using System.Linq;
using Bogus;
using JMuelbert.BDE.Shared.Models;

namespace JMuelbert.BDE.Shared.Data
{
    public static class DataInitializer
    {
        public static void Initialize(BDEContext bdeContext)
        {
            Randomizer.Seed = new Random(867530);

            if (!bdeContext.Employee.Any())
            {
                // Create text data
                var testEmployees =
                    new Faker<Employee>()
                        .RuleFor(e => e.FirstName, (e, f) => f.FirstName)
                        // Optional: After all rules are applied finish with the following action
                        .FinishWith((e, f) => { Console.WriteLine("User Created! Id={0}", f.ID); });

                var employee = testEmployees.Generate();
                Console.WriteLine(employee.DumpAsJson());
            }
        }

        public static void CreatePathForDB() { }
    }
}
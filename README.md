# JMBde Application

[![GitHub license](https://img.shields.io/badge/license-EUPL-blue.svg)](https://joinup.ec.europa.eu/page/eupl-text-11-12)
[![AppVeyor](https://ci.appveyor.com/api/projects/status/ja8a7j6jscj7k3xa/branch/master?svg=true)](https://ci.appveyor.com/project/jmuelbert/jmbde-aspnet)
[![Build Status](https://travis-ci.org/jmuelbert/jmbde-aspnet.svg?branch=master)](https://travis-ci.org/jmuelbert/jmbde-aspnet)

jmbde is a program to collect data for the IT. The database contains employees, departments, functions, phones, mobiles, computers, printers, faxes and accounts.

jmbde is free software; you can redistribute ot and/or modify ir under the terms
of the [European Public License Version 1.2](https://joinup.ec.europa.eu/page/eupl-text-11-12).
Please read the [LICENSE](https://github.com/jmuelbert/jmbde-aspnet/blob/master/LICENSE) for additional information.

The master branch represents the latest pre-release code.

- [Releases](https://github.com/jmuelbert/jmbde-aspnet/releases)

- [Milestones](https://github.com/jmuelbert/jmbde-aspnet/milestones)

## Requests and Bug reports

- [GitHub issues (preferred)](https://github.com/jmuelbert/jmbde-aspnet/issues)

## Questions or Comments

## Wiki

- [Main Page](https://github.com/jmuelbert/jmbde-aspnet/wiki)
- [User Manual](http://jmuelbert.github.io/jmbde-aspnet/)

## Building

### Requirments

#### For Windows

- [.NET Core SDK 2.2 for Windows](https://www.microsoft.com/net/download/windows)

#### For Linux

- [.NET Core SDK 2.2 for Linux](https://www.microsoft.com/net/download/linux)

#### For Mac

- [.NET Core SDK 2.2 for MacOS](https://www.microsoft.com/net/download/macos)

## Prepare the App

### Windows

- Open a command prompt and cd `src\jmbde`.
- Run `dotnet build`
- Run `dotnet ef database update`- Create a new blank database.

### Linux or macOS

- Open a command prompt and execute `cd src/jmbde`.
- Run `dotnet build`
- Run `dotnet ef database update`- Create a new blank database.

## Run the jmbde App

### Run on Windows

- Open a command prompt and cd `src\jmbde`.
- Run `dotnet run` (This hosts the app in a console application - Application started at URL **`http://localhost:5000/`**).

### Run on Linux or macOS

- Open a command prompt and excute `cd src/jmbde`.
- Try run `dotnet run` (This hosts the app in a console application - Application started at URL **`http://localhost:5000/`**).

## Publish the jmbde App

### Publish on Windows

- Open a command prompt and cd `src\jmbde`.
- Run `dotnet publish -c Release -o [RELEASEDIRECTORY]`

### Publish on Linux or macOS

- Open a command prompt and excute `cd src/jmbde`.
- Run `dotnet publish -c Release -o [RELEASEDIRECTORY]`

## License

EUPL-1.2 © [Jürgen Mülbert](https://github.com/jmuelbert/jmbde-aspnet/blob/master/LICENSE)

[Return to top](#top)

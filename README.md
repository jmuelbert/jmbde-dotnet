# JMBde Application

[![Gitpod-Ready-Code](https://img.shields.io/badge/Gitpod-Ready--to--Code-blue?logo=gitpod)](https://gitpod.io/#https://github.com/jmuelbert/jmbde-aspnet)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/c63d1cf887384176977da4e7ba43495e)](https://app.codacy.com/manual/jmuelbert/jmbde-aspnet?utm_source=github.com&utm_medium=referral&utm_content=jmuelbert/jmbde-aspnet&utm_campaign=Badge_Grade_Dashboard)
[![Total alerts](https://img.shields.io/lgtm/alerts/g/jmuelbert/jmbde-aspnet.svg?logo=lgtm&logoWidth=18)](https://lgtm.com/projects/g/jmuelbert/jmbde-aspnet/alerts/)
[![Language grade: JavaScript](https://img.shields.io/lgtm/grade/javascript/g/jmuelbert/jmbde-aspnet.svg?logo=lgtm&logoWidth=18)](https://lgtm.com/projects/g/jmuelbert/jmbde-aspnet/context:javascript)
[![Language grade: C#](https://img.shields.io/lgtm/grade/csharp/g/jmuelbert/jmbde-aspnet.svg?logo=lgtm&logoWidth=18)](https://lgtm.com/projects/g/jmuelbert/jmbde-aspnet/context:csharp)
[![GitHub All Releases](https://img.shields.io/github/downloads/jmuelbert/jmbde-aspnet/total?label=downloads%40all)](https://github.com/jmuelbert/jmbde-aspnet/releases)
[![GitHub license](https://img.shields.io/badge/license-EUPL-blue.svg)](https://joinup.ec.europa.eu/page/eupl-text-11-12)
[![Build status](https://ci.appveyor.com/api/projects/status/ja8a7j6jscj7k3xa/branch/master?svg=true)](https://ci.appveyor.com/project/jmuelbert/jmbde-aspnet)
![Misspell fixer](https://github.com/jmuelbert/jmbde-aspnet/workflows/Misspell%20fixer/badge.svg)
[![pre-commit](https://img.shields.io/badge/pre--commit-enabled-brightgreen?logo=pre-commit&logoColor=white)](https://github.com/pre-commit/pre-commit)

[Features](https://github.com/jmuelbert/jmbde-aspnet) | [Documentation](https://jmuelbert.github.io/jmbde-aspnet/) | [Changelog](CHANGELOG.md) | [Contributing](CONTRIBUTING.md) | [FAQ](https://github.com/jmuelbert/jmbde-aspnet/wiki/FAQ) | [deutPsch](README_de-DE.md)

jmbde is a program to collect data for the IT. The database contains employees, departments, functions, phones, mobiles, computers, printers, faxes and accounts.

|  type  |                           branch                            |                                                                                                        build                                                                                                         |                                                                     downloads                                                                      |
| :----: | :---------------------------------------------------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: | :------------------------------------------------------------------------------------------------------------------------------------------------: |
| alpha  | [master](https://github.com/jmuelbert/jmbde-aspnet/tree/master) | [![GitHub Workflow Status](https://github.com/jmuelbert/jmbde-aspnet/workflows/CI:%20Build%20Test/badge.svg?branch=master&event=push)](https://github.com/jmuelbert/jmbde-aspnet/actions?query=event%3Apush+branch%3Amaster) |                                                                         -                                                                          |
|  beta  | [v0.4.0-alpha](https://github.com/jmuelbert/jmbde-aspnet/tree/v0.4.0-alpha) | [![GitHub Workflow Status](https://github.com/jmuelbert/jmbde-aspnet/workflows/CI:%20Build%20Test/badge.svg?branch=v0.4.0-alpha&event=push)](https://github.com/jmuelbert/jmbde-aspnet/actions?query=event%3Apush+branch%3Av0.4.0-alpha) | [![Downloads](https://img.shields.io/github/downloads/jmuelbert/jmbde-aspnet/v0.4.0-alpha/total)](https://github.com/jmuelbert/jmbde-aspnet/releases/tag/v0.4.0-alpha) |
| stable | [v0.4.0](https://github.com/jmuelbert/jmbde-aspnet/tree/v0.4.0) | [![GitHub Workflow Status](https://github.com/jmuelbert/jmbde-aspnet/workflows/CI:%20Build%20Test/badge.svg?branch=v0.4.0&event=push)](https://github.com/jmuelbert/jmbde-aspnet/actions?query=event%3Apush+branch%3v0.4.0)  | [![Downloads](https://img.shields.io/github/downloads/jmuelbert/jmbde-aspnet/v0.4.0/total)](https://github.com/jmuelbert/jmbde-aspnet/releases/tag/v0.4.0)

## Setup

## Supported platforms

## Execute

Below are some helpful hints on how to use jmbde on your native
platform.

### Unix


### Windows

### macOS


The master branch represents the latest pre-release code.

- [Releases](https://github.com/jmuelbert/jmbde-aspnet/releases)

- [Milestones](https://github.com/jmuelbert/jmbde-aspnet/milestones)

## Requirements and bug reports

- [GitHub issues (preferred)](https://github.com/jmuelbert/jmbde-aspnet/issues)

## Code Sources

The master branch contains the latest pre-release code.

- [Releases](https://github.com/jmuelbert/jmbde-aspnet/releases)

- [Milestones](https://github.com/jmuelbert/jmbde-aspnet/milestones)

## Wiki

- [Main Page](https://github.com/jmuelbert/jmbde-aspnet/wiki)
- [User Manual](http://jmuelbert.github.io/jmbde-aspnet/)

## Create program

In the following you will find hints for developers how to use jmbde on your
native system. They are not complete guides, but
contain information on the necessary measures. libraries,
compile flags, etc.

### Dependencies

#### on Windows

- [.NET Core SDK 3.1 for Windows](https://www.microsoft.com/net/download/windows)

#### on Linux

- [.NET Core SDK 3.1 for Linux](https://www.microsoft.com/net/download/linux)

#### on macOS

- [.NET Core SDK 3.1 for MacOS](https://www.microsoft.com/net/download/macos)

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

EUPL-1.2 © [Jürgen Mülbert](https://github.com/jmuelbert/jmbde-aspnet/blob/master/LICENSE)

[Return to top](#top)

# JMBde Application

---

[![Gitpod Ready Code][gitpod-shield]][gitpod-url]
[![Codacy Badge][codacy-shield]][codacy-url]
[![Total Alerts][lgtm-alerts-shield]][lgtm-alerts-url]
[![Language grade: c#][lgtm-csharp-shield]][lgtm-csharp-url]
[![Language grade: Python][lgtm-python-shield]][lgtm-python-url]
[![Language grade: JavaScript][lgtm-js-shield]][lgtm-js-url]
[![GitHub All Releases][downloads_all-shield]][downloads_all-url]
[![Issues][issues-shield]][issues-url]
[![Help wanted issues][help-issues-shield]][help-issues-url]
[![Pull Requests][pr-shield]][pr-url] [![pre-commit][pre-commit-shield]][pre-commit-url]
[![Codecov][codecov-shield]][codecov-url]
[![Misspell fixer][misspell_fixer-shield]][misspell_fixer-url]
[![Documentation][documentation-shield]][documentation-url]
[![License][license-shield]][license-url]

[Features](https://github.com/jmuelbert/jmbde-aspnet) | [Documentation](https://jmuelbert.github.io/jmbde-aspnet/) | [Changelog](CHANGELOG.md) | [Contributing](CONTRIBUTING.md) | [FAQ](https://github.com/jmuelbert/jmbde-aspnet/wiki/FAQ) | [deutsch](README_de-DE.md)

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

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-shield]: https://img.shields.io/github/contributors/jmuelbert/jmbde-aspnet
[contributors-url]: https://github.com/jmuelbert/jmbde-aspnet/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/jmuelbert/jmbde-aspnet
[forks-url]: https://github.com/jmuelbert/jmbde-aspnet/network/members
[issues-shield]: https://img.shields.io/github/issues-raw/jmuelbert/jmbde-aspnet
[issues-url]: https://github.com//jmuelbert/jmbde-aspnet/issues
[license-shield]: https://img.shields.io/badge/license-EUPL-blue.svg
[license-url]: https://github.com/jmuelbert/jmbde-aspnet/blob/master/LICENSE
[product-screenshot]: images/doc/images/Logo_template.png
[build-shield]:
    https://img.shields.io/github/workflow/status/jmuelbert/jmbde-aspnet/Build/release
[build-url]: https://github.com/jmuelbert/jmbde-aspnet/workflows/Build
[gitpod-shield]: https://img.shields.io/badge/Gitpod-Ready--to--Code-blue?logo=gitpod
[gitpod-url]: https://gitpod.io/#https://github.com/jmuelbert/jmbde-aspnet
[codacy-shield]:
    https://api.codacy.com/project/badge/Grade/c63d1cf887384176977da4e7ba43495e
[codacy-url]:
    https://app.codacy.com/manual/jmuelbert/jmbde-aspnet?utm_source=github.com&utm_medium=referral&utm_content=jmuelbert/jmbde-aspnet&utm_campaign=Badge_Grade_Dashboard
[downloads_all-shield]:
    https://img.shields.io/github/downloads/jmuelbert/jmbde-aspnet/total?label=downloads%40all
[downloads_all-url]: https://github.com/jmuelbert/jmbde-aspnet/releases
[pre-commit-shield]:
    https://img.shields.io/badge/pre--commit-enabled-brightgreen?logo=pre-commit&logoColor=white
[pre-commit-url]: https://github.com/pre-commit/pre-commit
[misspell_fixer-shield]:
    https://github.com/jmuelbert/jmbde-aspnet/workflows/Misspell%20fixer/badge.svg
[misspell_fixer-url]: https://github.com/marketplace/actions/misspell-fixer-action
[help-issues-shield]:
    https://img.shields.io/github/issues/jmuelbert/jmbde-aspnet/help%20wanted
[help-issues-url]:
    https://github.com/jmuelbert/jmbde-aspnet/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22
[documentation-shield]: https://img.shields.io/badge/Documentation-latest-blue.svg
[documentation-url]: https://jmuelbert.github.io/jmbde-aspnet
[lgtm-alerts-shield]: https://img.shields.io/lgtm/alerts/g/jmuelbert/jmbde-aspnet.svg?logo=lgtm&logoWidth=18
[lgtm-alerts-url]: https://lgtm.com/projects/g/jmuelbert/jmbde-aspnet/alerts/
[lgtm-csharp-shield]:
    https://img.shields.io/lgtm/grade/csharp/g/jmuelbert/jmbde-aspnet.svg?logo=lgtm&logoWidth=18
[lgtm-csharp-url]: https://lgtm.com/projects/g/jmuelbert/jmbde-aspnet/context:csharp
[lgtm-python-shield]: https://img.shields.io/lgtm/grade/python/g/jmuelbert/jmbde-aspnet.svg?logo=lgtm&logoWidth=18
[lgtm-python-url]: https://lgtm.com/projects/g/jmuelbert/jmbde-aspnet/context:python
[lgtm-js-shield]: https://img.shields.io/lgtm/grade/javascript/g/jmuelbert/jmbde-aspnet.svg?logo=lgtm&logoWidth=18
[lgtm-js-url]: https://lgtm.com/projects/g/jmuelbert/jmbde-aspnet/context:javascript
[cdash-shield]: https://img.shields.io/badge/CDash-Access-blue.svg
[cdash-url]: http://my.cdash.org/index.php?project=jmbde-aspnet
[pr-shield]: https://img.shields.io/github/issues-pr-raw/jmuelbert/jmbde-aspnet.svg
[pr-url]: https://github.com/jmuelbert/jmbde-aspnet/pulls
[codecov-shield]: https://codecov.io/gh/jmuelbert/jmbde-aspnet/branch/master/graph/badge.svg
[codecov-url]: https://codecov.io/gh/jmuelbert/jmbde-aspnet

<!--
SPDX-FileCopyrightText: 2021 Jürgen Mülbert <juergen.muelbert@gmail.com>

SPDX-License-Identifier: CC-BY-4.0
-->

# jmbde

jmbde ist ein Programm für das Management von Ressourcen in Unternehmen. Mit diesem
Programm können die Mitarbeiter und die Ausrüstung, die sie für ihre Arbeit benötigen
erfasst werden. Das sind unter anderem Computer, Drucker und Telefone.

---

[![Build](https://github.com/jmuelbert/jmbde-aspnet/actions/workflows/build.yml/badge.svg)](https://github.com/jmuelbert/jmbde-aspnet/actions/workflows/build.yml)
[![GitHub All Releases](https://img.shields.io/github/downloads/jmuelbert/jmbde-aspnet/total?label=downloads%40all)](https://github.com/jmuelbert/jmbde-aspnet/releases)
[![Codacy Security Scan](https://github.com/jmuelbert/jmbde-aspnet/actions/workflows/codacy-analysis.yml/badge.svg)](https://github.com/jmuelbert/jmbde-aspnet/actions/workflows/codacy-analysis.yml)
[![CodeQL](https://github.com/jmuelbert/jmbde-aspnet/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/jmuelbert/jmbde-aspnet/actions/workflows/codeql-analysis.yml)
[![DevSkim](https://github.com/jmuelbert/jmbde-aspnet/actions/workflows/devskim-analysis.yml/badge.svg)](https://github.com/jmuelbert/jmbde-aspnet/actions/workflows/devskim-analysis.yml)
[![OSSAR](https://github.com/jmuelbert/jmbde-aspnet/actions/workflows/ossar-analysis.yml/badge.svg)](https://github.com/jmuelbert/jmbde-aspnet/actions/workflows/ossar-analysis.yml)
[![Sonar Cloud Scan](https://github.com/jmuelbert/jmbde-aspnet/actions/workflows/sonarcloud-analysis.yml/badge.svg)](https://github.com/jmuelbert/jmbde-aspnet/actions/workflows/sonarcloud-analysis.yml)
[![License](https://img.shields.io/github/license/jmuelbert/jmbde-aspnet)](https://github.com/jmuelbert/jmbde-aspnet/blob/master/LICENSE)
[![jmbde-aspnet.github.io][docs-badge]][docs]

[Features](https://github.com/jmuelbert/jmbde-aspnet) | [Documentation](https://jmuelbert.github.io/jmbde-aspnet/) | [Changelog](CHANGELOG.md) | [Contributing](CONTRIBUTING.md) | [FAQ](https://github.com/jmuelbert/jmbde-aspnet/wiki/FAQ) | [english](README_en.md)

## Setup

Das Programm verwendet das Microsoft dotnet Framework und ist somit auf fast allen Plattformen ausführbar. Es wird die aktuelle Version 6.x verwendet. Um das Programm zu compilieren muss das dotnet-sdk-framework installiert werden. Für den Start des gebauten Programms reicht der Download und die Installation der Runtime. Der Download wird von Microsoft [hier](hhttps://dotnet.microsoft.com/download/dotnet/6.0) angeboten

## Unterstützte Plattformen

## Ausführen

Im Folgenden finden Sie einige hilfreiche Hinweise, wie Sie jmbde auf Ihrer nativen Plattform ausführen können.

### Unix

### Windows

### macOS

## Anforderungen und Fehlerberichte

- [GitHub issues (preferred)](https://github.com/jmuelbert/jmbde-aspnet/issues)

## Fragen und Kommentare

## Wiki

- [Main Page](https://github.com/jmuelbert/jmbde-aspnet/wiki)
- [User Manual](http://jmuelbert.github.io/jmbde-aspnet/)

## Code-Quellen

In dem master branch befindet sich der aktuellste Pre-Release Code.

- [Releases](https://github.com/jmuelbert/jmbde-aspnet/releases)

- [Milestones](https://github.com/jmuelbert/jmbde-aspnet/milestones)

## Programm erstellen

Im Folgenden finden Sie Hinweise für Entwickler, wie Sie jmbde auf Ihrem nativen System
aufbauen können. Sie sind keine vollständigen Leitfäden, sondern enthalten Hinweise zu
den notwendigen Maßnahmen. Bibliotheken, Kompilierungs-Flags, etc.

### Abhängigkeiten

Zum erstellen des Programms wird das dotnet-sdk in der Version 6.0.100 benötigt. Das Framework ist im Internet bei der Adresse [https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-6.0.100-macos-x64-installer](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-6.0.100-macos-x64-installer) zu finden. Das Framework muss nach dem Download installiert werden.

#### Für die Release-Version

```bash
        cd src/jmbde
        dotnet build -c Release
        dotnet ef database update

```

#### Für die Debug-Version

```bash
        cd src/jmbde
        dotnet build -c Debug
        dotnet ef database update

```

Sie können nun `jmbde` mit dem Befehl `bin/jmbde` aus der Kommandozeile starten.

## Installation

## License

EUPL-1.2 © [Jürgen Mülbert](https://github.com/jmuelbert/jmbde-aspnet/blob/master/LICENSE)

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[docs-badge]: https://img.shields.io/badge/Docs-github.io-blue
[docs]: https://jmuelbert.github.io/jmbde-QT/

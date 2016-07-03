# JMBDE Application

AppVeyor: [![AppVeyor](https://ci.appveyor.com/api/projects/status/ja8a7j6jscj7k3xa/branch/dev?svg=true)](https://ci.appveyor.com/project/jmuelbert/jmbde-aspnet)

Travis: [![Travis](https://travis-ci.org/aspnet/MusicStore.svg?branch=dev)](https://travis-ci.org/jmuelbert/jmbde-aspnet)

A database tool to manage Employees, Computers, Phones and Mobiles in a Company

## Run on Windows
* Open a command prompt and cd `src\jmbde`.
* **[WebListener:**
    4. Run `dnx . web`(Application started at URL **http://localhost:5002/**)
* **[Kestrel]**
    5. Run `dnx . kestrel`(Apllication started at URL **http://localhost:5004/**)
* **[CustomHost]**
    6. Run `dnx . run`(This hosts the app in a console applcation - Application started at URL **http://localhost:5003/**).

## To run the jmbde App on Mac/Mono or Linux:
* Follow the instructions at the [Home](https://github.com/aspnet/Home( repository to install Mono and DNVM on the System
* Open a command prompt and excute `cd src/jmbde'.
* Execute `dnu restore``
* Try run `dnx kestrel`to run the application

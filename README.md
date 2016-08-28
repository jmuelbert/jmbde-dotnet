# JMBDE Application

AppVeyor: [![AppVeyor](https://ci.appveyor.com/api/projects/status/ja8a7j6jscj7k3xa/branch/dev?svg=true)](https://ci.appveyor.com/project/jmuelbert/jmbde-aspnet)

Travis: [![Travis](https://travis-ci.org/aspnet/MusicStore.svg?branch=dev)](https://travis-ci.org/jmuelbert/jmbde-aspnet)

A database tool to manage Employees, Computers, Phones and Mobiles in a Company
## Prepare the App
* **[Windows]**
* Open a command prompt and cd `src\jmbde`.
* Run `dotnet restore` - Load the Dependencies.
* Run `dotnet ef database update`- Create a new blank database.

* **[Linux or maxOS]**
* Open a command prompt and excute `cd src/jmbde'.
* Run `dotnet restore` - Load the Dependencies.
* Run `dotnet ef database update`- Create a new blank database.

## Run the jmbde App
* **[Windows]**
* Open a command prompt and cd `src\jmbde`.
* Run `dotnet run` (This hosts the app in a console application - Application started at URL **http://localhost:5000/**).

* **[Linux or macOS]**
* Open a command prompt and excute `cd src/jmbde'.
* Run `dotnet restore` - Load the Dependencies.
* Try run `dotnet run` (This hosts the app in a console application - Application started at URL **http://localhost:5000/**).

rem build
dotnet build jmbde.sln -c Release
nuget push %%i -Source http://zlzforever.6655.la:40001/nuget
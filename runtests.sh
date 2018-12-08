dotnet --info
dotnet test tests/jmbde.Tests/jmbdeTests.csproj -f netcoreapp2.1 -c release
dotnet test tests/GenSampleData/GenSampleData.csproj -f netcoreapp2.1 -c release

msbuild /p:RunCodeAnalysis=true
dotnet --info
dotnet test tests/jmbde.Tests/jmbde.Tests.csproj -f netcoreapp2.2 -c release

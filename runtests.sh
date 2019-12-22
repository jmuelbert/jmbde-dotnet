#!/bin/sh
msbuild /p:RunCodeAnalysis=true
dotnet --info
dotnet test tests/jmbde.Tests/jmbde.Tests.csproj -f netcoreapp3.1 -c release

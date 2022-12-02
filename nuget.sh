dotnet build --configuration Release &&
dotnet pack --configuration Release --no-build --output ./nupkg &&
nuget push ""./nupkg/*.nupkg"" -SkipDuplicate -ForceEnglishOutput -Source "https://api.nuget.org/v3/index.json"
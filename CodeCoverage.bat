@echo off

opencover.console.exe -target:"dotnet.exe" -targetargs:"test -f netcoreapp1.1 -c Release E:\Repos\WebApplication1\Cibertec.Repositories.Tests\Cibertec.Repositories.Tests.csproj" -mergeoutput -hideskipped:File -output:coverage.xml -oldStyle -filter:"+[Cibertec.*]* -[Cibertec.Repositories.Tests*]*" -searchdirs:"E:\Repos\WebApplication1\Cibertec.Repositories.Tests\bin\Release\netcoreapp1.1" -register:user

reportgenerator.exe -reports:coverage.xml -targetdir:coverage -verbosity:Error
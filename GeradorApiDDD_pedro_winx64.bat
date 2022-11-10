REM Chame o script passando o nome da Solucao
REM Irá criar dentro de uma pasta com o mesmo nome da solução.

mkdir %1
xcopy /S /Q /Y /F .\Auxiliary\global.json .\%1\global.json*
cd %1

dotnet new gitignore


dotnet new sln  -n %1
dotnet new webapi -n %1.Api
dotnet new classlib -n %1.Infrastructure
dotnet new classlib -n %1.Domain
dotnet new xunit -n %1.Testes

dotnet sln add %1.Api/%1.Api.csproj
dotnet sln add %1.Infrastructure/%1.Infrastructure.csproj
dotnet sln add %1.Domain/%1.Domain.csproj
dotnet sln add %1.Testes/%1.Testes.csproj

dotnet add %1.Api/%1.Api.csproj reference %1.Domain/%1.Domain.csproj
dotnet add %1.Api/%1.Api.csproj reference %1.Infrastructure/%1.Infrastructure.csproj
dotnet add %1.Infrastructure/%1.Infrastructure.csproj reference %1.Domain/%1.Domain.csproj

dotnet add %1.Testes/%1.Testes.csproj reference %1.Api/%1.Api.csproj

cd %1.Api
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.11

mkdir Profiles
cd ..

cd %1.Domain
mkdir Contracts
mkdir Contracts/Requests
mkdir Contracts/Responses
mkdir Entities
mkdir Interfaces
mkdir Interfaces/Repositories
mkdir Interfaces/Services
mkdir Services
mkdir Settings
dotnet add package BCrypt.Net-Next
dotnet add package Newtonsoft.Json --version 13.0.1
cd ..

cd %1.Infrastructure
mkdir Context
mkdir Migrations
mkdir Repositories
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.11
dotnet add package Microsoft.EntityFrameworkCore.Proxies --version 6.0.11
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.11
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.11
cd ..



xcopy /S /Q /Y /F ..\Auxiliary\bases\BaseController.cs  .\%1.Api\Controllers\BaseController.cs*

//TODO: Definir arquivos que Vão ser copiados.
xcopy /S /Q /Y /F ..\Auxiliary\DeleteMe.txt .\%1.CrossCutting\Mappers\DeleteMe.txt*
xcopy /S /Q /Y /F ..\Auxiliary\DeleteMe.txt .\%1.Domain\Contracts\DeleteMe.txt*
xcopy /S /Q /Y /F ..\Auxiliary\DeleteMe.txt .\%1.Domain\Entities\DeleteMe.txt*
xcopy /S /Q /Y /F ..\Auxiliary\DeleteMe.txt .\%1.Domain\Interfaces\Repositories\DeleteMe.txt*
xcopy /S /Q /Y /F ..\Auxiliary\DeleteMe.txt .\%1.Domain\Interfaces\Services\DeleteMe.txt*
xcopy /S /Q /Y /F ..\Auxiliary\DeleteMe.txt .\%1.IoC\DeleteMe.txt*
xcopy /S /Q /Y /F ..\Auxiliary\DeleteMe.txt .\%1.Repository\DeleteMe.txt*
xcopy /S /Q /Y /F ..\Auxiliary\DeleteMe.txt .\%1.Service\DeleteMe.txt*
xcopy /S /Q /Y /F ..\Auxiliary\Program.cs .\%1.Api\Program.cs*
xcopy /S /Q /Y /F ..\Auxiliary\appsettings.Development.json .\%1.Api\appsettings.Development.json*

git init .
git add .
git commit -m ":tada: Initial commit"
git branch -m master main
dotnet build
dotnet test
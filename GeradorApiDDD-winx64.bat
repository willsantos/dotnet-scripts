REM Chame o script passando o nome da Solucao
REM Irá criar dentro de uma pasta com o mesmo nome da solução.

mkdir %1
cd %1

dotnet new gitignore


dotnet new sln  -n %1
dotnet new webapi -n %1.Api
dotnet new classlib -n %1.CrossCutting
dotnet new classlib -n %1.Domain
dotnet new classlib -n %1.IoC
dotnet new classlib -n %1.Repository
dotnet new classlib -n %1.Service
dotnet new xunit -n %1.Testes

dotnet sln add %1.Api/%1.Api.csproj
dotnet sln add %1.CrossCutting/%1.CrossCutting.csproj
dotnet sln add %1.Domain/%1.Domain.csproj
dotnet sln add %1.IoC/%1.IoC.csproj
dotnet sln add %1.Repository/%1.Repository.csproj
dotnet sln add %1.Service/%1.Service.csproj

dotnet add %1.Api/%1.Api.csproj reference %1.Domain/%1.Domain.csproj
dotnet add %1.Api/%1.Api.csproj reference %1.IoC/%1.IoC.csproj

dotnet add %1.CrossCutting/%1.CrossCutting.csproj reference %1.Domain/%1.Domain.csproj
dotnet add %1.CrossCutting/%1.CrossCutting.csproj reference %1.Repository/%1.Repository.csproj
dotnet add %1.CrossCutting/%1.CrossCutting.csproj reference %1.Service/%1.Service.csproj

dotnet add %1.IoC/%1.IoC.csproj reference %1.CrossCutting/%1.CrossCutting.csproj

dotnet add %1.Repository/%1.Repository.csproj reference %1.Domain/%1.Domain.csproj

dotnet add %1.Service/%1.Service.csproj reference %1.Domain/%1.Domain.csproj
dotnet add %1.Testes/%1.Testes.csproj reference %1.Domain/%1.Domain.csproj
dotnet add %1.Testes/%1.Testes.csproj reference %1.Api/%1.Api.csproj

cd %1.Api
dotnet add package Microsoft.EntityFrameworkCore.Design
mkdir Controllers
cd ..

cd %1.CrossCutting
dotnet add package AutoMapper
dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
mkdir DependencyInjection
mkdir Mappers
cd ..

cd %1.Domain
mkdir Contracts
mkdir Entities
mkdir Interfaces
mkdir Interfaces/Repositories
mkdir Interfaces/Services
cd ..

cd %1.IoC
dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions
cd ..

cd %1.Repository
dotnet add package Microsoft.EntityFrameworkCore
cd ..

cd %1.Service
dotnet add package AutoMapper
cd ..

cp Auxiliary/NativeInjectorBootStrapper.cs %1.IoC/NativeInjectorBootStrapper.cs

dotnet sln add %1.Testes/%1.Testes.csproj

git init .
git add .
git commit -m ":tada: Initial commit"
git branch -m master main
dotnet build
dotnet test
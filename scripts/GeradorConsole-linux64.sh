#!/bin/bash 

#Chame o script passando o nome da Solucao seguido do nome do projeto
#Irá criar dentro de uma pasta com o mesmo nome da solução.

mkdir $1
cd $1

dotnet new gitignore


dotnet new sln  -n $1
dotnet new console -n $2
dotnet new mstest -n Testes
dotnet sln add $2/$2.csproj
dotnet sln add Testes/Testes.csproj
dotnet add Testes/Testes.csproj reference $2/$2.csproj
dotnet build
dotnet test
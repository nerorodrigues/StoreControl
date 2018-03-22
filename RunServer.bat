@echo off
set currentPath=%~dp0
set serverDirectory= %currentPath%StoreControl
cd %serverDirectory%
echo Initilizing Server...
start dotnet run --Configuration Release -p %serverDirectory%\StoreControl.csproj
exit
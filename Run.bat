@echo off
set currentPath=%~dp0
echo Initilizing Server...
start RunServer.bat
echo Initilizing Web Application...
start RunWeb.bat
ping 127.0.0.1 -n 15 > nul

echo Opening Swagger
start "" http://localhost:64527/swagger

echo Opening WebApplication
start "" http://localhost:4200

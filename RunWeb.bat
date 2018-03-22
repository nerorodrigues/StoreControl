@echo off
set currentPath=%~dp0
set webDirectory= %currentPath%StoreControlWeb
cd %webDirectory%
echo Initilizing Web Application...
call ng serve
exit

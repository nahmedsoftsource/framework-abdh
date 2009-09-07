@ECHO OFF
:init
setlocal
set commandname=%0
set ACTION=builddb

if "%1" == "" goto dowork
rem set ACTION=%1
rem shift

:checkoption
if "%1" == "" goto dowork
if /I "%1" == "-o" goto setoutput
echo Option '%1' is not supported.
echo Type '%COMMANDNAME% help' for more information.
goto exit

:setoutput
shift
set OUTPUTPATH=%1
shift
goto checkoption

:dowork
if "%OUTPUTPATH%" == "" goto usage

if "%ACTION%" == "builddb" goto builddb
if "%ACTION%" == "help" goto usage
echo Acion '%ACTION%' is not supported. 
echo Type '%COMMANDNAME% help' for more information.
goto usage

:builddb
C:\WINDOWS\Microsoft.NET\Framework\v3.5\MSBuild BuildDb.proj /t:Build /p:OutDir=%OUTPUTPATH% /l:FileLogger,Microsoft.Build.Engine;logfile=builddb.log

goto exit

:usage
echo Usage: builddb [help] [-o pathname]
echo   -o   : location where the dbscript is located
goto exit

:exit

@ECHO OFF
:init
setlocal
set commandname=%0
set ACTION=deploy

if "%1" == "" goto dowork
set ACTION=%1
shift

:checkoption
if "%1" == "" goto dowork
if /I "%1" == "-c" goto setconfig
echo Option '%1' is not supported.
echo Type '%COMMANDNAME% help' for more information.
goto exit

:setconfig
shift
set DeployConfigFile=%1
shift
goto checkoption

:dowork
if "%ACTION%" == "deploy" goto deploy
if "%ACTION%" == "help" goto usage
echo Acion '%ACTION%' is not supported. 
echo Type '%COMMANDNAME% help' for more information.
goto usage

:deploy
REM where yymmdd_hhmmss is a date_time stamp like 030902_134200
set hh=%time:~0,2%
REM Since there is no leading zero for times before 10 am, have to put in
REM a zero when this is run before 10 am.
if "%time:~0,1%"==" " set hh=0%hh:~1,1%
set yymmdd_hhmmss=%date:~12,2%%date:~4,2%%date:~7,2%_%hh%%time:~3,2%%time:~6,2%
set LOGFOLDER=%cd%\logs

if exist "%LOGFOLDER%" goto deployweb
mkdir "%LOGFOLDER%"

:deployweb
"%SYSTEMROOT%\Microsoft.NET\Framework\v3.5\MSBuild" Deploy.proj /t:DeploySample /l:FileLogger,Microsoft.Build.Engine;logfile="%LOGFOLDER%\sampledata_%yymmdd_hhmmss%.log"

goto exit

:usage
echo Usage: sampledata [help] [-c filename]
echo   -c   : locate the deploy.config file
goto exit

:exit
pause
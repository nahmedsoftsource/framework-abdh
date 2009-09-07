@ECHO OFF
:init
setlocal
set commandname=%0
set LOGFOLDER=.
set ACTION=deploydb

:checkoption
if "%1" == "" goto dowork
if /I "%1" == "-s" goto setserver
if /I "%1" == "-d" goto setdatabase
if /I "%1" == "-u" goto setuser
if /I "%1" == "-p" goto setpassword
if /I "%1" == "-w" goto setworkingfolder
if /I "%1" == "-l" goto setlogfolder
echo Option '%1' is not supported.
echo Type '%COMMANDNAME% help' for more information.
goto exit

:setserver
shift
set DBSERVER=%1
rem trim quote
for /f "useback tokens=*" %%a in ('%DBSERVER%') do set DBSERVER=%%~a
shift
goto checkoption

:setdatabase
shift
set DBNAME=%1
for /f "useback tokens=*" %%a in ('%DBNAME%') do set DBNAME=%%~a
shift
goto checkoption

:setuser
shift
set DBUSER=%1
for /f "useback tokens=*" %%a in ('%DBUSER%') do set DBUSER=%%~a
shift
goto checkoption

:setpassword
shift
set DBPASSWORD=%1
for /f "useback tokens=*" %%a in ('%DBPASSWORD%') do set DBPASSWORD=%%~a
shift
goto checkoption

:setworkingfolder
shift
set WORKFOLDER=%1
shift
goto checkoption

:setlogfolder
shift
set LOGFOLDER=%1
for /f "useback tokens=*" %%a in ('%LOGFOLDER%') do set LOGFOLDER=%%~a
shift
goto checkoption

:dowork
if "%DBSERVER%" == "" goto usage

if "%ACTION%" == "deploydb" goto deploydb
if "%ACTION%" == "help" goto usage
echo Acion '%ACTION%' is not supported. 
echo Type '%COMMANDNAME% help' for more information.
goto usage

:deploydb
if "%WORKFOLDER%" == "" set WORKFOLDER="."
pushd %WORKFOLDER%

echo About to deploying table schema on...
echo ...server:         %DBSERVER%
echo ...database:       %DBNAME%
echo ...db user:        %DBUSER%

echo Verifying table schema...
FOR /F "usebackq" %%i IN (`sqlcmd -W -S "%DBSERVER%" -d "%DBNAME%" -U "%DBUSER%" -P "%DBPASSWORD%" -b -Q "SET NOCOUNT ON; SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[metadata].[Version]') AND type in (N'U')"`) DO SET DBEXISTS=%%i
if errorlevel 1 goto afterDeploy

if not "%DBEXISTS%" == "0" goto upgradedb

echo Creating table schema...
sqlcmd -W -S "%DBSERVER%" -d "%DBNAME%" -U "%DBUSER%" -P "%DBPASSWORD%" -b -i creationscripts\schema.sql > "%LOGFOLDER%\create-schema.log"
if errorlevel 1 goto afterDeploy

echo Inserting table metadata...
sqlcmd -W -S "%DBSERVER%" -d "%DBNAME%" -U "%DBUSER%" -P "%DBPASSWORD%"  -b -i creationscripts\metadata.sql > "%LOGFOLDER%\create-metadata.log"
if errorlevel 1 goto afterDeploy

call creationscripts\zipcode.bat import -s "%DBSERVER%" -d "%DBNAME%" -u "%DBUSER%" -p "%DBPASSWORD%" -i creationscripts\zipcode.dat
if errorlevel 1 goto afterDeploy

:upgradedb
echo Upgrading database...
sqlcmd -W -S "%DBSERVER%" -d "%DBNAME%" -U "%DBUSER%" -P "%DBPASSWORD%"  -b -i upgradedb.sql > "%LOGFOLDER%\upgrade-db.log"
echo %LOGFOLDER%
:afterDeploy
popd
if errorlevel 1 goto showerror
echo Database deployed successful.
goto exit
:showerror
echo Error: Database deployed failed. Please check the log file for more detail. 1>&2
exit /B 1
goto exit

:usage
echo Usage: createdb {-s server} {-d database} {-u user} {-p password}
goto exit

:exit

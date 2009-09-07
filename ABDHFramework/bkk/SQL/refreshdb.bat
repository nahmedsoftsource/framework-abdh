@echo off
setlocal
call prepenv.bat
if errorlevel 1 goto error

echo WARNING:
echo This script will erase ALL of your data in the database. Please make sure that you run this on the right database.
echo If you want to change the database configuration, please update the file ~configdb.txt.
echo    DBSERVER: %DBSERVER%
echo    DBNAME  : %DBNAME%
echo.
echo Please enter the database name again or switch to another one: 
set DBNAME=
set /P DBNAME=Database name (leave it blank for cancel):
if "%DBNAME%" == "" goto exit

FOR /F "usebackq" %%i IN (`sqlcmd -W -S "%DBSERVER%" -d "master" -U "%DBUSER%" -P "%DBPASSWORD%" -b -Q "SET NOCOUNT ON; SELECT COUNT(*) FROM sys.databases WHERE name='%DBNAME%'"`) DO SET DBEXISTS=%%i
if "%DBEXISTS%" == "0" goto db_failed_error
if errorlevel 1 goto db_failed_error

echo Droping tables...
:droptables
sqlcmd -W -S "%DBSERVER%" -d "%DBNAME%" -U "%DBUSER%" -P "%DBPASSWORD%" -b -Q "exec sp_MSforeachtable 'DROP TABLE ?'" >nul
FOR /F "usebackq" %%i IN (`sqlcmd -W -S "%DBSERVER%" -d "%DBNAME%" -U "%DBUSER%" -P "%DBPASSWORD%" -b -Q "SET NOCOUNT ON; SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES where TABLE_TYPE='BASE TABLE'"`) DO SET TABLECOUNT=%%i
if not "%TABLECOUNT%" == "0" goto droptables

echo. > refreshdb.log

echo Creating database schema...
sqlcmd -W -S "%DBSERVER%" -d "%DBNAME%" -U "%DBUSER%" -P "%DBPASSWORD%" -b -i creationscripts\schema.sql >> refreshdb.log
if errorlevel 1 goto error

echo Importing zipcode...
call creationscripts\zipcode.bat import -s "%DBSERVER%" -d "%DBNAME%" -u "%DBUSER%" -p "%DBPASSWORD%" -i creationscripts\zipcode.dat
if errorlevel 1 goto error

call xConcat.bat -wf ChangeScripts
if errorlevel 1 goto error

echo Upgrading database...
sqlcmd -W -S "%DBSERVER%" -d "%DBNAME%" -U "%DBUSER%" -P "%DBPASSWORD%" -b -i UpgradeDB.sql >> refreshdb.log
if errorlevel 1 goto error

rem echo Importing sample data...
rem sqlcmd -W -S "%DBSERVER%" -d "%DBNAME%" -U "%DBUSER%" -P "%DBPASSWORD%" -b -i SampleData\SampleData.sql >> refreshdb.log
rem if errorlevel 1 goto error

echo Upgrade database successful.
goto exit

:db_failed_error
echo Cannot open database %DBNAME% on the server. Please check.
goto error

:error
echo Upgrade database failed. Please check the log file. 2>&1

:exit
pause
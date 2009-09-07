@echo off
setlocal
call prepenv.bat
if errorlevel 1 goto error

call xConcat.bat -wf ChangeScripts
if errorlevel 1 goto error

echo Upgrading database...
sqlcmd -W -S "%DBSERVER%" -d "%DBNAME%" -U "%DBUSER%" -P "%DBPASSWORD%" -b -i UpgradeDB.sql > upgradedb.log
if errorlevel 1 goto error

echo Upgrade database successful.
goto exit

:error
echo Upgrade database failed. Please check the log file. 2>&1

:exit
pause
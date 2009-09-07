@echo off
echo Preparing environment to run upgrade script...
if exist "~configdb.txt" goto readconfig
echo #This is your first time running this script.>~configdb.txt
echo #Please config your local database server, then run this script again.>>~configdb.txt
echo DBSERVER=localhost>>~configdb.txt
echo DBNAME=SMM-TRUNK>>~configdb.txt
echo DBUSER=>>~configdb.txt
echo DBPASSWORD=>>~configdb.txt

:readconfig
for /F "eol=# tokens=1* delims== " %%i in (~configdb.txt) do set %%i=%%j
if "%DBSERVER%" == "" goto error
if "%DBNAME%" == "" goto error
if "%DBUSER%" == "" goto error
if "%DBPASSWORD%" == "" goto error
exit /B

:error
echo Your environment hasn't been configured properly. Please config the database server in the "~configdb.txt", then run this script again.
start notepad.exe "~configdb.txt"
exit /B 1


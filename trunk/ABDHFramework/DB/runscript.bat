echo on
set TEMP=%CD%
set USER=sa
set PASSWORD=snowman09
set CONNECTIONGSTRING=DUONG-D9EB8AEE5\SQLEXPRESS
set DATABASENAME=NguyenHiep
set 
set pathSqlPub=C:\Program Files\Microsoft SQL Server\90\Tools\Publishing\1.2\
cd /d %pathSqlPub%
call  SqlPubWiz.exe script -d %DATABASENAME% -U %USER% -P %PASSWORD% -S %CONNECTIONGSTRING% %databasename% -f
cd /d %temp%
echo script out successfully
pause
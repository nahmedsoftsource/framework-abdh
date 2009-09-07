@ECHO OFF

if NOT "%1" == "" goto step0
:usage
echo Usage: xConcat ^<-wf path^> [-out filename] [-log filename] [-header filename] [-in filename]
echo   -wf     : set working directory
echo   -out    : output file
echo   -header : script header template
echo   -in     : build list
goto exit

:step0
setlocal
set WORKFOLDER=%cd%
set OUTPUTFILE=%cd%\UpgradeDB.sql
set BUILDLIST=BuildList.txt
set HEADERTMPL=ScriptHeader.sql

:step1
if "%1" == "" goto step2
if /I "%1" == "-wf" goto setworkingfolder
if /I "%1" == "-out" goto setoutput
if /I "%1" == "-header" goto setheadertemplate
if /I "%1" == "-in" goto setbuildlist
echo Option "%1" is not supported
goto exit

:setworkingfolder
shift
set WORKFOLDER=%1
shift
goto step1

:setoutput
shift
set OUTPUTFILE=%1
shift
goto step1

:setbuildlist
shift
set BUILDLIST=%1
shift
goto step1

:setheadertemplate
shift
set HEADERTMPL=%1
shift
goto step1

:step2

if "%WORKFOLDER%" == "" set WORKFOLDER="."
pushd %WORKFOLDER%

@ECHO -- Built by xConcat at %date% %time% > %OUTPUTFILE%

TYPE %HEADERTMPL% >> %OUTPUTFILE%

@ECHO Building change scripts...
FOR /F "usebackq tokens=2" %%i IN (`findstr /R "^#include" %BUILDLIST%`) DO @echo.>>%OUTPUTFILE% & echo.>>%OUTPUTFILE% & type %%i >> %OUTPUTFILE% || (echo Error processing: %%i)

@ECHO Batch file finished.
@ECHO.

popd
:exit

@echo off
rem *********************************************************************
rem	          Project: Recreation Outlet
rem
rem       Description: Database Creation Script
rem
rem	 Revision History:
rem        01/29/2014 Frank Eddy - Create initial version
rem 
rem *********************************************************************

set dbPath="."

echo.
echo. 1. Setup DB on (local) computer using Windows Autentication
echo. 2. Setup DB on specificed computer using Windows Autentication 
echo. 3. Setup DB on specificed computer using SQL Autentication
echo. 3. Setup DB on WSU Titan
echo. 9. Exit
echo.
echo. Please enter either 1-9
set /p a= :
if /i %a%==1 goto :1
if /i %a%==2 goto :2
if /i %a%==3 goto :3
if /i %a%==7 goto :7
if /i %a%==9 goto :9

:1
rem Setup DB on (local) computer using Windows Autentication
set dbServer=-E -S "(local)"
goto :ExecuteDBScripts

:2
rem Setup DB on specificed computer using Windows Autentication
set /P host=Enter Computer Hostname: %=%
set dbServer=-E -S "%host%"
goto :ExecuteDBScripts

:3
rem Setup DB on specificed computer using SQL Autentication
set /P host=Enter Computer Hostname: %=%
set /P uname=Enter Database User Login Name: %=%
set /P pw=Enter Database User Password: %=%
set dbServer=-S "%host%" -U %uname% -P %pw%
set %uname%=""
set %pw%=""
goto :ExecuteDBScripts


:7
rem Setup DB on Titan 
set dbServer=-S "titan.cs.weber.edu,10433" -U recreation -P outlet
goto :ExecuteDBScripts

:9
goto :END


:ExecuteDBScripts
sqlcmd %dbServer% -i %dbPath%\00_Database.sql
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbPath%\01_Tables.sql
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbPath%\02_Keys.sql
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbPath%\03_ConstrainsAndDefaults.sql
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbPath%\04_UserDefinedFunctions.sql
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbPath%\05_Views.sql
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbPath%\06_StoredProcedures.sql
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbPath%\07_Triggers.sql
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbPath%\08_DataDefaults.sql
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG

echo. 
echo. *** Create Database Successful
goto :END


:ERRORMSG
echo. 
echo. *** Create Database Failed
echo. Error: %ERRORLEVEL%
goto END

:END
pause
exit
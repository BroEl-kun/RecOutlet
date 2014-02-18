@echo off
rem *********************************************************************
rem	          Project: Recreation Outlet
rem
rem       Description: Load Demo/Test Data
rem
rem	 Revision History:
rem        01/29/2014 Frank Eddy - Create initial version
rem 

rem ********************************************************************
set dbScriptsPath="."
set testDataScriptsPath=".\"
set outputLogFile=".\Load_TestData.log"

echo.
echo. 1. Insert Test Data on (local) computer using Windows Autentication
echo. 2. Insert Test Data on specificed computer using Windows Autentication 
echo. 3. Insert Test Data on specificed computer using SQL Autentication
echo. 7. Insert Test Data to Titan Server (Use with Caution)
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
rem Insert Test Data on (local) computer using Windows Autentication
set dbServer=-E -S "(local)"
goto :ExecuteDBScripts

:2
rem Insert Test Data on specificed computer using Windows Autentication
set /P host=Enter Computer Hostname: %=%
set dbServer=-E -S "%host%"
goto :ExecuteDBScripts

:3
rem Insert Test Data on specificed computer using SQL Autentication
set /P host=Enter Computer Hostname: %=%
set /P uname=Enter Database User Login Name: %=%
set /P pw=Enter Database User Password: %=%
set dbServer=-S "%host%" -U %uname% -P %pw%
set %uname%=""
set %pw%=""
goto :ExecuteDBScripts


:7
rem Insert Test Data on Titan 
set dbServer=-S "titan.cs.weber.edu,10433" -U runway -P rubys
goto :ExecuteDBScripts

:9
goto :END


:ExecuteDBScripts
rem clear output log
copy /y nul %outputLogFile% 
rem load primary key tables first

sqlcmd %dbServer% -i %dbScriptsPath%\Vendor.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbScriptsPath%\Sales_Rep.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbScriptsPath%\Tax_Rate.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG

sqlcmd %dbServer% -i %dbScriptsPath%\Product_Line.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG

sqlcmd %dbServer% -i %dbScriptsPath%\Item_Category.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbScriptsPath%\Item_Department.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbScriptsPath%\Item_Subcategory.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG

sqlcmd %dbServer% -i %dbScriptsPath%\Item.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG

sqlcmd %dbServer% -i %dbScriptsPath%\Employee.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbScriptsPath%\Location.sql >> %outputLogFile%

IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbScriptsPath%\Override_Code.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbScriptsPath%\Payment_Type.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG

sqlcmd %dbServer% -i %dbScriptsPath%\Qty_Type.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbScriptsPath%\Purchase_Order.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbScriptsPath%\PO_LineItem.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG

sqlcmd %dbServer% -i %dbScriptsPath%\Receiving_Log.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbScriptsPath%\Refund_Code.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG

sqlcmd %dbServer% -i %dbScriptsPath%\Event_Type.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
sqlcmd %dbServer% -i %dbScriptsPath%\Sale_Pricing.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG


sqlcmd %dbServer% -i %dbScriptsPath%\Inventory.sql >> %outputLogFile%
IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG


rem sqlcmd %dbServer% -i %dbScriptsPath%\Store_Transaction.sql >> %outputLogFile%
rem IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG

rem sqlcmd %dbServer% -i %dbScriptsPath%\Transaction_Line_Item.sql >> %outputLogFile%
rem IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG
rem sqlcmd %dbServer% -i %dbScriptsPath%\Exceptions.sql >> %outputLogFile%
rem IF NOT %ERRORLEVEL% EQU 0 GOTO ERRORMSG





echo. 
echo. *** Test Data Loaded to Database Successful
goto :END


:ERRORMSG
echo. 
echo. *** Test Data Loaded to Database Failed
echo. Error: %ERRORLEVEL%
goto END

:END
pause

set dbPath=
set dbServer=(local)

sqlcmd -E -S %dbServer% -i %dbPath%Test1DBscript.sql
pause
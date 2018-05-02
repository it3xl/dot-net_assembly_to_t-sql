# dot-net_assembly_to_t-sql
The app converts .NET .dll files to a T-SQL

The App converts .NET .dll files to a hexadecimal line that can be integrated to a Transact-SQL.
This allows to deploy .NET assablies as a SQL script, which eliminates need to deploy .dll files to the file system of your DB server.

But consider to use DacPac to do the same (SSDT or Visual Studio Database project).

This is a simple converter utility with according to
http://stackoverflow.com/questions/10583862/create-sql-server-create-assembly-script-automatically/10584202#10584202
http://stackoverflow.com/questions/4737686/how-to-generate-sql-clr-stored-procedure-installation-script-w-o-visual-studio/4740325#4740325

This was used for a while in production environments and was replaced by DacPac (SSDT).

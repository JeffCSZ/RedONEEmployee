 1. Use Docker Volume to Map to the correct folder
--------------------------------------------------------------------------------------------------------------------
docker run -e 'ACCEPT_EULA=1' \
-e 'MSSQL_SA_PASSWORD=tcc123#@!' \
-e 'MSSQL_PID=Developer' \
-e 'MSSQL_USER=sa' -p 1433:1433 \
-v /Users/tc/Desktop/sqlData/data:/var/opt/mssql/data \
-d --name=sql mcr.microsoft.com/azure-sql-edge

 2. Db first approach, run the command below: ( made sure Nuget package is EntityTools & EntitySQLServer installed )
--------------------------------------------------------------------------------------------------------------------
 Scaffold-DbContext "Server=192.168.1.9;User Id=sa;Password=tcc123#@!;Database=MyDB;Trusted_Connection=False;Encrypt=False;MultipleActiveResultSets=False;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data
 In the DbContext generated, move ConnectionStrings to appsettings.json for security
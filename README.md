# GraphQL-ConferancePlanner
This is a finished Conferance planner web site based on the Hot Chocalate Conferance planner web site with a few addtion.

## Configuring the database.
The Hot Chocale conferance planner uses a SQL-Lite database, for simpliesty, but no one uses sql lite in reality, except for perhaps IOT Apps. Since we will not be developing an IOT application lets give our Conferance planner a full fledged database such as SQL Server.

## Configuring SQL Server on Docker
The fastest way to configure and setup a database is by using docker. Where small prebuilt images can be used to configure and create complex applications. 

### Pull down the latest version of SQL SERVER

sudo docker pull mcr.microsoft.com/mssql/server:2019-latest

or on windows

docker pull mcr.microsoft.com/mssql/server:2019-latest

### Install SQL Server

for are password, so we can remember it for the SA Account lets create it with the state animal of New York plus a zip code New york city which would make a password of
Beaver10105

sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Beaver10105" \
   -p 1433:1433 --name sqlServer --hostname sql1 \
   -d mcr.microsoft.com/mssql/server:2019-latest
 
 or on windows
 
 docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Beaver10105" -p 1433:1433 --name sqlServer --hostname sql1 -d mcr.microsoft.com/mssql/server:2019-latest
 
 ### Create the Conferance Planner User
 Create a new SQL Server user
 
 **Step 1: create Login**
   --Create the Login
   UserAccount:ConPlanUser
   Password:ConPlanPassword!
 
 CREATE LOGIN ConPlanUser   
    WITH PASSWORD = 'ConPlanPassword!';  
   GO 
 
 **Step 2: Create User**
 CREATE USER ConPlanUser FOR LOGIN ConPlanUser;  
 GO  
 
 **Step 3: Verify User was created**
 select name as username,
       create_date,
       modify_date,
       type_desc as type,
       authentication_type_desc as authentication_type
from sys.database_principals
where name ='ConPlanUser'
 

  ### Create the Conferance Planner database
  ConfPlanDB
  
  
  
USE ConfPlanDB;
GO
ALTER ROLE db_owner ADD MEMBER ConPlanUser;

CREATE LOGIN AbolrousHazem   
    WITH PASSWORD = '340$Uuxwp7Mcxo7Khy';  
GO  
  
 
 

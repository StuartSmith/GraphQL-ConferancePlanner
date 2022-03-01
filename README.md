# GraphQL-ConferancePlanner
This is a finished Conferance planner web site based on the Hot Chocalate Conferance planner web site with a few additions.

## Configuring the database.
The Hot Chocale conferance planner uses a SQL-Lite database, for simpliesty, but no one uses sql lite in reality, except for perhaps IOT Apps. Since we will not be developing an IOT application lets give our Conferance planner a full fledged database such as SQL Server.

## Configuring SQL Server on Docker
The fastest way to configure and setup a database is by using docker. Where small prebuilt images can be used to configure and create complex applications. 

### Pull down the latest version of SQL SERVER

<code>sudo docker pull mcr.microsoft.com/mssql/server:2019-latest </code>

or on windows

<code>docker pull mcr.microsoft.com/mssql/server:2019-latest</code>

### Install SQL Server

For the password, so we can remember it, for the SA Account lets create it with the state animal of New York, plus a zip code from New york city which would make a password of
Beaver10105. This is type of password should only be used in development environments. In production one should use a much stronger password.

To create the SQL Server docker instance from a linux console run.  

<code>sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Beaver10105" \
   -p 1433:1433 --name sqlServer --hostname sql1 \
   -d mcr.microsoft.com/mssql/server:2019-latest</code>
 
 or from a windows console run. 
 
<code> docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Beaver10105" -p 1433:1433 --name sqlServer --hostname sql1 -d mcr.microsoft.com/mssql/server:2019-latest</code>
 
 ### Create the Conferance Planner User
We would like the Conferance Planner Application to use it's own user and password that only has access to the conferance planner database and no other databases within our configuraton. 
 
 **Step 1: create Login**
 Create the Login
 
 UserAccount:ConPlanUser<br>
 Password:ConPlanPassword!<br>
 
 <code>CREATE LOGIN ConPlanUser   
    WITH PASSWORD = 'ConPlanPassword!';<br>  
   GO </code>
 
 **Step 2: Create User**<br>
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
The database name will be ConfPlanDB
  

  
 
 

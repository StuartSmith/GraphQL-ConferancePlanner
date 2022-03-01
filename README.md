# GraphQL-ConferancePlanner
This is a finished Conferance planner web site based on the Hot Chocalate Conferance planner web site with a few addtion.

## Configuring the database.
The Hot Chocale conferance planner uses a sqllite database, for simpliesty but no one uses sql lite in reality, except for perhaps IOT Apps. Since we will not be developing an IOT application lets give our Conferance planner a full fledged database such as SQL Server.

## Configuring SQL Server on Docker
The fastest way to configure and setup a database is by using Docker. Where small prebuilt images can be used to configure and create complex applications. 

### Pull down the latest version of SQL SERVER

sudo docker pull mcr.microsoft.com/mssql/server:2019-latest

or on windows

docker pull mcr.microsoft.com/mssql/server:2019-latest

### install SQL Server

for our password so we can remember it for the SA Account lets create it with the state animal of Newyork plus the zipcod of Newyork which is
Beaver10105

sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Beaver10105" \
   -p 1433:1433 --name sqlServer --hostname sql1 \
   -d mcr.microsoft.com/mssql/server:2019-latest
 
 or on windows
 
 docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Beaver10105" -p 1433:1433 --name sqlServer --hostname sql1 -d mcr.microsoft.com/mssql/server:2019-latest
 

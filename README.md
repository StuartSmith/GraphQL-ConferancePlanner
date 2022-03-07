# GraphQL-ConferancePlanner
This is a finished Conferance planner web site based on the Hot Chocalate Conferance planner web site with a few additions.

## Creating and Configuring the SQL Server database.
The Hot Chocale conferance planner uses a SQL-Lite database, for simpliesty, but no one uses sql lite in reality, except for perhaps IOT apps. Since we will not be developing an IOT application, lets configure our conferance planner application to use a full fledged database such as SQL Server.

### Configuring SQL Server on Docker
The fastest way to configure and setup a database is by using docker, where small prebuilt images can be used to configure and create complex applications. 

### Pull down the latest version of SQL SERVER

From a linux console

<code>sudo docker pull mcr.microsoft.com/mssql/server:2019-latest </code>

or from a windows console

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
 
 ### Create the Conferance Planner SQl Server User
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

<code>
   Create Database ConfPlanDB;
</code><br>

Add the newly created user to the newly created database <br>
  <code>   
   Use ConfPlanDB;
   </code>   
  <code>   
   EXEC sp_adduser 'ConPlanUser';  
 </code>

Give the newly created user the ability to create / drop / select all tables in the database<br>
 
   <code> 
      Use ConfPlanDB;
   </code>
   <br>
   <code> 
      EXEC sp_addrolemember N'db_datawriter', N'ConPlanUser'
   </code> 
   <br>
   <code> 
         EXEC sp_addrolemember N'db_datareader', N'ConPlanUser'
   </code>
   <br>
   <code> 
      exec sp_addrolemember 'db_owner', N'ConPlanUser'
   </code>
  <br> <br>
 Set the ConPlanUser has a default schema of dbo. 
  <code> 
   Use ConfPlanDB;
   </code><br>
  <code> 
   ALTER USER ConPlanUser  WITH DEFAULT_SCHEMA = dbo;
  </code>

  Update the conferance planner application to us the newly created database in the startup.cs file.
  <br>
   <code>
   services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=localhost;Database=ConfPlanDB;User Id=ConPlanUser;Password=ConPlanPassword!;"));   
   </code>
Now lets the create the database through visual studio.
<code>
   Install-Package Microsoft.EntityFrameworkCore.Tools<br>
   Add-Migration InitialCreate<br>
   Update-Database<br>
</code>

 ### Lets create data for our application

#### Create the speaker data...

 blazor track <br>
Jeff fritz: Build your first web app with Blazor & Web Assembly<br>
Jeff fritz: deep dive into  Blazor & Web Assembly<br>

mutation AddSpeaker {
  addSpeaker(input: {
    name: "Jeff fritz"
    bio: "I write code live on video streams and teach as I build fun applications. I work on the .NET and Visual Studio groups at Microsoft"
    webSite: "https://www.linkedin.com/in/jeffreytfritz/" }) {
    speaker {
      id
    }
  }
}

IOT Track<br>
Sam George: Building Digital Twins, Mixed Reality and Metaverse Apps<br>
Sam George: Building Digital Twins, Mixed Reality and Metaverse Apps (R1)<br>

mutation AddSpeaker {
  addSpeaker(input: {
    name: "Sam George"
    bio: "Sam George is the Corporate Vice President of Azure IoT, delivering a broad portfolio of services and capabilities that help our customers and partners realize the full potential of the Internet of Things. He is responsible for Azure IoT services including Digital Twins, IoT Hub, IoT Edge, IoT Central and leads the Azure industries for Manufacturing, Automotive, Real Estate and Energy including cross industry efforts like the Open Manufacturing Platform and the Digital Twins Consortium. Sam and his team’s mission is to simplify IoT so that every business on the planet can benefit from the digital transformation it enables. A 21-year Microsoft veteran, Sam started his career as a software developer and is passionate about how technology can enable a more inclusive and sustainable world. You can follow Sam online on his IoT Blog aka.ms/SamGeorge or on Twitter at @samjgeorge."
     }) {
    speaker {
      id
    }
  }
}

AI Track<br>
Eric Boyd: Build intelligent applications infused with world-class AI <br>
Ayşegül Yönet: Build intelligent applications infused with world-class AI<br>

mutation AddSpeaker {
  Eric:addSpeaker(input: {
    name: "Eric Boyd"
    bio: "Eric Boyd leads the AI Platform team within Microsoft’s Cloud + AI division. This global organization includes Azure Machine Learning, Cognitive Services, Cognitive Search, and internal platforms that provide data, experimentation, and Graphics Processing Units (GPU) cluster management to groups across Microsoft. Our mission is to make Microsoft’s Azure AI platform the best platform for first- and third-party customers. He has held several roles during his ten-year tenure at Microsoft and has an innate talent to inspire and engage team members at every level. He joined the company in 2009 to create the Silicon Valley Search Ads team. He moved to Bellevue in 2011 to lead the Bing Ads Development team prior to taking on his current role in 2015. Before coming to Microsoft, Eric was the VP of Engineering at Mochi Media, an ads startup that was acquired by Shanda Games. Prior to Mochi Media, Eric was a VP of Platform Engineering at Yahoo for ten years. Boyd graduated from the Massachusetts Institute of Technology with a bachelor’s degree in Computer Science. He is an avid skier, Seattle Seahawks and Boston Red Sox fan, and a semi-retired professional blackjack player."
     }) {
    speaker {
      id
    }
  }

  Ay:addSpeaker(input: {
    name: "Ayşegül Yönet"
    bio: "Ayşegül Yönet is a Senior Azure Cloud Developer Advocate at Microsoft and focusing on Cognitive Services, Spatial Computing and WebXR. She is a co-chair of W3C Immersive Web Working Group and Community Group working on WebXR Device APIs."
     }) {
    speaker {
      id
    }
  }
}


ASP.net <br>
Shayne Boyer:Create a web API with ASP.NET Core <br>
Jon Galloway: Lessons learned from crating the ASP.Net Music store<br>

mutation AddSpeaker {
  Shayne:addSpeaker(input: {
    name: "Shayne Boyer"
    bio: "Shayne Boyer works as a Principal Developer Advocate for Microsoft on Azure, .NET Core and Open Source. He speaks at national & community events and to help everyone build the web"
    webSite: "https://www.linkedin.com/in/shayneboyer/"
     }) {
    speaker {
      id
    }
  }

  Jon:addSpeaker(input: {
    name: "Jon Galloway"
    bio: "on works at Microsoft as a .NET Program Manager on the .NET Community Team. He’s co-author of Wrox Professional ASP.NET MVC, writes samples and tutorials like the MVC Music Store and is a frequent speaker at conferences and international Web Camps events. Jon’s been doing professional web development since the late 1990's, including high scale applications in financial, entertainment and healthcare analytics. He’s part of the Herding Code podcast and Twitters as @jongalloway. He likes to travel but spends most of his time in San Diego with his amazingly patient wife Rachel, three wonderful daughters, a dozen avocado trees and the occasional rattlesnake."
     }) {
    speaker {
      id
    }
  }
}

To Query the Speakers run
query GetSpeakers{
  speakers {
    name
    bio
    id
  }
}

Multithreaded query... this will return 2 query Results

query GetSpeakersMultiThreaded {
  a:speakers {
    name
    bio
    id
  }
  b:speakers {
    name
    bio
    id
  }
}


Retrieve a secific Speaker... 

query GetSpeaker {
  a:speaker(id: "U3BlYWtlcgppMQ==") {
    name
    bio
    id
  }

}


#### Create the session data...


# TernopilDotNet
Source code and presentation for Ternopil .NET meet up #4 (01.08.2018)
## Usage
Make sure you have Docker with Linux containers running on your machine.
If you are using Visual Studio 2017 set "docker-compose" section as StartUp Project and start application.

To switch between MS Sql Server and My Sql databases comment/uncomment respective code in ConfigureService.cs file.

## Useful Docker commands
* ### When working with docker
```
docker rm $(docker ps -a -q) --force     <-- remove all containers
docker rmi $(docker images -q) --force   <-- remove all images
```
* ### When the app is running
```
sqlcmd -S localhost,1443 -U SA -P "<YourStrong!Passw0rd>"   <- connect from Host to MS sql database located inside container (sql server has to be installed on Host)
/* When ms sql cmd is ready run e.g. */
1> SELECT @@version
2> GO
/* Or */
1> SELECT * FROM [ternopildotnetdb].[dbo].[Comments]
2> GO
```
```
docker exec -it **CONTAINERID** mysql -uroot -p<YourStrong!Passw0rd>   <- execute mysql commands from inside container with specific id
/* When mysql cmd is ready run e.g. */
SHOW VARIABLES LIKE "%version%";
/* Or */
USE ternopildotnetdb; SELECT * FROM Comments;
```

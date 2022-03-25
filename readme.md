# Template for Full-stack Blazor + Web API

Serve a Web API and a Blazor project from the same ASP.NET Core project.

## Try it out - publish on localhost

Using bash / zsh:

```
$ dotnet tool install --global dotnet-ef
$ dotnet publish -c Release 
$ cd server
$ dotnet ef database update
$ mkdir bin/Release/net6.0/publish/bin
$ cp bin/database.db* bin/Release/net6.0/publish/bin
$ cd bin/Release/net6.0/publish
$ ./TodoApi
```

Explanation of the above commands:
- First install the Entity Framework cli
- Publish a release build of the project
- Go to server folder
- Create the database contents from migrations using the ef cli
- Create a folder for the database (sqlite)
- Copy database files to new folder
- Go to program folder
- Start the executable (TodoApi)

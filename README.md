# FoodieMe
*a Chingdo v45-tier3-50 project* 

An app with a React frontend and an ASP.NET Core Web API backend

## React App
Located in the `./reactapp` folder

from this location, you can run

```bash
npm install #install dependencies
npm run start #run application once dependices are installed
```

## ASP.NET Core Web Api
Located in the `./webapi` folder

You are provided with a `appsettings.example.json`. you would need to create a `appsettings.json` from it, with the proper Connection String in order to communicate with the DB.


from this location, you can run

```bash
dotnet watch
```

to run the server and the SwaggerAPI related to it.

## Running the whole project with Visual Studio
At the root of the project, you may be able to launch both at once pressing "Start"
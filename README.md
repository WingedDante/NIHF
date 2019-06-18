# Car Parts Tracker

This repo contains both the react application under car-parts, and the netcore webapi to drive it's connection to a sqlite db.  I grabbed the template service from another repo I have for when I want to make a service or api to handle data for a db, and the sqlite is easy to pass around for examples.

# Steps to run

- 1 : Ensure you have a version of dotnet core that can build/run 2.1
- 2 : Clone the repo

## Backend

- 3 : navigate to the soa_template_service directory or open it with vscode.
- 4 : Either vscode will automatically restore what you need, or if you're using just the terminal, run `dotnet restore` and then run `dotnet run` if you have one of the proper verisons of dotnet core installed, then our backend is now up and running.

## React

- 5 : now navigate into the react folder 'car-parts/'
- 6 : run `npm install`
- 7 : run `npm start`

If the stars aligned on your machine we should have the app ready to test.
# Run the code

## Start node webserver

`cd Stratsys.WebServer`
`npm install`
`npm start`

## Start .NET Web API

`cd Stratsys.WebApi`
`dotnet run --environment "dev"`

### IMPORTANT
If --enviorment is not provided the hosting is going to be in production mode, CORS is not configurated and it will not work.



## Thought process

* Use a REST API instead of a html site directly, this way we can use this API in mobile apps, 3 party integrations and a HTML site
* Make the core functionallity inside the Stratsys.Core project. This way we can change the delivery method in the future from HTTP to lets say RPC.

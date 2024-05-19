# WebServer_Proof_of_concept

## About
This is a proof of concept for a web server application. In this example there are 4 pages:
* Home: example of an entry point into an app
* Create New User/Business: example of using the API's POST routes to create new data as well as using a form in C#.
* Data Tables: listing page and an example of how the GET route of the API would work. The table also has functionality for modal generation on a table column, different tabs, exporting to CSV/Excel, refreshing, searching, sorting, and filtering

There is more to be done with these pages (authentication, session management, etc) and more research needs to be done as to how we can spin up an application on our servers.


## Folders
* wwwroot: root webserver
* components: parts of the pages/assets
* Assets: sub pages (Ex: modals)
* Helpers: helper functions that can be used by any page
* Layout: main background and nav bar
* Models: classes that page will interact with
* Pages: pages that will be rendered

## Files
* _Imports.razor: all the imports that will be used globally
* App.razor: main app that combines all the routes
* Routes.razor: router for all the pages navigation
* Program.cs: main launcher for the web app
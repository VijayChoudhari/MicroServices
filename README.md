# Sympli
Front end application is developed in ReactJs 17.0.1
It is typescript-based project which uses Redux, Thunk, Formik, Yup and Material UI
This application can be launched from " Sympli\Interview\react-client " using npm start command.
Currently when launched, front end shows initial urls [e.g. www.sympli.com] and tokens [e.g. e-settlement].
Page is divided vertically in in two sections. Top section allows to enter url and search token.
⦁	If url is not already added, then on Add button click url and token gets added in below list.
⦁	If url already present, then new search token gets added under appropriate url in below section.
⦁	In all other cases no action is taken
User can either delete url or individual search token under url.
On deleting url child tokens will get deleted.
If all child tokens are deleted, url still remains and newly added token for same url will get added there.

Client Validations: Basic validations such as required, max-length and valid domain name are applied using Yup and Formik.

Remaining Work, and choices
⦁	UI project could not be completed in time. Remaining work is as below
⦁	Instead of use of Redux store make use of useState and useEffect and manage state
⦁	On Form load fetch previously stored urls and search tokens from Dashboard service and render on UI
⦁	Remove initial data hardcoded in UI
⦁	Once data is fetched from Dashboard, using url and search tokens get search occurrence count from Google Search service and Bing search service and render on page
⦁	Request validation
⦁	Error boundary
⦁	Resolve CORS issue
⦁	Unit tests






Gateway:
It currently only performs request routing operation. Work should be done in it to validate JWTToken, Antiforgery token. It should also authenticate user from Authentication service [Not implemented] and then attach JWT token.
Gateway project used Ocelot as a gateway. It is opensource and routing is configured in ocelot.json


Google Search Microservice:
It is dotnet core 5.0 application. Which uses response caching. Search engine url and max search result to fetch are configurable in appsettings.json.
Note that no third-party library is used for searching.
To fetch first 100 results more research, need to be done on cookie settings. Currently on first 10 records are getting fetched.
Also, currently string search is performed which also captures href tags which otherwise not visible on browser. This returns additional findings. To avoid is possibly html can be refined and converted to XML and then LINQ to SQL can be used to get occurrences. 

Unit tests for this project need to be implemented.

Bing Search Microservices:
It is dotnet core 5.0 application. Which uses response caching. Search engine url and max search result to fetch are configurable in appsettings.json.
Note that no third-party library is used for searching.
Similar to Google Search service, currently string search is performed which also captures href tags which otherwise not visible on browser. This returns additional findings. To avoid is possibly html can be refined and converted to XML and then LINQ to SQL can be used to get occurrences.

Unit tests for this project need to be implemented.




Dashboard Service:
This is dotnet core 5.0 project making use of entity framework core and uses SQLserver database.
Connection string can be congfigured into appsettings.josn [Default]. Please change localhost database credentials appropriately and use below commands to apply EF migrations and udpate database schema and add seed values to it.

Powershell Terminal
 
dotnet tool install --global dotnet -ef
dotnet build //To build project
dotnet ef migrations add InitialModel
dotnet ef database update
dotnet ef migrations add SeedDatabase
dotnet ef database update


Also AutheticationService, Support for JWT token and Antiforgery token need to be implemented.

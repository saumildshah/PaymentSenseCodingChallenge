# CodingChallenge
Paymentsense coding challenge

## Setup
* Please download latest dotnet core (3+) -> https://dotnet.microsoft.com/download/dotnet-core

1. Clone repository to local

2. Run API project

3. Open website folder location in command window / powershell 

4. "npm install" to get all references

5. "ng build" to compile UI project

6. "ng serve -o" to run the UI project


LaunchSettings file is pushed to use same Url every time. 
If UI is failing to call API then update following two files to use correct Url / port.

environment.ts
paymentsense-coding-challenge-api.service.ts (Not updating to use base Url as this part of the code is provided by client.)

Working Solution behavior.

1. All API tests must be running without any issues. These includes integration and unit tests.
2. Run both UI and API, you must see Green Thumbs up indicates UI is connecting to API successfully.
3. Click on "Countries" to load list of countries. This should first time call rest API to load fresh list.
4. Click on any country to load more details about the country.
5. Click on "Countries" again to reload the list but this time it should load from cache and should not make any API calls.

Feel free to ask any questions.

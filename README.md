# Weborama.Api.Connector
Library provides functionality for connecting and using methods to Weborama API.\
[Weborama](https://weborama.com) is a platform specializing in the collection of marketing data and the dissemination of online advertising campaigns. Weborama provides access to databases of consumer profiles, technological solutions and services for digital marketing.

## Installation
Package is available at [nuget](https://www.nuget.org/packages/Weborama.Api.Connector). You can either use your favorite package manager or run 

```bash
Install-Package Weborama.Api.Connector -Version 1.2.0
```

## Usage

```c#
using Weborama.Api.Connector;

// Obtaining authentification token
string token = new Authentication().GetToken(Settings.WeboramaLogin, Settings.WeboramaPassword);

// Getting ad spaces list
var adSpaces = new AdSpaces(yourWeboramaAccountId, token).GetAdSpacesList(Settings.WeboramaAccountId);
// Getting insertions list
var insertions = new Insertions(yourWeboramaAccountId, token).GetInsertionsList(Settings.WeboramaAccountId);
// Getting creatives list
var creatives = new Creatives(yourWeboramaAccountId, token).GetCreativesList(Settings.WeboramaAccountId);

// Gathering statistics
var statistics = new Statistics(yourWeboramaAccountId, token).GetGeneralStatistics(accountId, startDate, endDate);

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## Plans
Right now our library can be used only for the most popular data gathering operations. We are looking forward to expand it to other Api methods.

## License
[MIT](https://choosealicense.com/licenses/mit/)

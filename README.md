# CluedIn.Crawling.LatestWins

CluedIn crawler for LatestWins.

[![Build Status](https://dev.azure.com/CluedIn-io/CluedIn%20Crawlers/_apis/build/status/CluedIn-io.CluedIn.Crawling.LatestWins?branchName=master)](https://dev.azure.com/CluedIn-io/CluedIn%20Crawlers/_build/latest?definitionId=TODO&branchName=master)
------

## Overview

This repository contains the code and associated tests for the LatestWins crawler.

## Working with the Code

Load [Crawling.LatestWins.sln](.\Crawling.LatestWins.sln) in Visual Studio or your preferred development IDE.

### Running Tests

<!-- A mocked environment is required to run `integration` and `acceptance` tests. The mocked environment can be built and run using the following [Docker](https://www.docker.com/) command:

```Shell
docker-compose up --build -d
``` -->

To run all `unit` and `integration` tests

```Shell
dotnet test --filter Unit
```

To run only `integration` tests

```Shell
dotnet test --filter Integration
```

To run [Pester](https://github.com/pester/Pester) `acceptance` tests

```PowerShell
invoke-pester test\acceptance
```

<!-- 
To review the [WireMock](http://wiremock.org/) HTTP proxy logs

```Shell
docker-compose logs wiremock
``` -->

## References

* [LatestWins](TODO)

### Tooling

* [Docker](https://www.docker.com/)
* [Pester](https://github.com/pester/Pester)
<!-- * [WireMock](http://wiremock.org/) -->

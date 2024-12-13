# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [2.1.0] / 2024-12-12
### Updated
- Update `Oss` to use upload files in `s3`.
- Add `APS_CLIENT_ID`, `APS_CLIENT_SECRET`, `APS_CLIENT_CUSTOM_HEADER_VALUE` to the `DesignAutomationService`.

## [2.0.0] / 2024-08-20
### Features
- Support .NET 6.0 and .NET 8.0
### Updated
- Update `ricaun.Autodesk.Forge.Oss` to `2.0.0` to fix auth issue.

## [1.0.8] / 2023-12-07
### Updated
- Add `DesignAutomationEngineDateUtils` to enable `DeprecationDate` on Engine.
- Update `ForgeCustomHeaderValueHandler` with content and only when engine is deprecated.
- Update `UpdateCustomHeaderEngineName` to check if engine is deprecated.

## [1.0.7] / 2023-10-03
### Updated
- Update `ParameterActivityLanguageAttribute` to ignore empty value (Fix: #9)
- Update `DesignAutomationService` show `Engine` when `Run` in the console (Fix: #10)

## [1.0.6] / 2023-08-26
### Updated
- Update `ParameterInputAttribute` with Zip support.
- Update `ParameterInputAttribute` and `ParameterOutputAttribute` with Ondemand support.
- Update `ParameterOutputAttribute` with Verb support.
- Update `DesignAutomationService` to console Json activity and workitem.

## [1.0.5] / 2023-08-09
### Updated
- Update `Autodesk.Forge.DesignAutomation` to `5.1.2` - (Migrate from OAuth V1 to OAuth V2 with `Autodesk.Forge.Core` to `3.0.2`) 
- Update readme with custom header value example.
 
## [1.0.4] / 2023-06-30
### Features
- Add `FORGE_CLIENT_CUSTOM_HEADER_VALUE` environment variable to set custom header value for `ForgeClient` class.

## [1.0.3] / 2023-06-17
- Fix `RunTimeOutMinutes` not show report.

## [1.0.2] / 2023-05-32
- Update `DesignAutomationService` report output file without estimate.
- Add `EnableReportConsoleLogger`
- Add `Log` class

## [1.0.1] / 2023-05-31
- Update `Tests` project using `Samples` project
- Add `Samples` project
- Add `App` project

## [1.0.0] / 2023-05-30
- First Release (Copy project from: [RevitAddin.DA.Tester](https://github.com/ricaun-io/RevitAddin.DA.Tester/tree/package))

[vNext]: ../../compare/1.0.0...HEAD
[2.1.0]: ../../compare/2.0.0...2.1.0
[2.0.0]: ../../compare/1.0.8...2.0.0
[1.0.8]: ../../compare/1.0.7...1.0.8
[1.0.7]: ../../compare/1.0.6...1.0.7
[1.0.6]: ../../compare/1.0.5...1.0.6
[1.0.5]: ../../compare/1.0.4...1.0.5
[1.0.4]: ../../compare/1.0.3...1.0.4
[1.0.3]: ../../compare/1.0.2...1.0.3
[1.0.2]: ../../compare/1.0.1...1.0.2
[1.0.1]: ../../compare/1.0.0...1.0.1
[1.0.0]: ../../compare/1.0.0
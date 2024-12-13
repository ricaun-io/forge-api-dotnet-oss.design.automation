# Autodesk.Forge.Oss.DesignAutomation

[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](https://github.com/ricaun-io/forge-api-dotnet-oss.design.automation)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](https://github.com/ricaun-io/forge-api-dotnet-oss.design.automation/actions/workflows/Build.yml/badge.svg)](https://github.com/ricaun-io/forge-api-dotnet-oss.design.automation/actions)
[![.NET 6.0](https://img.shields.io/badge/.NET%206.0-blue.svg)](https://github.com/ricaun-io/forge-api-dotnet-oss.design.automation)
[![Nuget](https://img.shields.io/nuget/v/ricaun.Autodesk.Forge.Oss.DesignAutomation?logo=nuget&label=nuget&color=blue)](https://www.nuget.org/packages/ricaun.Autodesk.Forge.Oss.DesignAutomation)

### PackageReference

```xml
<PackageReference Include="ricaun.Autodesk.Forge.Oss.DesignAutomation" Version="*" />
```

### Requirements

- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later
- A registered app on the [Autodesk Platform Service](http://aps.autodesk.com). 

### Dependencies

* [forge-api-dotnet-oss](https://github.com/ricaun-io/forge-api-dotnet-oss)
* [forge-api-dotnet-design.automation](https://github.com/Autodesk-Forge/forge-api-dotnet-design.automation)

### Configuration

By default the Forge credentials could be defined with the following environment variables:

```bash
APS_CLIENT_ID=<your client id>
APS_CLIENT_SECRET=<your client secret>
```

or

```bash
FORGE_CLIENT_ID=<your client id>
FORGE_CLIENT_SECRET=<your client secret>
```

#### Region

You can define the region of the bucket. [Available regions](https://aps.autodesk.com/en/docs/data/v2/reference/http/buckets-POST/)

```bash
APS_CLIENT_BUCKET_REGION=<region>
```

or

```bash
FORGE_CLIENT_BUCKET_REGION=<region>
```

#### Custom

You can define a custom header to be sent with each Design Automation requests to the Forge API.
**The custom header is only enabled if the engine is deprecated.**

```bash
APS_CLIENT_CUSTOM_HEADER_VALUE=<your custom header>
```

or

```bash
FORGE_CLIENT_CUSTOM_HEADER_VALUE=<your custom header>
```

The custom header follow pattern `x-my-custom-header: engine value is {0}`. (The value `{0}` is replaced with the engine+version.)
The header gonna be `x-my-custom-header` and the value `engine value is Autodesk.Revit+2023` when using the engine `Autodesk.Revit+2023`.

### Samples

This repository contains each sample of the [Autodesk Step-by-Step Tutorial](https://aps.autodesk.com/en/docs/design-automation/v3/tutorials/).

* [Autodesk Tutorial for 3dsmax](https://aps.autodesk.com/en/docs/design-automation/v3/tutorials/3dsmax/) - [DA_3dMax.cs](Autodesk.Forge.Oss.DesignAutomation.Samples/DA_3dMax.cs)
* [Autodesk Tutorial for Autocad](https://aps.autodesk.com/en/docs/design-automation/v3/tutorials/autocad/) - [DA_AutoCAD.cs](Autodesk.Forge.Oss.DesignAutomation.Samples/DA_AutoCAD.cs)
* [Autodesk Tutorial for Inventor](https://aps.autodesk.com/en/docs/design-automation/v3/tutorials/inventor/) - [DA_Inventor.cs](Autodesk.Forge.Oss.DesignAutomation.Samples/DA_Inventor.cs)
* [Autodesk Tutorial for Revit](https://aps.autodesk.com/en/docs/design-automation/v3/tutorials/revit/) - [DA_Revit.cs](Autodesk.Forge.Oss.DesignAutomation.Samples/DA_Revit.cs)

## API Reference

The package use the namespace `Autodesk.Forge.Oss.DesignAutomation`.

### DesignAutomationService

`DesignAutomationService` class contain the methods to interact with the Oss and Design Automation API. 
Internaly uses the `ParameterArgumentService` to convert a class with `Attributes` to convert in the `Activity` and `WorkItem` to send the request to the Design Automation API.

#### MaxDesignAutomationService
```csharp
IDesignAutomationService designAutomationService = new MaxDesignAutomationService("AppName")
{
	EngineVersions = new[] { "2021" },
};
```
#### AutoCADDesignAutomationService
```csharp
IDesignAutomationService designAutomationService = new AutoCADDesignAutomationService("AppName")
{
	EngineVersions = new[] { "24" },
};
```
#### InventorDesignAutomationService
```csharp
IDesignAutomationService designAutomationService = new InventorDesignAutomationService("AppName")
{
	EngineVersions = new[] { "2021" },
};
```
#### RevitDesignAutomationService
```csharp
IDesignAutomationService designAutomationService = new RevitDesignAutomationService("AppName")
{
	EngineVersions = new[] { "2021" },
};
```

### Initialize

Initialize `AppBundle` by creating and uploading the zip file to the Design Automation.

```csharp
await designAutomationService.Initialize("Path/AppBundle.zip");
```

### Run

Create the `Activity` and run the `WorkItem` and wait for the result, use the `Parameters` class to define the parameters of the `Activity` and `WorkItem`.

```csharp
bool result = await designAutomationService.Run<Parameters>();
```

```csharp
bool result = await designAutomationService.Run<Parameters>((parameters) => {});
```

```csharp
Parameters parameters;
bool result = await designAutomationService.Run<Parameters>(parameters);
```

### Delete

Delete all the resources created by the `Initialize` and `Run`. 
`AppBundle` and `Activity` gonna be deleted if exists.

```csharp
await designAutomationService.Delete();
```

### Parameters

The `Parameters` class is used to define the parameters of the `Activity` and `WorkItem` using the `Attributes`.
* `ParameterInputAttribute` - Define the input parameter of the `Activity` and `WorkItem`.
* `ParameterOutputAttribute` - Define the output parameter of the `Activity` and `WorkItem`.

### ParameterInputAttribute
Base class `ParameterActivityAttribute` is used to update the `Activity` before send the request to the Design Automation API.
* `ParameterActivityClearBundleAttribute` - Clear the `AppBundle` before update the `Activity`.
* `ParameterActivityInputArgumentAttribute` - Define the input argument of the `Activity`.
* `ParameterActivityInputAttribute` - Define the input parameter of the `Activity`.
* `ParameterActivityInputOpenAttribute` - Define the input parameter of the `Activity` with `Open` file.
* `ParameterActivityLanguageAttribute` - Define the language of the `Activity`.
* `ParameterActivityScriptAttribute` - Define the script of the `Activity`.

### ParameterWorkItemAttribute
Base class `ParameterWorkItemAttribute` is used to update the `WorkItem` before send the request to the Design Automation API.

* `ParameterWorkItemTimeSecAttribute` - Define the timeout of the `WorkItem`.

## License

This project is [licensed](LICENSE) under the [MIT License](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](https://github.com/ricaun-io/forge-api-dotnet-oss.design.automation/stargazers)!
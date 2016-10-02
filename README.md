# LoRaClient

## Introduction
This is a C# client library built to simplify the usage of the API which is available for the KPN LoRa network.

The client is published as a [NuGet package](https://www.nuget.org/packages/Kpn.LoRa.Client/) and the source code is available on [GitHub](https://github.com/kpnlora/LoRaClient/). 

This repository also contains a **Stub** for the API which fakes most of the behavior, allowing you to test outside the network.

For more information about LoRa, visit the [KPN LoRa](http://www.kpn.com/lora) website.
For sales information, please contact KPN by mail at iot@kpn.com or by phone at 088-6601034

## Get Started

### .NET Core platform
Simply add a dependency to `Kpn.LoRa.Client` in your project.json file.

### Older versions of .NET
Right click on your project in Visual Studio and select **Manage NuGet Packages**. Select the **Browse** tab, search for `Kpn.LoRa.Client` and click install.

## Example: Create a connection with the LoRaClient
To start coding with the LoRaClient, add the following usings
```C#
using Kpn.LoRa.Client;
```

To start making calls, initiate a new LoRa client
```C#
using (ILoRaClient client = new LoRaClient("username", "password", "subscriberId", "baseAddress"))
{
	// Example 1: Retrieve customer information
	var customers = await client.GetCustomers();

	// Example 2: Retrieve network connections
	var networkSubscriptions = await client.GetNetworkSubscriptions(customers.subscription.href);

	// Example 3: Retrieve device profiles
	var deviceProfiles = await client.GetDeviceProfiles(customers.subscription.href);

	// Example 4: Retrieve devices
	await client.GetDevices(customers.subscription.href);
}
```

## Complete list of available calls
### Related to the subscription
* GetCustomers
* GetDeviceProfiles
* GetNetworkSubscriptions

### Related to routing profiles
* GetAppServerRoutingProfiles
* GetAppServerRoutingProfile
* AddAppServerRoutingProfile
* UpdateAppServerRoutingProfile
* RemoveAppServerRoutingProfile

### Related to devices
* GetDevices
* GetDevice
* AddDevice
* UpdateDevice
* RemoveDevice

### Related to alarms
* GetAlarms
* AckAlarmsForDevice

## LoRa API stub


## Contributors


## License
The LoRa Client is under the [MIT license][MIT].

[MIT]:LICENSE.md

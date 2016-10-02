using Betabit.Lora.Nuget.Example.Models;
using Kpn.LoRa.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Betabit.Lora.Nuget.Example.Controllers
{
	/// <summary>
	/// This controller can be used as a base for 
	/// communicating with the application context and the LoRa network.
	/// </summary>
	/// <seealso cref="Microsoft.AspNet.Mvc.Controller" />
	public abstract class BaseController : Controller
	{
		/// <summary>
		/// A readonly reference to the configuration.
		/// </summary>
		protected readonly IConfigurationRoot _configuration;

		/// <summary>
		/// A readonly reference to the context.
		/// </summary>
		protected readonly AppDbContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseController"/> class.
		/// </summary>
		/// <param name="configuration">The application configuration.</param>
		/// <param name="appDbContext">The application database context.</param>
		protected BaseController(IConfigurationRoot configuration, AppDbContext appDbContext)
		{
			_configuration = configuration;
			_context = appDbContext;
		}

		/// <summary>
		/// This encapsulation provides the username for the service bus event hub.
		/// This info is retrieved from the appsettings.json
		/// Make sure the key "Kpn::LoraClient::Username" is correctly provided.
		/// </summary>
		public string Username
		{
			get
			{
				// Retrieve the username from the appsettings.json
				var connectionInfo = _configuration["Kpn:LoraClient:Username"];

				// Make sure we have a username
				if (string.IsNullOrWhiteSpace(connectionInfo))
				{
					throw new ArgumentException("You need to provide the username in the appsettings.json");
				}

				// Return the username
				return connectionInfo;
			}
		}

		/// <summary>
		/// This encapsulation provides the password for the service bus event hub.
		/// This info is retrieved from the appsettings.json
		/// Make sure the key "Kpn::LoraClient::Password" is correctly provided.
		/// </summary>
		public string Password
		{
			get
			{
				// Retrieve the password from the appsettings.json
				var connectionInfo = _configuration["Kpn:LoraClient:Password"];

				// Make sure we have a password
				if (string.IsNullOrWhiteSpace(connectionInfo))
				{
					throw new ArgumentException("You need to provide the password in the appsettings.json");
				}

				// Return the password
				return connectionInfo;
			}
		}

		/// <summary>
		/// This encapsulation provides the subscriber id for the service bus event hub.
		/// This info is retrieved from the appsettings.json
		/// Make sure the key "Kpn::LoraClient::SubscriberId" is correctly provided.
		/// </summary>
		public string SubscriberId
		{
			get
			{
				// Retrieve the subscriber id from the appsettings.json
				var connectionInfo = _configuration["Kpn:LoraClient:SubscriberId"];

				// Make sure we have a subscriber id
				if (string.IsNullOrWhiteSpace(connectionInfo))
				{
					throw new ArgumentException("You need to provide the subscriber id in the appsettings.json");
				}

				// Return the subscriber id
				return connectionInfo;
			}
		}

		/// <summary>
		/// This encapsulation provides the base address for the service bus event hub.
		/// This info is retrieved from the appsettings.json
		/// Make sure the key "Kpn::LoraClient::BaseAddress" is correctly provided.
		/// </summary>
		public string BaseAddress
		{
			get
			{
				// Retrieve the base address from the appsettings.json
				var connectionInfo = _configuration["Kpn:LoraClient:BaseAddress"];

				// Make sure we have a base address
				if (string.IsNullOrWhiteSpace(connectionInfo))
				{
					throw new ArgumentException("You need to provide the base address in the appsettings.json");
				}

				// Return the base address
				return connectionInfo;
			}
		}

		/// <summary>
		/// Creates the LoRa client.
		/// </summary>
		protected ILoRaClient CreateLoRaClient()
		{
			return new LoRaClient(Username, Password, SubscriberId, BaseAddress);
		}
	}
}

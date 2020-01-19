using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace EPICCentral.REST.Core
{
	// This was adapted from the example at the following web address:
	// http://stackoverflow.com/questions/5087979/specifying-a-wcf-binding-when-using-serviceroute

	/// <summary>
	/// A specialized <see cref="WebServiceHost"/> that can accept a maximum message size
	/// parameter on construction and then configure the bindings to allow the service to
	/// accept messages of that maximum size.
	/// </summary>
	public class ServiceHost : WebServiceHost
	{
		private readonly int maxReceivedMessageSize;

		/// <summary>
		/// Construct an instance for the specified <code>Type</code> and base addresses.
		/// It will configure the bindings to receive messages up to the specified maximum
		/// message size.
		/// If the default message size is greater than the size specified, the default will
		/// not be changed.
		/// </summary>
		/// <param name="serviceType">the <code>Type</code> of the class that implements the service</param>
		/// <param name="maxReceivedMessageSize">maximum size of messages that can be received; 0
		///		specifies that the default be used</param>
		/// <param name="baseAddresses">base URI addresses for the service</param>
		public ServiceHost(Type serviceType, int maxReceivedMessageSize, params Uri[] baseAddresses)
			: base(serviceType, baseAddresses)
		{
			this.maxReceivedMessageSize = maxReceivedMessageSize;
		}

		/// <summary>
		/// When the <code>ServiceHost</code> instance is opened/initialized, set the maximum
		/// message size if necessary.
		/// </summary>
		protected override void OnOpening()
		{
			base.OnOpening();

			// Is there a specified maximum message size? If not, do nothing.
			if (maxReceivedMessageSize > 0)
			{
				foreach (Uri baseAddress in BaseAddresses)
				{
					// Try to configure endpoints first.
					if (!ConfigureEndpoint(baseAddress))
					{
						// No endpoints were configured. So create one.
						if (ImplementedContracts.Count > 1)
							throw new InvalidOperationException("Service '" + Description.ServiceType.Name +
								                                "' implements multiple ServiceContract types, and no endpoints are defined in the configuration file. " +
								                                "This WebServiceHost can set up default endpoints, but only if the service implements only a single ServiceContract. " +
								                                "Either change the service to only implement a single ServiceContract, or else define endpoints for the service explicitly " +
								                                "in the configuration file. When more than one contract is implemented, must add base address endpoint manually");

						// Get the only service contract.
						var enumerator = ImplementedContracts.Values.GetEnumerator();
						enumerator.MoveNext();

						// Create a web binding with the specified maximum message size.
						WebHttpBinding binding = new WebHttpBinding {MaxReceivedMessageSize = maxReceivedMessageSize, MaxBufferSize = maxReceivedMessageSize, MaxBufferPoolSize = maxReceivedMessageSize};

						// Add a service endpoint for the service contract type with the new binding
						// and the base address.
						AddServiceEndpoint(enumerator.Current.ContractType, binding, baseAddress);
					}
				}

				// Configure an web behavior for each endpoint.
				foreach (ServiceEndpoint se in Description.Endpoints)
					if (se.Behaviors.Find<WebHttpBehavior>() == null)
						se.Behaviors.Add(new WebHttpBehavior());
			}
		}

		/// <summary>
		/// Configure any endpoint for the maximum size of message.
		/// </summary>
		/// <param name="baseAddress">base address for the service</param>
		/// <returns><code>true</code> if an endpoint is configured, <code>false</code> if no
		///		endpoint is configured</returns>
		private bool ConfigureEndpoint(Uri baseAddress)
		{
			// Find endpoints for the specified base address.
			foreach (ServiceEndpoint se in Description.Endpoints)
			{
				if (se.Address.Uri == baseAddress)
				{
					// Is the binding a default HTTP binding?
					if (se.Binding is WebHttpBinding)
					{
						// HTTP. Set the size of messages, and buffers, to the max for this instance,
						// but only if it is greater than the default.
						WebHttpBinding binding = (WebHttpBinding)se.Binding;
						if (binding.MaxReceivedMessageSize < maxReceivedMessageSize)
						{
							binding.MaxReceivedMessageSize = maxReceivedMessageSize;
							binding.MaxBufferSize = maxReceivedMessageSize;
							binding.MaxBufferPoolSize = maxReceivedMessageSize;
						}
					}
					// Is the binding a custom binding?
					else if (se.Binding is CustomBinding)
					{
						// Find the transport binding element.
						foreach (BindingElement bindingElement in ((CustomBinding)se.Binding).Elements)
						{
							if (bindingElement is TransportBindingElement)
							{
								// Set the size of messages, and buffers, to the max for this instance,
								// but only if it is greater than the defaul.
								TransportBindingElement transportBindingElement = (TransportBindingElement)bindingElement;
								if (transportBindingElement.MaxReceivedMessageSize < maxReceivedMessageSize)
								{
									transportBindingElement.MaxReceivedMessageSize = maxReceivedMessageSize;
									transportBindingElement.MaxBufferPoolSize = maxReceivedMessageSize;
								}
							}
						}
					}

					// Indicate an endpoint was configures.
					return true;
				}
			}

			// Indicate no endpoint was configured.
			return false;
		}
	}

	/// <summary>
	/// A specialized <see cref="WebServiceHostFactory"/> for creating
	/// <see cref="System.ServiceModel.ServiceHost"/> instances with binding configured to accept
	/// messages larger than the default size of the system.
	/// </summary>
	public class ServiceHostFactory : WebServiceHostFactory
	{
		private readonly int maxReceivedMessageSize;

		/// <summary>
		/// Construct an instance of the factory to create <see cref="ServiceHost"/> instances
		/// able to recieve messages restricted to the default message size of the system.
		/// </summary>
		public ServiceHostFactory()
		{
		}

		/// <summary>
		/// Construct an instance of the factory to create <see cref="ServiceHost"/> instances
		/// able to recieve messages of the specified size.
		/// If the specified message size is 0, the default message size of the system will be used.
		/// </summary>
		/// <param name="maxReceivedMessageSize">maximum size (in bytes) for messages received;
		///		use 0 to keep the system default size</param>
		public ServiceHostFactory(int maxReceivedMessageSize)
		{
			this.maxReceivedMessageSize = maxReceivedMessageSize;
		}

		/// <summary>
		/// Create a <see cref="ServiceHost"/> instance implemented by the specified <code>Type</code>
		/// for the specified base addresses.
		/// The <code>ServiceHost</code> will configure the transport bindings to accept messages
		/// restricted to the maximum size specified when the factory was constructed.
		/// </summary>
		/// <param name="serviceType"><code>Type</code> of the class that implements the service</param>
		/// <param name="baseAddresses">base URI addresses that will invoke the service</param>
		/// <returns>a <code>ServiceHost</code> instance for the service</returns>
		protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
		{
			return new ServiceHost(serviceType, maxReceivedMessageSize, baseAddresses);
		}
	}
}
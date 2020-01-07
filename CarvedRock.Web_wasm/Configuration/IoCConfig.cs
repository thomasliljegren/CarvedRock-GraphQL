using CarvedRock.Web.Clients;
using GraphQL.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Reflection;

namespace CarvedRock.Web.Configuration
{
    public sealed class IoCConfig
    {
        private static bool _configured = false;

        public static void ConfigureServices(IServiceCollection services)
        {
            if (!_configured)
            {
                services.AddSingleton<IProductGraphClient, ProductGraphClient>();

                var wasmHttpMessageHandlerType = Assembly.Load("WebAssembly.Net.Http").GetType("WebAssembly.Net.Http.HttpClient.WasmHttpMessageHandler");
                var wasmHttpMessageHandler = (HttpMessageHandler)Activator.CreateInstance(wasmHttpMessageHandlerType);

                services.AddSingleton(t => new GraphQLClient("https://localhost:5001/graphql", options: new GraphQLClientOptions { HttpMessageHandler = wasmHttpMessageHandler }));
            }
            _configured = true;
        }
    }
}

using System;
using FreshInterview.Shared.Http;
using FreshInterview.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FreshInterview
{
	public static class DependencyInjection
	{
		public static IServiceProvider ServiceProvider;

        public static void Init()
        {
            var collection = new ServiceCollection();

            RegisterViewModels(collection);
            RegisterHttpClients(collection);

            ServiceProvider = collection.BuildServiceProvider();
        }

        static void RegisterViewModels(ServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<MainVm>()
                .AddTransient<BreweryDetailVm>();
        }

        static void RegisterHttpClients(ServiceCollection serviceCollection)
        {
            serviceCollection
                .AddHttpClient<OpenBrewApiClient>();
        }
    }
}


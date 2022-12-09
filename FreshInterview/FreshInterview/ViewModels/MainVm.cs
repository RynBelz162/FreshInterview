using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using FreshInterview.Pages;
using FreshInterview.Shared.Http;
using FreshInterview.Shared.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Xamarin.Forms;

namespace FreshInterview.ViewModels
{
	public partial class MainVm : ObservableObject
	{
		readonly OpenBrewApiClient _openBrewApiClient;
		int _page = 1;

		[ObservableProperty]
		private bool isBusy = true;

		[ObservableProperty]
		private ObservableCollection<Brewery> breweries = new ObservableCollection<Brewery>();

        public IAsyncRelayCommand<Brewery> NavigateToBreweryCommand { get; }
        public IAsyncRelayCommand LoadMoreBreweriesCommand { get; }

        public MainVm(OpenBrewApiClient openBrewApiClient)
		{
			_openBrewApiClient = openBrewApiClient;

			NavigateToBreweryCommand = new AsyncRelayCommand<Brewery>(NavigateToDetailPage);
            LoadMoreBreweriesCommand = new AsyncRelayCommand(LoadMore);

            Task.Run(async () => await LoadBrewries(_page));
		}

        async Task NavigateToDetailPage(Brewery brewery)
		{
			var raw = JsonSerializer.Serialize(brewery);
            await Shell.Current.GoToAsync($"{nameof(BreweryDetailPage)}?Brewery={raw}");
        }


        async Task LoadBrewries(int page)
		{
			try
			{
                var allBreweries = await _openBrewApiClient.GetBreweries(page);

				if (page == 1)
				{
                    Breweries = new ObservableCollection<Brewery>(allBreweries);
                }
				else
				{
					foreach (var brewery in allBreweries)
					{
						Breweries.Add(brewery);
					}
				}
            }
			catch
			{
				// display toast or error alert
			}
			finally
			{
				Device.BeginInvokeOnMainThread(() => IsBusy = false);
			}
		}

		async Task LoadMore()
		{
			_page++;
			await LoadBrewries(_page);
		}
	}
}


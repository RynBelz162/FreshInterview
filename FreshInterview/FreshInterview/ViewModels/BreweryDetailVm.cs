using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Web;
using FreshInterview.Shared.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Xamarin.Forms;

namespace FreshInterview.ViewModels
{
    public partial class BreweryDetailVm : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        public Brewery brewery;

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            var breweryRaw = HttpUtility.UrlDecode(query[nameof(Brewery)]);
            Brewery = JsonSerializer.Deserialize<Brewery>(breweryRaw);
        }
    }
}

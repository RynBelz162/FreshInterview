using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using FreshInterview.ViewModels;

using Xamarin.Forms;

namespace FreshInterview.Pages
{
    public partial class BreweryDetailPage : ContentPage
    {
        public BreweryDetailPage()
        {
            InitializeComponent();

            BindingContext = DependencyInjection.ServiceProvider.GetRequiredService<BreweryDetailVm>();
        }
    }
}


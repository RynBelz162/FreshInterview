using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FreshInterview.Pages
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BreweryDetailPage), typeof(BreweryDetailPage));
        }
    }
}


using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace FreshInterview.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = DependencyInjection.ServiceProvider.GetRequiredService<ViewModels.MainVm>();
        }
    }
}

using Xamarin.Forms;
using FreshInterview.Pages;

namespace FreshInterview
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            DependencyInjection.Init();

            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}


using KPI.Services;
using KPI.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KPI
{
    public partial class App : Application
    {
        
        public static string passwordMemory { set; get; }
        public static string loginMemory { set; get; }

        public App()
        {
            InitializeComponent();

            passwordMemory = string.Empty;
            loginMemory = string.Empty;
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            Shell.Current.GoToAsync("//LoginPage");
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

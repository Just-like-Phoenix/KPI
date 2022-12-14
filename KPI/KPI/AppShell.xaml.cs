using KPI.Classes;
using KPI.ViewModels;
using KPI.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace KPI
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("AddPersonPage", typeof(AddPersonPage));
            Routing.RegisterRoute("EditPersonPage", typeof(EditPersonPage));
            Routing.RegisterRoute("PersonnelPage", typeof(PersonnelPage));
            Routing.RegisterRoute("PersonPage", typeof(PersonPage));
            Routing.RegisterRoute("AddMenegerPage", typeof(AddMenegerPage));
            Routing.RegisterRoute("EditMenegerPage", typeof(EditMenegerPage));
            Routing.RegisterRoute("MenegersPage", typeof(MenegersPage));

            if (App.loginpram == 3)
            {
                Employee.IsVisible = false;
            }
            if (App.loginpram == 2)
            {
                Employee.IsVisible = false;
            }
            if (App.loginpram == 1)
            {
                Menegers.IsVisible = false;
                Employees.IsVisible = false; 
            }
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Connection.GetConnection().Disconnect();
            await Shell.Current.GoToAsync("//LoginPage");
        }

        protected override async void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
        }
    }
}

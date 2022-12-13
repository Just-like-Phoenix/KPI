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
            Routing.RegisterRoute("PersonnelPage", typeof(PersonnelPage));

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
                Employees.IsVisible = false; 
            }
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Connection.GetConnection().Disconnect();
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}

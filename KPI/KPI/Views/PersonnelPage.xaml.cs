using App3.ViewModels;
using KPI.Classes;
using KPI.Models;
using Syncfusion.Data;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.SfDataGrid.XForms.DataPager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace KPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonnelPage : ContentPage
    {
        public PersonnelPage()
        {

            InitializeComponent();

            deleteButton.IsVisible = false;
            updateButton.IsVisible = false;
            gotopersonButton.IsVisible = false;

            sfDataPager.AppearanceManager = new App.CustomAppearance();
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync("//PersonnelPage/AddPersonPage");
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            Connection connection = Connection.GetConnection();
            for (int i = 0; i < personsGrid.SelectedItems.Count; i++)
            {
                Persons person = personsGrid.SelectedItems[i] as Persons;
                connection.DelPerson(person.uuid);
            }
            var ViewModel = new BaseViewModel();
            ViewModel.PersonsGrid = connection.GetWorkerPersons();
            sfDataPager.Source = ViewModel.PersonsGrid;
            personsGrid.ItemsSource = sfDataPager.PagedSource;
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            EditPersonPage.person = personsGrid.SelectedItem as Persons;
            AppShell.Current.GoToAsync("//PersonnelPage/EditPersonPage");
        }

        private void gotopersonButton_Clicked(object sender, EventArgs e)
        {
            if (personsGrid.SelectedItems.Count == 1)
            {
                Persons person = personsGrid.SelectedItem as Persons;
                PersonPage.uuid_from_grid = person.uuid;
                PersonPage.ueid_from_grid = person.ueid;
                PersonPage.upid_from_grid = person.upid;
            }
            AppShell.Current.GoToAsync("//PersonnelPage/PersonPage");
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            addButton.IsVisible = true;
            deleteButton.IsVisible = false;
            updateButton.IsVisible = false;
            gotopersonButton.IsVisible = false;
            Connection connection = Connection.GetConnection();
            var ViewModel = new BaseViewModel();
            ViewModel.PersonsGrid = connection.GetWorkerPersons();
            sfDataPager.Source = ViewModel.PersonsGrid;
            personsGrid.ItemsSource = sfDataPager.PagedSource;
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            addButton.IsVisible = true;
            deleteButton.IsVisible = false;
            updateButton.IsVisible = false;
            gotopersonButton.IsVisible = false;
        }

        private void personsGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
        }

        private void personsGrid_GridTapped(object sender, GridTappedEventArgs e)
        {
            if (e.RowColumnIndex.RowIndex != 0)
            {
                if (personsGrid.SelectionController.SelectedRows.Count == 0)
                {
                    addButton.IsVisible = true;
                    deleteButton.IsVisible = false;
                    updateButton.IsVisible = false;
                    gotopersonButton.IsVisible = false;
                }
                if (personsGrid.SelectionController.SelectedRows.Count == 1)
                {
                    addButton.IsVisible = true;
                    deleteButton.IsVisible = true;
                    updateButton.IsVisible = true;
                    gotopersonButton.IsVisible = true;
                }
                if (personsGrid.SelectionController.SelectedRows.Count > 1)
                {
                    addButton.IsVisible = true;
                    deleteButton.IsVisible = true;
                    updateButton.IsVisible = false;
                    gotopersonButton.IsVisible = false;
                }
            }
        }
    }
}
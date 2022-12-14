using App3.ViewModels;
using KPI.Classes;
using KPI.Models;
using Syncfusion.SfDataGrid.XForms.DataPager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenegersPage : ContentPage
    {
        public MenegersPage()
        {
            InitializeComponent();

            deleteButton.IsVisible = false;
            updateButton.IsVisible = false;

            sfDataPager.AppearanceManager = new App.CustomAppearance();
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("AddMenegerPage");
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            Connection connection = Connection.GetConnection();
            for(int i = 0; i < menegerGrid.SelectedItems.Count; i++)
            {
                Persons person = menegerGrid.SelectedItems[i] as Persons;
                connection.DelPerson(person.uuid);
            }
            var ViewModel = new BaseViewModel();
            ViewModel.PersonsGrid = connection.GetMenegerPersons();
            sfDataPager.Source = ViewModel.PersonsGrid;
            menegerGrid.ItemsSource = sfDataPager.PagedSource;
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {

            EditMenegerPage.person = menegerGrid.SelectedItem as Persons;
            Shell.Current.GoToAsync("EditMenegerPage");
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            Connection connection = Connection.GetConnection();
            var ViewModel = new BaseViewModel();
            ViewModel.PersonsGrid = connection.GetMenegerPersons();
            sfDataPager.Source = ViewModel.PersonsGrid;
            menegerGrid.ItemsSource = sfDataPager.PagedSource;
        }

        private void menegerGrid_SelectionChanged(object sender, Syncfusion.SfDataGrid.XForms.GridSelectionChangedEventArgs e)
        {
            if (menegerGrid.SelectionController.SelectedRows.Count == 0)
            {
                addButton.IsVisible = true;
                deleteButton.IsVisible = false;
                updateButton.IsVisible = false;
            }
            if (menegerGrid.SelectionController.SelectedRows.Count == 1)
            {
                addButton.IsVisible = true;
                deleteButton.IsVisible = true;
                updateButton.IsVisible = true;
            }
            if (menegerGrid.SelectionController.SelectedRows.Count > 1)
            {
                addButton.IsVisible = true;
                deleteButton.IsVisible = true;
                updateButton.IsVisible = false;
            }
        }
    }
}
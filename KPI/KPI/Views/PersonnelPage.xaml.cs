﻿using App3.ViewModels;
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
            Shell.Current.GoToAsync("//AddPersonPage");
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            Persons person = personsGrid.SelectedItem as Persons;
            Connection connection = Connection.GetConnection();
            connection.DelPerson(person.uuid);
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private void gotopersonButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            Connection connection = Connection.GetConnection();
            var ViewModel = new BaseViewModel();
            ViewModel.PersonsGrid = connection.GetWorkerPersons();
            sfDataPager.Source = ViewModel.PersonsGrid;
            personsGrid.ItemsSource = sfDataPager.PagedSource;
        }

        private void personsGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
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
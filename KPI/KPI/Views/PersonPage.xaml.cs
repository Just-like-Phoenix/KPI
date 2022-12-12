﻿using App3.ViewModels;
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
    public partial class PersonPage : ContentPage
    {
        public PersonPage()
        {
            InitializeComponent();
            var ViewModel = new BaseViewModel();
            sfDataPager.Source = ViewModel.PersonTasksGrid;
            person_tasksGrid.ItemsSource = sfDataPager.PagedSource;
        }
    }
}
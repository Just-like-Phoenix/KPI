using App3.ViewModels;
using KPI.Classes;
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
    public partial class PersonnelPage : ContentPage
    {
        public PersonnelPage()
        {

            InitializeComponent();



            searchSettings.Hint = "Поиск";
            searchSettings.EnableHintAnimation = true;
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//AddPersonPage");
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            Connection connection = Connection.GetConnection();


            var ViewModel = new BaseViewModel();
            ViewModel.PersonsGrid = connection.GetPersons();
            sfDataPager.Source = ViewModel.PersonsGrid;
            personsGrid.ItemsSource = sfDataPager.PagedSource;
        }
    }
}
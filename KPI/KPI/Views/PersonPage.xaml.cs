using App3.ViewModels;
using KPI.Classes;
using KPI.Models;
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
            sfDataPager.AppearanceManager = new App.CustomAppearance();
            var ViewModel = new BaseViewModel();
            sfDataPager.Source = ViewModel.PersonTasksGrid;
            person_tasksGrid.ItemsSource = sfDataPager.PagedSource;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            Connection conection = Connection.GetConnection();
            int uuid = int.Parse(App.logineduserid);
            Persons person = (Persons)conection.GetPerson(uuid);
            
            first_name.Text = person.name;
            last_name.Text = person.surname;
            patronymic.Text = person.patronymic;
            email.Text = person.email;
            telephone.Text = person.telephone;
        }
    }
}
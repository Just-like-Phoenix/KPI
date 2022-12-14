using App3.ViewModels;
using KPI.Classes;
using KPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public static bool isMeneger = false;
        public static int uuid_from_grid = 0;

        public PersonPage()
        {
            InitializeComponent();
            if (isMeneger == false)
            {
                ButtonsFrame.IsVisible = false;
            }
            else
            {
                ButtonsFrame.IsVisible = true;
            }
            sfDataPager.AppearanceManager = new App.CustomAppearance();
            var ViewModel = new BaseViewModel();
            sfDataPager.Source = ViewModel.PersonTasksGrid;
            person_tasksGrid.ItemsSource = sfDataPager.PagedSource;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            Connection conection = Connection.GetConnection();
            int uuid;
            if (isMeneger == false)
            {
                uuid = int.Parse(App.logineduserid);
            }    
            else
            {
                uuid = uuid_from_grid;
            }

            Persons person = (Persons)conection.GetPerson(uuid);
            conection.GetTasks(uuid);
            first_name.Text = person.name;
            last_name.Text = person.surname;
            patronymic.Text = person.patronymic;
            salary.Text = "" + person.salry;
            award.Text = "" + person.award;
            email.Text = person.email;
            telephone.Text = person.telephone;
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//PersonnelPage/PersonPage/AddTask");
        }
    }
}
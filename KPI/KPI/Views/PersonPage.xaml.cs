using App3.ViewModels;
using KPI.Classes;
using KPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static int upid_from_grid = 0;
        public static int ueid_from_grid = 0;
        public int uuid;

        public PersonPage()
        {
            InitializeComponent();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            sfDataPager.AppearanceManager = new App.CustomAppearance();
            if (isMeneger == false)
            {
                ButtonsFrame.IsVisible = false;
            }
            else
            {
                ButtonsFrame.IsVisible = true;
                addButton.IsVisible = true;
                plsoneButton.IsVisible = false;
            }
            Connection conection = Connection.GetConnection();
            if (isMeneger == false)
            {
                this.uuid = int.Parse(App.logineduserid);
            }    
            else
            {
                this.uuid = uuid_from_grid;
            }

            Persons person = (Persons)conection.GetPerson(uuid);
            first_name.Text = person.name;
            last_name.Text = person.surname;
            patronymic.Text = person.patronymic;
            salary.Text = "" + person.salry;
            award.Text = "" + person.award;
            email.Text = person.email;
            telephone.Text = person.telephone;

            var ViewModel = new BaseViewModel();
            ViewModel.PersonTasksGrid = conection.GetTasks(uuid);
            sfDataPager.Source = ViewModel.PersonTasksGrid;
            person_tasksGrid.ItemsSource = sfDataPager.PagedSource;

            List<double> tasks_ret = conection.KPI(uuid, double.Parse(salary.Text));
            award.Text = "" + tasks_ret[0];
            CircularProgressBar.Progress = tasks_ret[1]; 
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            AddTask.uuid = uuid_from_grid;
            AddTask.ueid = ueid_from_grid;
            AddTask.upid = upid_from_grid;
            AppShell.Current.GoToAsync("//AddTask");
        }

        private void plsoneButton_Clicked(object sender, EventArgs e)
        {
            Connection connection = Connection.GetConnection();
            for (int i = 0; i < person_tasksGrid.SelectedItems.Count; i++)
            {
                PersonTask task = person_tasksGrid.SelectedItems[i] as PersonTask;
                task.count_of_complited += 1;
                connection.UpdateTask(task.utid, task.uuid, "" + task.count_of_complited);
            }
            var ViewModel = new BaseViewModel();
            ViewModel.PersonTasksGrid = connection.GetTasks(uuid);
            sfDataPager.Source = ViewModel.PersonTasksGrid;
            person_tasksGrid.ItemsSource = sfDataPager.PagedSource;

            List<double> tasks_ret = connection.KPI(uuid, double.Parse(salary.Text));
            award.Text = "" + tasks_ret[0];
            CircularProgressBar.Progress = tasks_ret[1];
            ButtonsFrame.IsVisible = false;
        }

        private void person_tasksGrid_GridTapped(object sender, Syncfusion.SfDataGrid.XForms.GridTappedEventArgs e)
        {
            if (e.RowColumnIndex.RowIndex != 0)
            {
                if (person_tasksGrid.SelectionController.SelectedRows.Count == 0)
                {
                    if (isMeneger == false)
                    {
                        ButtonsFrame.IsVisible = false;
                    }
                    else
                    {
                        ButtonsFrame.IsVisible = true;
                        addButton.IsVisible = true;
                        plsoneButton.IsVisible = false;
                    }
                }
                if (person_tasksGrid.SelectionController.SelectedRows.Count == 1)
                {
                    if (isMeneger == false)
                    {
                        ButtonsFrame.IsVisible = true;
                        addButton.IsVisible = false;
                        plsoneButton.IsVisible = true;
                    }
                    else
                    {
                        ButtonsFrame.IsVisible = true;
                        addButton.IsVisible = true;
                        plsoneButton.IsVisible = false;
                    }
                }
                if (person_tasksGrid.SelectionController.SelectedRows.Count > 1)
                {
                    if (isMeneger == false)
                    {
                        ButtonsFrame.IsVisible = true;
                        addButton.IsVisible = false;
                        plsoneButton.IsVisible = true;
                    }
                    else
                    {
                        ButtonsFrame.IsVisible = true;
                        addButton.IsVisible = true;
                        plsoneButton.IsVisible = false;
                    }
                }
            }
        }
    }
}
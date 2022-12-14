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
    public partial class AddMenegerPage : ContentPage
    {
        public AddMenegerPage()
        {
            InitializeComponent();

            loginEdit.Value = "";
            passwordEdit.Value = "";
            nameEdit.Value = "";
            surnameEdit.Value = "";
            patronymicEdit.Value = "";
            salaryEdit.Value = "";
            emailEdit.Value = "";
            telephoneEdit.Value = "";
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            if (loginEdit.Value.ToString() != "" && passwordEdit.Value.ToString() != "" && nameEdit.Value.ToString() != "" && surnameEdit.Value.ToString() != "" && patronymicEdit.Value.ToString() != "" && salaryEdit.Value.ToString() != "" && emailEdit.Value.ToString() != "" && telephoneEdit.Value.ToString() != "")
            {
                Connection connection = Connection.GetConnection();
                bool tmp = connection.AddPerson(loginEdit.Value as string, passwordEdit.Value as string, nameEdit.Value as string, surnameEdit.Value as string, patronymicEdit.Value as string, emailEdit.Value as string, telephoneEdit.Value as string, "meneger", salaryEdit.Value as string);

                if (tmp)
                {
                    Shell.Current.GoToAsync("//MenegersPage");
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Ошибка добавления", "Запись не внесена в базу данных", "Ок");
                    Shell.Current.GoToAsync("//MenegersPage");
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Ошибка ввода", "Данные введены неверно", "Ок");
            }
        }
    }
}
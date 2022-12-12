using KPI.Classes;
using Syncfusion.XForms.MaskedEdit;
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
    public partial class AddPersonPage : ContentPage
    {
        public AddPersonPage()
        {
            InitializeComponent();
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            Connection connection = Connection.GetConnection();
            bool tmp = connection.AddWorker(loginEdit.Value as string, passwordEdit.Value as string, nameEdit.Value as string, surnameEdit.Value as string, patronymicEdit.Value as string, emailEdit.Value as string, telephoneEdit.Value as string, "worker", salaryEdit.Value as string);

            if (tmp)
            {
                Shell.Current.GoToAsync("//PersonnelPage");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Ошибка добавления", "Запись не внесена в базу данных", "Ок");
                Shell.Current.GoToAsync("//PersonnelPage");
            }
        }
    }
}
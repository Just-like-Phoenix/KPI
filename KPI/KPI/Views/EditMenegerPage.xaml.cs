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
    public partial class EditMenegerPage : ContentPage
    {
        public static Persons person { get; set; }

        public EditMenegerPage()
        {
            InitializeComponent();

            nameEdit.Value = person.name;
            surnameEdit.Value = person.surname;
            patronymicEdit.Value = person.patronymic;
            emailEdit.Value = person.email;
            telephoneEdit.Value = person.telephone;
        }

        private void updButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MenegersPage");
            Connection connection = Connection.GetConnection();
            connection.Update("" + person.uuid, nameEdit.Value.ToString(), surnameEdit.Value.ToString(), patronymicEdit.Value.ToString(), emailEdit.Value.ToString(), telephoneEdit.Value.ToString(), "" + person.salry);
        }

        private void exitButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MenegersPage");
        }
    }
}
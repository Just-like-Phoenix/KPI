using KPI.Classes;
using KPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPersonPage : ContentPage
    {
        public static Persons person { get; set; }
        
        public EditPersonPage()
        {
            InitializeComponent();

            nameEdit.Value = person.name;
            surnameEdit.Value = person.surname;
            patronymicEdit.Value = person.patronymic;
            salaryEdit.Value = person.salry;
            emailEdit.Value = person.email;
            telephoneEdit.Value = person.telephone;
        }

        private void updButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//PersonnelPage");
            Connection connection = Connection.GetConnection();
            connection.Update("" + person.uuid, nameEdit.Value.ToString(), surnameEdit.Value.ToString(), patronymicEdit.Value.ToString(), emailEdit.Value.ToString(), telephoneEdit.Value.ToString(), salaryEdit.Value.ToString());
        }
    }
}
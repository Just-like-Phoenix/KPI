using KPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace KPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTask : ContentPage
    {
        public static int uuid;
        public static int ueid;
        public static int upid;

        public AddTask()
        {
            InitializeComponent();
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            if (task_text.Value.ToString() != "" && need_to_do.Value.ToString() != "")
            {
                Connection connection = Connection.GetConnection();
                DateTime date = startdate.Date;
                connection.AddTask(uuid, upid, ueid, task_text.Value.ToString(), int.Parse(need_to_do.Value.ToString()), date.ToShortDateString(), date.AddDays(30).ToShortDateString());
                Shell.Current.GoToAsync("//PersonnelPage/PersonPage");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Ошибка ввода", "Данные введены неверно", "Ок");
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//PersonnelPage/PersonPage");
        }
    }
}
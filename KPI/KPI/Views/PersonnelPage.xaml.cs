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
    }
}
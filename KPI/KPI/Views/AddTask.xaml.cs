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
        public AddTask()
        {
            InitializeComponent();
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//PersonnelPage/PersonPage");
        }
    }
}
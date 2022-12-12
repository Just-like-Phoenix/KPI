using App3.ViewModels;
using KPI.Classes;
using Syncfusion.SfDataGrid.XForms.DataPager;
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
    public partial class PersonnelPage : ContentPage
    {
        public PersonnelPage()
        {

            InitializeComponent();

            sfDataPager.AppearanceManager = new CustomAppearance();

            searchSettings.Hint = "Поиск";
            searchSettings.EnableHintAnimation = true;
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//AddPersonPage");
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            Connection connection = Connection.GetConnection();


            var ViewModel = new BaseViewModel();
            ViewModel.PersonsGrid = connection.GetPersons();
            sfDataPager.Source = ViewModel.PersonsGrid;
            personsGrid.ItemsSource = sfDataPager.PagedSource;
        }

        public class CustomAppearance : AppearanceManager
        {
            OSAppTheme currentTheme = Application.Current.RequestedTheme;

            public override Color GetDataPagerBackgroundColor()
            {
                Color color;
                if (currentTheme == OSAppTheme.Dark)
                {
                    color = Color.FromHex("#2d2d2d");
                }
                else
                {
                    color = Color.FromHex("#ffffff");
                }
                return color;
            }

            public override Color GetNumericButtonBackgroundColor(ButtonShape shape = ButtonShape.Rectangle)
            {
                Color color;
                if (currentTheme == OSAppTheme.Dark)
                {
                    color = Color.FromHex("#393939");
                }
                else
                {
                    color = Color.FromHex("#f8f8f8");
                }
                return color;
            }

            public override Color GetNumericButtonForegroundColor()
            {
                Color color;
                if (currentTheme == OSAppTheme.Dark)
                {
                    color = Color.FromHex("#ffffff");
                }
                else
                {
                    color = Color.FromHex("#000000");
                }
                return color;
            }

            public override Color GetNumericButtonSelectionBackgroundColor()
            {
                Color color;
                if (currentTheme == OSAppTheme.Dark)
                {
                    color = Color.FromHex("#7eff60");
                }
                else
                {
                    color = Color.FromHex("#03b800");
                }
                return color;
            }

            public override Color GetNumericButtonSelectionForegroundColor()
            {
                Color color;
                if (currentTheme == OSAppTheme.Dark)
                {
                    color = Color.FromHex("#081216");
                }
                else
                {
                    color = Color.FromHex("#e5eff8");
                }
                return color;
            }
        }
    }
}
using KPI.Services;
using KPI.Views;
using KPI.Classes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.SfDataGrid.XForms.DataPager;

namespace KPI
{
    public partial class App : Application
    {
        
        public static string passwordMemory { set; get; }
        public static string loginMemory { set; get; }
        public static string logineduserid { set; get; }
        public static int loginpram { set; get; }

        public App()
        {
            InitializeComponent();

            Connection connection = new Connection();
            Connection.SetConnection(connection);
            loginpram = 0;
            passwordMemory = string.Empty;
            loginMemory = string.Empty;
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            AppShell.Current.GoToAsync("//LoginPage");
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
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

            public override Color GetNavigationButtonIconColor()
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
            public override Color GetNavigationButtonBackgroundColor(ButtonShape shape = ButtonShape.Rectangle)
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
            public override Color GetPagerButtonBorderColor(ButtonShape shape = ButtonShape.Rectangle)
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
        }
    }
}

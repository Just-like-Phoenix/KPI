using KPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.XForms;

namespace KPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

            login.Text = App.passwordMemory;
            password.Text = App.passwordMemory;

            loginSettings.Hint = "Логин";
            loginSettings.EnableHintAnimation = true;

            passwordSettings.Hint = "Пароль";
            passwordSettings.EnableHintAnimation = true;
            passwordSettings.EnablePasswordVisibilityToggle = true;
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new AppShell();
            App.passwordMemory = password.Text;
            App.loginMemory = login.Text;
        }
    }
}
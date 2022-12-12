using KPI.ViewModels;
using KPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.XForms;
using System.Net.Sockets;

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
            Connection.GetConnection().Connect();
            App.loginpram = Connection.GetConnection().Login(login.Text, password.Text);
            if (App.loginpram == 3) 
            {
                App.Current.MainPage = new AppShell();
                App.passwordMemory = password.Text;
                App.loginMemory = login.Text;
            }
            if (App.loginpram == 2)
            {
                App.Current.MainPage = new AppShell();
                App.passwordMemory = password.Text;
                App.loginMemory = login.Text;
            }
            if (App.loginpram == 1)
            {
                App.Current.MainPage = new AppShell();
                App.passwordMemory = password.Text;
                App.loginMemory = login.Text;
            }
            if (App.loginpram == 0)
            {
                App.Current.MainPage.DisplayAlert("Ошибка входа", "Неправильный логин или пароль", "Ок");
                Connection.GetConnection().Disconnect();
            }
        }
    }
}
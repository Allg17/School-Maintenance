using consult__studentsApp.Resources;
using consult__studentsApp.Services;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace consult__studentsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var language = CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList().First(element => element.EnglishName.Contains("Spanish")); ;
            Thread.CurrentThread.CurrentUICulture = language;
            AppResources.Culture = language;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            ApiHelper.InitializeClient();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

using PAM_MB_APP.Pages;

namespace PAM_MB_APP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CriarContaPage());


        }

    }
}

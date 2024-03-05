using MVVM_CRUD.Views;

namespace MVVM_CRUD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new EmpleadoMainPage());
        }
    }
}

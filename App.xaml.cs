namespace arodriguezExamen
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // NavigationPage permite pasar de una ventana a otra con PushAsync
            return new Window(new NavigationPage(new Views.Login()));
        }
    }
}
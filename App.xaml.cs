namespace arodriguezExamen
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Tema claro aunque el dispositivo esté en modo oscuro
            UserAppTheme = AppTheme.Light;

#if ANDROID
            // Quita la línea inferior que Android dibuja en Entry, Picker y DatePicker
            var transparente = global::Android.Content.Res.ColorStateList.ValueOf(
                global::Android.Graphics.Color.Transparent);

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("SinLinea",
                (handler, view) => handler.PlatformView.BackgroundTintList = transparente);

            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("SinLinea",
                (handler, view) => handler.PlatformView.BackgroundTintList = transparente);

            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("SinLinea",
                (handler, view) => handler.PlatformView.BackgroundTintList = transparente);
#endif
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var navegacion = new NavigationPage(new Views.Login())
            {
                BarBackgroundColor = Color.FromArgb("#0E7490"),
                BarTextColor = Colors.White
            };

            return new Window(navegacion);
        }
    }
}
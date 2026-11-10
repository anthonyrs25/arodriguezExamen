namespace arodriguezExamen.Views;

public partial class Registro : ContentPage
{
    const double COSTO_CURSO = 1500;
    const int NUMERO_CUOTAS = 4;
    const double PORCENTAJE = 0.04;

    string usuarioConectado;
    double montoInicial;
    double pagoMensual;

    public Registro(string usuario)
    {
        InitializeComponent();

        usuarioConectado = usuario;
        lblUsuario.Text = "Usuario conectado: " + usuario;

        pkPais.ItemsSource = new List<string> { "Ecuador", "Colombia", "Perú" };
        pkCiudad.ItemsSource = new List<string> { "Cuenca", "Quito", "Guayaquil", "Bogotá", "Lima" };
    }

    // Calcula el pago mensual. Devuelve false si el monto no es válido.
    private bool Calcular()
    {
        if (!double.TryParse(txtMonto.Text, out montoInicial)
            || montoInicial < 0 || montoInicial > COSTO_CURSO)
        {
            return false;
        }

        double cuota = (COSTO_CURSO - montoInicial) / NUMERO_CUOTAS;
        double recargo = COSTO_CURSO * PORCENTAJE; // 4 % del costo = 60
        pagoMensual = cuota + recargo;

        txtPagoMensual.Text = pagoMensual.ToString("F2");
        return true;
    }

    private async void btnCalcular_Clicked(object sender, EventArgs e)
    {
        if (!Calcular())
        {
            await DisplayAlert("Dato incorrecto", "Ingrese un monto inicial entre 0 y 1500", "OK");
        }
    }

    private async void btnResumen_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text)
            || string.IsNullOrWhiteSpace(txtApellido.Text)
            || string.IsNullOrWhiteSpace(txtEdad.Text)
            || pkPais.SelectedItem == null
            || pkCiudad.SelectedItem == null)
        {
            await DisplayAlert("Datos incompletos", "Complete todos los campos", "OK");
            return;
        }

        if (!Calcular())
        {
            await DisplayAlert("Dato incorrecto", "Ingrese un monto inicial entre 0 y 1500", "OK");
            return;
        }

        string fecha = string.Format("{0:dd/MM/yyyy}", dpFecha.Date);
        string pais = pkPais.SelectedItem.ToString() ?? "";
        string ciudad = pkCiudad.SelectedItem.ToString() ?? "";

        await Navigation.PushAsync(new Resumen(
            usuarioConectado, txtNombre.Text, txtApellido.Text, txtEdad.Text,
            fecha, ciudad, pais, montoInicial, pagoMensual));
    }
}
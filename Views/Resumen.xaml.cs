namespace arodriguezExamen.Views;

public partial class Resumen : ContentPage
{
    public Resumen(string usuario, string nombre, string apellido, string edad,
                   string fecha, string ciudad, string pais,
                   double montoInicial, double pagoMensual)
    {
        InitializeComponent();

        double pagoTotal = montoInicial + (pagoMensual * 4);

        lblUsuario.Text = "Usuario conectado: " + usuario;
        lblNombre.Text = nombre;
        lblApellido.Text = apellido;
        lblEdad.Text = edad;
        lblFecha.Text = fecha;
        lblCiudad.Text = ciudad;
        lblPais.Text = pais;
        lblMonto.Text = "$" + montoInicial.ToString("F2");
        lblPagoMensual.Text = "$" + pagoMensual.ToString("F2");
        lblPagoTotal.Text = "$" + pagoTotal.ToString("F2");
    }
}
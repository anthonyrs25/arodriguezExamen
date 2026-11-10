namespace arodriguezExamen.Views;

public partial class Login : ContentPage
{
    // Matriz 2x2: columna 0 = usuario, columna 1 = contraseña
    string[,] usuarios =
    {
        { "estudiante", "moviles" },
        { "suda", "2025" }
    };

    public Login()
    {
        InitializeComponent();
    }

    private async void btnIniciar_Clicked(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text ?? "";
        string clave = txtClave.Text ?? "";
        bool correcto = false;

        // Recorre las filas de la matriz buscando una coincidencia
        for (int i = 0; i < usuarios.GetLength(0); i++)
        {
            if (usuarios[i, 0] == usuario && usuarios[i, 1] == clave)
            {
                correcto = true;
            }
        }

        if (correcto)
        {
            await Navigation.PushAsync(new Registro(usuario));
        }
        else
        {
            await DisplayAlert("Dato incorrecto", "Usuario o contraseña incorrectos", "OK");
        }
    }
}
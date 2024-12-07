namespace ProyectoP2.Views;

using Newtonsoft.Json;
using ProyectoP2.Models;
using System.Security.Cryptography.X509Certificates;

public partial class InicioSesion : ContentPage
{
    string _fileUsuarios = "C:\\Users\\tomas\\OneDrive\\Documents\\UDLA quinto semestre\\Programacion IV\\ProyectoP2\\Usuarios.txt";
    Usuarios usuario= new Usuarios();

    public InicioSesion()
	{
		InitializeComponent();
	}

    private void IniciarSesion_Clicked(object sender, EventArgs e)
    {
        

    }

    public IEnumerable<Usuarios> DevuelveListadoUsuarios()
    {
        IEnumerable<Usuarios> usuarios;
        string jsonData=File.ReadAllText(_fileUsuarios);
        usuarios=JsonConvert.DeserializeObject<IEnumerable<Usuarios>>(jsonData);
        return usuarios;
    }

    private void Registrar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.RegistroUsuario());

    }
}
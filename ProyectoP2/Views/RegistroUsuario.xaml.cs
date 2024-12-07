using ProyectoP2.Models;

using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace ProyectoP2.Views;

public partial class RegistroUsuario : ContentPage
{
    string _fileUsuarios = "C:\\Users\\tomas\\OneDrive\\Documents\\UDLA quinto semestre\\Programacion IV\\ProyectoP2\\Usuarios.txt";
    string _fileMembresias = "C:\\Users\\tomas\\OneDrive\\Documents\\UDLA quinto semestre\\Programacion IV\\ProyectoP2\\Membresias1.txt";
    public RegistroUsuario()
	{
		InitializeComponent();
        
        
	}

    public async void NuevoUsuario_Clicked(object sender, EventArgs e)
    {
		Usuarios usuario = new Usuarios()
        {
            Correo=Correo_Editor.Text,
            Clave=Contrasena_Editor.Text,
            Credenciales=Credenciales_Editor.Text
        };
        Membresias membresia = new Membresias()
        {
            Nombre=Nombre_Editor.Text,
            Cedula=Cedula_Editor.Text,
            Id_Membresias=ID_Editor.Text,
            Membresia=Credenciales_Editor.Text
        };
        if (File.Exists(_fileUsuarios))
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(usuario);
                File.AppendAllText(_fileUsuarios, jsonData);
            }
            catch (Exception)
            {
                throw;
            }
        }
        else
        {
            string jsonData = JsonConvert.SerializeObject(usuario);
            File.WriteAllText(_fileUsuarios, jsonData);
        }
        if (File.Exists(_fileMembresias))
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(membresia);
                File.AppendAllText(_fileMembresias, jsonData);
            }
            catch (Exception)
            {
                throw;
            }
        }
        else
        {
            string jsonData = JsonConvert.SerializeObject(membresia);
            File.WriteAllText(_fileMembresias, jsonData);
        }
        await DisplayAlert("Usuario registrado con exito", "Porfavor, Inicie sesión", "ok");
        await Navigation.PushAsync(new Views.InicioSesion());

        

    }

    
}
using ProyectoP2.Models;

using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace ProyectoP2.Views;

public partial class RegistroUsuario : ContentPage
{
    
    
    List<Membresias> _membresias = new List<Membresias>();
    List<Usuarios> _usuarios = new List<Usuarios>();
    string _fileUsuarios = "C:\\Users\\tomas\\OneDrive\\Documents\\UDLA quinto semestre\\Programacion IV\\ProyectoP2\\Usuarios.txt";
    string _fileMembresias = "C:\\Users\\tomas\\OneDrive\\Documents\\UDLA quinto semestre\\Programacion IV\\ProyectoP2\\Membresias1.txt";
    public RegistroUsuario()
	{
		InitializeComponent();
        
        
	}

    public async void NuevoUsuario_Clicked(object sender, EventArgs e)
    {
        
        string dataUsuarios=File.ReadAllText(_fileUsuarios);
        if (!string.IsNullOrEmpty(dataUsuarios))
        {
            _usuarios = JsonConvert.DeserializeObject<List<Usuarios>>(dataUsuarios);
        }
        
        Usuarios usuario = new Usuarios()
        {
            Correo=Correo_Editor.Text,
            Clave=Contrasena_Editor.Text,
            Credenciales=Credenciales_Editor.Text
        };
        _usuarios.Add(usuario);

        string dataMembresias = File.ReadAllText(_fileMembresias);
        if (!string.IsNullOrEmpty(dataMembresias))
        {
            _membresias = JsonConvert.DeserializeObject<List<Membresias>>(dataMembresias);
        }
        Membresias membresia = new Membresias()
        {
            Nombre=Nombre_Editor.Text,
            Cedula=Cedula_Editor.Text,
            Id_Membresias=ID_Editor.Text,
            Membresia=Credenciales_Editor.Text
        };
        _membresias.Add(membresia);
        if (File.Exists(_fileUsuarios))
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(_usuarios, Formatting.Indented);
                File.WriteAllText(_fileUsuarios, jsonData);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        if (File.Exists(_fileMembresias))
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(_membresias, Formatting.Indented);
                File.WriteAllText(_fileMembresias, jsonData);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        await DisplayAlert("Usuario registrado con exito", "Porfavor, Inicie sesión", "ok");
        await Navigation.PushAsync(new Views.InicioSesion());

        

    }

    
}
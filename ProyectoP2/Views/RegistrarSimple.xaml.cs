using Microsoft.Maui;
using Newtonsoft.Json;
using ProyectoP2.Models;

namespace ProyectoP2.Views;

public partial class RegistrarSimple : ContentPage
{
    List<Membresias> _membresias = new List<Membresias>();
    List<Usuarios> _usuarios = new List<Usuarios>();
    string _fileUsuarios = Path.Combine(FileSystem.AppDataDirectory, "Usuarios.txt");
    string _fileMembresias = Path.Combine(FileSystem.AppDataDirectory, "Membresias.txt");
    public RegistrarSimple()
	{
		InitializeComponent();
	}
    public async void NuevoUsuario_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileUsuarios))
        {
            string dataUsuarios = File.ReadAllText(_fileUsuarios);
            if (!string.IsNullOrEmpty(dataUsuarios))
            {
                _usuarios = JsonConvert.DeserializeObject<List<Usuarios>>(dataUsuarios);
            }
        }

        Usuarios usuario = new Usuarios()
        {
            Correo = Correo_Editor.Text,
            Clave = Contrasena_Editor.Text,
            Credenciales = "Cliente"
        };
        _usuarios.Add(usuario);


        if (File.Exists(_fileMembresias))
        {
            string dataMembresias = File.ReadAllText(_fileMembresias);
            if (!string.IsNullOrEmpty(dataMembresias))
            {
                _membresias = JsonConvert.DeserializeObject<List<Membresias>>(dataMembresias);
            }
        }

        Membresias membresia = new Membresias()
        {
            Nombre = Nombre_Editor.Text,
            Cedula = Cedula_Editor.Text,
            Id_Membresias = ID_Editor.Text,
            Membresia = "Cliente"
        };
        _membresias.Add(membresia);

        try
        {
            string jsonData = JsonConvert.SerializeObject(_usuarios, Formatting.Indented);
            File.WriteAllText(_fileUsuarios, jsonData);
        }
        catch (Exception)
        {
            throw;
        }



        try
        {
            string jsonData = JsonConvert.SerializeObject(_membresias, Formatting.Indented);
            File.WriteAllText(_fileMembresias, jsonData);
        }
        catch (Exception)
        {
            throw;
        }


        await DisplayAlert("Usuario registrado con exito", "Porfavor, Inicie sesi�n", "ok");
        await Navigation.PushAsync(new Views.InicioSesion());



    }

    
}
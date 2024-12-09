namespace ProyectoP2.Views;

using Newtonsoft.Json;
using ProyectoP2.Models;
using System.Security.Cryptography.X509Certificates;

public partial class InicioSesion : ContentPage
{
    string _fileUsuarios = Path.Combine(FileSystem.AppDataDirectory, "Usuarios.txt");
    string _fileMembresias = Path.Combine(FileSystem.AppDataDirectory, "Membresias.txt");
    Usuarios usuario= new Usuarios();
    DateTime fechaHoy = DateTime.Today;
    

    public InicioSesion()
	{
		InitializeComponent();
        if (!File.Exists(_fileUsuarios))
        {
            Usuarios usuarioOG = new Usuarios { Correo = "admin@gmail.com",
            Clave="1234",
            Credenciales="Administrador"};
            Membresias membresiaOG = new Membresias { Cedula = "0987654321", Id_Membresias = "0", Membresia = "Administrador", Nombre = "OG" };
            List <Usuarios> lista = new List<Usuarios>();
            List<Membresias> listam = new List<Membresias>();
            listam.Add(membresiaOG);
            lista.Add(usuarioOG);
            string jsonData1=JsonConvert.SerializeObject(lista);
            string jsonData2=JsonConvert.SerializeObject(listam);
            File.WriteAllText(_fileUsuarios, jsonData1);
            File.WriteAllText(_fileMembresias, jsonData2);
        }
	}
    List<Usuarios> _usuarios = new List<Usuarios>();
    private async void IniciarSesion_Clicked(object sender, EventArgs e)
    {
        
        
        if ((File.Exists(_fileUsuarios)) )
        {
            int a = 0;
            IEnumerable<Usuarios> usuarios = DevuelveListadoUsuarios();
            foreach (Usuarios user in usuarios)
            {
                if ((user.Clave == ClaveInicio.Text) && (user.Correo == CorreoInicio.Text))
                {
                    if (user.Credenciales == "Administrador")
                    {
                        a = 1;
                        Navigation.PushAsync(new Views.MembresiaAdministrador());
                    }
                    if (user.Credenciales == "Cliente")
                    {
                        DayOfWeek diaSemana = fechaHoy.DayOfWeek;
                        a = 1;
                        if (diaSemana == DayOfWeek.Monday || diaSemana == DayOfWeek.Thursday)
                        {
                            Navigation.PushAsync(new Views.MembresiaUsuario(user));
                        }
                        else if (diaSemana == DayOfWeek.Tuesday || diaSemana == DayOfWeek.Friday)
                        {
                            Navigation.PushAsync(new Views.MembresiaUsuarioEspalda());
                        }
                        else
                        {
                            Navigation.PushAsync(new Views.MembresiaUsuarioPiernas());
                        }

                    }
                }

            }
            if (a == 0)
            {
                await DisplayAlert("Inicio de sesión fallido", "Usuario o contraseña incorrectos", "ok");
            }
        }
        else
        {
            await DisplayAlert("Inicio de sesión fallido", "No hay usuarios registrados", "ok");
        }
        
        

    }

    public IEnumerable<Usuarios> DevuelveListadoUsuarios()
    {
        List<Usuarios> usuarios;
        string jsonData=File.ReadAllText(_fileUsuarios);
        usuarios=JsonConvert.DeserializeObject<List<Usuarios>>(jsonData);
        return usuarios;
    }
    

    private void Registrar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.RegistrarSimple());

    }
}
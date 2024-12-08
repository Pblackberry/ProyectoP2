using ProyectoP2.Models;

namespace ProyectoP2.Views;

public partial class MembresiaUsuario : ContentPage
{
	public MembresiaUsuario(Usuarios user)
	{
		InitializeComponent();
		BindingContext=user;
		
	}
}
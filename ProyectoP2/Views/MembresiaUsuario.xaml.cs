using ProyectoP2.Models;

namespace ProyectoP2.Views;

public partial class MembresiaUsuario : ContentPage
{
	public MembresiaUsuario(Usuarios user)
	{
		InitializeComponent();
		BindingContext=this;

        /*DateTime fechaHoy = DateTime.Today;
        DayOfWeek diaSemana = fechaHoy.DayOfWeek;
		string imagen = "chest.png";

		if (diaSemana == DayOfWeek.Monday || diaSemana == DayOfWeek.Thursday)
		{
			imagen = "chest.png";
		}
		else if (diaSemana == DayOfWeek.Tuesday || diaSemana == DayOfWeek.Friday)
		{
			imagen = "back.png";
		}
		else
		{
			imagen = "squat.png";
		}*/
    }
}
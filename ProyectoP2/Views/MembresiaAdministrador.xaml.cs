namespace ProyectoP2.Views;

public partial class MembresiaAdministrador : ContentPage
{
	public MembresiaAdministrador()
	{
		InitializeComponent();

		BindingContext = new Models.AllMembresias();
	}

    protected override void OnAppearing()
    {
		((Models.AllMembresias)BindingContext).LoadMembresias();
    }
}
using ENT;

namespace MAUI.Views;

// NombreVariableLocal, NombreKeyDiccionario
[QueryProperty(nameof(Persona), "Persona")]
public partial class DetallesPersonaView : ContentPage
{
	PersonaConDepartamento _p;

	public PersonaConDepartamento Persona
	{
		get => _p;
		set
		{
			_p = value;
			OnPropertyChanged("Persona");
		}
	}

	public DetallesPersonaView()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private async void onBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///listaPersonas");
    }
}
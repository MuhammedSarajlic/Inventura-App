namespace Inventura_App;

public partial class SignUp : ContentPage
{
	public SignUp()
	{
		InitializeComponent();
	}
    private async void TapGestureRecognizer_Tapped_For_SignIn(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("//SignIn");
    }
}
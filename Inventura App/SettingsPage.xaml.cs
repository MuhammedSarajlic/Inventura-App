namespace Inventura_App;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private void ProfilePage_Tapped(object sender, EventArgs e)
    {
        // Navigate to the profile page
        Navigation.PushAsync(new ProfilePage());
    }
    private void EditProfilePage_Tapped(object sender, EventArgs e)
    {
        // Navigate to the profile page
        Navigation.PushAsync(new EditProfilePage());
    }
    private async void LogOut_Tapped(object sender, EventArgs e)
    {
        // Navigate to the profile page
        await Shell.Current.GoToAsync("//SignIn");
    }

}
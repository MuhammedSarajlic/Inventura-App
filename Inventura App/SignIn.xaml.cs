using Inventura_App.Models;
using Inventura_App.Data;
using SQLite;

namespace Inventura_App
{
    public partial class SignIn : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        public SignIn()
        {
            InitializeComponent();
            _connection = new SQLiteAsyncConnection(Data.Database.DatabasePath, Data.Database.Flags);
            SignInButton.Clicked += SignInButton_Clicked;
        }
        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var query = _connection.Table<User>().Where(u => u.Email == EmailEntry.Text);
                var user = await query.FirstOrDefaultAsync();

                if (user != null)
                {
                    if (user.Password == PasswordEntry.Text)
                    {
                        // User exists in the database and the password is correct
                        await Shell.Current.GoToAsync("//MainPage");
                        UserCred.Email = EmailEntry.Text;
                        PasswordEntry.Text = "";
                        EmailEntry.Text = "";
                    }
                    else
                    {
                        // User exists in the database but the password is incorrect
                        await DisplayAlert("Error", "Incorrect password", "Ok");
                    }
                }
                else
                {
                    // User does not exist in the database
                    await DisplayAlert("Error", "User with this email does not exist!", "Ok");
                }
            }
            catch (Exception ex)
            {
                // Handle any exception that may have occurred
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private async void TapGestureRecognizer_Tapped_For_SignUp(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//SignUp");
        }
    }
}
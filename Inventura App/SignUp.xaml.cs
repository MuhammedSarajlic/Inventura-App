using Inventura_App.Data;
using Inventura_App.Models;
using SQLite;

namespace Inventura_App
{
    public partial class SignUp : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        public SignUp()
        {
            InitializeComponent();
            
            _connection = new SQLiteAsyncConnection(Data.Database.DatabasePath, Data.Database.Flags);
            SignUpButton.Clicked += SignUpButton_Clicked;
        }

        private async void SignUpButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var query = _connection.Table<User>().Where(u => u.Email == EmailEntry.Text);
                var user = await query.FirstOrDefaultAsync();
                if (user != null)
                {
                    //user already exists in the database
                    await DisplayAlert("Error", "User with this email already exists!", "Ok");
                    return;
                }
                else
                {
                    //user does not exist in the database
                    var newUser = new User
                    {
                        Name = NameEntry.Text,
                        Email = EmailEntry.Text,
                        Password = PasswordEntry.Text
                    };

                    await _connection.InsertAsync(newUser);
                    await DisplayAlert("Success", "User successfully added to the database!", "Ok");
                }
                await Shell.Current.GoToAsync("//SignIn");
            }
            catch (DllNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

        }

        private async void TapGestureRecognizer_Tapped_For_SignIn(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//SignIn");
        }
    }
}

using Inventura_App.Data;
using Inventura_App.Models;
using SQLite;
using static Inventura_App.ProfilePage;
using System.Xml;

namespace Inventura_App;

public partial class EditProfilePage : ContentPage
{
    private SQLiteAsyncConnection _connection;
    public EditProfilePage()
    {
        InitializeComponent();
        _connection = new SQLiteAsyncConnection(Data.Database.DatabasePath, Data.Database.Flags);
        var email = UserCred.Email;
        var query = _connection.Table<User>().Where(u => u.Email == email);
        var user = query.FirstOrDefaultAsync();

        user.ContinueWith(t =>
        {
            if (t.Result != null)
            {
                BindingContext = t.Result;
                nameEntry.BindingContext = BindingContext;
                nameEntry.SetBinding(Entry.TextProperty, "Name");
                emailEntry.BindingContext = BindingContext;
                emailEntry.SetBinding(Entry.TextProperty, "Email");

            }
        });

    }
    private async void Update_Clicked(object sender, EventArgs e)
    {
        var email = UserCred.Email;
        var query = _connection.Table<User>().Where(u => u.Email == email);
        var user = await query.FirstOrDefaultAsync();
        user.Name = nameEntry.Text;
        user.Email = emailEntry.Text;
        try
        {
            await _connection.UpdateAsync(user);
            UserCred.Email = emailEntry.Text;
            await DisplayAlert("Success", "User data updated", "Ok");
        }
        catch (SQLiteException ex)
        {
            if (ex.Message.Contains("UNIQUE constraint failed"))
                await DisplayAlert("Error", "Email already exists. Please enter a different email", "Ok");
            else
                await DisplayAlert("Error", ex.Message, "Ok");
        }
    }

}


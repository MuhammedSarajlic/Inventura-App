using Inventura_App.Data;
using Inventura_App.Models;
using SQLite;

namespace Inventura_App;

public partial class ProfilePage : ContentPage
{
    private SQLiteAsyncConnection _connection;
    
    public ProfilePage()
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
                nameLabel.BindingContext = BindingContext;
                emailLabel.BindingContext = BindingContext;
            }
        });
    }
}
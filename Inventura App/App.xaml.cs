using Inventura_App.Data;
using Inventura_App.Models;
using SQLite;

namespace Inventura_App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
    protected override void OnStart()
    {
        base.OnStart();

        using (var conn = new SQLiteConnection(Database.DatabasePath, Database.Flags))
        {
            conn.CreateTable<User>();
        }
    }
}

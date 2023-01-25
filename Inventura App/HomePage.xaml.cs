using AndroidX.Lifecycle;
using Inventura_App.Models;
using SQLite;

namespace Inventura_App;

public partial class HomePage : ContentPage
{
    public int TotalProducts { get; set; }
    public int ItemsInStock { get; set; }
    private SQLiteAsyncConnection _connection;
    public HomePage()
	{
		InitializeComponent();
        _connection = new SQLiteAsyncConnection(Data.Database.DatabasePath, Data.Database.Flags);
        
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var count = await _connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM products");
        var uniqueCount = await _connection.ExecuteScalarAsync<int>("SELECT COUNT(DISTINCT name) FROM products");
        TotalProducts = uniqueCount;
        ItemsInStock = count;
        totalProducts.Text = TotalProducts.ToString();
        itemsInStock.Text = ItemsInStock.ToString();
        BindingContext = this;

    }
}
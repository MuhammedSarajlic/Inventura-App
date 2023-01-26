using AndroidX.Lifecycle;
using Inventura_App.Models;
using SQLite;

namespace Inventura_App;

public partial class HomePage : ContentPage
{
    public int TotalProducts { get; set; }
    public int ItemsInStock { get; set; }
    public double Height { get; set; }

    public string CurrentDay { get; set; }

    private SQLiteAsyncConnection _connection;
    public HomePage()
	{
		InitializeComponent();
        _connection = new SQLiteAsyncConnection(Data.Database.DatabasePath, Data.Database.Flags);
        CurrentDay = DateTime.Today.DayOfWeek.ToString();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var count = await _connection.ExecuteScalarAsync<int>("SELECT SUM(quantity) FROM products");
        var uniqueCount = await _connection.ExecuteScalarAsync<int>("SELECT COUNT(DISTINCT name) FROM products");
        TotalProducts = uniqueCount;
        ItemsInStock = count;
        totalProducts.Text = TotalProducts.ToString();
        itemsInStock.Text = ItemsInStock.ToString();
        Height = (count * 10) + 20;
        if(CurrentDay == "Monday")
        {
            Monday.HeightRequest = Height;
        }else if(CurrentDay == "Tuesday")
        {
            Tuesday.HeightRequest = Height;
        }
        else if (CurrentDay == "Wednesday")
        {
            Wednesday.HeightRequest = Height;
        }
        else if (CurrentDay == "Thursday")
        {
            Thursday.HeightRequest = Height;
        }
        else if (CurrentDay == "Friday")
        {
            Friday.HeightRequest = Height;
        }
        else if (CurrentDay == "Saturday")
        {
            Saturday.HeightRequest = Height;
        }
        else if (CurrentDay == "Sunday")
        {
            Sunday.HeightRequest = Height;
        }
        else
        {
            Height = 0;
        }
        BindingContext = this;

    }
}
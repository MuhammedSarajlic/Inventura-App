using SQLite;
using Inventura_App.Models;
using static Android.Util.EventLogTags;
using static Java.Util.Jar.Attributes;

namespace Inventura_App;

public partial class AddProductPage : ContentPage
{
	private SQLiteAsyncConnection _connection;

    public AddProductPage()
    {
        InitializeComponent();
        _connection = new SQLiteAsyncConnection(Data.Database.DatabasePath, Data.Database.Flags);
    }

    private async void AddProduct_Clicked(object sender, EventArgs e)
    {
        try
        {
            var product = new Product
            {
                Name = productNameEntry.Text,
                Category = categoryEntry.Text,
                Location = locationEntry.Text,
                Description = descriptionEntry.Text,
                Date = dateEntry.Text
            };

            await _connection.InsertAsync(product);
            if (product.Id != 0)
            {
                productNameEntry.Text = "";
                categoryEntry.Text = "";
                locationEntry.Text = "";
                descriptionEntry.Text = "";
                dateEntry.Text = "";
            }
            await DisplayAlert("Success", "Product added", "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to add product. Please try again.", "Ok");
        }
    }

}
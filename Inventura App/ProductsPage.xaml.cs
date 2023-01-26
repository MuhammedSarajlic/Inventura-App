using Inventura_App.Models;
using SQLite;
using System.Collections.ObjectModel;

namespace Inventura_App;

public partial class ProductsPage : ContentPage
{
    private SQLiteAsyncConnection _connection;
    public ObservableCollection<Product> Products { get; set; }

    public ProductsPage()
    {
        InitializeComponent();
        _connection = new SQLiteAsyncConnection(Data.Database.DatabasePath, Data.Database.Flags);
        Products = new ObservableCollection<Product>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var numberOfProducts = await _connection.Table<Product>().CountAsync();
        totalProducts.Text = numberOfProducts.ToString();
        var products = await _connection.Table<Product>().ToListAsync();
        Products.Clear();
        foreach (var product in products)
        {
            Products.Add(product);
        }
        productListView.ItemsSource = Products;

    }

    private async void OnSearchButtonPressed(object sender, EventArgs e)
    {
        var searchText = searchBar.Text;
        if (string.IsNullOrWhiteSpace(searchText))
        {
            return;
        }

        // Perform the search and update the products list
        var filteredProducts = Products.Where(p => p.Name.Contains(searchText));
        productListView.ItemsSource = filteredProducts;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddProductPage());
    }

}

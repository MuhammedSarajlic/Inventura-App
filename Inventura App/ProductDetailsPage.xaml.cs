using Inventura_App.Data;
using static Inventura_App.WelcomePage;
using static Java.Util.Jar.Attributes;
using Inventura_App.Models;

namespace Inventura_App;

public partial class ProductDetailsPage : ContentPage
{
	public class CurrentProduct
	{
		public string Name { get; set; }
		public string Category { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public string Quantity { get; set; }
		public string Date { get; set; }
		
	}
	public CurrentProduct Item { get; set; }
	public ProductDetailsPage()
	{
        Item = new CurrentProduct
		{
			Name = ProductItem.SelectedProduct.Name,
			Category = ProductItem.SelectedProduct.Category,
			Location = ProductItem.SelectedProduct.Location,
			Description = ProductItem.SelectedProduct.Description,
			Quantity = ProductItem.SelectedProduct.Quantity.ToString(),
            Date = ProductItem.SelectedProduct.Date
        };
        this.BindingContext = Item;
		InitializeComponent();
    }

	private void Button_Clicked(object sender, EventArgs e)
	{
        Navigation.PopAsync();
    }
}
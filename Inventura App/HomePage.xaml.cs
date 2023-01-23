namespace Inventura_App;

public partial class HomePage : ContentPage
{
    public PlotModel MyModel { get; set; }
    public HomePage()
	{
		InitializeComponent();

        MyModel = new PlotModel { Title = "Weekly Sales" };
        var lineSeries = new LineSeries
        {
            Title = "Sales",
            ItemsSource = new[]
            {
                new DataPoint(0, 10),
                new DataPoint(1, 15),
                new DataPoint(2, 20),
                new DataPoint(3, 25)
            },
            LabelFormatString = "{0}"
        };
        MyModel.Series.Add(lineSeries);
        var categoryAxis = new CategoryAxis
        {
            Position = AxisPosition.Bottom,
            Labels = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }
        };
        MyModel.Axes.Add(categoryAxis);
        var valueAxis = new LinearAxis
        {
            Position = AxisPosition.Left,
            Minimum = 0,
            Maximum = 30,
            MajorStep = 5,
            MinorStep = 1
        };
        MyModel.Axes.Add(valueAxis);
        BindingContext = this;

    }
}
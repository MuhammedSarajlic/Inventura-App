namespace Inventura_App;

public partial class WelcomePage : ContentPage
{
    public class WelcomeMessage
    {
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Subtitle { get; set; }
        public string Paragraph { get; set; }
    }

    public List<WelcomeMessage> WelcomeMessages { get; set; }
    public int CurrentPage { get; set; }

    public WelcomePage()
	{
        CurrentPage = 0;
        WelcomeMessages = new List<WelcomeMessage>()
        {
            new WelcomeMessage { Title = "Welcome to Stock Management", Photo = "welcome1.png", Subtitle = "Streamline your inventory", Paragraph = "Get started today" },
            new WelcomeMessage { Title = "Manage Your Stock", Photo = "welcome2.png", Subtitle = "Efficiently and Effectively", Paragraph = "Start managing your stock today" },
            new WelcomeMessage { Title = "Get Started", Photo = "welcome3.png", Subtitle = "Take control of your inventory", Paragraph = "Join us now" },
        };
        this.BindingContext = this;
        InitializeComponent();
    }


}
namespace Inventura_App
{
    public partial class SingIn : ContentPage
    {
        public SingIn()
        {
            InitializeComponent();
        }
        private async void TapGestureRecognizer_Tapped_For_SignUp(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//SignUp");
        }
    }
}
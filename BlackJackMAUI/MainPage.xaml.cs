namespace BlackJackMAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void PullRandomCard(object sender, EventArgs e)
        {
            Card card = new Card();
            RandomCard.Text = card.ToString();
        }
    }
}

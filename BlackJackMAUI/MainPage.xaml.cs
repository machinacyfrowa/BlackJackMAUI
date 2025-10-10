namespace BlackJackMAUI
{
    public partial class MainPage : ContentPage
    {
        Shoe Shoe;
        public MainPage()
        {
            InitializeComponent();
            Shoe = new Shoe();
        }
        //test losowania karty z puli
        private void PullRandomCard(object sender, EventArgs e)
        {
            Card card = Shoe.Draw();
            RandomCard.Text = card.ToString();
            CardImage.Source = ImageSource.FromFile(card.GetFileName());
        }
        private void TestHand(object sender, EventArgs e)
        {
            //stworzenie ręki
            Hand hand = new Hand();
            //dodanie do ręki dwóch kart
            hand.AddCard(Shoe.Draw());
            hand.AddCard(Shoe.Draw());
            //wykorzystamy sobie labelke od random card zeby wyświetlić wynik
            RandomCard.Text = "Wartość kart: " + hand.Value();
        }
    }
}

namespace BlackJackMAUI
{
    public partial class MainPage : ContentPage
    {
        Shoe Shoe;
        Hand PlayerHand;
        public MainPage()
        {
            InitializeComponent();
            Shoe = new Shoe();
            PlayerHand = new Hand();
        }
        //test losowania karty z puli
        //private void PullRandomCard(object sender, EventArgs e)
        //{
        //    Card card = Shoe.Draw();
        //    RandomCard.Text = card.ToString();
        //    CardImage.Source = ImageSource.FromFile(card.GetFileName());
        //}
        private void TestHand(object sender, EventArgs e)
        {

            //dodanie do ręki dwóch kart
            PlayerHand.AddCard(Shoe.Draw());
            PlayerHand.AddCard(Shoe.Draw());
            //wykorzystamy sobie labelke od random card zeby wyświetlić wynik
            RandomCard.Text = "Wartość kart: " + PlayerHand.Value();
            //renderujemy karty na ekranie
            RenderCards();
        }
        private void RenderCards()
        {
            //tutaj będziemy renderować karty na ekranie
            //najpierw czyścimi stare karty
            PlayerCardsHLayout.Children.Clear();
            //reka gracza - PlayerCardsHLayout
            foreach (Card card in PlayerHand.cards)
            {
                Image cardImage = new Image();
                cardImage.Source = ImageSource.FromFile(card.GetFileName());
                cardImage.HeightRequest = 150;   
                PlayerCardsHLayout.Add(cardImage);
            }
        }
    }
}

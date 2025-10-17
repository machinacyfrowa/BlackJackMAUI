namespace BlackJackMAUI
{
    public partial class MainPage : ContentPage
    {
        Shoe Shoe;
        Hand PlayerHand;
        Hand DealerHand;
        //definiujemy flagę czy gracz jeszcze dobiera karty
        bool PlayerTurn;
        public MainPage()
        {
            InitializeComponent();
            Shoe = new Shoe();
            PlayerHand = new Hand();
            DealerHand = new Hand();
            this.BackgroundImageSource = "table_background.jpg";
            PlayerTurn = true;
        }

        private void NewGame(object sender, EventArgs e)
        {
            //znikamy guzik
            StartGameButton.IsVisible = false;
            //pokazujemy guziki do gry
            HitButton.IsVisible = true;
            StandButton.IsVisible = true;
            //czyścimy ręce
            PlayerHand.cards.Clear();
            DealerHand.cards.Clear();
            //dwie karty dla dealera i gracza
            DealerHand.AddCard(Shoe.Draw());
            DealerHand.AddCard(Shoe.Draw());
            PlayerHand.AddCard(Shoe.Draw());
            PlayerHand.AddCard(Shoe.Draw());
            PlayerTurn = true;
            RenderCards();
        }
        //test losowania karty z puli
        //private void PullRandomCard(object sender, EventArgs e)
        //{
        //    Card card = Shoe.Draw();
        //    RandomCard.Text = card.ToString();
        //    CardImage.Source = ImageSource.FromFile(card.GetFileName());
        //}
        //private void TestHand(object sender, EventArgs e)
        //{

        //    //dodanie do ręki dwóch kart
        //    PlayerHand.AddCard(Shoe.Draw());
        //    PlayerHand.AddCard(Shoe.Draw());
        //    //wykorzystamy sobie labelke od random card zeby wyświetlić wynik
        //    RandomCard.Text = "Wartość kart: " + PlayerHand.Value();
        //    //renderujemy karty na ekranie
        //    RenderCards();
        //}
        private void RenderCards()
        {
            //tutaj będziemy renderować karty na ekranie
            //najpierw czyścimi stare karty
            PlayerCardsHLayout.Children.Clear();
            DealerCardsHLayout.Children.Clear();
            //reka gracza - PlayerCardsHLayout
            foreach (Card card in PlayerHand.cards)
            {
                Image cardImage = new Image();
                cardImage.Source = ImageSource.FromFile(card.GetFileName());
                cardImage.HeightRequest = 150;
                PlayerCardsHLayout.Add(cardImage);
            }
            PlayerScore.Text = "Wartość kart: " + PlayerHand.Value();
            //reka dealera - DealerCardsHLayout
            foreach (Card card in DealerHand.cards)
            {
                Image cardImage = new Image();
                cardImage.Source = ImageSource.FromFile(card.GetFileName());
                cardImage.HeightRequest = 150;
                DealerCardsHLayout.Add(cardImage);
            }
            //podmień obrazek drugiej karty dealera jeśli trwa tura gracza
            if (PlayerTurn)
            {
                if (DealerCardsHLayout.Children.Count > 1)
                {
                    Image backImage = new Image();
                    backImage.Source = ImageSource.FromFile("card_back.png");
                    backImage.HeightRequest = 150;
                    DealerCardsHLayout.Children[1] = backImage;
                }
            }
            DealerScore.Text = "Wartość kart: " + DealerHand.Value();
        }

        private void HitButtonClicked(object sender, EventArgs e)
        {
            PlayerHand.AddCard(Shoe.Draw());
            RenderCards();
            //sprawdzenie czy gracz nie przekroczył 21 punktów
            if (PlayerBust())
            {
                DisplayAlert("Przegrałeś!", "Przekroczyłeś 21 punktów!", "OK");
                StartGameButton.IsVisible = true;
                HitButton.IsVisible = false;
                StandButton.IsVisible = false;
            }
        }
        /// <summary>
        /// Metoda sprawdzająca czy gracz przekroczył 21 punktów
        /// </summary>
        /// <returns>True jeśli wartość ręki przekracza 21</returns>
        private bool PlayerBust()
        {
            return PlayerHand.Value() > 21;
        }
        /// <summary>
        /// Gracz kończy dobieranie kart, kolej na dealera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StandButtonClicked(object sender, EventArgs e)
        {
            PlayerTurn = false;
            while (DealerHand.Value() < 17)
            {
                DealerHand.AddCard(Shoe.Draw());
            }
            //pokazujemy karty
            RenderCards();
            //teraz mamy dwie opcje - albo dealer przekroczył 21 albo porównujemy wyniki
            if (DealerHand.Value() > 21)
            {
                DisplayAlert("Wygrałeś!", "Dealer przekroczył 21 punktów!", "OK");
            }
            else
            {
                //porównujemy wyniki
                if (PlayerHand.Value() > DealerHand.Value())
                {
                    DisplayAlert("Wygrałeś!", "Masz więcej punktów niż dealer!", "OK");
                }
                else if (PlayerHand.Value() < DealerHand.Value())
                {
                    DisplayAlert("Przegrałeś!", "Dealer ma więcej punktów!", "OK");
                }
                else
                {
                    DisplayAlert("Remis!", "Masz tyle samo punktów co dealer!", "OK");
                }
            }
            StartGameButton.IsVisible = true;
            HitButton.IsVisible = false;
            StandButton.IsVisible = false;
        }
    }
}

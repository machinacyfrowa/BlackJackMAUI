using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackMAUI
{
    enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }
    enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
    internal class Card
    {
        /// <summary>
        /// Każda karta posiada rangę i kolor
        /// Zostawiamy je publicznie dostępne dla wygody
        /// TODO: Zmienić na prywatne?
        /// </summary>
        public Rank Rank;
        public Suit Suit;
        /// <summary>
        /// Uproszczony konstruktor - zwraca losową kartę
        /// </summary>
        public Card()
        {
            //Tworzymy sobie generator liczb losowych
            Random r = new Random();
            //losujemy rangę z zakresu 0-12 (13 wartości)
            int randomInt = r.Next(0, 13);
            //rzutujemy liczbę losową na Enum - dostajemy losową rangę
            Rank = (Rank)randomInt;
            //losujemy kolor z zakresu 0-3 (4 wartości)
            randomInt = r.Next(0, 4);
            //rzutujemy liczbę losową na Enum - dostajemy losowy kolor
            Suit = (Suit)randomInt;
        }
        /// <summary>
        /// Domyślny konstruktor - tworzy kartę o podanej randze i kolorze
        /// </summary>
        /// <param name="rank">Ranga karty</param>
        /// <param name="suit">Kolor karty</param>
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }
        /// <summary>
        /// Zwraca czytelny opis karty, np. "Ace of Spades"
        /// </summary>
        /// <returns>Opis karty</returns>
        public override string ToString()
        {
            return Rank + " of " + Suit;
        }
    }
}

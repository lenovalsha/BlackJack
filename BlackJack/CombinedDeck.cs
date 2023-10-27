using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public class CombinedDeck
    {
        Deck ThisDeck;
        public List<Card> Cards { get; set; }
        List<Deck> Decks = new List<Deck>();

        public CombinedDeck(ListBox listBox1)
        {
            Cards = new List<Card>();
            for (int i = 0; i < 4; i++) //make 4 decks
            {
                ThisDeck = new Deck();
                Decks.Add(ThisDeck);
                Cards.AddRange(ThisDeck.Cards);
            }
            //Shuffle();//shuffle again
            
        }
        public Card DrawFromCombinedDeck()
        {
            if (Cards.Count > 0)
            {
                Card drawnCard = Cards[0];
                Cards.RemoveAt(0);
                return drawnCard;
            }
            else
            {
                throw new Exception("No more cards left");
            }
        }
        public void Shuffle()
        {
            Random rnd = new Random();
            int n = Cards.Count;

            // While there are still cards to shuffle
            while (n > 1)
            {
                n--;
                // Generate a random index between 0 and n
                int k = rnd.Next(n + 1);

                // Swap the card at index k with the card at index n
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }
        public string Play()
        {
            //get the first of the card
            string firstCards;
            if (Cards.Count > 0)
            {
                firstCards = "";
                for (int i = 0; i < 3; i++)
                {
                    string[] drawnCard = DrawFromCombinedDeck().ToString().Split(':');
                    firstCards = firstCards + ":" + drawnCard[0];
                }
                return firstCards;
            }
            else
            {
                throw new Exception("No more cards left");
            }
        }
        public int Hit()
        {
            string[] cardDrawn;
            int card; 

            if (Cards.Count > 0)
            {
                cardDrawn = DrawFromCombinedDeck().ToString().Split(':');
                card = (int)Enum.Parse(typeof(Rank), cardDrawn[0]);
                if (card > 11)
                {
                    card = 10;
                }
                return card; //return the int version of our enum
            }
            else
            {
                throw new Exception("No more cards left");

            }
        }


    }
}

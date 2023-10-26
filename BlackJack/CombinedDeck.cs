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
            //we need to get every card in this four deck
            //listBox1.Items.AddRange(CombinedDecks.ToArray());
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
        public string Play()
        {
            //get the first of the card
            string firstCards;
            List <string> cards = new List<string>();
            if(Cards.Count > 0)
            {
                    firstCards="";
                //DrawFromCombinedDeck();
                for(int i = 0;i<3;i++)
                {
                    string [] drawnCard = DrawFromCombinedDeck().ToString().Split(':');
                    //firstCards = drawnCard[0];
                    //cards.Add(firstCards);
                    firstCards = firstCards + ":" + drawnCard[0];
                }
                return firstCards;
            }
            else
            {
                throw new Exception("No more cards left");
            }
        }

    }
}

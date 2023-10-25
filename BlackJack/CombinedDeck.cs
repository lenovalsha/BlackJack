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
        public List<Card> CombinedDecks { get; set; }
        List<Deck> Decks = new List<Deck>();

        public CombinedDeck(ListBox listBox1)
        {
            CombinedDecks = new List<Card>();
            for (int i = 0; i < 4; i++) //make 4 decks
            {
                ThisDeck = new Deck();
                Decks.Add(ThisDeck);
                CombinedDecks.AddRange(ThisDeck.Cards);
            }
            //we need to get every card in this four deck
            //listBox1.Items.AddRange(CombinedDecks.ToArray());
        }
        public Card DrawFromCombinedDeck()
        {
            if (CombinedDecks.Count > 0)
            {
                Card drawnCard = CombinedDecks[0];
                CombinedDecks.RemoveAt(0);
                return drawnCard;
            }
            else
            {
                throw new Exception("No more cards left");
            }
        }

    }
}

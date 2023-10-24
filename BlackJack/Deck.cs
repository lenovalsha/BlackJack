using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public class Deck
    {
        // Property to hold the list of cards
        public List<Card> Cards { get; set; }

        // Constructor to initialize the deck
        public Deck()
        {
            // Generate a new deck of cards when a Deck object is created
            Cards = GenerateDeck();
            Shuffle();
        }

        // Private method to generate a deck of cards
        private List<Card> GenerateDeck()
        {
            // Create a new list to hold the cards
            List<Card> deck = new List<Card>();

            // Loop through all possible suits
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                // Loop through all possible ranks
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    // Add a new card with the current suit and rank to the deck
                    deck.Add(new Card(suit, rank));
                    //MessageBox.Show(suit + " : " + rank); 
                }
            }

            // Return the generated deck
            return deck;
        }

        // Method to shuffle the deck
        public void Shuffle()
        {
            // Create a new random number generator
            Random rnd = new Random();

            // Get the number of cards in the deck
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

        // Method to draw a card from the deck
        public Card Draw()
        {
            // If there are cards in the deck
            if (Cards.Count > 0)
            {
                // Remove and return the first card in the list
                //MessageBox.Show(Cards.Count.ToString());
                Card drawnCard = Cards[0];
                Cards.RemoveAt(0);
                return drawnCard;
            }
            else
            {
                // If the deck is empty, throw an exception
                throw new InvalidOperationException("The deck is empty.");
            }
        }
        public ListBox Generate() //check if we have all of the cards
        {
            ListBox lst = new ListBox();    

            foreach(Card card in Cards) {
            lst.Items.Add(card);
            }
            return lst;
        }
    }
}

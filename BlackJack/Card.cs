using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public enum Suit
    {
        Hearts,
        Diamond,
        Clubs,
        Spades
    }
    public enum Rank
    {
       two, three, four, five, six, seven, eight, nine, ten, jack, queen, king, ace
    }
    public class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set;}

        public Card(Suit suit, Rank rank) {
            this.Suit = suit;
            this.Rank = rank;
        }
        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}

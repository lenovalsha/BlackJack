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
       two = 2, three = 3, four = 4 , five = 5, six = 6, seven = 7, eight = 8, nine = 9, ten = 10, jack = 10, queen = 10 , king = 10, ace = 10
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
            return $"{Rank}:{Suit}";
        }
    }
}

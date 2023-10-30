using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        string playerTotal;
        int finalPlayerTotal;

        int HouseTotal;
        int currentPlayerLocationIndex = 0;
        int num;
        int hit;
        int a, b, c;

        bool hadAce, stayOnAce; //fix this later
        List<Label> labels = new List<Label>();
        //Deck ThisDeck;
        //List<Card> CombinedDeck = new List<Card>();
        //List<Deck> Decks = new List<Deck>();
        CombinedDeck CombinedDecks;

        List<int> playersCards = new List<int>();

        string[] cards;

        public Form1()
        {
            InitializeComponent();
            btnStay.Enabled = false;
            btnHit.Enabled = false;
            CombinedDecks = new CombinedDeck(listBox1);
            //cards.AddRange(CombinedDecks.CombinedDecks.ToArray());
        }

        public void btnPlay_Click(object sender, EventArgs e)
        {
            hadAce= false;
            listBox1.Items.Clear();
            playersCards.Clear();

            Play();

            listBox1.Items.AddRange(CombinedDecks.Cards.ToArray());

            cards = CombinedDecks.Play().ToString().Split(':'); //place them in an array split by : => without array ":four:ace:queen"There is technically a character in the [0] position so whe start at [1] => will clean this up later
            a = (int)Enum.Parse(typeof(Rank), cards[1]); //player

            // You can directly use Enum values for the other cards
            b = (int)Enum.Parse(typeof(Rank), cards[2]); //house
            c = (int)Enum.Parse(typeof(Rank), cards[3]); //player

            if (a > 10)
                a = 10;
            if (b > 10)
                b = 10;
            if (c > 10)
                c = 10;

            playersCards.Add(a); //add to players card list
            playersCards.Add(c);
            finalPlayerTotal = a + c;
            //if we pull an ace
            HasAce();

            CreateLabel(100, 100, b, false); //house's first number
            CreateLabel(100, 200, a, false); //players's first number
            CreateLabel(150, 200, c, false); //players's second number

            HouseTotal = b;
            lblHouseTotal.Text = b.ToString();

        }
      private void HasAce()
        {

            if (playersCards.Contains(1))
            {
                
                if ((finalPlayerTotal < 11 && !hadAce ) || (a == 1 && c ==1))
                {
                    playerTotal = (finalPlayerTotal).ToString() + "/" + (finalPlayerTotal + 10).ToString();
                    lblTotal.Text = playerTotal.ToString();
                    stayOnAce = true;
                    //hadAce= true;
                }
                else if(finalPlayerTotal > 11)
                {
                    stayOnAce= false;
                    hadAce = true;
                    playersCards.Remove(1);
                    lblHouseTotal.Text = finalPlayerTotal.ToString();
                    GetPlayerTotal(finalPlayerTotal);
                }
                else if (finalPlayerTotal == 11) //if 21
                {
                   GotBlackJack(finalPlayerTotal);
                    btnHit.Enabled = false;
                    btnStay.Enabled = false;
                }

            }
            else //if not then proceed normally
            {
                GetPlayerTotal(finalPlayerTotal);

            }
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            hit++;
            int hitCard = CombinedDecks.Hit();
            CreateLabel(150 + (hit * 50), 200, hitCard, false);
            finalPlayerTotal+= hitCard;
            playersCards.Add(hitCard);
       
            HasAce();
        }
        private void GotBlackJack(int num)
        {
            lblTotal.Text = num.ToString();
            MessageBox.Show("BLACK JACK");
            ClearPanel();
            btnPlay.Enabled = true;
        }
        private void GetPlayerTotal(int total)
        {
            lblTotal.Text = total.ToString();
            if (total >= 21)
            {
                btnHit.Enabled = false;
                btnStay.Enabled = false;
                if (total == 21)
                {
                    Stay();
                }
                else
                {
                    MessageBox.Show("Bust");
                    btnPlay.Enabled = true;
                    ClearPanel();
                }
            }
            else
            {
                btnHit.Enabled = true;
                btnStay.Enabled = true;
            }
        }
        private void CreateLabel(int x, int y, int value, bool type)
        {
            Point point = new Point(x, y);
            Font font = new Font("Consolas", 10);
            Label newLabel = new Label();
            currentPlayerLocationIndex = type == false ? 0 : currentPlayerLocationIndex;
            newLabel.Text = value.ToString();
            newLabel.Font = font;
            newLabel.Location = point; // Change the index to 0 to use the first set of points
            newLabel.AutoSize = true;
            this.Controls.Add(newLabel);
            labels.Add(newLabel);
            if (type == true)
            {

                currentPlayerLocationIndex++;
            }
        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            Stay();
        }
        private void Stay()
        {
            //num = rnd.Next(1, 11); //this is only getting hit once
            if (stayOnAce)
            {
                finalPlayerTotal += 10; // originally the Ace is =1
            }
            for (int i = 0; i < 7; i++)
            {
                if (HouseTotal < 17)
                {
                    num = CombinedDecks.Hit();
                    CreateLabel(150 + (i * 50), 100, num, false);
                    HouseTotal += num;
                    lblHouseTotal.Text = HouseTotal.ToString();
                }
            }

            if (HouseTotal > finalPlayerTotal && HouseTotal <= 21)
            {
                MessageBox.Show("house wins");
            }
            else if((HouseTotal < finalPlayerTotal && finalPlayerTotal <=21) || HouseTotal > 21)
            {
                MessageBox.Show("Player wins");
            }
            else if(HouseTotal == finalPlayerTotal)
            {
                MessageBox.Show("Draw");
            }
            btnPlay.Enabled = true;
        }
        private void Play()
        {
            btnPlay.Enabled = true;
            hadAce = false;
            ClearPanel();
            hit = 0;
        }
        private void ClearPanel()
        {
            foreach (Control control in labels)
            {
                if (control is Label)
                {
                    this.Controls.Remove(control);
                    control.Dispose();
                }
            }
        }

        private void lblHouseTotal_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

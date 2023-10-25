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
        int playerTotal;
        int HouseTotal;
        int currentPlayerLocationIndex = 0;
        int num;
        int hit;
        List<Label> labels = new List<Label>();
        Deck ThisDeck;
        List<Card> CombinedDeck = new List<Card>();
        List<Deck> Decks = new List<Deck>();

        
        public Form1()
        {
            InitializeComponent();
            btnStay.Enabled = false;
            btnHit.Enabled = false;
            for (int i = 0; i < 4; i++) //make 4 decks
            {
                ThisDeck = new Deck();
                Decks.Add(ThisDeck);

                CombinedDeck.AddRange(ThisDeck.Cards);
            }
            //we need to get every card in this four deck
            listBox1.Items.AddRange(CombinedDeck.ToArray());
        }
        public Card DrawFromCombinedDeck()
        {
            if(CombinedDeck.Count > 0)
            {
                Card drawnCard = CombinedDeck[0];
                CombinedDeck.RemoveAt(0);
                return drawnCard;
            }
            else
            {
                throw new Exception("No more cards left");
            }
        }

        public void btnPlay_Click(object sender, EventArgs e)
        {

            // Play();
            // btnPlay.Enabled = false;
            //int house1 = rnd.Next(1, 11);

            ////get random number for our player
            //int num1 = rnd.Next(1,11);
            //int num2 = rnd.Next(1,11);
            ////display the random numbers
            //CreateLabel(100, 100, house1,false); //house's first number

            //CreateLabel(100, 200, num1,false);
            //CreateLabel(150, 200, num2,false);        
            //playerTotal = num1 + num2;
            //HouseTotal = house1;
            //lblHouseTotal.Text = HouseTotal.ToString();

            ////if the player number is not 21 then give the choice of hit or stay
            //GetPlayerTotal(playerTotal);

            MessageBox.Show(DrawFromCombinedDeck().ToString());
            listBox1.Items.Clear();
            listBox1.Items.AddRange(CombinedDeck.ToArray() );


        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            hit++;
            num = rnd.Next(1, 11); //this is only getting hit once

            for (int i = 0; i < 1; i++)
            {
                

                    num = rnd.Next(1, 11);
                    CreateLabel(150 + (hit * 50), 200, num, false);
                    playerTotal += num;
                    lblTotal.Text = playerTotal.ToString();
                GetPlayerTotal(playerTotal);
                
            }

        }
        private void GetPlayerTotal(int total)
        {
            lblTotal.Text = total.ToString();
           if(total >= 21)
            {
                btnHit.Enabled = false;
                btnStay.Enabled = false;
                if(total == 21)
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
        private void ShuffleDecks()
        {

        }

        private void CreateLabel(int x, int y, int value, bool type)
        {
            Point point = new Point (x,y);
            Font font = new Font("Consolas", 10);
            Label newLabel = new Label();
            currentPlayerLocationIndex = type == false? 0 : currentPlayerLocationIndex;
            newLabel.Text = value.ToString();
            newLabel.Font = font;
            newLabel.Location = point; // Change the index to 0 to use the first set of points
            newLabel.AutoSize = true;
            this.Controls.Add(newLabel);
            labels.Add(newLabel);
            if(type == true) {

                currentPlayerLocationIndex++;
            }
        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            Stay();
        }
        private void Stay()
        {
            num = rnd.Next(1, 11); //this is only getting hit once

            for (int i = 0; i < 7; i++)
            {
                if (HouseTotal < 17)
                {
                    num = rnd.Next(1, 11);
                    CreateLabel(150 + (i * 50), 100, num, false);
                    HouseTotal += num;
                    lblHouseTotal.Text = HouseTotal.ToString();
                }
            }

            if(HouseTotal > playerTotal && HouseTotal <=21)
            {
                MessageBox.Show("house wins");
            }
            else 
            {
                MessageBox.Show("Player wins");
            }
            btnPlay.Enabled = true;
        }
        private void Play()
        {
            btnPlay.Enabled = true;
           ClearPanel();
            hit = 0;
        }
        private void ClearPanel()
        {
            foreach(Control control in labels)
            {
                if(control is Label)
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

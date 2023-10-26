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
        //Deck ThisDeck;
        //List<Card> CombinedDeck = new List<Card>();
        //List<Deck> Decks = new List<Deck>();
        CombinedDeck CombinedDecks;
        List<Card> cards = new List<Card>();


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

            listBox1.Items.Clear();
            
            Play();
           

            string[] cards;
            int a, b, c;

            listBox1.Items.AddRange(CombinedDecks.Cards.ToArray());

            cards = CombinedDecks.Play().ToString().Split(':'); //place them in an array split by : => without array ":four:ace:queen"There is technically a character in the [0] position so whe start at [1] => will clean this up later
            a = (int)Enum.Parse(typeof(Rank), cards[1]); //player

            // You can directly use Enum values for the other cards
            b = (int)Enum.Parse(typeof(Rank), cards[2]); //house
            c = (int)Enum.Parse(typeof(Rank), cards[3]); //player

           if(a>10) 
                a = 10;
           if(b>10)
                b = 10;
           if(c>10)
                c = 10;

            CreateLabel(100, 100, b, false); //house's first number

            CreateLabel(100, 200, a, false); //players's first number
            CreateLabel(150, 200, c, false); //players's second number

            HouseTotal = b;
            lblHouseTotal.Text = b.ToString();
            playerTotal = a + c;
            GetPlayerTotal(playerTotal);

        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            hit++;
            int hitCard = CombinedDecks.Hit();
            CreateLabel(150 + (hit * 50), 200, hitCard, false);
            playerTotal+= hitCard;
            lblTotal.Text = playerTotal.ToString();
            GetPlayerTotal(playerTotal);
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

            if (HouseTotal > playerTotal && HouseTotal <= 21)
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

using System;
using System.Windows.Forms;

namespace _4_A_Day_At_The_Races
{
    public partial class Form1 : Form
    {
        Guy[] guys = new Guy[3];
        Guy joe = new Guy();
        Guy bob = new Guy();
        Guy al = new Guy();
        Greyhound[] greyhounds = new Greyhound[4];
        Random Randomizer;
        bool running = false;

        public Form1()
        {   
            InitializeComponent();
            Randomizer = new Random();

            greyhounds[0] = new Greyhound() {
                Randomizer = Randomizer,
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Location.X
            };
            greyhounds[1] = new Greyhound() { 
                Randomizer = Randomizer, 
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Location.X
            };
            greyhounds[2] = new Greyhound() { 
                Randomizer = Randomizer, 
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Location.X
            };
            greyhounds[3] = new Greyhound() { 
                Randomizer = Randomizer, 
                MyPictureBox = pictureBox4 ,
                StartingPosition = pictureBox4.Location.X
            };

            guys[0] = new Guy()
            {
                Name = "Joe",
                Cash = 50,
                MyRadioButton = joeRadioButton,
                MyLabel = joeBetLabel,
                MyBet = null
            };

            guys[1] = new Guy()
            {
                Name = "Bob",
                Cash = 75,
                MyRadioButton = bobRadioButton,
                MyLabel = bobBetLabel,
                MyBet = null
            };

            guys[2] = new Guy()
            {
                Name = "Al",
                Cash = 45,
                MyRadioButton = alRadioButton,
                MyLabel = alBetLabel,
                MyBet = null
            };

            joe = guys[0];
            bob = guys[1];
            al = guys[2];

            for (int i = 0; i < guys.Length; i++)
            {
                guys[i].UpdateLabels();
            }

        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                label1.Text = guys[0].Name;
            }
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bobRadioButton.Checked)
            {
                label1.Text = guys[1].Name;
            }
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (alRadioButton.Checked)
            {
                label1.Text = guys[2].Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 

            if (joeRadioButton.Checked && !running)
            {
                joe.PlaceBet((int)numericAmount.Value, (int)numericDog.Value);
                joe.UpdateLabels();
            }

            if (bobRadioButton.Checked && !running)
            {
                bob.PlaceBet((int)numericAmount.Value, (int)numericDog.Value);
                bob.UpdateLabels();
            }

            if (alRadioButton.Checked && !running)
            {
                al.PlaceBet((int)numericAmount.Value, (int)numericDog.Value);
                al.UpdateLabels();
            }



            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            running = true;
            bool noWinner = true;
            int winner = 0;
            while(noWinner)
            {
                System.Threading.Thread.Sleep(50);
                for (int  i = 0; i < greyhounds.Length; i++)
                {
                    noWinner = !(greyhounds[i].Run());
                    if (!noWinner)
                    {
                        winner = i;
                        i = greyhounds.Length;//Finish for loop
                    }                    
                }
            }

            for (int i = 0; i < greyhounds.Length; i++)
            {
                greyhounds[i].TakeStartingPosition();

            }
            for (int i = 0; i < guys.Length; i++)
            {
                guys[i].Collect(winner);
                guys[i].ClearBet();
                guys[i].UpdateLabels();
            }


            running = false;

        }
    }
}

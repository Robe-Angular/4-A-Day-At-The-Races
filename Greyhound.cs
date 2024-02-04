using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _4_A_Day_At_The_Races
{
    class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;

        public bool Run()
        {
            RacetrackLength = 450;
            Location += Randomizer.Next(10);
            
            if(Location >= RacetrackLength)
            {   
                return true;
            }
            else
            {
                MyPictureBox.Location = new Point()
                {
                    X = StartingPosition + Location,
                    Y = MyPictureBox.Location.Y
                };
                return false;
            }
        }
        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Location = new Point()
            {
                X = StartingPosition + Location,
                Y = MyPictureBox.Location.Y
            };
        }

    }
}

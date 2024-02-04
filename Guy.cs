using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_A_Day_At_The_Races
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            if(MyBet == null)
            {
                MyLabel.Text = "no bet yet";
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription();
            }
            //MyRadioButton.Text = Name + " has " + Cash + " bucks.";
            MyRadioButton.Text = ($"{Name} has {Cash} bucks.");

        }

        public void ClearBet()
        {
            MyBet = null;
        }

        public bool PlaceBet(int Amount, int Dog)
        {
            MyBet = new Bet() { };
            if(Cash >= Amount && Amount >= 5 && Amount <= 15 && Dog < 4)
            {
                MyBet.Amount = Amount;
                MyBet.Dog = Dog;
                MyBet.Bettor = this;
                return true;
            }
            else
            {
                MyBet = null;
                return false;
            }
            
            
        }

        public void Collect(int Winner)
        {
            if(MyBet == null)
            {

            }
            else
            {
                Cash += MyBet.PayOut(Winner);
            }
            
        }
    }
}

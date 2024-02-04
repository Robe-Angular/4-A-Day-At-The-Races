using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_A_Day_At_The_Races
{
    class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public String GetDescription()
        {
            string description = Bettor.Name + " bets " + Amount + " on dog #" + Dog;
            return description;
        }

        public int PayOut(int Winner)
        {
            if(Dog == Winner)
            {
                return Amount * 2;

            }
            else
            {
                return Amount * -1;
            }
            
        }
    }
}

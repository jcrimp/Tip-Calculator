using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment10
{
    class Tip
    {
        //fields
        private double mealAmount;
        private double tipPercent;
        private const double taxPercent = .094;
        private const double percentDivisor = 100;


        //public properties for each of the fields
        public double MealAmount//no parentheses for properties
        {
            get { return mealAmount; }//lets user see the value
            set { mealAmount = value; }//lets user change the value
        }
        
        public double TipPercent
        {
            get { return tipPercent; }
            set { tipPercent = value; }
        }

        public double TaxPercent
        {
            get { return taxPercent; }
        }

        public double PercentDivisor
        {
            get { return percentDivisor; }
        } 

        //methods
        public double CalculateTax()
        {
            return MealAmount * TaxPercent;
        }

        public double CalculateSubtotal()
        {
            return MealAmount + CalculateTax();
        }

        public double CalculateTip()
        {
            double tipamount;
            if(TipPercent > 1)
            {
                tipamount = CalculateSubtotal() * (TipPercent / PercentDivisor);
            }
            else
            {
                tipamount = CalculateSubtotal() * TipPercent;
            }

            return tipamount;
        }


        public double CalculateTotal()
        {
            double tip = CalculateTip();
            return MealAmount + CalculateTax() + tip;
        }
    }

}

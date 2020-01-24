
/// <summary>
//============================================================
// Student Number	: S10198319, S10196678
// Student Name	: Tan Yuan Ming, Gladys
// Module  Group	: P08 //============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Project
{
	class ClassBBed: Bed
	{
        public bool AirCon { get; set; }

        public ClassBBed(int wa, int bn, double dr, bool a, bool ac) : base(wa, bn, dr, a)
        {
            AirCon = ac;
        }
        public override double CalculateCharges(string citizenStatus, int noOfDays) 
        {
            double charges;
            double weeks = noOfDays / 7;
            double Total;

            if (AirCon == false)
            {
                charges = 50 * Math.Round(weeks, 0);
            }
            else if(AirCon == true)
            {
                if(noOfDays == 8)
                {
                    charges = 100;
                }
                else
                {
                    charges = 0;
                }
            }
            else
            {
                charges = 0;
            }

            if (citizenStatus == "SC")
            {
                Total = charges + (DailyRate * 0.7 * noOfDays);
                
            }
            else if (citizenStatus == "PR")
            {
                Total = charges * (DailyRate * 0.4 * noOfDays);
            }
            else if (citizenStatus == "Foreigner")
            {
                Total = charges * (DailyRate * noOfDays);
            }
            else
            {
                Total = 0;
            }
            return Total;
        }
        public override string ToString()
        {
            return base.ToString() + "\tAirCon: " + AirCon;
        }
    }
}

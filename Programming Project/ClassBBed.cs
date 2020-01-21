
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
        public override double CalculateCharges(string cs, int nos) 
        {
            if (cs == "SC")
            {
                return DailyRate * 70 / 100 * nos;
            }
            else if (cs == "PR")
            {
                return DailyRate * 40 / 100 * nos;
            }
            else if (cs == "Foreigner")
            {
                return DailyRate * nos;
            }
            else
            {
                return 0;
            }
        }
        public override string ToString()
        {
            return base.ToString() + "\tAirCon: " + AirCon;
        }
    }
}

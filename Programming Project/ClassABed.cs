//============================================================
    // Student Number	: S10198319, S10196678
    // Student Name	: Tan Yuan Ming, Gladys
    // Module  Group	: P08
//============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Project
{
	class ClassABed:Bed
	{
        public bool AccompanyingPerson { get; set; }
        public ClassABed() : base() { }
        public ClassABed(int wa, int bn, double dr, bool a) : base(wa, bn, dr, a) { }
        public override double CalculateCharges(string citizenStatus, int noOfDays) 
        {
            double charge;
            if (AccompanyingPerson == true)
            {
                charge = 100 * noOfDays;
            }
            else
                charge = 0;
            double Total = DailyRate + charge;
            return Total;
        }
        public override string ToString()
        {
            return base.ToString() + "\tAccompanyingPerson: " + AccompanyingPerson;
        }
    }
   
}

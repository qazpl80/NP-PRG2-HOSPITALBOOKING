
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
	class ClassABed:Bed
	{
        public bool AccompanyingPerson { get; set; }
        public ClassABed(int wa,  int bn, double dr, bool a,bool ap):base(wa,bn,dr,a)
        {
            AccompanyingPerson = ap;
        }
        public override double CalculateCharges(string citizenStatus, int noOfDays) 
        {
            return DailyRate * noOfDays;
        }
        public override string ToString()
        {
            return base.ToString() + "\tAccompanyingPerson: " + AccompanyingPerson;
        }
    }
   
}

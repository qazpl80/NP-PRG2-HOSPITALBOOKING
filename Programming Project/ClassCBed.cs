
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
	class ClassCBed: Bed
	{
        public bool PortableTv { get; set; }
        public ClassCBed(int wa, int bn, double dr, bool a, bool pt) : base(wa, bn, dr, a)
        {
            PortableTv = pt;
        }
        public override double CalculateCharges(string citizenStatus, int noOfDays) 
        {
            if (citizenStatus == "SC")
            {
                return DailyRate * 80 / 100 * noOfDays;
            }
            else if (citizenStatus == "PR")
            {
                return DailyRate * 60 / 100 * noOfDays;
            }
            else if (citizenStatus == "Foreigner")
            {
                return DailyRate * noOfDays;
            }
            else
            {
                return 0;
            }
        }
        public override string ToString()
        {
            return base.ToString() + "\tPortableTv: " + PortableTv;
        }
    }
}

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
    class ClassCBed : Bed
    {
        public bool PortableTv { get; set; }
        public ClassCBed():base(){}
        public ClassCBed(int wa, int bn, double dr, bool a) : base(wa, bn, dr, a) { }
        public override double CalculateCharges(string citizenStatus, int noOfDays) 
        {
            int cost;
            double Total;
            if(PortableTv == true)
            {
                cost = 30;
            }
            else
            {
                cost = 0;
            }
            if (citizenStatus == "SC")
            {
                Total = cost +( DailyRate * 80 / 100 * noOfDays);
            }
            else if (citizenStatus == "PR")
            {
                Total = cost + ( DailyRate * 60 / 100 * noOfDays);
            }
            else if (citizenStatus == "Foreigner")
            {
                Total = cost + (DailyRate * noOfDays); ;
            }
            else
            {
                return 0;
            }
            return Total;
        }
        public override string ToString()
        {
            return base.ToString() + "\tPortableTv: " + PortableTv;
        }
    }
}

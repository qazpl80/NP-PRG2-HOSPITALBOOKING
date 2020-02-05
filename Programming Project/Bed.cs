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
    abstract class Bed
    {
        public int WardNo { get; set; }
        public int BedNo { get; set; }
        public double DailyRate { get; set; }
        public bool Available { get; set; }

        public Bed() { }
        public Bed(int wn , int bn,double dr, bool a)
        {
            WardNo = wn;
            BedNo = bn;
            DailyRate = dr;
            Available = a;
        }
        public abstract double CalculateCharges(string cs, int nod);
        
        public override string ToString()
        {
            return "WardNo: " + WardNo + "\tBedNo: " + BedNo + "\tDailyRate: " + DailyRate + "\tAvailable: " + Available;
        }
    }
}


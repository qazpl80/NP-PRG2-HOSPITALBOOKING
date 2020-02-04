//============================================================
// Student Number	: S10198319, S10196678G
// Student Name	: Tan Yuan Ming, Gladys
// Module  Group	: P08 //============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Project
{
	class BedStay
	{
        public DateTime StartBedstay { get; set; }
        public DateTime? EndBedstay { get; set; }
        public  Bed Bed { get; set; }

        public BedStay() { }
        public BedStay(DateTime sbs, Bed b)
        {
            StartBedstay = sbs;
            Bed = b;
        }
        public override string ToString()
        {
            return base.ToString() +
                "\tStartBedstay: " + StartBedstay +
                "\tEndBedstay: " + EndBedstay
                + Bed;
        }


    }
}

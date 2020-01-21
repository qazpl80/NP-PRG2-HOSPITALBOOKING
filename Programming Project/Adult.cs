
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
    class Adult : Patient
    {
        public double medisaveBalance { get; set; }

        public Adult(string id, string n, int a, char g, string cs, string s, double m) : base(id, n, a, g, cs, s)
        {
            medisaveBalance = m;
        }
        public override CalculateCharges()
        {
            return base.CalculateCharges() - medisaveBalance;
        }
        public override string ToString()
        {
            return base.ToString() + "\tMedisave Balance : " + medisaveBalance;
        }
    }
}

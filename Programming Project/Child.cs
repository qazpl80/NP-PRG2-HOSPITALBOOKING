
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
	class Child:Patient
	{
        public double CdaBalance{ get; set; }

        public Child(string id, string n, int a, char g, string cs, string s, double cb) : base(id, n, a, g, cs, s)
        {
            CdaBalance = cb;
        }

        public new double CalculateCharges()
        {
            return base.CalculateCharges() - CdaBalance;
        }
        public override string ToString()
        {
            return base.ToString() + "\tCdaBalance: " + CdaBalance;
        }
    }
}

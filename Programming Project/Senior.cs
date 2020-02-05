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
    class Senior : Patient
    {
        public Senior(string id, string n, int a, char g, string cs, string s) : base(id, n, a, g, cs, s) { }
        public new double CalculateCharges()
        {
            return base.CalculateCharges() / 2;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

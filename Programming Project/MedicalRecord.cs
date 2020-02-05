//==============================//============================================================
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
    class MedicalRecord
    {
        public string Diagnosis { get; set; }
        public double Temperature { get; set; }
        public DateTime DatetimeEntered { get; set; }

        public MedicalRecord() { }
        public MedicalRecord(string d , double t, DateTime dte)
        {
            Diagnosis = d;
            Temperature = t;
            DatetimeEntered = dte;
        }
        public override string ToString()
        {
            return "Diagnosis: " +
                Diagnosis +
                "\tTemperature: "
                + Temperature +
                "\tDateTimeEntered: "
                + DatetimeEntered;
        }


    }
}


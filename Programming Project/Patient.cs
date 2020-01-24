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
    abstract class Patient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string CitizenStatus { get; set; }
        public string Status { get; set; }
        public Stay Stay { get; set; }

        public Patient(string id, string n, int a, char g, string cs, string s)
        {
            Id = id;
            Name = n;
            Age = a;
            Gender = g;
            CitizenStatus = cs;
            Status = s;
        }
        public double CalculateCharges()
        {
          
            
            foreach (BedStay bs in Stay.BedstayList)
            {
                int daysin = 0;
                DateTime admission = bs.StartBedstay;
                DateTime? discharge = bs.EndBedstay.GetValueOrDefault();
                daysin = Convert.ToInt32(discharge - admission);
                Bed bed = bs.Bed;

                if (bed is ClassABed)
                {
                    return bed.CalculateCharges(CitizenStatus, daysin);

                }
                else if (bed is ClassBBed)
                {
                    return bed.CalculateCharges(CitizenStatus, daysin);
                }
                else if (bed is ClassCBed)
                {

                    return bed.CalculateCharges(CitizenStatus, daysin);
                }
               
            }
            return 0;
            

        }
        public override string ToString()
        {
            return "ID: " + Id
                + "\tName: " + Name
                + "\tAge: " +  Age
                + "\tGender" + Gender
                + "\tCitizen Status: " + CitizenStatus
                + "\tStatus: " + Status;
        }
    }
}

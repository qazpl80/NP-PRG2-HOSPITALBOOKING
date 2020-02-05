//======//============================================================
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
    class Stay
	{
        public DateTime AdmittedDate { get; set; }  
        public DateTime? DischargedDate { get; set; }
        public bool IsPaid { get; set; }
        public List<MedicalRecord> MedicalRecordList { get; set; } = new List<MedicalRecord>();
        public List<BedStay> BedstayList { get; set; } = new List<BedStay>();
        public Patient Patient { get; set; }

        public Stay() { }
        public Stay(DateTime ad , Patient p)
        {
            AdmittedDate = ad;
            Patient = p;
        }
        public void AddMedicalRecord(MedicalRecord mr)
        {
            MedicalRecordList.Add(mr);
        }
        public void AddBedstay(BedStay bs)
        {
            BedstayList.Add(bs);
        }
        public override string ToString()
        {
            return "AdmittedDate: " + AdmittedDate +
                "\tDischargedDate: " + DischargedDate +
                Patient;
        }
    }
}

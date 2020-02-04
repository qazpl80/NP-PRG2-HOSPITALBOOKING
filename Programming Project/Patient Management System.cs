﻿//============================================================
// Student Number	: S10198319, S10196678
// Student Name	: Tan Yuan Ming, Gladys
// Module  Group	: P08 //============================================================


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Programming_Project
{
    class Patient_Management_System
    {
        static void Main(string[] args)
        {
            //create list to store patients
            List<Patient> patientsList = new List<Patient>();
            //create list to store registered/ discharged
            //Create list to store beds
            List<Bed> bedsList = new List<Bed>();
            //Implement csv files into List
            InitData(patientsList, bedsList);

            string i = "1";

            while (!i.Equals("0"))
            {
                DisplayMenu();
                Console.Write("Enter your option: ");
                i = Console.ReadLine();
                if (i.Equals("1"))
                {
                    Console.WriteLine("Option 1. View All Patients");
                    DisplayPatients(patientsList);
                }
                else if (i.Equals("2"))
                {
                    Console.WriteLine("Option 2. View All Beds");
                    DisplayBeds(bedsList);
                }
                else if (i.Equals("3"))
                {
                    Console.WriteLine("Option 3. Register Patient");
                    RegisterPatient(patientsList);

                }
                else if (i.Equals("4"))
                {
                    Console.WriteLine("Option 4. Add new bed");
                    Addnewbed(bedsList);
                }
                else if (i.Equals("5"))
                {
                    Console.WriteLine("Option 5. Register hospital stay");
                 
                    RegisterHospitalStay(patientsList, bedsList);

                 
                }
                else if (i.Equals("6"))
                {
                    Console.WriteLine("Option 6. Retrieve Patient");
                    retrievePatient(patientsList, bedsList);
                }
                else if (i.Equals("7"))
                {
                    Console.WriteLine("Option 7. Add Medical Record Entry");
                    DisplayPatients(patientsList);
                    AddMedicalRecord(patientsList);
                }
                else if (i.Equals("8"))
                {
                    Console.WriteLine("Option 8. View medical records");
                    DisplayPatientsM(patientsList);
                    Console.Write("Enter patient ID number: ");
                    string pid = Console.ReadLine();
                    foreach (Patient p in patientsList)
                    {
                        if (p.Id == pid)
                        {
                            Console.WriteLine("Patient found: {0}", p.Name);
                            DisplayMedicalRecord(p);
                            break;
                        }
                    }
                }
                else if (i.Equals("9"))
                {
                    Console.WriteLine("Option 9.Transfer Patient to Another Bed");
                }
                else if (i.Equals("10"))
                {
                    Console.WriteLine("Option 10. Discharge and payment");
                    DisplayPatientsM(patientsList);
                }
                else if (i.Equals("11"))
                {
                    Console.WriteLine("Option 11. Display currencies exchange rate");
                }
                else if (i.Equals("12"))
                {
                    Console.WriteLine("Option 12. Display PM 2.5 information");
                }
                else
                {
                    Console.WriteLine("Invalid Option, Please Try Again.");
                }
            }
        }
        //display menu
        static void DisplayMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("MENU");
            Console.WriteLine("====");
            Console.WriteLine("1. View all patients");
            Console.WriteLine("2. View all beds");
            Console.WriteLine("3. Register patient");
            Console.WriteLine("4. Add new bed");
            Console.WriteLine("5. Register a hospital stay");
            Console.WriteLine("6. Retrieve patient details");
            Console.WriteLine("7. Add medical record entry");
            Console.WriteLine("8. View medical records");
            Console.WriteLine("9. Transfer patient to another bed");
            Console.WriteLine("10. Discharge and payment");
            Console.WriteLine("11. Display currencies exchange rate");
            Console.WriteLine("12. Display PM 2.5 information");
            Console.WriteLine("0. Exit");
            Console.WriteLine("\n");
        }

        //Display Bedlist
        static void DisplayBeds(List<Bed> bedsList)
        {
            Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}","No", "Ward Type", "Ward No", "Bed No", "Availability", "Daily Rate");
            int count = 1;
            foreach (Bed b in bedsList)
            {
                if (b is ClassABed)
                {
                    ClassABed cab = (ClassABed)b;
                    Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", count, "A", cab.WardNo, cab.BedNo, cab.DailyRate, cab.Available);
                }
                else if (b is ClassBBed)
                {
                    ClassBBed cbb = (ClassBBed)b;
                    Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", count, "B", cbb.WardNo, cbb.BedNo, cbb.DailyRate, cbb.Available);
                }
                else if (b is ClassCBed)
                {
                    ClassCBed ccb = (ClassCBed)b;
                    Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", count, "C", ccb.WardNo, ccb.BedNo, ccb.DailyRate, ccb.Available);
                }
                count++;
            }
        }
        //display patients
        static void DisplayPatients(List<Patient> pList)
        {
            //read lines from patients.csv
            Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", "Name", "ID No.", "Age", "Gender", "Citizenship", "Status");
            foreach (Patient p in pList)
            {
                Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", p.Name, p.Id, p.Age, p.Gender, p.CitizenStatus, p.Status);
            }
        }
        static void DisplayPatientsM(List<Patient> pList)
        {
            //read lines from patients.csv
            Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", "Name", "ID No.", "Age", "Gender", "Citizenship", "Status");
            foreach (Patient p in pList)
            {
                if (p.Status == "Admitted")
                {
                    Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", p.Name, p.Id, p.Age, p.Gender, p.CitizenStatus, p.Status);
                }
            }
        }  static void DisplayPatientsRetrieve(List<Patient> pList)
        {
            //read lines from patients.csv
            Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", "Name", "ID No.", "Age", "Gender", "Citizenship", "Status");
            foreach (Patient p in pList)
            {
                if (p.Status != "Admitted")
                {
                    Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", p.Name, p.Id, p.Age, p.Gender, p.CitizenStatus, p.Status);
                }
            }
        }
        //InIt List

        static void InitData(List<Patient> pList, List<Bed>bList)
        {
            // read csv lines from patients
            string[] lines = File.ReadAllLines("patients(1).csv");

            for (int l = 1; l < lines.Length; l++)
            {
                string[] info = lines[l].Split(',');
                if (Convert.ToInt32(info[2]) <= 12)
                {
                    if (info[4] == "SC")
                    {

                        Patient child = new Child(info[1], info[0], Convert.ToInt32(info[2]), Convert.ToChar(info[3]), info[4], "Registered", Convert.ToDouble(info[5]));
                        pList.Add(child);
                    }
                    else
                    {
                        Patient child = new Child(info[1], info[0], Convert.ToInt32(info[2]), Convert.ToChar(info[3]), info[4], "Registered", 0);
                        pList.Add(child);
                    }
                }
                else if (Convert.ToInt32(info[2]) < 64)
                {
                    if (info[4] == "SC" || info[4] == "PR")
                    {
                        Patient adult = new Adult(info[1], info[0], Convert.ToInt32(info[2]), Convert.ToChar(info[3]), info[4], "Registered", Convert.ToDouble(info[5]));
                        pList.Add(adult);
                    }
                    else
                    {
                        Patient adult = new Adult(info[1], info[0], Convert.ToInt32(info[2]), Convert.ToChar(info[3]), info[4], "Registered", 0);
                        pList.Add(adult);
                    }

                }
                else
                {
                    Senior senior = new Senior(info[1], info[0], Convert.ToInt32(info[2]), Convert.ToChar(info[3]), info[4], "Registered");
                    pList.Add(senior);
                }

            }

            //Read from Beds.csv
            string[] sents = File.ReadAllLines("beds.csv");

            for (int l = 1; l < sents.Length; l++)
            {
                string[] sbed = sents[l].Split(',');
                if (sbed[0] == "A")
                {
                    Bed cab = new ClassABed(Convert.ToInt32(sbed[1]), Convert.ToInt32(sbed[2]), Convert.ToDouble(sbed[4]), true);
                    bList.Add(cab);
                }
                else if (sbed[0] == "B")
                {
                    Bed cbb = new ClassBBed(Convert.ToInt32(sbed[1]), Convert.ToInt32(sbed[2]), Convert.ToDouble(sbed[4]), true);
                    bList.Add(cbb);
                }
                else if (sbed[0] == "C")
                {
                    Bed ccb = new ClassCBed(Convert.ToInt32(sbed[1]), Convert.ToInt32(sbed[2]), Convert.ToDouble(sbed[4]), true);
                    bList.Add(ccb);
                }
            }
        }
        static void AddMedicalRecord(List<Patient> patientsList)
        {
            Console.Write("Enter patient ID number: ");
            string pid = Console.ReadLine();
            Console.Write("\n Patient temperature: ");
            double ptm = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter patient observation: ");
            string pob = Console.ReadLine();

            foreach (Patient p in patientsList)
            {
                if (p.Id == pid)
                {
                    Stay st = new Stay(DateTime.Now, p);
                    MedicalRecord mr = new MedicalRecord(pob, ptm, DateTime.Now);
                    st.AddMedicalRecord(mr);
                    Console.WriteLine("Medical record entry successfully added.");
                    break;
                }
                else
                {
                    Console.WriteLine("Error, Patient not found, please try again");
                    break;
                }
            }
        }
        static void DisplayMedicalRecord(Patient p)
        {
            Console.WriteLine("Name of patient: {0}", p.Name);
            Console.WriteLine("ID number: {0}", p.Id);
            Console.WriteLine("Citizenship status: {0}", p.CitizenStatus);
            Console.WriteLine("Gender: {0}", p.Gender);
            Console.WriteLine("Status: {0}", p.Status);
            Console.WriteLine("\n======Stay ======");
            Console.WriteLine("Admission Date: {0}", p.Stay.AdmittedDate);
            Console.WriteLine("Discharge Date: {0}", p.Stay.DischargedDate);

            int counter = 1;
            foreach (MedicalRecord mr in p.Stay.MedicalRecordList)
            {
                Console.WriteLine("\n======Record # {0}======", counter);
                Console.WriteLine("Date/Time: ", mr.DatetimeEntered);
                Console.WriteLine("Temperature: ", mr.Temperature);
                Console.WriteLine("Diagnosis: ", mr.Diagnosis);
                counter++;

            }
        }
        static void dischargepayment(List<Patient> patientsList,List<Bed> bedsList)
        {
            Console.Write("Enter patient ID number: ");
            string pid = Console.ReadLine();
            Console.Write("Date of discharge (DD/MM/YYYY): ");
            string dod = Console.ReadLine();
            foreach (Patient p in patientsList)
            {
                if (p.Id == pid)
                {
                    Console.WriteLine("Name of patient: {0}", p.Name);
                    Console.WriteLine("ID number: {0}", p.Id);
                    Console.WriteLine("Citizenship status: {0}", p.CitizenStatus);
                    Console.WriteLine("Gender: {0}", p.Gender);
                    Console.WriteLine("Status: {0}", p.Status);
                    Console.WriteLine("\n======Stay ======");
                    Console.WriteLine("Admission Date: {0}", p.Stay.AdmittedDate);
                    Console.WriteLine("Discharge Date: {0}", dod);
                    p.Stay.IsPaid = false;
                    foreach (Bed b in bedsList)
                    {
                        if (b is ClassABed)
                        {
                            Console.WriteLine("\n======Bed # 1 ======");
                            Console.WriteLine("Ward number: ", b.WardNo);
                            Console.WriteLine("Bed number: ", b.BedNo);
                            Console.WriteLine("Ward Class: ", "A");
                            foreach (BedStay bs in p.Stay.BedstayList)
                            {
                                Console.WriteLine("Start of bed stay: ", bs.StartBedstay);
                                Console.WriteLine("End of bed stay: ", bs.EndBedstay);
                            }

                        }
                        else if (b is ClassBBed)
                        {
                            Console.WriteLine("\n======Bed # 1 ======");
                            Console.WriteLine("Ward number: ", b.WardNo);
                            Console.WriteLine("Bed number: ", b.BedNo);
                            Console.WriteLine("Ward Class: ", "B");
                            foreach (BedStay bs in p.Stay.BedstayList)
                            {
                                Console.WriteLine("Start of bed stay: ", bs.StartBedstay);
                                Console.WriteLine("End of bed stay: ", bs.EndBedstay);
                                Console.WriteLine("Accompanying person: ",);
                            }
                        }
                        else if (b is ClassCBed)
                        {
                            Console.WriteLine("\n======Bed # 1 ======");
                            Console.WriteLine("Ward number: ", b.WardNo);
                            Console.WriteLine("Bed number: ", b.BedNo);
                            Console.WriteLine("Ward Class: ", "C");
                            foreach (BedStay bs in p.Stay.BedstayList)
                            {
                                Console.WriteLine("Start of bed stay: ", bs.StartBedstay);
                                Console.WriteLine("End of bed stay: ", bs.EndBedstay);
                            }
                        }
                    }
                }
            }
        }
        static void RegisterPatient(List<Patient> pList)
        {
            
            string patientdeets;
            Console.Write("Enter Name: ");
           
            string name = Console.ReadLine();
           
            Console.Write("Enter Identification Number: ");
            string Idn = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = 0;
            try
            {
               age = Convert.ToInt32(Console.ReadLine());
            
            
            Console.Write("Enter Gender [M/F]: ");
            char gender = Convert.ToChar(Console.ReadLine().ToUpper());
            Console.Write("Enter Citizenship Status [SC/PR/Foreigner]: ");
            string citizenship = Console.ReadLine();
            using (StreamWriter file = new StreamWriter("patients(1).csv",true))
            {
                if (age <= 12)
                {
                    //if child is sc create patient child object with cdabalance
                    if (citizenship == "SC")
                    {
                        Console.Write("Enter Child Development Account Balance: ");
                        double balance = Convert.ToDouble(Console.ReadLine());
                        Patient c1 = new Child(Idn, name, age, gender, citizenship, "Registered", balance);
                        pList.Add(c1);
                        patientdeets = name + "," + Idn + "," + age + "," + gender + "," + citizenship + "," + balance;
                       
                    }
                    //if child is not SC , no cdabalance
                    else
                    {
                        Patient c1 = new Child(Idn, name, age, gender, citizenship, "Registered", 0);
                        pList.Add(c1);
                        patientdeets = name + "," + Idn + "," + age + "," + gender + "," + citizenship;
                       
                    }
                }
                else if (age < 64)
                {
                    if (citizenship == "SC" || citizenship == "PR")
                    {
                        Console.Write("Enter Medisave Balance: ");
                        double medisave = Convert.ToDouble(Console.ReadLine());
                        Patient a1 = new Adult(Idn, name, age, gender, citizenship, "Registered", medisave);
                        pList.Add(a1);
                        patientdeets = name + "," + Idn + "," + age + "," + gender + "," + citizenship + "," + medisave;
                        


                    }
                    else
                    {
                        Patient a1 = new Adult(Idn, name, age, gender, citizenship, "Registered", 0);
                        pList.Add(a1);


                        patientdeets = name + "," + Idn + "," + age + "," + gender + "," + citizenship;
                        
                    }
                }
                else
                {
                    Patient s1 = new Senior(Idn, name, age, gender, citizenship, "Registered");
                    pList.Add(s1);


                    patientdeets = name + "," + Idn + "," + age + "," + gender + "," + citizenship;
                    
                }
                file.WriteLine(patientdeets);
                Console.WriteLine("{0} is registered successfully", name);
                
            }
            }
            catch{
                Console.WriteLine("{0} is not registered successfully",name);
            }
        }
        static void Addnewbed(List<Bed> blist)
        {
            Console.Write("Enter Ward Type [A/B/C]: ");
            string wt = Console.ReadLine();
            Console.Write("Enter Ward No.: ");
            int wn = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Bed No.: ");
            int bn = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Daily Rate: $");
            double dr = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Available [Y/N]: ");
            string av = Console.ReadLine();

            if (wt == "A")
            {
                if (av == "Y")
                {
                    Bed cab = new ClassABed(wn, bn, dr, true);
                    blist.Add(cab);
                    Console.WriteLine("Bed added successfully.");
                }
                else if (av == "N")
                {
                    Bed cab = new ClassABed(wn, bn, dr, false);
                    blist.Add(cab);
                    Console.WriteLine("Bed added successfully.");
                }
            }
            if (wt == "B")
            {
                if (av == "Y")
                {
                    Bed cab = new ClassBBed(wn, bn, dr, true);
                    blist.Add(cab);
                    Console.WriteLine("Bed added successfully.");
                }
                else if (av == "N")
                {
                    Bed cab = new ClassBBed(wn, bn, dr, false);
                    blist.Add(cab);
                    Console.WriteLine("Bed added successfully.");
                }
            }
            if (wt == "C")
            {
                if (av == "Y")
                {
                    Bed cab = new ClassCBed(wn, bn, dr, true);
                    blist.Add(cab);
                    Console.WriteLine("Bed added successfully.");
                }
                else if (av == "N")
                {
                    Bed cab = new ClassCBed(wn, bn, dr, false);
                    blist.Add(cab);
                    Console.WriteLine("Bed added successfully.");
                }
            }

        }
        static void retrievePatient(List<Patient> pList,List<Bed>bList)
        {
            string wardClass = "";
            DisplayPatients(pList);
            Console.Write("Enter patient ID Number: ");
            string id = Console.ReadLine();
            foreach (Patient p in pList)
            {
                

                if (p.Id == id)
                {
                    Console.WriteLine("\nName of Patient: {0}\nID number: {1}\nCitizenship Status: {2}\nGender: {3}\nStatus: {4}", p.Name, p.Id, p.CitizenStatus, p.Gender, p.Status);
                    Console.WriteLine("Admission Date: {0}\nDischarge Date: {1}\nPayment Status: {2}",p.Stay.AdmittedDate,p.Stay.DischargedDate,p.Stay.IsPaid);
                    Console.WriteLine("======");

                    foreach (BedStay bs in p.Stay.BedstayList)
                    {
                        if(bs.Bed is ClassABed)
                        {
                            wardClass = "A";
                        }
                        else if(bs.Bed is ClassBBed)
                        {
                            wardClass = "B";
                        }
                        else
                        {
                            wardClass = "C";
                        }
                        Console.WriteLine("Ward Number: {0}\nBed Number: {1}\nWard Class: {2}\nStart of Bed Stay: {3}\nEnd of Bed Stay: {4}", bs.Bed.WardNo, bs.Bed.BedNo, wardClass, bs.StartBedstay, bs.EndBedstay);




                    }
                    break;
                }
                else
                    Console.WriteLine("Patient Not Found, Please try again...");
                
            }
        }
      
        static void RegisterHospitalStay(List<Patient> pList, List<Bed> bList)
        {
            DisplayPatientsRetrieve(pList);
      
            Console.Write("Enter patient ID number: ");
            string Patientid = Console.ReadLine();
         

            DisplayBeds(bList);
            Console.Write("\nSelect bed to stay: ");
            int bednum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Date of Admission (DD/MM/YYYY): ");
            DateTime Dates = Convert.ToDateTime(Console.ReadLine());
          
           
            BedStay newbedStay = new BedStay();
            Bed b = bList[bednum - 1];

            if (b.Available != false)
            {

                if (b is ClassABed)
                {
                    ClassABed bl = (ClassABed)b;
                    Console.Write("Any accompanying guest?(Additional $100 per day)[Y/N]: ");
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == "Y")
                    {
                        bl.AccompanyingPerson = true;
                        newbedStay = new BedStay(Dates, bl);

                    }
                    else if (answer == "N")
                    {
                        bl.AccompanyingPerson = false;
                        newbedStay = new BedStay(Dates, bl);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input, Please Try again...");

                    }

                }
                else if (b is ClassBBed)
                {
                    ClassBBed bb = (ClassBBed)b;
                    Console.Write("Is AirCon needed? [Y/N]: ");
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "Y")
                    {
                        bb.AirCon = true;
                        newbedStay = new BedStay(Dates, bb);

                    }
                    else if (answer == "N")
                    {
                        bb.AirCon = false;
                        newbedStay = new BedStay(Dates, bb);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input, Please Try again...");

                    }
                }
                else
                {
                    ClassCBed bc = (ClassCBed)b;
                    Console.Write("Is a portable TV required? [Y/N]: ");
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "Y")
                    {
                        bc.PortableTv = true;
                        newbedStay = new BedStay(Dates, bc);

                    }
                    else if (answer == "N")
                    {
                        bc.PortableTv = false;
                        newbedStay = new BedStay(Dates, bc);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input, Please Try again...");

                    }
                }
                foreach (Patient p in pList)
                {
                    if (p.Id == Patientid)
                    {

                        Stay NewStay = new Stay(Dates,p);

                        NewStay.AddBedstay(newbedStay);
                        p.Stay = NewStay;
                        p.Status = "Admitted";
                        Console.WriteLine("Testing: Patient {0}", p.Stay.AdmittedDate);

                    }
                }
                Console.WriteLine("\n\nStay registration successful!\n");

            }
            else
            {
                Console.WriteLine("Bed does not exist..");
                Console.WriteLine("Stay registration unsucessful\n");
            }
        }
          
        
    }
}

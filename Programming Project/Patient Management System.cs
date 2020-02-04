//============================================================
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
            InitData(patientsList, bedsList);
            //create object for medical record
            List<Stay> stayList = new List<Stay>();

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
                    List<Patient> nonadmittedList = new List<Patient>();
                    AddNonAdmitted(patientsList, nonadmittedList);
                    RegisterHospitalStay(patientsList,nonadmittedList, bedsList);

                 
                }
                else if (i.Equals("6"))
                {
                    Console.WriteLine("Option 6. Retrieve Patient");
                }
                else if (i.Equals("7"))
                {
                    Console.WriteLine("Option 7. Add Medical Record Entry");
                    DisplayPatients(patientsList);
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
                            MedicalRecord mr = new MedicalRecord(pob,ptm,DateTime.Now);
                            p.Stay.AddMedicalRecord(mr);
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
                else if (i.Equals("8"))
                {
                    Console.WriteLine("Option 8. View medical records");
                    DisplayPatients(patientsList);
                    Console.Write("Enter patient ID number: ");
                    string pid = Console.ReadLine();
                    foreach (Patient p in patientsList)
                    {
                        if (p.Id == pid)
                        {
                            Console.WriteLine("Name of patient: {0}", p.Name);
                            Console.WriteLine("ID number: {0}", p.Id);
                            Console.WriteLine("Citizenship status: {0}", p.CitizenStatus);
                            Console.WriteLine("Gender: {0}", p.Gender);
                            Console.WriteLine("Status: {0}", p.Status);
                            Console.WriteLine("\n======Stay======");
                            Console.WriteLine("Admission Date: {0}",/*p.Stay.AdmittedDate*/DateTime.Now);
                            Console.WriteLine("Admission Date: {0}", /*p.Stay.DischargedDate*/DateTime.Now);
                            Console.WriteLine("\n======Record # 1======");
                            Console.WriteLine("Temperature: ", stayList[1]);
                            Console.WriteLine("Temperature: ", stayList[0]);
                            Console.WriteLine("Diagnosis: ", stayList[2]);
                        }
                        else
                        {
                            Console.WriteLine("Error, Patient not found, please try again");
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

            string[] sents = File.ReadAllLines("beds.csv");

            for (int l = 1; l < sents.Length; l++)
            {
                string[] sbed = sents[l].Split(',');
                if (sbed[0] == "A")
                {
                    Bed cab = new ClassABed(Convert.ToInt32(sbed[1]), Convert.ToInt32(sbed[2]), Convert.ToDouble(sbed[4]), true, false);
                    bList.Add(cab);
                }
                else if (sbed[0] == "B")
                {
                    Bed cbb = new ClassBBed(Convert.ToInt32(sbed[1]), Convert.ToInt32(sbed[2]), Convert.ToDouble(sbed[4]), true, false);
                    bList.Add(cbb);
                }
                else if (sbed[0] == "C")
                {
                    Bed ccb = new ClassCBed(Convert.ToInt32(sbed[1]), Convert.ToInt32(sbed[2]), Convert.ToDouble(sbed[4]), true, false);
                    bList.Add(ccb);
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
                    Bed cab = new ClassABed(wn, bn, dr, true, false);
                    blist.Add(cab);
                    Console.WriteLine("Bed added successfully.");
                }
                else if (av == "N")
                {
                    Bed cab = new ClassABed(wn, bn, dr, false, false);
                    blist.Add(cab);
                    Console.WriteLine("Bed added successfully.");
                }
            }
            if (wt == "B")
            {
                if (av == "Y")
                {
                    Bed cab = new ClassBBed(wn, bn, dr, true, false);
                    blist.Add(cab);
                    Console.WriteLine("Bed added successfully.");
                }
                else if (av == "N")
                {
                    Bed cab = new ClassBBed(wn, bn, dr, false, false);
                    blist.Add(cab);
                    Console.WriteLine("Bed added successfully.");
                }
            }
            if (wt == "C")
            {
                if (av == "Y")
                {
                    Bed cab = new ClassCBed(wn, bn, dr, true, false);
                    blist.Add(cab);
                    Console.WriteLine("Bed added successfully.");
                }
                else if (av == "N")
                {
                    Bed cab = new ClassCBed(wn, bn, dr, false, false);
                    blist.Add(cab);
                    Console.WriteLine("Bed added successfully.");
                }
            }

        }
        //static Patient retrievePatient(List<Patient>pList, Stay obj,  )
        //{
        //    DisplayPatients(pList);
        //    Console.Write("Enter patient ID Number: ");
        //    string id = Console.ReadLine();
        //    foreach(Patient p in pList)
        //    {
        //        if (p.Id == id)
        //        {
        //            Console.WriteLine("\nName of Patient: {0}\nID number{1}\nCitizenship Status: {2}\nGender: {3}\nStatus: ", p.Name, p.Id, p.CitizenStatus, p.Gender, p.Status);
        //            Console.WriteLine("Admission Date: {0}\nDischarge Date: {1}\nPayment Status: {2}", obj.AdmittedDate, obj.DischargedDate, obj.IsPaid);
        //            Console.WriteLine("======");
        //            Console.WriteLine("Ward Number: {0}\nBed Number: {1}\nWard Class: {2}\nStart of Bed Stay: {3}\nEnd of Bed Stay: {4}",)
        //        }
        //        else
        //            Console.WriteLine("Patient Not Found, Please try again...");
        //        continue;
        //    }
        //}
        static Patient searchPatient(List<Patient> pList, string Patientid)
        {
            foreach (Patient p in pList)
            {
                if (p.Id == Patientid)
                {
                    return p;
                }


            }
            Console.WriteLine("Patient does not exist, please enter the correct patient number.");
            return null;

        }
        static Patient retrievePatient(List<Patient> pList, string Patientid)
        {
            foreach (Patient p in pList)
            {
                if (p.Id == Patientid)
                {
                    return p;
                }


            }
            Console.WriteLine("Patient does not exist, please enter the correct patient number.");
            return null;

        }
        static void AddNonAdmitted(List<Patient>pList,List<Patient>nList)
        {
            foreach (Patient i in pList)
            {
                if (i.Status != "Admitted")
                {
                    
                    nList.Add(i);
                    
                }
                
            }
        }
        static void RegisterHospitalStay(List<Patient>pList, List<Patient>nList , List<Bed>bList)
        {
            DisplayPatients(nList);
            Console.Write("Enter patient ID number: ");
            string Patientid = Console.ReadLine();
            // loop through the list and see if there a match
            
            searchPatient(nList, Patientid);
            DisplayBeds(bList);
            Stay NewStay = new Stay();
            Console.Write("\nSelect bed to stay: ");
            int bednum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Date of Admission (DD/MM/YYYY): ");
            string Date = Console.ReadLine();
            string[] cal = Date.Split('/');
            DateTime Dates = new DateTime(Convert.ToInt32(cal[2]), Convert.ToInt32(cal[1]), Convert.ToInt32(cal[0]));
            BedStay newbedStay = new BedStay();
            for (int b = 0;b<bList.Count;b++)
            {
                if (bednum - 1 == b)
                {
                    if (bList[b].Available != false)
                    {

                        if (bList[b] is ClassABed)
                        {
                            ClassABed bl = (ClassABed)bList[b];
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
                                Console.WriteLine("Incorrect Input, Please Try again...");
                        }
                        else if (bList[b] is ClassBBed)
                        {
                            ClassBBed bb = (ClassBBed)bList[b];
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
                            ClassCBed bc = (ClassCBed)bList[b];
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
                        foreach (Patient n in nList)
                        {
                            if (n.Id == Patientid)
                            {

                                NewStay = new Stay();

                                NewStay.AddBedstay(newbedStay);
                                n.Status = "Admitted";

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
    
}

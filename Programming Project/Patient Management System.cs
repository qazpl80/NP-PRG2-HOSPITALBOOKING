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
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

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
                    DisplayPatientsM(patientsList);
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
                            DisplayMedicalRecord(p);
                            break;
                        }
                    }
                }
                else if (i.Equals("9"))
                {
                    Console.WriteLine("Option 9.Transfer Patient to Another Bed");
                    TransferPatient(patientsList, bedsList);
                }
                else if (i.Equals("10"))
                {
                    Console.WriteLine("Option 10. Discharge and payment");
                    DisplayPatientsM(patientsList);
                    Dischargepayment(patientsList);
                }
                else if (i.Equals("11"))
                {
                    Console.WriteLine("Option 11. Display currencies exchange rate");
                    Currency();
                }
                else if (i.Equals("12"))
                {
                    Console.WriteLine("Option 12. Display PM 2.5 information");
                    //ADVANCE FEATURES
                    APIPM();
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
            Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", "No", "Ward Type", "Ward No", "Bed No", "Availability", "Daily Rate");
            int count = 1;
            foreach (Bed b in bedsList)
            {
                if (b is ClassABed)
                {
                    ClassABed cab = (ClassABed)b;
                    Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", count, "A", cab.WardNo, cab.BedNo, cab.Available, cab.DailyRate);
                }
                else if (b is ClassBBed)
                {
                    ClassBBed cbb = (ClassBBed)b;
                    Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", count, "B", cbb.WardNo, cbb.BedNo, cbb.Available, cbb.DailyRate);
                }
                else if (b is ClassCBed)
                {
                    ClassCBed ccb = (ClassCBed)b;
                    Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", count, "C", ccb.WardNo, ccb.BedNo, ccb.Available, ccb.DailyRate);
                }
                else
                {
                    Console.WriteLine("Bed not found");
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
        }
        static void DisplayPatientsRetrieve(List<Patient> pList)
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

        static void InitData(List<Patient> pList, List<Bed> bList)
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
            try
            {
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
            catch
            {
                Console.WriteLine("Unable to Read File/File does not exist");
            }
        }
        static void AddMedicalRecord(List<Patient> patientsList)
        {
            try
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
                        p.Stay = st;
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
            catch
            {
                Console.WriteLine("Invalid Input. Please try again.");
            }
        }
        static void DisplayMedicalRecord(Patient p)
        {
            try
            {
                Console.WriteLine("Name of patient: {0}", p.Name);
                Console.WriteLine("ID number: {0}", p.Id);
                Console.WriteLine("Citizenship status: {0}", p.CitizenStatus);
                Console.WriteLine("Gender: {0}", p.Gender);
                Console.WriteLine("Status: {0}", p.Status);
                Console.WriteLine("\n======Stay ======");
                Console.WriteLine("Admission Date: {0}", p.Stay.AdmittedDate.ToString("dd/MM/yyyy"));
                Console.WriteLine("Discharge Date: {0}", p.Stay.DischargedDate);
                int counter = 1;
                foreach (MedicalRecord mr in p.Stay.MedicalRecordList)
                {
                    Console.WriteLine("\n======Record # {0}======", counter);
                    Console.WriteLine("Date/Time: {0}", mr.DatetimeEntered);
                    Console.WriteLine("Temperature: {0}", mr.Temperature);
                    Console.WriteLine("Diagnosis: {0}", mr.Diagnosis);
                    counter++;
                }
            }
            catch
            {
                Console.WriteLine("Unable to Display Medical Record for Patient");
            }
        }
        static void Dischargepayment(List<Patient> patientsList)
        {
            try
            {
                Console.Write("Enter patient ID number: ");
                string pid = Console.ReadLine();
                Console.Write("Date of discharge (DD/MM/YYYY): ");
                string dod1 = Console.ReadLine();
                DateTime dod = Convert.ToDateTime(dod1);
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
                        p.Stay.DischargedDate = dod;
                        p.Stay.IsPaid = false;
                        int count = 1;
                        foreach (BedStay bs in p.Stay.BedstayList)
                        {
                            int daysDiff = ((TimeSpan)(bs.EndBedstay - bs.StartBedstay)).Days;
                            Console.WriteLine("\n======Bed # {0} ======", count);
                            Console.WriteLine("Ward number: {0}", bs.Bed.WardNo);
                            Console.WriteLine("Bed number: {0}", bs.Bed.BedNo);
                            Console.WriteLine("Ward Class: {0}", "A");
                            //Console.WriteLine("Start of bed stay: {0}", bs.StartBedstay);
                            //Console.WriteLine("End of bed stay: {0}", bs.EndBedstay);
                            if (bs.Bed is ClassABed)
                            {
                                ClassABed cab = (ClassABed)bs.Bed;
                                Console.WriteLine("Accompanying Person: ", cab.AccompanyingPerson);
                                bs.Bed.CalculateCharges(p.CitizenStatus, daysDiff);
                            }
                            else if (bs.Bed is ClassBBed)
                            {
                                ClassBBed cbb = (ClassBBed)bs.Bed;
                                Console.WriteLine("AirCon: ", cbb.AirCon);
                                bs.Bed.CalculateCharges(p.CitizenStatus, daysDiff);
                            }
                            else if (bs.Bed is ClassCBed)
                            {
                                ClassCBed ccb = (ClassCBed)bs.Bed;
                                Console.WriteLine("Avaliable: ", ccb.Available);
                                bs.Bed.CalculateCharges(p.CitizenStatus, daysDiff);
                            }
                            Console.WriteLine("Number of days stayed: ", daysDiff);
                            count++;
                        }
                        Console.WriteLine("[Press any key to proceed with payment]");
                        Console.ReadKey();
                        Console.WriteLine("\nCommencing payment...\n");
                        if (p is Child)
                        {
                            Child ch = (Child)p;
                            Console.WriteLine("{0} has been deducted from CDA",ch.CdaBalance);
                            double chcost = ch.CalculateCharges();
                            if (ch.CdaBalance > chcost)
                            {
                                ch.CdaBalance -= chcost;
                                chcost = 0;
                                Console.WriteLine("New CDA balance: ${0}", ch.CdaBalance);
                                Console.WriteLine("Sub-total: ${0} has been paid by cash", chcost);
                                Console.WriteLine("Payment Successful!");
                                p.Stay.IsPaid = true;
                            }
                            else if (ch.CdaBalance < chcost)
                            {
                                chcost -= ch.CdaBalance;
                                ch.CdaBalance = 0;
                                Console.WriteLine("New CDA balance: ${0}", ch.CdaBalance);
                                Console.WriteLine("Sub-total: ${0} has been paid by cash", chcost);
                                Console.WriteLine("Payment Successful!");
                                p.Stay.IsPaid = true;
                            }
                            else if (ch.CdaBalance == chcost)
                            {
                                chcost = 0;
                                ch.CdaBalance = 0;
                                Console.WriteLine("New CDA balance: ${0}", ch.CdaBalance);
                                Console.WriteLine("Sub-total: ${0} has been paid by cash", chcost);
                                Console.WriteLine("Payment Successful!");
                                p.Stay.IsPaid = true;
                            }
                            else
                            {
                                Console.WriteLine("Error in calculating Balance");
                            }
                        }
                        else if (p is Adult)
                        {
                            Adult ad = (Adult)p;
                            Console.WriteLine("{0} has been deducted from Medisave", ad.MedisaveBalance);
                            double adcost = ad.CalculateCharges();
                            if (ad.MedisaveBalance > adcost)
                            {
                                ad.MedisaveBalance -= adcost;
                                adcost = 0;
                                Console.WriteLine("New CDA balance: ${0}", ad.MedisaveBalance);
                                Console.WriteLine("Sub-total: ${0} has been paid by cash", adcost);
                                Console.WriteLine("Payment Successful!");
                                p.Stay.IsPaid = true;
                            }
                            else if (ad.MedisaveBalance < adcost)
                            {
                                adcost -= ad.MedisaveBalance;
                                ad.MedisaveBalance = 0;
                                Console.WriteLine("New CDA balance: ${0}", ad.MedisaveBalance);
                                Console.WriteLine("Sub-total: ${0} has been paid by cash", adcost);
                                Console.WriteLine("Payment Successful!");
                                p.Stay.IsPaid = true;
                            }
                            else if (ad.MedisaveBalance == adcost)
                            {
                                adcost = 0;
                                ad.MedisaveBalance = 0;
                                Console.WriteLine("New CDA balance: ${0}", ad.MedisaveBalance);
                                Console.WriteLine("Sub-total: ${0} has been paid by cash", adcost);
                                Console.WriteLine("Payment Successful!");
                                p.Stay.IsPaid = true;
                            }
                            else
                            {
                                Console.WriteLine("Error in calculating Balance");
                            }
                        }
                        else if (p is Senior)
                        {
                            Senior sn = (Senior)p;
                            Console.WriteLine("Total Cost has been reduced by half");
                            double sncost = sn.CalculateCharges();
                            Console.WriteLine("Sub-total: ${0} has been paid by cash", sncost);
                            Console.WriteLine("Payment Successful!");
                            p.Stay.IsPaid = true;
                        }
                        else
                        {
                            Console.WriteLine("Error in Patient (Child/Adult/Senior) Class");
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Unable to Discharge or Settle payments");
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
                using (StreamWriter file = new StreamWriter("patients(1).csv", true))
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
            catch
            {
                Console.WriteLine("{0} is not registered successfully", name);
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
        static void retrievePatient(List<Patient> pList, List<Bed> bList)
        {
            string wardClass = "";
            DisplayPatients(pList);
            Console.Write("Enter patient ID Number: ");
            string id = Console.ReadLine();
            foreach (Patient p in pList)
            {
                if (p.Id == id)
                {
                    string pay = "";
                    Console.WriteLine("\nName of Patient: {0}\nID number: {1}\nCitizenship Status: {2}\nGender: {3}\nStatus: {4}", p.Name, p.Id, p.CitizenStatus, p.Gender, p.Status);
                    if (p.Stay.IsPaid == false)
                    {
                        pay = "Unpaid";
                    }
                    else
                    {
                        pay = "Paid";
                    }
                    Console.WriteLine("Admission Date: {0}\nDischarge Date: {1}\nPayment Status: {2}", p.Stay.AdmittedDate.ToString("dd/MM/yyyy"), p.Stay.DischargedDate, pay);
                    Console.WriteLine("======");

                    foreach (BedStay bs in p.Stay.BedstayList)
                    {
                        if (bs.Bed is ClassABed)
                        {
                            wardClass = "A";
                        }
                        else if (bs.Bed is ClassBBed)
                        {
                            wardClass = "B";
                        }
                        else
                        {
                            wardClass = "C";
                        }
                        Console.WriteLine("Ward Number: {0}\nBed Number: {1}\nWard Class: {2}\nStart of Bed Stay: {3}\nEnd of Bed Stay: {4}", bs.Bed.WardNo, bs.Bed.BedNo, wardClass, bs.StartBedstay.ToString("dd/MM/yyyy"), bs.EndBedstay);
                    }
                }
                break;
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
            string d = Console.ReadLine();
            string[] d2 = d.Split('/');
            DateTime Dates = new DateTime(Convert.ToInt32(d2[2]), Convert.ToInt32(d2[1]), Convert.ToInt32(d2[0]));

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
                        Stay NewStay = new Stay(Dates, p);
                        NewStay.AddBedstay(newbedStay);
                        p.Stay = NewStay;
                        p.Status = "Admitted";

                    }
                }
                b.Available = false;
                Console.WriteLine("\n\nStay registration successful!\n");

            }
            else
            {
                Console.WriteLine("Bed does not exist.  .");
                Console.WriteLine("Stay registration unsucessful\n");
            }
        }

        static void TransferPatient(List<Patient> pList, List<Bed> bList)
        {
            DisplayPatientsM(pList);
            Console.Write("Enter patientID number: ");
            string p_ID = Console.ReadLine();
            DisplayBeds(bList);
            Console.Write("Select bed to transfer: ");
            int num = Convert.ToInt32(Console.ReadLine());
            BedStay bedStay = new BedStay();
            Console.Write("Date of Transfer (DD/MM/YYYY): ");
            string d = Console.ReadLine();
            string[] d2 = d.Split('/');
            DateTime Transfer = new DateTime(Convert.ToInt32(d2[2]), Convert.ToInt32(d2[1]), Convert.ToInt32(d2[0]));
            Bed N = bList[num - 1];
            if (N.Available != false)
            {
                if (N is ClassABed)
                {
                    ClassABed ba = (ClassABed)N;
                    Console.Write("Any accompanying guest?(Additional $100 per day)[Y/N]: ");
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == "Y")
                    {
                        ba.AccompanyingPerson = true;
                        bedStay = new BedStay(Transfer, ba);

                    }
                    else if (answer == "N")
                    {
                        ba.AccompanyingPerson = false;
                        bedStay = new BedStay(Transfer, ba);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input, Please Try again...");

                    }
                }
                else if (N is ClassBBed)
                {
                    ClassBBed bb = (ClassBBed)N;
                    Console.Write("Is AirCon needed (Additional $50 per week)? [Y/N]: ");
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "Y")
                    {
                        bb.AirCon = true;
                        bedStay = new BedStay(Transfer, bb);

                    }
                    else if (answer == "N")
                    {
                        bb.AirCon = false;
                        bedStay = new BedStay(Transfer, bb);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input, Please Try again...");

                    }
                }
                else
                {
                    ClassCBed bc = (ClassCBed)N;
                    Console.Write("Is a portable TV required (Additional $30 one time cost) [Y/N]: ");
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "Y")
                    {
                        bc.PortableTv = true;
                        bedStay = new BedStay(Transfer, bc);

                    }
                    else if (answer == "N")
                    {
                        bc.PortableTv = false;
                        bedStay = new BedStay(Transfer, bc);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input, Please Try again...");

                    }
                }
                foreach (Patient p in pList)
                {
                    if (p.Id == p_ID)
                    {
                        p.Stay.BedstayList[p.Stay.BedstayList.Count - 1].EndBedstay = Transfer;
                        p.Stay.BedstayList[p.Stay.BedstayList.Count - 1].Bed.Available = true;
                        Console.WriteLine("{0} will be transferred to Ward {1} Bed {2} on {3}", p.Name, N.WardNo, N.BedNo, Transfer.ToString("dd/MM/yyyy"));
                        p.Stay.AddBedstay(bedStay);
                    }
                }
                N.Available = false;

            }
        }

        static void APIPM()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.data.gov.sg");
                Task<HttpResponseMessage> responseTask = client.GetAsync("/v1/environment/pm25");
                responseTask.Wait();
                HttpResponseMessage result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    string data = readTask.Result;
                    RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(data);
                    Item item = rootObject.items[0];
                    Console.WriteLine("\n============================3.2 Display the PM 2.5 information=================================\n");
                    Console.WriteLine("Timestamp: " + item.timestamp + "\n");
                    Console.WriteLine("West: " + item.readings.pm25_one_hourly.west);
                    Console.WriteLine("East: " + item.readings.pm25_one_hourly.east);
                    Console.WriteLine("Central: " + item.readings.pm25_one_hourly.central);
                    Console.WriteLine("North: " + item.readings.pm25_one_hourly.north);
                    Console.WriteLine("South: " + item.readings.pm25_one_hourly.south);


                }
            }
        }
        static void Currency()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.exchangerate-api.com/");
                //HTTP GET
                Task<HttpResponseMessage> responseTask = client.GetAsync("/v1/latest/SGD");
                responseTask.Wait();
                HttpResponseMessage result = responseTask.Result;
                //if successful, read string and print
                if (result.IsSuccessStatusCode)
                {
                    Task<string> readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    string info = readTask.Result;
                   

                    // header
                    Console.WriteLine("\n============================3.1 Display currencies exchange rate=================================\n");
                    Console.WriteLine("Base: Singaporea Dollars(SGD)");
                    //Console.WriteLine("Date: ",objectt)

                }


            }
        }

    }
}
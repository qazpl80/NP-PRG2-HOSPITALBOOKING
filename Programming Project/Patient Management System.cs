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
            List<Patient> nonadmittedList = new List<Patient>();
            //Create list to store beds


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
                }
                else if (i.Equals("3"))
                {
                    Console.WriteLine("Option 3. Register Patient");
                    RegisterPatient(patientsList);

                }
                else if (i.Equals("4"))
                {
                    Console.WriteLine("Option 4. Add new bed");
                }
                else if (i.Equals("5"))
                {
                    Console.WriteLine("Option 5. Register hospital stay");
                    foreach (Patient p in patientsList)
                    {

                        if (p.Status != "admitted")
                        {
                            nonadmittedList.Add(p);
                        }
                    }
                    DisplayPatients(nonadmittedList);
                }
                else if (i.Equals("6"))
                {
                    Console.WriteLine("Option 6. Retrieve Patient");
                }
                else if (i.Equals("7"))
                {
                    Console.WriteLine("Option 7. Add Medical Record Entry");
                }
                else if (i.Equals("8"))
                {
                    Console.WriteLine("Option 8. View medical records");
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
        //Intialize data
        static void InitDate(List<Patient> pList, List<Bed>bList)
        {
            
        }
        //display patients
        static void DisplayPatients(List<Patient> pList)
        {

            //read lines from patients.csv
           



            Console.WriteLine("{0,-10}{1,-15}{2,-10}{3,-10}{4,-15}{5,-15}", "Name", "ID No.", "Age", "Gender", "Citizenship", "Status");
            foreach(Patient p in pList)
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
        static void RegisterHospitalStay(List<Patient>nList , List<Bed>bList){
            Console.Write("Enter patient ID number: ");
            string Patientid = Console.ReadLine();
            
            

                // loop through the list and see if there a match
            foreach (Patient p in nList)
             {
                    if (p.Id == Patientid)
                    {
                        return Patient p;
                    }

             }
                

            



        }
    }
    
}

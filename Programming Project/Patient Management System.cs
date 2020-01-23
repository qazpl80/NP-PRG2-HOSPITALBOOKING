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
    class Patient_Management_System
    {
        static void Main(string[] args)
        {
            DisplayMenu();
            Console.Write("Enter your option: ");
            int i = Convert.ToInt32(Console.ReadLine());
            while (i != 0)
            {
                if (i == 1)
                {

                }
                if (i == 2)
                {

                }
                if (i == 3)
                {

                }
                if (i == 4)
                {

                }
                if (i == 5)
                {

                }
                if (i == 6)
                {

                }
                if (i == 7)
                {

                }
                if (i == 8)
                {

                }
                if (i == 9)
                {

                }
                if (i == 10)
                {

                }
                if (i == 11)
                {

                }
                if (i == 12)
                {

                }
                else
                {

                }
            }
        }
        static void DisplayMenu()
        {
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
        }
    }
}

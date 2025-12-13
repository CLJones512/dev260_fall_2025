// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata;
using FinalProject;

namespace FinalProject
{
    class Program
    {
        public static bool isRunning = true;
        static JuryManagement juryManagement = new JuryManagement();
        static void Main(string[] args)
        {
                juryManagement.populateJurorDictionary();

                while(isRunning)
            {
                DisplayMenu();
                string input = Console.ReadLine();
                HandleInput(input);
            }
        }
        private static void DisplayMenu()
        {
            Console.WriteLine("┌─ Jury Management System ────────────────────────────────────────┐");
            Console.WriteLine("│ 1. Add Juror       │ 2. Search by ID  │ 3. Delete Juror         │");
            Console.WriteLine("│ 4. Undo Deletion   │ 5. Summon Jurors │ 6. Print List of Jurors │");
            Console.WriteLine("│ 7. Exit                                                         │");
            Console.WriteLine("└─────────────────────────────────────────────────────────────────┘");
        }

        private static void HandleInput(string input)
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return;

            string command = parts[0].ToLower();
            string[] args = parts.Skip(1).ToArray();
            
            switch(command)
            {
                case "1":
                case "add":
                    HandleAddJuror();
                    break;
                case "2":
                case "search":
                    HandleSearch();
                    break;
                case "3":
                case "delete":
                    HandleDeletion();
                    break;
                case "4":
                case "undo":
                    HandleUndo();
                    break;
                case "5":
                case "summon":
                    HandleSummons();
                    break;
                case "6":
                case "print":
                    HandlePrint();
                    break;
                case "7":
                case "exit":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
        static void HandleAddJuror()
        {
            bool isYearValid = false;
            bool isMonthValid = false;
            bool isDayValid = false;
            int year = 0;
            int month = 0;
            int day = 0;

            Console.WriteLine("\n=== Testing AddJuror() ===");
            Console.WriteLine("Enter The Juror's Full Name");
            string? fullName = Console.ReadLine();
            while(!isYearValid)
            {
                Console.WriteLine("Enter the Year the juror will be serving (Four digits)");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                    isYearValid = true;
                }
                catch(InvalidCastException)
                {
                    Console.WriteLine("Invalid year, please try again");
                }
                
            }
            while(!isMonthValid)
            {
                Console.WriteLine("Enter the Month the juror will be serving (Numbers 1-12)");
                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if(month >=1 && month <= 12)
                    {
                        isMonthValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid month, please try again");
                    }
                }
                catch(InvalidCastException)
                {
                    Console.WriteLine("Invalid month, please try again");
                }
            }

            while(!isDayValid)
            {
                Console.WriteLine("Enter the Date the juror will be serving (1-31)");
                try
                {
                    day = Convert.ToInt32(Console.ReadLine());
                    if(day >= 1 && day <= 31)
                    {
                        isDayValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid day, please try again");
                    }
                }
                catch(InvalidCastException)
                {
                    Console.WriteLine("Invalid day, please try again");
                }
            }
            DateTime summonsDate = new DateTime(year, month, day);
            Juror juror = new Juror(fullName, summonsDate);
            juryManagement.addJuror(juror);
        }
        static void HandleSearch()
        {
            int jurorID = 0;
            bool isJurorValid = false;
            Console.WriteLine("===Testing Search Function===");
            Console.WriteLine("Enter the ID of the juror you wish to search for");
            while(!isJurorValid)
            {
                try
                    {
                        jurorID = Convert.ToInt32(Console.ReadLine());
                        isJurorValid = true;
                    }
                    catch(InvalidCastException)
                    {
                        Console.WriteLine("Invalid Juror ID, please try again");
                    }
                    catch(NullReferenceException)
                    {
                        Console.WriteLine("Invalid JurorID, please try again");
                    }
            }
            Juror juror = juryManagement.searchById(jurorID);
            Console.WriteLine($"Juror Name: {juror.FullName}, Date Serving: {juror.SummonsDate:MMMM d yyyy}");
        }
        static void HandleDeletion()
        {
            int jurorID = 0;
            bool isJurorValid = false;
            Console.WriteLine("===Testing Delete Function===");
            Console.WriteLine("Enter the ID of the juror you wish to remove");
            while(!isJurorValid)
            {
                try
                    {
                        jurorID = Convert.ToInt32(Console.ReadLine());
                        isJurorValid = true;
                    }
                    catch(InvalidCastException)
                    {
                        Console.WriteLine("Invalid Juror ID, please try again");
                    }
            }
            juryManagement.DeleteJuror(jurorID);
        }
        static void HandleUndo()
        {
            bool isDeletionValid = juryManagement.UndoDelete();
            if(!isDeletionValid)
            {
                Console.WriteLine("Unable to undo");
            }
        }
        static void HandleSummons()
        {
            juryManagement.SummonJurors();
        }
        static void HandlePrint()
        {
            juryManagement.PrintDictionary();
        }
    }
}



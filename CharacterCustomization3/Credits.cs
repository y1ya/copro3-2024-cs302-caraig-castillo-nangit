using System;

namespace CharacterCreationSystem
{
    public class Credits
    {
        public void ShowCredits()
        {
            string space = "====";
            Console.Clear();
            Console.Write(space);   
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" CREDITS ");
            Console.ResetColor();
            Console.WriteLine(space);
            
            Console.Write($"\n{space}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" Group Members ");
            Console.ResetColor();
            Console.WriteLine(space);           

            Console.Write("Caraig, Emmanuel Joseph Balatucan - ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\"Pancit Canton, Documentationist, Programmerist\"");
            Console.ResetColor();

            Console.Write("Castillo, Harry - ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\"Pancit Canton, Documentationist, Programmerist\"");
            Console.ResetColor();

            Console.Write("Nangit, Mart Emmanuel - ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\"The Smurf, Documentationist, Programmerist\"");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nThank you for using the Character Creation System.");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress any key to return to the Main Menu...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}

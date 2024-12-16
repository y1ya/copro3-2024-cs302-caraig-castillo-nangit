using System;

namespace CharacterCreationSystem
{
    public class Credits
    {
        public void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("===== CREDITS =====");
            Console.WriteLine("\n=== Group Members ===");
            Console.Write("Caraig, Emmanuel Joseph Balatucan - ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\"Pancit Canton\"");
            Console.ResetColor();
            Console.WriteLine("Castillo, Harry");
            Console.WriteLine("Nangit, Mart Emmanuel");
            Console.WriteLine("\nThank you for using the Character Creation System.");
            Console.WriteLine("\nPress any key to return to the Main Menu...");
            Console.ReadKey();
        }
    }
}

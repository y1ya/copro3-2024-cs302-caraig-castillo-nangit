using System;

namespace CharacterCreationSystem
{
    public class CharacterTitle
    {
        public string GetTitle()
        {
            Console.WriteLine("=== Character Title ===");
            Console.WriteLine("\nBased on your selections, here are the titles you can earn:");
            Console.WriteLine("(a) Crop Master");
            Console.WriteLine("(b) Animal Caretaker");
            Console.WriteLine("(c) Harvest Master");
            Console.WriteLine("(d) Trailblazer");
            Console.WriteLine("(e) Soil Engineer");

            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "a": return "Crop Master: A master cultivator recognized for unmatched efficiency in crop growth and harvesting.";
                case "b": return "Animal Caretaker: Renowned for extraordinary care of animals, ensuring their happiness and productivity.";
                case "c": return "Harvest Master: Celebrated for record-breaking harvests and agricultural prowess.";
                case "d": return "Trailblazer: A pioneering farmer exploring untapped opportunities in agriculture.";
                case "e": return "Soil Engineer: Known for optimizing soil conditions for maximum productivity.";
                default:
                    Console.WriteLine("Invalid choice.");
                    return GetTitle();
            }
        }
    }
}

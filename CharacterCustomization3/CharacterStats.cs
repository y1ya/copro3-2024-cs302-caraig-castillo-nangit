using System;

namespace CharacterCreationSystem
{
    public class CharacterStats
    {
        public string GetStats()
        {
            Console.WriteLine("=== Character Stats ===");
            Console.WriteLine("\nDistribute your character's stats (Max 7 per stat, total 10 points):");
            Console.WriteLine("Strength: [1-7]");
            Console.WriteLine("Luck: [1-7]");
            Console.WriteLine("Speed: [1-]");
            Console.WriteLine("Endurance: [1-7]");
            Console.WriteLine("Dexterity: [1-7]");
            Console.WriteLine("Intelligence: [1-7]");

            int totalPoints = 10;
            int strength = GetStatInput("Strength", totalPoints);
            totalPoints -= strength;

            int luck = GetStatInput("Luck", totalPoints);
            totalPoints -= luck;

            int speed = GetStatInput("Speed", totalPoints);
            totalPoints -= speed;

            int endurance = GetStatInput("Endurance", totalPoints);
            totalPoints -= endurance;

            int dexterity = GetStatInput("Dexterity", totalPoints);
            totalPoints -= dexterity;

            if (totalPoints > 0)
            {
                int intelligence = GetStatInput("Intelligence", totalPoints);
                totalPoints -= intelligence;
            }
            else
            {
                Console.WriteLine("You have already used all 10 points.");
            }

            if (totalPoints > 0)
            {
                Console.WriteLine($"You have {totalPoints} points left unused. Please allocate all 10 points.");
                return GetStats();
            }

            return $"\n{"Strength: ",-21}{strength}\n{"Luck: ",-21}{luck}\n{"Speed: ",-21}{speed}\n{"Endurance: ",-21}{endurance}\n{"Dexterity: ",-21}{dexterity}";
        }

        private int GetStatInput(string statName, int remainingPoints)
        {
            if (remainingPoints <= 0)
            {
                return 0;  
            }

            int statValue = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine($"\nAssign points to {statName} (Remaining Points: {remainingPoints}):");
                string input = Console.ReadLine();

                if (int.TryParse(input, out statValue) && statValue >= 1 && statValue <= 25 && statValue <= remainingPoints)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine($"Invalid input. You must assign between 1 and 10 points, and you have {remainingPoints} remaining.");
                }
            }

            return statValue;
        }
    }
}

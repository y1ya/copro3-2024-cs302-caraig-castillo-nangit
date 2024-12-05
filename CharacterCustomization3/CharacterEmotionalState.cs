using System;
namespace CharacterCreationSystem
{
    public class CharacterEmotionalState
    {
        public string GetEmotionalState()
        {
            int score = 0;
            Console.WriteLine("=== Character Emotional State ===");
            // Question 1
            Console.WriteLine("\nDo you prioritize planting crops that are sustainable and beneficial to the local environment? (Yes/No)");
            string response1 = Console.ReadLine().ToLower();
            if (response1 == "yes") score++;
            if (response1 == "no") score--;
            // Question 2
            Console.WriteLine("Do you take time to help NPCs (non-playable characters) with their requests or quests, even if it slows your farm progress? (Yes/No)");
            string response2 = Console.ReadLine().ToLower();
            if (response2 == "yes") score++;
            if (response2 == "no") score--;
            // Question 3
            Console.WriteLine("Do you hoard resources for personal gain instead of sharing them with struggling NPCs or friends in the game? (Yes/No)");
            string response3 = Console.ReadLine().ToLower();
            if (response3 == "yes") score--;
            if (response3 == "no") score++;
            // Question 4
            Console.WriteLine("Do you steal crops or items from neighboring farms or NPCs to get ahead? (Yes/No)");
            string response4 = Console.ReadLine().ToLower();
            if (response4 == "yes") score--;
            if (response4 == "no") score++;
            // Question 5
            Console.WriteLine("Do you prioritize planting rare, high-profit crops over those that the village needs to thrive? (Yes/No)");
            string response5 = Console.ReadLine().ToLower();
            if (response5 == "yes") score--;
            if (response5 == "no") score++;
            if (score >= 2)
                return "Good";
            else if (score <= -2)
                return "Evil";
            else
                return "Neutral";
        }
    }
}
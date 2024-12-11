using CharacterCustomization;
using System;

namespace CharacterCreationSystem
{
    public class CharacterEmotionalState : CheckForErrors
    {
        public string GetEmotionalState()
        {
            int score = 0;
            Console.WriteLine("\n=== Character Emotional State ===");

            // Question 1
            score += AskQuestion(
                "Do you prioritize planting crops that are sustainable and beneficial to the local environment? (Yes/No)",
                1, -1
            );

            // Question 2
            score += AskQuestion(
                "Do you take time to help NPCs (non-playable characters) with their requests or quests, even if it slows your farm progress? (Yes/No)",
                1, -1
            );

            // Question 3
            score += AskQuestion(
                "Do you hoard resources for personal gain instead of sharing them with struggling NPCs or friends in the game? (Yes/No)",
                -1, 1
            );

            // Question 4
            score += AskQuestion(
                "Do you steal crops or items from neighboring farms or NPCs to get ahead? (Yes/No)",
                -1, 1
            );

            // Question 5
            score += AskQuestion(
                "Do you prioritize planting rare, high-profit crops over those that the village needs to thrive? (Yes/No)",
                -1, 1
            );

            if (score >= 2)
                return "Good";
            else if (score <= -2)
                return "Evil";
            else
                return "Neutral";
        }

        private int AskQuestion(string question, int goodScore, int evilScore)
        {
            int result = 0;
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    Console.WriteLine(question);
                    string response = Console.ReadLine().ToLower();

                    if (response == "yes")
                    {
                        result = goodScore;
                        validInput = true;
                    }
                    else if (response == "no")
                    {
                        result = evilScore;
                        validInput = true;
                    }
                    else
                    {
                        throw new InvalidResponseException("Invalid response. Please answer with 'yes' or 'no'.");
                    }
                }
                catch (InvalidResponseException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error: " + ex.Message);
                }
            }
            return result;
        }
    }
}

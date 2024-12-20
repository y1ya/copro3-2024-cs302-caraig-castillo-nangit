﻿using CharacterCustomization;
using System;

namespace CharacterCreationSystem
{
    public class CharacterEmotionalState : CheckForErrors
    {
        public int score;
        public bool? EmotionalState;
        public void GetEmotionalState()
        {
            int score = 0;
            Console.WriteLine("\n=== Character Emotional State ===");

            // Question 1
            score += AskQuestion(
                "Do you prioritize planting crops that are sustainable and beneficial to the local environment? (a: Yes, b: No)",
                1, -1
            );

            // Question 2
            score += AskQuestion(
                "Do you take time to help NPCs (non-playable characters) with their requests or quests, even if it slows your farm progress? (a: Yes, b: No)",
                1, -1
            );

            // Question 3
            score += AskQuestion(
                "Do you hoard resources for personal gain instead of sharing them with struggling NPCs or friends in the game? (a: Yes, b: No)",
                -1, 1
            );

            // Question 4
            score += AskQuestion(
                "Do you steal crops or items from neighboring farms or NPCs to get ahead? (a: Yes, b: No)",
                -1, 1
            );

            // Question 5
            score += AskQuestion(
                "Do you prioritize planting rare, high-profit crops over those that the village needs to thrive? (a: Yes, b: No)",
                -1, 1
            );

            if (score >= 2)
            {                
                this.EmotionalState = true;
            }
            else if (score <= -2)
            {
                this.EmotionalState = false;
            }
            else
            {
                this.EmotionalState = null;
            }
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

                    if (response == "a")
                    {
                        result = goodScore;
                        validInput = true;
                    }
                    else if (response == "b")
                    {
                        result = evilScore;
                        validInput = true;
                    }
                    else
                    {
                        throw new InvalidResponseException("Invalid response. Please answer with 'a' for Yes or 'b' for No.");
                    }
                }
                catch (InvalidResponseException ex)
                {
                    Console.WriteLine("==Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("==Unexpected error: " + ex.Message);
                }
            }
            return result;
        }
    }
}

using System;
namespace CharacterCreationSystem
{
    public class MainMenu
    {
        public static void DisplayMainMenu()
        {
            string[] menuItems =
            {
                "NEW GAME",
                "LOAD GAME",
                "CAMPAIGN MODE",
                "CREDITS",
                "EXIT"
            };
            int selectedIndex = 0;
            ConsoleKey key;
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== Main Menu ===");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(">>> " + menuItems[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("" + menuItems[i]);
                    }
                }
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    if (selectedIndex == 0)
                    {
                        NewGame newGame = new NewGame();
                        newGame.CreateCharacter();
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.WriteLine("Load Game not implemented yet.");
                    }
                    else if (selectedIndex == 2)
                    {
                        CampaignMode campaignMode = new CampaignMode();
                        campaignMode.DisplayStory();
                    }
                    else if (selectedIndex == 3)
                    {
                        Credits credits = new Credits();
                        credits.ShowCredits();
                    }
                    else if (selectedIndex == 4)
                    {
                        Console.WriteLine("Exiting the program. Goodbye!");
                        Console.ReadKey();
                        isRunning = false;
                    }
                }
            }
        }
        public static void Main(string[] args)
        {
            DisplayMainMenu();
        }
    }
}
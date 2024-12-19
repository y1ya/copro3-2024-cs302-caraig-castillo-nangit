using System;
using System.Data.SqlClient;

namespace CharacterCreationSystem
{
    public class MainMenu
    {
        public static SqlConnection con;
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
                string space = "===";
                Console.Clear();
                Console.Write(space);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" Main Menu ");
                Console.ResetColor();
                Console.WriteLine(space);

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($">>> {menuItems[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {menuItems[i]}");
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
                        DisplayCharacters displayCharacters = new DisplayCharacters();
                        displayCharacters.LoadGameMenu();
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
                        Thread.Sleep(500);
                        isRunning = false;
                        Environment.Exit(0);
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            string databaseConnect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""C:\Users\Emmanuel\Downloads\CharacterCustomization3-master\CharacterCustomization3\Database\Characters.mdf"";Integrated Security=True;MultipleActiveResultSets=True";
            con = new SqlConnection(databaseConnect);

            try
            {
                //Console.WriteLine("Connecting to Database...");
                con.Open();
                //Console.WriteLine("Connected Successfully");
                DisplayMainMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }
    }
}


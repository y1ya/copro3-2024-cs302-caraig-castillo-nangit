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
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== Main Menu ===");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.WriteLine($"({(char)('a' + i)}) {menuItems[i]}");
                }

                Console.Write("Input: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "a":
                        Console.Clear();
                        NewGame newGame = new NewGame();
                        newGame.CreateCharacter();
                        break;
                    case "b":
                        Console.Clear();
                        Console.WriteLine("Load Game not implemented yet.");
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey();
                        break;
                    case "c":
                        Console.Clear();
                        CampaignMode campaignMode = new CampaignMode();
                        campaignMode.DisplayStory();
                        break;
                    case "d":
                        Console.Clear();
                        Credits credits = new Credits();
                        credits.ShowCredits();
                        break;
                    case "e":
                        Console.Clear();
                        Console.WriteLine("Exiting the program. Goodbye!");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void Main(string[] args)
        {
            string databaseConnect = @"Data Source=(localdb)\MSSQLLocalDB;
                Initial Catalog=""C:\Users\PC\source\repos\CharacterCustomization3\CharacterCustomization3\Database\Characters.mdf"";
                Integrated Security=True";
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

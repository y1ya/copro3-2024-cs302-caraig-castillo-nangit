using CharacterCustomization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationSystem
{
    public class DisplayCharacters
    {
        public void DisplayCharactersDatabase()
        {
            string query = "SELECT * FROM dbo.CharacterDetails ORDER BY Character_Number";

            try
            {
                if (MainMenu.con == null || MainMenu.con.State != System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Database connection is not established.");
                    return;
                }

                SqlCommand command = new SqlCommand(query, MainMenu.con);

                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Select a character to edit or delete:");
                Console.WriteLine("---------------------------------------------------");
                int counter = 1;

                while (reader.Read())
                {
                    Console.WriteLine($"" +
                        $"({counter})" +
                        $"\nID: \t\t{reader["Character_Id"]}" +
                        $"\nName: \t\t{reader["Character_Name"]}" +
                        $"\nAge: \t\t{reader["Character_Age"]}" +
                        $"\nGender: \t{reader["Character_Gender"]}" +
                        $"\nRace: \t\t{reader["Character_Race"]}" +
                        $"\nFarmer Type: \t{reader["Character_FarmerType"]}");
                    Console.WriteLine("---------------------------------------------------");
                    counter++;
                }
                reader.Close();

                Console.Write("Enter the row number to select: ");
                int selectedRow = int.Parse(Console.ReadLine());
                HandleRowSelection(selectedRow);
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        }

        private void HandleRowSelection(int selectedRow)
        {
            while (true)
            {
                try
                {
                    string query = $"SELECT * FROM dbo.CharacterDetails ORDER BY Character_Number OFFSET {selectedRow - 1} ROWS FETCH NEXT 1 ROWS ONLY";
                    SqlCommand command = new SqlCommand(query, MainMenu.con);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string characterId = reader["Character_Id"].ToString();
                        string characterName = reader["Character_Name"].ToString();
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine($"You selected Character: \nCharacter ID: \t\t{characterId} \nCharacter Name: \t{characterName}");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Do you want to (1) Delete this character? ");
                        Console.Write("Input: ");
                        string action = Console.ReadLine();

                        if (action == "1") 
                        {
                            Console.WriteLine("Are you sure? \n(1) Yes \n(2) No");
                            Console.Write("Input: ");
                            string delete = Console.ReadLine();
                            if (delete.Equals("1")) { DeleteCharacter(characterId); }
                            else if (delete.Equals("2")) 
                            {
                                Console.WriteLine("Going back to Main Menu...");
                                Console.WriteLine("Press any key to proceed...");
                                Console.ReadKey();
                            }
                        }
                        else { throw new Exception("-Invalid option."); }
                    }
                    reader.Close();
                    break;
                }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
            }
        }

        private void DeleteCharacter(string characterId)
        {
            Console.WriteLine($"Deleting character with ID: {characterId}");
            string query = "DELETE FROM dbo.CharacterDetails WHERE Character_Id = @CharacterId";
            SqlCommand command = new SqlCommand(query, MainMenu.con);
            command.Parameters.AddWithValue("@CharacterId", characterId);

            try
            {
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0) 
                { 
                    Console.WriteLine("--Character deleted successfully.");
                    Console.WriteLine("Press any key to proceed...");
                    Console.ReadKey();
                }
                else { throw new Exception("--No character found with the specified ID."); }
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        }
    }
}

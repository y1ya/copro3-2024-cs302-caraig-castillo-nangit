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

                Console.WriteLine("Select a character to view or delete:");
                Console.WriteLine("---------------------------------------------------");

                int counter = 1;

                if (!reader.HasRows)
                {
                    Console.WriteLine("No saved characters found in the database.");
                    reader.Close();
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine($"" +
                        $"({counter})" +
                        $"\nID: \t\t{reader["Character_Id"]}" +
                        $"\nName: \t\t{reader["Character_Name"]}");
                    Console.WriteLine("---------------------------------------------------");
                    counter++;
                }
                reader.Close();

                int selectedRow;
                while (true)
                {
                    try
                    {
                        Console.Write("Enter the row number to select: ");
                        selectedRow = Convert.ToInt32(Console.ReadLine());

                        if (selectedRow < 1 || selectedRow >= counter)
                        {
                            Console.WriteLine($"Invalid Input. It must be between 1 and {counter - 1}. Please try again.");
                        }
                        else
                        {
                            HandleRowSelection(selectedRow);
                            break;
                        }
                    }
                    catch (FormatException) { Console.WriteLine("Invalid input. Please enter a numeric value."); }
                    catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
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
                        string characterAge = reader["Character_Age"].ToString();
                        string characterRace = reader["Character_Race"].ToString();
                        string characterFarmerType = reader["Character_FarmerType"].ToString();
                        string positiveEffect = reader["Positive_Effect"].ToString();
                        string negativeEffect = reader["Negative_Effect"].ToString();
                        string characterTools = reader["Character_Tools"].ToString();
                        string characterAccessories = reader["Character_Accessories"].ToString();
                        string characterClothes = reader["Character_Clothes"].ToString();
                        string strength = reader["Character_Strength"].ToString();
                        string luck = reader["Character_Luck"].ToString();
                        string speed = reader["Character_Speed"].ToString();
                        string endurance = reader["Character_Endurance"].ToString();
                        string dexterity = reader["Character_Dexterity"].ToString();
                        string intelligence = reader["Character_Intelligence"].ToString();
                        string faceShape = reader["Character_FaceShape"].ToString();
                        string eyeShape = reader["Character_EyeShape"].ToString();
                        string eyeColor = reader["Character_EyeColor"].ToString();
                        string eyebrowShape = reader["Character_EyebrowShape"].ToString();
                        string noseShape = reader["Character_NoseShape"].ToString();
                        string mouthShape = reader["Character_MouthShape"].ToString();
                        string earShape = reader["Character_EarShape"].ToString();
                        string facialHair = reader["Character_FacialHair"].ToString();
                        string hairstyle = reader["Character_Hairstyle"].ToString();
                        string accessory = reader["Character_Accessory"].ToString();
                        string bodyType = reader["Character_BodyType"].ToString();
                        string skinTone = reader["Character_SkinTone"].ToString();
                        string title = reader["Character_Title"].ToString();
                        string titleDesc = reader["Character_TitleDescription"].ToString();
                        string emotionalState = reader["Character_EmotionalState"].ToString();

                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine($"You selected Character: " +
                            "\n\t\t=== Character Info ===" +
                            $"\nCharacter ID: \t\t\t{characterId} " +
                            $"\nCharacter Name: \t\t{characterName}" +
                            $"\nCharacter Age: \t\t\t{characterAge}" +
                            $"\nCharacter Race: \t\t{characterRace}" +
                            $"\nCharacter Farmer Type: \t\t{characterFarmerType}" +
                            "\n\n\t\t=== Character Attributes ===" +
                            $"\nPositive Effect: \t\t{positiveEffect}" +
                            $"\nNegative Effect: \t\t{negativeEffect}" +
                            $"\nCharacter Tools: \t\t{characterTools}" +
                            $"\nCharacter Accessories: \t\t{characterAccessories}" +
                            $"\nCharacter Clothes: \t\t{characterClothes}" +
                            "\n\n\t\t=== Character Stats ===" +
                            $"\nCharacter Strength: \t\t{strength}" +
                            $"\nCharacter Luck: \t\t{luck}" +
                            $"\nCharacter Speed: \t\t{speed}" +
                            $"\nCharacter Endurance: \t\t{endurance}" +
                            $"\nCharacter Dexterity: \t\t{dexterity}" +
                            $"\nCharacter Intelligence: \t{intelligence}" +
                            "\n\n\t\t=== Character Appearance===" +
                            $"\nCharacter Face Shape: \t\t{faceShape}" +
                            $"\nCharacter Eye Shape: \t\t{eyeShape}" +
                            $"\nCharacter Eye Color: \t\t{eyeColor}" +
                            $"\nCharacter Eyebrow Shape: \t{eyebrowShape}" +
                            $"\nCharacter Nose Shape: \t\t{noseShape}" +
                            $"\nCharacter Mouth Shape: \t\t{mouthShape}" +
                            $"\nCharacter Ear Shape: \t\t{earShape}" +
                            $"\nCharacter Facial Hair: \t\t{facialHair}" +
                            $"\nCharacter Hairstyle: \t\t{hairstyle}" +
                            $"\nCharacter Accessory: \t\t{accessory}" +
                            $"\nCharacter Body Type: \t\t{bodyType}" +
                            $"\nCharacter Skin Tone: \t\t{skinTone}" +
                            "\n\n\t\t=== Character Title ===" +
                            $"\nCharacter Title: \t\t{title}" +
                            $"\nCharacter Description: \t\t{titleDesc}" +
                            "\n\n\t\t=== Character Emotional State ===" +
                            $"\nEmotional State: \t\t{emotionalState}");

                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Do you want to Delete this character? \n(1) Yes \n(2) No");
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
                                Console.WriteLine("\nGoing back to Main Menu...");
                                Console.WriteLine("\nPress any key to proceed...");
                                Console.ReadKey();
                            }
                        }
                        else if (action == "2")
                        {
                            Console.WriteLine("\nGoing back to Main Menu...");
                            Console.WriteLine("\nPress any key to proceed...");
                            Console.ReadKey();
                            MainMenu.DisplayMainMenu();
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

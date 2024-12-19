using CharacterCustomization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CharacterCreationSystem
{
    public class DisplayCharacters
    {
        public void LoadGameMenu()
        {
            string[] menuItems =
                {
            "View all characters",
            "View a specific character",
            "Delete a character",
            "Go back to main menu"
        };

            int selectedIndex = 0;
            ConsoleKey key;

            while (true)
            {
                string space = "===";
                Console.Clear();
                Console.Write(space);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" LOAD GAME ");
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
                    switch (selectedIndex)
                    {
                        case 0:
                            DisplayAllCharacters();
                            break;
                        case 1:
                            ViewSpecificCharacter();
                            break;
                        case 2:
                            DeleteCharacterMenu();
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Returning to main menu...");
                            Console.ResetColor();
                            Thread.Sleep(500);
                            return;
                    }
                }
            }
        }

        private void DisplayAllCharacters()
        {
            string query = "SELECT * FROM dbo.CharacterDetails ORDER BY Character_Number";

            try
            {
                if (MainMenu.con == null || MainMenu.con.State != System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Database connection is not established.");
                    Console.ReadKey();
                    return;
                }

                SqlCommand command = new SqlCommand(query, MainMenu.con);
                SqlDataReader reader = command.ExecuteReader();

                string space = "===";
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n\n\n======================================================================================================================");
                Console.ResetColor();

                Console.Write(space);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" View All Characters ");
                Console.ResetColor();
                Console.WriteLine($"{space}");

                if (!reader.HasRows)
                {
                    Console.WriteLine("No characters found.");
                }
                else
                {
                    while (reader.Read())
                    {
                        DisplayCharacterDetails(reader);
                    }
                }

                reader.Close();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("======================================================================================================================");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ResetColor();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void ViewSpecificCharacter()
        {
            string space = "===";
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("======================================================================================================================");
            Console.ResetColor();

            Console.Write(space);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" VIEW SPECIFIC CHARACTER ");
            Console.ResetColor();
            Console.WriteLine(space);

            string query = "SELECT Character_Id, Character_Name FROM dbo.CharacterDetails ORDER BY Character_Number";
            List<(string CharacterId, string CharacterName)> characters = new List<(string, string)>();

            try
            {
                if (MainMenu.con == null || MainMenu.con.State != System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Database connection is not established.");
                    Console.ReadKey();
                    return;
                }

                SqlCommand command = new SqlCommand(query, MainMenu.con);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string characterId = reader["Character_Id"].ToString();
                        string characterName = reader["Character_Name"].ToString();
                        characters.Add((characterId, characterName));
                    }
                }
                else
                {
                    Console.WriteLine("No characters found.");
                    reader.Close();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }

                reader.Close();

                int selectedIndex = 0;
                bool isSelecting = true;

                while (isSelecting)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("======================================================================================================================");
                    Console.ResetColor();

                    Console.Write(space);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" SELECT A SPECIFIC CHARACTER ");
                    Console.ResetColor();
                    Console.WriteLine(space);                    

                    for (int i = 0; i < characters.Count; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($">>> {characters[i].CharacterName} [ID: {characters[i].CharacterId}]");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"  {characters[i].CharacterName} [ID: {characters[i].CharacterId}]");
                        }
                    }

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        selectedIndex = (selectedIndex == 0) ? characters.Count - 1 : selectedIndex - 1; 
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        selectedIndex = (selectedIndex == characters.Count - 1) ? 0 : selectedIndex + 1;
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("======================================================================================================================");
                        Console.ResetColor();

                        string selectedCharacterId = characters[selectedIndex].CharacterId;
                        DisplayCharacterDetails(selectedCharacterId);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        isSelecting = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("======================================================================================================================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ResetColor();
            Console.ReadKey();
        }

        private void DisplayCharacterDetails(string characterId)
        {
            string query = "SELECT * FROM dbo.CharacterDetails WHERE Character_Id = @CharacterId";

            try
            {
                SqlCommand command = new SqlCommand(query, MainMenu.con);
                command.Parameters.AddWithValue("@CharacterId", characterId);

                SqlDataReader reader = command.ExecuteReader();
                
                
                if (reader.Read())
                {
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
                    string emotionalStateDisplay =      
                                                    emotionalState == "1" ? "Good" :
                                                    emotionalState == "0" ? "Evil" :
                                                                          "Neutral";

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.ResetColor();

                    Console.Write($"You Selected Character: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(characterName);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n=== Character Summary ===");
                    Console.ResetColor();
                    Console.WriteLine($"{"ID:",-20}{characterId}");
                    Console.WriteLine($"{"Name:",-20}{characterName}");
                    Console.WriteLine($"{"Age:",-20}{characterAge}");
                    Console.WriteLine($"{"Race:",-20}{characterRace}");
                    Console.WriteLine($"{"Farmer Type:",-20}{characterFarmerType}");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n=== Character Attributes ===");
                    Console.ResetColor();
                    Console.WriteLine($"{"Positive Effect:",-20}{positiveEffect}");
                    Console.WriteLine($"{"Negative Effect:",-20}{negativeEffect}");
                    Console.WriteLine($"{"Tools:",-20}{characterTools}");
                    Console.WriteLine($"{"Accessories:",-20}{characterAccessories}");
                    Console.WriteLine($"{"Clothes:",-20}{characterClothes}");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n=== Character Stats ===");
                    Console.ResetColor();
                    Console.WriteLine($"{"Strength:",-20}{strength}");
                    Console.WriteLine($"{"Luck:",-20}{luck}");
                    Console.WriteLine($"{"Speed:",-20}{speed}");
                    Console.WriteLine($"{"Endurance:",-20}{endurance}");
                    Console.WriteLine($"{"Dexterity:",-20}{dexterity}");
                    Console.WriteLine($"{"Intelligence:",-20}{intelligence}");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n=== Character Appearance ===");
                    Console.ResetColor();
                    Console.WriteLine($"{"Face Shape:",-20}{faceShape}");
                    Console.WriteLine($"{"Eye Shape:",-20}{eyeShape}");
                    Console.WriteLine($"{"Eye Color:",-20}{eyeColor}");
                    Console.WriteLine($"{"Eyebrow Shape:",-20}{eyebrowShape}");
                    Console.WriteLine($"{"Nose Shape:",-20}{noseShape}");
                    Console.WriteLine($"{"Mouth Shape:",-20}{mouthShape}");
                    Console.WriteLine($"{"Ear Shape:",-20}{earShape}");
                    Console.WriteLine($"{"Facial Hair:",-20}{facialHair}");
                    Console.WriteLine($"{"Hairstyle:",-20}{hairstyle}");
                    Console.WriteLine($"{"Accessory:",-20}{accessory}");
                    Console.WriteLine($"{"Body Type:",-20}{bodyType}");
                    Console.WriteLine($"{"Skin Tone:",-20}{skinTone}");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n=== Character Title ===");
                    Console.ResetColor();

                    Console.Write($"{"Title:",-20}");
                    if (title == "Crop Master") { Console.ForegroundColor = ConsoleColor.Green; }// Green for Crop Master
                    else if (title == "Animal Caretaker") { Console.ForegroundColor = ConsoleColor.Yellow; }// Yellow for Animal Caretaker
                    else if (title == "Harvest Master") { Console.ForegroundColor = ConsoleColor.Yellow; }// Golden Yellow for Harvest Master
                    else if (title == "Trailblazer") { Console.ForegroundColor = ConsoleColor.Blue; }// Blue for Trailblazer
                    else { Console.ForegroundColor = ConsoleColor.DarkGreen; }// Dark Green for Farmer
                    Console.WriteLine($"{title}");
                    Console.ResetColor();

                    Console.WriteLine($"{"Description:",-20}{titleDesc}");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n=== Character Emotional State ===");
                    Console.ResetColor();
                    
                    Console.Write($"{"Emotional State:",-20}");
                    if (emotionalStateDisplay == "Good" || emotionalStateDisplay == "1") { Console.ForegroundColor = ConsoleColor.Green; }
                    else if (emotionalStateDisplay == "Evil" || emotionalStateDisplay == "0") { Console.ForegroundColor = ConsoleColor.Red; }
                    else { Console.ForegroundColor = ConsoleColor.Yellow; }
                    Console.WriteLine($"{emotionalStateDisplay}\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Character not found.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void DisplayCharacterDetails(SqlDataReader reader)
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
            string emotionalStateDisplay = 
                   emotionalState == "1" ? "Good" :
                   emotionalState == "0" ? "Evil" :
                                     "Neutral";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.Write($"Your Character: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(characterName);
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Character Summary ===");
            Console.ResetColor();
            Console.WriteLine($"{"ID:",-20}{characterId}");
            Console.WriteLine($"{"Name:",-20}{characterName}");
            Console.WriteLine($"{"Age:",-20}{characterAge}");
            Console.WriteLine($"{"Race:",-20}{characterRace}");
            Console.WriteLine($"{"Farmer Type:",-20}{characterFarmerType}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Character Attributes ===");
            Console.ResetColor();
            Console.WriteLine($"{"Positive Effect:",-20}{positiveEffect}");
            Console.WriteLine($"{"Negative Effect:",-20}{negativeEffect}");
            Console.WriteLine($"{"Tools:",-20}{characterTools}");
            Console.WriteLine($"{"Accessories:",-20}{characterAccessories}");
            Console.WriteLine($"{"Clothes:",-20}{characterClothes}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Character Stats ===");
            Console.ResetColor();
            Console.WriteLine($"{"Strength:",-20}{strength}");
            Console.WriteLine($"{"Luck:",-20}{luck}");
            Console.WriteLine($"{"Speed:",-20}{speed}");
            Console.WriteLine($"{"Endurance:",-20}{endurance}");
            Console.WriteLine($"{"Dexterity:",-20}{dexterity}");
            Console.WriteLine($"{"Intelligence:",-20}{intelligence}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Character Appearance ===");
            Console.ResetColor();
            Console.WriteLine($"{"Face Shape:",-20}{faceShape}");
            Console.WriteLine($"{"Eye Shape:",-20}{eyeShape}");
            Console.WriteLine($"{"Eye Color:",-20}{eyeColor}");
            Console.WriteLine($"{"Eyebrow Shape:",-20}{eyebrowShape}");
            Console.WriteLine($"{"Nose Shape:",-20}{noseShape}");
            Console.WriteLine($"{"Mouth Shape:",-20}{mouthShape}");
            Console.WriteLine($"{"Ear Shape:",-20}{earShape}");
            Console.WriteLine($"{"Facial Hair:",-20}{facialHair}");
            Console.WriteLine($"{"Hairstyle:",-20}{hairstyle}");
            Console.WriteLine($"{"Accessory:",-20}{accessory}");
            Console.WriteLine($"{"Body Type:",-20}{bodyType}");
            Console.WriteLine($"{"Skin Tone:",-20}{skinTone}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Character Title ===");
            Console.ResetColor();

            Console.Write($"{"Title:",-20}");
            if (title == "Crop Master") { Console.ForegroundColor = ConsoleColor.Green; }// Green for Crop Master
            else if (title == "Animal Caretaker") { Console.ForegroundColor = ConsoleColor.Yellow; }// Yellow for Animal Caretaker
            else if (title == "Harvest Master") { Console.ForegroundColor = ConsoleColor.Yellow; }// Golden Yellow for Harvest Master
            else if (title == "Trailblazer") { Console.ForegroundColor = ConsoleColor.Blue; }// Blue for Trailblazer
            else { Console.ForegroundColor = ConsoleColor.DarkGreen; }// Dark Green for Farmer
            Console.WriteLine($"{title}");
            Console.ResetColor();
            Console.WriteLine($"{"Description:",-20}{titleDesc}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Character Emotional State ===");
            Console.ResetColor();
            
            Console.Write($"{"Emotional State:",-20}");
            if (emotionalStateDisplay == "Good" || emotionalStateDisplay == "1") { Console.ForegroundColor = ConsoleColor.Green; }
            else if (emotionalStateDisplay == "Evil" || emotionalStateDisplay == "0") { Console.ForegroundColor = ConsoleColor.Red; }
            else { Console.ForegroundColor = ConsoleColor.Yellow; }
            Console.WriteLine($"{emotionalStateDisplay}\n");
            Console.ResetColor();
        }

        private void DeleteCharacterMenu()
        {
            string space = "===";
            Console.Clear();
            Console.Write(space);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" DELETE CHARACTER ");
            Console.ResetColor();
            Console.WriteLine(space);

            string query = "SELECT Character_Id, Character_Name FROM dbo.CharacterDetails";
            List<(string CharacterId, string CharacterName)> characters = new List<(string, string)>();

            try
            {
                if (MainMenu.con == null || MainMenu.con.State != System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Database connection is not established.");
                    Console.ReadKey();
                    return;
                }

                SqlCommand command = new SqlCommand(query, MainMenu.con);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string characterId = reader["Character_Id"].ToString();
                        string characterName = reader["Character_Name"].ToString();
                        characters.Add((characterId, characterName));
                    }
                }
                else
                {
                    Console.WriteLine("No characters found.");
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }

                reader.Close();

                int selectedIndex = 0;
                bool isSelecting = true;

                while (isSelecting)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("======================================================================================================================");
                    Console.ResetColor();

                    Console.Write(space);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" SELECT A CHARACTER TO DELETE ");
                    Console.ResetColor();
                    Console.WriteLine(space);

                    for (int i = 0; i < characters.Count; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($">>> {characters[i].CharacterName} [ID: {characters[i].CharacterId}]");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"  {characters[i].CharacterName} [ID: {characters[i].CharacterId}]");
                        }
                    }

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        selectedIndex = (selectedIndex == 0) ? characters.Count - 1 : selectedIndex - 1;
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        selectedIndex = (selectedIndex == characters.Count - 1) ? 0 : selectedIndex + 1;
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        string selectedCharacterId = characters[selectedIndex].CharacterId;
                        string selectedCharacterName = characters[selectedIndex].CharacterName;

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("======================================================================================================================");
                        Console.ResetColor();

                        DisplayCharacterDetails(selectedCharacterId);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        Console.WriteLine("\nDo you want to delete this character? (y/n): ");
                        string confirm = Console.ReadLine().ToLower();

                        while (confirm != "y" && confirm != "n")
                        {
                            Console.WriteLine("Invalid input. Please enter 'y' for Yes or 'n' for No.");
                            confirm = Console.ReadLine().ToLower();
                        }

                        if (confirm == "y")
                        {
                            DeleteCharacter(selectedCharacterId);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"\nCharacter {selectedCharacterName} deleted successfully.");
                            Thread.Sleep(750);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nDeletion cancelled...");
                            Thread.Sleep(750);
                            Console.ResetColor();
                        }

                        isSelecting = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n======================================================================================================================\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to return to the menu...");
            Console.ResetColor();
            Console.ReadKey();
        }

        private void DeleteCharacter(string characterId)
        {
            string query = "DELETE FROM dbo.CharacterDetails WHERE Character_Id = @CharacterId";
            try
            {
                SqlCommand command = new SqlCommand(query, MainMenu.con);
                command.Parameters.AddWithValue("@CharacterId", characterId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

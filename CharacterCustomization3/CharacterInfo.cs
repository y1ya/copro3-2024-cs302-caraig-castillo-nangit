using CharacterCreationSystem;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace CharacterCustomization
{
    public interface IShowOptionsInfo
    {
        void ShowNameOptions();
        void ShowAgeOptions();
        void ShowGenderOptions();
        void ShowRaceOptions();
        void ShowFarmerTypeOptions();
    }
    public class CharacterInfo
    {
        private int id;
        private string name;
        private string age;
        private string gender;
        private string race;
        private string farmerType;
        public CharacterInfo(int id, string name, string age, string gender, string race, string farmerType)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.race = race;
            this.farmerType = farmerType;
        }

        public void SetId(int id) { this.id = id; }
        public void SetName(string name) { this.name = name; }
        public void SetAge(string age) { this.age = age; }
        public void SetGender(string gender) { this.gender = gender; }
        public void SetRace(string race) { this.race = race; }
        public void SetFarmerType(string farmerType) { this.farmerType = farmerType; }

        public int GetId() { return id; }
        public string GetName() { return name; }
        public string GetAge() { return age; }
        public string GetGender() { return gender; }
        public string GetRace() { return race; }
        public string GetFarmerType() { return farmerType; }
    }
    public class CustomCharacterInfo : CheckForErrors, IShowOptionsInfo
    {
        private CharacterInfo characterInfo;
        
        public CustomCharacterInfo()
        {
            characterInfo = new CharacterInfo(0, "", "", "", "", "");
        }
        public void CustomizeInfo()
        {
            Console.WriteLine("\n=== Customize Character Info ===");
            SetName();
            SetAge();
            SetGender();
            SetRace();
            SetFarmerType();
        }
        private void SetName()
        {
            while (string.IsNullOrEmpty(characterInfo.GetName()))
            {
                try
                {
                    Console.WriteLine("\n=== Character Name ===");
                    ShowNameOptions();
                    Console.Write("Enter Name: ");
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new Exception("Name cannot be empty or whitespace.");
                    }

                    if (input.Length < 3 || input.Length > 16)
                    {
                        throw new Exception("Name must be 3-16 characters long.");
                    }

                    if (!IsNameUnique(input))
                    {
                        Console.WriteLine("==Error: Name already exists in the database. Please enter a different name.");
                        continue;
                    }

                    characterInfo.SetName(input);
                    characterInfo.SetId(GenerateRandomID());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void SetAge()
        {
            while (string.IsNullOrEmpty(characterInfo.GetAge()))
            {
                try
                {
                    Console.WriteLine("\n=== Character Age ===");
                    ShowAgeOptions();
                    Console.Write("Enter choice: ");
                    characterInfo.SetAge(CheckForErrors.checkInput(Console.ReadLine(), new[]
                    {
                    "Young Adult (18-24)", "Adult (25-31)", "Middle-Aged (32-38)",
                    "Mature Adult (39-45)", "Experienced (46-52)"
                    }));
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }
        }

        private void SetGender()
        {

            while (string.IsNullOrEmpty(characterInfo.GetGender()))
            {
                try
                {
                    Console.WriteLine("\n=== Character Gender ===");
                    ShowGenderOptions();
                    Console.Write("Enter choice: ");
                    characterInfo.SetGender(CheckForErrors.checkInput(Console.ReadLine(), new[] { "Male", "Female", "Gay", "Lesbian", "Non-Binary", "Other" }));
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }
        }

        private void SetRace()
        {
            while (string.IsNullOrEmpty(characterInfo.GetRace()))
            {
                try
                {
                    Console.WriteLine("\n=== Character Race ===");
                    ShowRaceOptions();
                    Console.Write("Enter choice: ");
                    characterInfo.SetRace(CheckForErrors.checkInput(Console.ReadLine(), new[]
                    {
                    "Western European", "Asian", "Native American", "Australian", "Middle Eastern"
                }));
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }
        }

        private void SetFarmerType()
        {

            while (string.IsNullOrEmpty(characterInfo.GetFarmerType()))
            {
                try
                {
                    Console.WriteLine("\n=== Character Farmer Type ===");
                    ShowFarmerTypeOptions();
                    Console.Write("Enter choice: ");
                    characterInfo.SetFarmerType(CheckForErrors.checkInput(Console.ReadLine(), new[]
                    {
                    "Mixed/General Farmer", "Livestock Farmer", "Grain Farmer", "Vegetable Farmer", "Fruit Farmer"
                }));
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }
        }

        public void ShowDetailInfo()
        {
            Console.WriteLine($"{"ID:",-15} {GenerateRandomID()}");
            Console.WriteLine($"{"Name:",-15} {characterInfo.GetName()}");
            Console.WriteLine($"{"Age:",-15} {characterInfo.GetAge()}");
            Console.WriteLine($"{"Gender:",-15} {characterInfo.GetGender()}");
            Console.WriteLine($"{"Race:",-15} {characterInfo.GetRace()}");
            Console.WriteLine($"{"Farmer Type:",-15} {characterInfo.GetFarmerType()}");
        }

        public void ShowNameOptions() { Console.WriteLine("Name must be 3-16 characters long."); }
        public void ShowAgeOptions()
        {
            Console.WriteLine("(a) Young Adult (18-24)");
            Console.WriteLine("(b) Adult (25-31)");
            Console.WriteLine("(c) Middle-Aged (32-38)");
            Console.WriteLine("(d) Mature Adult (39-45)");
            Console.WriteLine("(e) Experienced (46-52)");
        }
        public void ShowGenderOptions()
        {
            Console.WriteLine("(a) Male");
            Console.WriteLine("(b) Female");
            Console.WriteLine("(c) Gay");
            Console.WriteLine("(d) Lesbian");
            Console.WriteLine("(e) Non-Binary");
            Console.WriteLine("(f) Others");
        }
        public void ShowRaceOptions()
        {
            Console.WriteLine("(a) Western European");
            Console.WriteLine("(b) Asian");
            Console.WriteLine("(c) Native American");
            Console.WriteLine("(d) Australian");
            Console.WriteLine("(e) Middle Eastern");
        }
        public void ShowFarmerTypeOptions()
        {
            Console.WriteLine("(a) Mixed/General Farmer");
            Console.WriteLine("(b) Livestock Farmer");
            Console.WriteLine("(c) Grain Farmer");
            Console.WriteLine("(d) Vegetable Farmer");
            Console.WriteLine("(e) Fruit Farmer");
        }

        public int GenerateRandomID()
        {
            Random random = new Random();
            int newId;

            while (true)
            {
                newId = random.Next(100000, 1000000);

                string checkQuery = "SELECT COUNT(*) FROM dbo.CharacterDetails WHERE Character_Id = @Character_Id";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, MainMenu.con))
                {
                    checkCommand.Parameters.AddWithValue("@Character_Id", newId);

                    int count = (int)checkCommand.ExecuteScalar();

                    if (count == 0) { break; }
                }
            }

            return newId;
        }

        private bool IsNameUnique(string name)
        {
            try
            {
                if (MainMenu.con.State == ConnectionState.Open)
                {
                    using (SqlCommand cleanupCommand = new SqlCommand("SET NOCOUNT ON;", MainMenu.con))
                    {
                        cleanupCommand.ExecuteNonQuery();
                    }
                }
                string query = "SELECT COUNT(*) FROM dbo.CharacterDetails WHERE Character_Name = @Name";

                using (SqlCommand checkNameCommand = new SqlCommand(query, MainMenu.con))
                {
                    checkNameCommand.Parameters.AddWithValue("@Name", name);

                    int count = (int)checkNameCommand.ExecuteScalar();
                    return count == 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("==Error checking name uniqueness: " + ex.Message);
                return false;
            }
        }


        public int getId() { return characterInfo.GetId(); }
        public string getName() { return characterInfo.GetName(); }
        public string getAge() { return characterInfo.GetAge(); }
        public string getGender() { return characterInfo.GetGender(); }
        public string getRace() {  return characterInfo.GetRace(); }
        public string getFarmerType() { return characterInfo.GetFarmerType(); }
    }
}

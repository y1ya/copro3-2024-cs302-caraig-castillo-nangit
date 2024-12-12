using CharacterCreationSystem;
using System;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace CharacterCustomization
{
    public interface IShowOptionsAtt
    {
        void ShowPositiveEffectOptions();
        void ShowNegativeEffectOptions();
        void ShowToolsOptions();
        void ShowAccessoriesOptions();
        void ShowClothesOptions();
    }
    public class CharacterAttributes
    {
        private string positiveEffect;
        private string negativeEffect;
        private string tools;
        private string accessories;
        private string clothes;

        private int strength;
        private int luck;
        private int speed;
        private int endurance;
        private int dexterity;
        private int intelligence;

        public CharacterAttributes() 
        {
            positiveEffect = "None";
            negativeEffect = "None";
            tools = "None";
            accessories = "None";
            clothes = "None";
            strength = 0;
            luck = 0;
            speed = 0;
            endurance = 0;
            dexterity = 0;
            intelligence = 0;
        }
        public string GetPositiveEffect() { return positiveEffect; }
        public string GetNegativeEffect() { return negativeEffect; }
        public string GetTools() { return tools; }
        public string GetAccessories() { return accessories; }
        public string GetClothes() { return clothes; }
        public int GetStrength() { return strength; }
        public int GetLuck() { return luck; }
        public int GetSpeed() { return speed; }
        public int GetEndurance() { return endurance; }
        public int GetDexterity() { return dexterity; }
        public int GetIntelligence() { return intelligence; }
        public void SetPositiveEffect(string effect) { positiveEffect = effect; }
        public void SetNegativeEffect(string effect) { negativeEffect = effect; }
        public void SetTools(string tools) { this.tools = tools; }
        public void SetAccessories(string accessories) { this.accessories = accessories; }
        public void SetClothes(string clothes) { this.clothes = clothes; }
        public void SetStrength(int value) { strength = value; }
        public void SetLuck(int value) { luck = value; }
        public void SetSpeed(int value) { speed = value; }
        public void SetEndurance(int value) { endurance = value; }
        public void SetDexterity(int value) { dexterity = value; }
        public void SetIntelligence(int value) { intelligence = value; }
    }    

    public class CustomAttributes : CheckForErrors, IShowOptionsAtt
    {
        private CharacterAttributes attributes;
        private string updateQueryString;
        public CustomAttributes() { attributes = new CharacterAttributes(); }

        public void CustomizeAttribute()
        {
            Console.WriteLine("\n=== Character Attributes ===");
            AllocateStats();

            while (attributes.GetPositiveEffect() == "None")
            {
                try
                {
                    SetAttribute("Positive Effect", ShowPositiveEffectOptions, attributes.SetPositiveEffect, new[]
                    {
                    "Energy Boost - Increases stamina by 20%",
                    "Speed Increase - Performs tasks 20% faster",
                    "Enhanced Harvest - Increases yield by 20%",
                    "Soil Fertility Boost - Speeds up crop growth by 20%",
                    "Animal Productivity - Animals produce 20% more goods"
                });
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }

            while (attributes.GetNegativeEffect() == "None")
            {
                try
                {
                    SetAttribute("Negative Effect", ShowNegativeEffectOptions, attributes.SetNegativeEffect, new[]
                    {
                    "Fatigue - Reduces stamina recovery",
                    "Sickness - Affects daily tasks",
                    "Crop Damage - Lowers crop yield",
                    "Animal Stress - Lowers animal productivity",
                    "Soil Degradation - Reduces soil fertility",
                    "Stress Build-Up - Affects character's overall performance"
                });
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }

            while (attributes.GetTools() == "None")
            {
                try
                {
                    SetAttribute("Tools", ShowToolsOptions, attributes.SetTools, new[]
                    {
                    "Basic Tools - Hoe, Shovel, Watering Can, Rake, Spade",
                    "Advanced Tools - Scythe, Axe, Pickaxe, Sickle, Power Tiller",
                    "Specialized Tools - Fertilizer, Bug Net, Pruning Shears, Sprinkler System, Soil Tester",
                    "Seasonal Tools - Snow Shovel, Winter Coat, Shade Net, Ice Pick, Storm Shelter Equiqment"             
                });
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }

            while (attributes.GetAccessories() == "None")
            {
                try
                {
                    SetAttribute("Accessories", ShowAccessoriesOptions, attributes.SetAccessories, new[]
                    {
                        "Storage Expansion Backpack", 
                        "Lucky Hoe", 
                        "Harvest Gloves", 
                        "Crop Analyzer", 
                        "Mechanical Shovel"
                });
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }

            while (attributes.GetClothes() == "None")
            {
                try
                {
                    SetAttribute("Clothes", ShowClothesOptions, attributes.SetClothes, new[]
                    {
                        "Classic Overalls", 
                        "Flannel Shirt and Jeans", 
                        "Wide-Brimmed Hat and Boots", 
                        "Straw Hat and Apron", 
                        "Farmer's Vest"
                });
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }

            try
            {
                updateQueryString = "UPDATE dbo.CharacterDetails SET " + 
                    "Positive_Effect = @PositiveEffect, " + 
                    "Negative_Effect = @NegativeEffect, " + 
                    "Character_Tools = @CharacterTools, " + 
                    "Character_Accessories = @CharacterAccessories, " + 
                    "Character_Strength = @Strength, " +
                    "Character_Luck = @Luck, " + 
                    "Character_Speed = @Speed, " +
                    "Character_Endurance = @Endurance, " + 
                    "Character_Dexterity = @Dexterity, " +
                    "Character_Intelligence = @Intelligence " + 
                    "WHERE Character_Id = @CharacterId";

                SqlCommand updateData = new SqlCommand(updateQueryString, MainMenu.con);
                updateData.Parameters.AddWithValue("@PositiveEffect", GetPositiveEffect());
                updateData.Parameters.AddWithValue("@NegativeEffect", GetNegativeEffect());
                updateData.Parameters.AddWithValue("@CharacterTools", GetTools());
                updateData.Parameters.AddWithValue("@CharacterAccessories", GetAccessory());
                updateData.Parameters.AddWithValue("@Strength", GetStrength());
                updateData.Parameters.AddWithValue("@Luck", GetLuck());
                updateData.Parameters.AddWithValue("@Speed", GetSpeed());
                updateData.Parameters.AddWithValue("@Endurance", GetEndurance());
                updateData.Parameters.AddWithValue("@Dexterity", GetDexterity());
                updateData.Parameters.AddWithValue("@Intelligence", GetIntelligence());
                updateData.Parameters.AddWithValue("@CharacterId", CustomCharacterInfo.Id);
                updateData.ExecuteNonQuery();
                //Console.WriteLine("--Updated " + CustomCharacterInfo.Id + "'s values.(Attributes)");
            }
            catch (Exception ex) { Console.WriteLine("==Error: " + ex.Message); }
        }

        public void DisplayStatsOnly()
        {
            Console.WriteLine($"{"Strength:",-20} {attributes.GetStrength()}");
            Console.WriteLine($"{"Luck:",-20} {attributes.GetLuck()}");
            Console.WriteLine($"{"Speed:",-20} {attributes.GetSpeed()}");
            Console.WriteLine($"{"Endurance:",-20} {attributes.GetEndurance()}");
            Console.WriteLine($"{"Dexterity:",-20} {attributes.GetDexterity()}");
            Console.WriteLine($"{"Intelligence:",-20} {attributes.GetIntelligence()}");
        }

        private void AllocateStats()
        {
            int pointsRemaining = 10;

            Console.WriteLine("\n=== Allocate Stats ===");

            while (pointsRemaining > 0)
            {
                Console.WriteLine($"\nYou have {pointsRemaining} points remaining.");
                Console.WriteLine("\nCurrent Stats:");
                DisplayStatsOnly();

                Console.WriteLine($"\nYou have {pointsRemaining} points remaining.");
                attributes.SetStrength(attributes.GetStrength() + AllocateAttributePoints("Strength", ref pointsRemaining));
                if (pointsRemaining <= 0) break;

                attributes.SetLuck(attributes.GetLuck() + AllocateAttributePoints("Luck", ref pointsRemaining));
                if (pointsRemaining <= 0) break;

                attributes.SetSpeed(attributes.GetSpeed() + AllocateAttributePoints("Speed", ref pointsRemaining));
                if (pointsRemaining <= 0) break;

                attributes.SetEndurance(attributes.GetEndurance() + AllocateAttributePoints("Endurance", ref pointsRemaining));
                if (pointsRemaining <= 0) break;

                attributes.SetDexterity(attributes.GetDexterity() + AllocateAttributePoints("Dexterity", ref pointsRemaining));
                if (pointsRemaining <= 0) break;
                attributes.SetIntelligence(attributes.GetIntelligence() + AllocateAttributePoints("Intelligence", ref pointsRemaining));
                if (pointsRemaining <= 0) break;
            }

            Console.WriteLine("You don't have remaining points.");
        }

        private int AllocateAttributePoints(string attributeName, ref int pointsRemaining)
        {
            int allocated = 0;
            if (pointsRemaining > 0)
            {
                while (pointsRemaining > 0)
                {
                    Console.WriteLine($"\nAssign points to {attributeName} (Remaining Points: {pointsRemaining}):");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out allocated) && allocated >= 0 && allocated <= Math.Min(10, pointsRemaining))
                    {
                        pointsRemaining -= allocated;
                        return allocated;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input. You must assign between 0 and {Math.Min(10, pointsRemaining)} points.");
                    }
                }
            }
            return 0;
        }

        private void SetAttribute(string attributeName, Action showOptions, Action<string> setAttribute, string[] options)
        {
            Console.WriteLine($"\n=== Choose {attributeName} ===");
            showOptions();
            Console.Write("Enter choice: ");
            try
            {
                setAttribute(CheckForErrors.checkInput(Console.ReadLine(), options));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void DisplayOptions(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"({(char)('a' + i)}) {options[i]}");
            }
        }

        public void ShowPositiveEffectOptions()
        {
            DisplayOptions(new[] {
            "Energy Boost - Increases stamina by 20%",
            "Speed Increase - Performs tasks 20% faster",
            "Enhanced Harvest - Increases yield by 20%",
            "Luck Boost - Raises chance of rare events",
            "Pest Resistance - Reduces crop failure by 25%",
            "Soil Fertility Boost - Speeds up crop growth by 20%",
            "Animal Productivity - Animals produce 20% more goods" });
        }

        public void ShowNegativeEffectOptions()
        {
            DisplayOptions(new[] {
            "Fatigue - Reduces stamina recovery",
            "Sickness - Affects daily tasks",
            "Crop Damage - Lowers crop yield",
            "Animal Stress - Lowers animal productivity",
            "Soil Degradation - Reduces soil fertility",
            "Stress Build-Up - Affects character's overall performance" });
        }

        public void ShowToolsOptions()
        {
            DisplayOptions(new[] {
            "Basic Tools - Hoe, Shovel, Watering Can, Rake, Spade",
            "Advanced Tools - Scythe, Axe, Pickaxe, Sickle, Power Tiller",
            "Specialized Tools - Fertilizer, Bug Net, Pruning Shears, Sprinkler System, Soil Tester",
            "Seasonal Tools - Snow Shovel, Winter Coat, Shade Net, Ice Pick, Storm Shelter Equiqment" });
        }

        public void ShowAccessoriesOptions() 
        { 
            DisplayOptions(new[] { 
                "Storage Expansion Backpack", 
                "Lucky Hoe", 
                "Harvest Gloves", 
                "Crop Analyzer", 
                "Mechanical Shovel" }); 
        }

        public void ShowClothesOptions() 
        { 
            DisplayOptions(new[] { 
                "Classic Overalls", 
                "Flannel Shirt and Jeans", 
                "Wide-Brimmed Hat and Boots", 
                "Straw Hat and Apron", 
                "Farmer's Vest" }); 
        }

        public string GetPositiveEffect() { return attributes.GetPositiveEffect(); }
        public string GetNegativeEffect() { return attributes.GetNegativeEffect(); }
        public string GetTools() { return attributes.GetTools(); }
        public string GetAccessory() { return attributes.GetAccessories(); }
        public string GetClothes() { return attributes.GetClothes(); }
        public int GetStrength() { return attributes.GetStrength(); }
        public int GetLuck() { return attributes.GetLuck(); }
        public int GetSpeed() { return attributes.GetSpeed(); }
        public int GetEndurance() { return attributes.GetEndurance(); }
        public int GetDexterity() { return attributes.GetDexterity(); }
        public int GetIntelligence() { return attributes.GetIntelligence(); }

    }
}

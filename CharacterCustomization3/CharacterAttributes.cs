using System;
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
        public string GetPositiveEffect() => positiveEffect;
        public string GetNegativeEffect() => negativeEffect;
        public string GetTools() => tools;
        public string GetAccessories() => accessories;
        public string GetClothes() => clothes;

        public int GetStrength() => strength;
        public int GetLuck() => luck;
        public int GetSpeed() => speed;
        public int GetEndurance() => endurance;
        public int GetDexterity() => dexterity;
        public int GetIntelligence() => intelligence;

        public void SetPositiveEffect(string effect) => positiveEffect = effect;
        public void SetNegativeEffect(string effect) => negativeEffect = effect;
        public void SetTools(string tools) => this.tools = tools;
        public void SetAccessories(string accessories) => this.accessories = accessories;
        public void SetClothes(string clothes) => this.clothes = clothes;

        public void SetStrength(int value) => strength = value;
        public void SetLuck(int value) => luck = value;
        public void SetSpeed(int value) => speed = value;
        public void SetEndurance(int value) => endurance = value;
        public void SetDexterity(int value) => dexterity = value;
        public void SetIntelligence(int value) => intelligence = value;
    }    

    public class CustomAttributes : CheckForErrors, IShowOptionsAtt
    {
        private CharacterAttributes attributes;
        public CustomAttributes() { attributes = new CharacterAttributes(); }

        public void CustomizeAttribute()
        {
            Console.WriteLine("\n=== Character Attributes ===");
            AllocateStats();

            if (string.IsNullOrEmpty(attributes.GetPositiveEffect()))
            {
                try
                {
                    SetAttribute("Positive Effect", ShowPositiveEffectOptions, attributes.SetPositiveEffect, new[]
                    {
                    "Energy Boost - Increases stamina by 20%",
                    "Speed Increase - Performs tasks 20% faster",
                    "Enhanced Harvest - Increases yield by 20%",
                    "Luck Boost - Raises chance of rare events",
                    "Pest Resistance - Reduces crop failure by 25%",
                    "Soil Fertility Boost - Speeds up crop growth by 20%",
                    "Animal Productivity - Animals produce 20% more goods"
                });
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }

            if (string.IsNullOrEmpty(attributes.GetNegativeEffect()))
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

            if (string.IsNullOrEmpty(attributes.GetTools()))
            {
                try
                {
                    SetAttribute("Tools", ShowToolsOptions, attributes.SetTools, new[]
                        {
                    "Basic Tools", "Advanced Tools", "Specialized Tools", "Seasonal Tools"
                });
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }

            if (string.IsNullOrEmpty(attributes.GetAccessories()))
            {
                try
                {
                    SetAttribute("Accessories", ShowAccessoriesOptions, attributes.SetAccessories, new[]
                        {
                    "Storage Expansion Backpack", "Lucky Hoe", "Harvest Gloves", "Crop Analyzer", "Mechanical Shovel"
                });
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }

            if (string.IsNullOrEmpty(attributes.GetClothes()))
            {
                try
                {
                    SetAttribute("Clothes", ShowClothesOptions, attributes.SetClothes, new[]
                        {
                    "Classic Overalls", "Flannel Shirt and Jeans", "Wide-Brimmed Hat and Boots", "Straw Hat and Apron", "Farmer's Vest"
                });
                }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("==Error: " + ex.Message); }
                catch (OnlyOneCharacter ex) { Console.WriteLine("==Error: " + ex.Message); }
            }
        }

        public void DisplayAttributes()
        {
            Console.WriteLine($"{"Strength:",-20} {attributes.GetStrength()}");
            Console.WriteLine($"{"Luck:",-20} {attributes.GetLuck()}");
            Console.WriteLine($"{"Speed:",-20} {attributes.GetSpeed()}");
            Console.WriteLine($"{"Endurance:",-20} {attributes.GetEndurance()}");
            Console.WriteLine($"{"Dexterity:",-20} {attributes.GetDexterity()}");
            Console.WriteLine($"{"Intelligence:",-20} {attributes.GetIntelligence()}");
            Console.WriteLine($"{"Positive Effect:",-20} {attributes.GetPositiveEffect()}");
            Console.WriteLine($"{"Negative Effect:",-20} {attributes.GetNegativeEffect()}");
            Console.WriteLine($"{"Tools:",-20} {attributes.GetTools()}");
            Console.WriteLine($"{"Accessories:",-20} {attributes.GetAccessories()}");
            Console.WriteLine($"{"Clothes:",-20} {attributes.GetClothes()}");
        }

        private void AllocateStats()
        {
            int pointsRemaining = 10;

            Console.WriteLine("\n=== Allocate Stats ===");

            while (pointsRemaining > 0)
            {
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

        public void ShowPositiveEffectOptions() => DisplayOptions(new[]
            {
                "Energy Boost - Increases stamina by 20%",
                "Speed Increase - Performs tasks 20% faster",
                "Enhanced Harvest - Increases yield by 20%",
                "Luck Boost - Raises chance of rare events",
                "Pest Resistance - Reduces crop failure by 25%",
                "Soil Fertility Boost - Speeds up crop growth by 20%",
                "Animal Productivity - Animals produce 20% more goods"
            });

        public void ShowNegativeEffectOptions() => DisplayOptions(new[]
        {
                "Fatigue - Reduces stamina recovery",
                "Sickness - Affects daily tasks",
                "Crop Damage - Lowers crop yield",
                "Animal Stress - Lowers animal productivity",
                "Soil Degradation - Reduces soil fertility",
                "Stress Build-Up - Affects character's overall performance"
            });

        public void ShowToolsOptions() => DisplayOptions(new[]
        {
                "Basic Tools", "Advanced Tools", "Specialized Tools", "Seasonal Tools"
            });

        public void ShowAccessoriesOptions() => DisplayOptions(new[]
        {
                "Storage Expansion Backpack", "Lucky Hoe", "Harvest Gloves", "Crop Analyzer", "Mechanical Shovel"
            });

        public void ShowClothesOptions() => DisplayOptions(new[]
        {
                "Classic Overalls", "Flannel Shirt and Jeans", "Wide-Brimmed Hat and Boots", "Straw Hat and Apron", "Farmer's Vest"
        });

        public string getPositiveEffect() { return attributes.GetPositiveEffect(); }
        public string getNegativeEffect() { return attributes.GetNegativeEffect(); }
        public string getTools() { return attributes.GetTools(); }
        public string getAccessory() {  return attributes.GetAccessories(); }
        public string getClothes() { return attributes.GetClothes(); }
        public int getStrength() {  return attributes.GetStrength(); }
        public int getLuck() {  return attributes.GetLuck(); }
        public int getSpeed() { return attributes.GetSpeed(); }
        public int getEndurance() {  return attributes.GetEndurance(); }
        public int getDexterity() {  return attributes.GetDexterity(); }
        public int getIntelligence() { return attributes.GetIntelligence(); }

    }
}

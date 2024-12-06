using CharacterCustomization;
using System;

namespace CharacterCreationSystem
{
    public struct CharacterDetails
    {
        public string name;
        public string age;
        public string gender;
        public string race;
        public string farmerType;
        public string positiveEffect;
        public string negativeEffect;
        public string tools;
        public string accessories;
        public string clothes;

        public int strength;
        public int luck;
        public int speed;
        public int endurance;
        public int dexterity;
        public int intelligence;
    }
    public class NewGame
    {
        public void CreateCharacter()
        {
            Console.Clear();
            CharacterDetails chardetails = new CharacterDetails();
            CustomCharacterInfo customcharacterInfo = new CustomCharacterInfo();
            CustomAttributes customAttributes = new CustomAttributes();
            CustomAppearance customAppearance = new CustomAppearance();
            Console.WriteLine("===== NEW GAME: Create Your Character =====");

            customcharacterInfo.CustomizeInfo();
            customAttributes.CustomizeAttribute();
            customAppearance.CustomizeAppearance();

            chardetails.name = customcharacterInfo.getName();
            chardetails.age = customcharacterInfo.getAge();
            chardetails.gender = customcharacterInfo.getGender();
            chardetails.race = customcharacterInfo.getRace();
            chardetails.farmerType = customcharacterInfo.getFarmerType();
            chardetails.positiveEffect = customAttributes.getPositiveEffect();
            chardetails.negativeEffect = customAttributes.getNegativeEffect();
            chardetails.tools = customAttributes.getTools();
            chardetails.accessories = customAttributes.getAccessory();
            chardetails.clothes = customAttributes.getClothes();

            chardetails.strength = customAttributes.getStrength();
            chardetails.luck = customAttributes.getLuck();
            chardetails.speed = customAttributes.getSpeed();
            chardetails.endurance = customAttributes.getEndurance();
            chardetails.dexterity = customAttributes.getDexterity();
            chardetails.intelligence = customAttributes.getIntelligence();

            Console.Clear();
            Console.WriteLine("\t===== Character Summary =====");
            customcharacterInfo.ShowDetailInfo();
            Console.WriteLine("\n\t=== Character Stats ===");
            Console.WriteLine($"{"Strength:",-20} {chardetails.strength}");
            Console.WriteLine($"{"Luck:",-20} {chardetails.luck}");
            Console.WriteLine($"{"Speed:",-20} {chardetails.speed}");
            Console.WriteLine($"{"Endurance:",-20} {chardetails.endurance}");
            Console.WriteLine($"{"Dexterity:",-20} {chardetails.dexterity}");
            Console.WriteLine($"{"Intelligence:",-20} {chardetails.intelligence}");
            Console.WriteLine($"{"Positive Effect:",-20} {chardetails.positiveEffect}");
            Console.WriteLine($"{"Negative Effect:",-20} {chardetails.negativeEffect}");
            Console.WriteLine($"{"Tools:",-20} {chardetails.tools}");

            Console.WriteLine("\n\t=== Appearance Details ===");
            customAppearance.showDetailAppearance();
            Console.WriteLine($"{"Accessories:",-20} {chardetails.accessories}");
            Console.WriteLine($"{"Clothes:",-20} {chardetails.clothes}");
            Console.WriteLine("\nCharacter creation complete! Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}

//create your branch first
//like this comment, from Git (Top of the screen) then press Commit, or you can just find the "Git Changes" on your right screen
//add a message, kung ano man yung bago sa code mo, then press commit all, and of course save the changes first before commiting, make sure nasa branch mo
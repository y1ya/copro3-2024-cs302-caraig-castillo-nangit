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
    public class NewGame : IntroduceGame
    {
        CustomCharacterInfo customcharacterInfo = new CustomCharacterInfo();
        CustomAttributes customAttributes = new CustomAttributes();
        CustomAppearance customAppearance = new CustomAppearance();
        CharacterTitle characterTitle = new CharacterTitle();
        CharacterEmotionalState emotionalState = new CharacterEmotionalState();
        public void CreateCharacter()
        {
            Console.Clear();
            CharacterDetails chardetails = new CharacterDetails();
            Introduce();
            
            customcharacterInfo.CustomizeInfo();
            customAttributes.CustomizeAttribute();
            customAppearance.CustomizeAppearance();

            chardetails.name = customcharacterInfo.getName();
            chardetails.age = customcharacterInfo.getAge();
            chardetails.gender = customcharacterInfo.getGender();
            chardetails.race = customcharacterInfo.getRace();
            chardetails.farmerType = customcharacterInfo.getFarmerType();
            chardetails.positiveEffect = customAttributes.GetPositiveEffect();
            chardetails.negativeEffect = customAttributes.GetNegativeEffect();
            chardetails.tools = customAttributes.GetTools();
            chardetails.accessories = customAttributes.GetAccessory();
            chardetails.clothes = customAttributes.GetClothes();

            chardetails.strength = customAttributes.GetStrength();
            chardetails.luck = customAttributes.GetLuck();
            chardetails.speed = customAttributes.GetSpeed();
            chardetails.endurance = customAttributes.GetEndurance();
            chardetails.dexterity = customAttributes.GetDexterity();
            chardetails.intelligence = customAttributes.GetIntelligence();

            string assignedTitle = characterTitle.AssignTitle(chardetails);
            string emotionalStateResult = emotionalState.GetEmotionalState();

            Console.Clear();
            Console.WriteLine("\n\n\t===== Character Summary =====");
            showCharacterDetail();
            Console.WriteLine("\n\t=== Character Stats ===");
            showCharacterDetail(chardetails.strength, chardetails.luck, chardetails.speed, chardetails.endurance, chardetails.dexterity, chardetails.intelligence,
                chardetails.positiveEffect, chardetails.negativeEffect, chardetails.tools);

            Console.WriteLine("\n\t=== Appearance Details ===");
            customAppearance.showDetailAppearance();
            showCharacterDetail(chardetails.accessories, chardetails.clothes);

            Console.WriteLine($"\n\t=== Character Emotional State ===");
            Console.WriteLine($"Your emotional state is: {emotionalStateResult}");

            Console.WriteLine("\n\t=== Character Title ===");
            Console.WriteLine(assignedTitle);
            Console.WriteLine("\nCharacter creation complete! Press any key to return to the main menu...");
            Console.ReadKey();
        }

        public void showCharacterDetail()
        {
            customcharacterInfo.ShowDetailInfo();
        }

        public void showCharacterDetail(int strength, int luck, int speed, int endurance, 
            int dexterity, int intelligence, string posEffect, string negEffect, string tools)
        {
            Console.WriteLine($"{"Strength:",-20} {strength}");
            Console.WriteLine($"{"Luck:",-20} {luck}");
            Console.WriteLine($"{"Speed:",-20} {speed}");
            Console.WriteLine($"{"Endurance:",-20} {endurance}");
            Console.WriteLine($"{"Dexterity:",-20} {dexterity}");
            Console.WriteLine($"{"Intelligence:",-20} {intelligence}");
            Console.WriteLine($"{"Positive Effect:",-20} {posEffect}");
            Console.WriteLine($"{"Negative Effect:",-20} {negEffect}");
            Console.WriteLine($"{"Tools:",-20} {tools}");
        }

        public void showCharacterDetail(string accessories, string clothes)
        {
            Console.WriteLine($"{"Accessories:",-20} {accessories}");
            Console.WriteLine($"{"Clothes:",-20} {clothes}");
        }

        public override void Introduce()
        {
            base.Introduce();

            Console.WriteLine("\n===== NEW GAME: Create Your Character =====");
        }
    }
}
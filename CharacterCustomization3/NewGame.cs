using CharacterCustomization;
using System;
using System.Data.SqlClient;

namespace CharacterCreationSystem
{
    public struct CharacterDetails
    {
        public int id;
        public string name;
        public string age;
        public string gender;
        public string race;
        public string farmerType;

        public int strength;
        public int luck;
        public int speed;
        public int endurance;
        public int dexterity;
        public int intelligence;
        public string positiveEffect;
        public string negativeEffect;
        public string tools;
        public string accessories;
        public string clothes;

        public string faceshape;
        public string eyeshape;
        public string eyecolor;
        public string eyebrowshape;
        public string noseshape;
        public string mouthshape;
        public string earshape;
        public string facialhair;
        public string hairstyle;
        public string accessory;
        public string bodytype;
        public string skintone;

        public string title;
        public string titleDescription;
        public bool? emotionalState;
    }
    public class NewGame : IntroduceGame
    {
        CustomCharacterInfo customcharacterInfo = new CustomCharacterInfo();
        CustomAttributes customAttributes = new CustomAttributes();
        CustomAppearance customAppearance = new CustomAppearance();
        CharacterEmotionalState emotionalState = new CharacterEmotionalState();
        CharacterTitle characterTitle = new CharacterTitle();
        public void CreateCharacter()
        {
            Console.Clear();
            CharacterDetails chardetails = new CharacterDetails();
            Introduce();

            customcharacterInfo.CustomizeInfo();
            customAttributes.CustomizeAttribute();
            customAppearance.CustomizeAppearance();
            characterTitle.AssignTitle(chardetails);
            emotionalState.GetEmotionalState();

            chardetails.id = customcharacterInfo.getId();
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

            chardetails.faceshape = customAppearance.getFaceShape();
            chardetails.eyeshape = customAppearance.getEyeShape();
            chardetails.eyecolor = customAppearance.getEyeColor();
            chardetails.eyebrowshape = customAppearance.getEyebrowShape();
            chardetails.noseshape = customAppearance.getNoseShape();
            chardetails.mouthshape = customAppearance.getMouthShape();
            chardetails.earshape = customAppearance.getEarShape();
            chardetails.facialhair = customAppearance.getFacialHair();
            chardetails.hairstyle = customAppearance.getHairstyle();
            chardetails.accessory = customAppearance.getAccessory();
            chardetails.bodytype = customAppearance.getBodyType();
            chardetails.skintone = customAppearance.getSkinTone();

            chardetails.title = characterTitle.title;
            chardetails.titleDescription = characterTitle.description;
            chardetails.emotionalState = emotionalState.EmotionalState;

            chardetails.strength = customAttributes.GetStrength();
            chardetails.luck = customAttributes.GetLuck();
            chardetails.speed = customAttributes.GetSpeed();
            chardetails.endurance = customAttributes.GetEndurance();
            chardetails.dexterity = customAttributes.GetDexterity();
            chardetails.intelligence = customAttributes.GetIntelligence();

            try
            {
                string insertQueryString = "INSERT INTO dbo.CharacterDetails " +
                    "(Character_Id, Character_Name, Character_Age, Character_Gender, Character_Race, Character_FarmerType, " +
                    "Positive_Effect, Negative_Effect, Character_Strength, Character_Luck, Character_Speed, Character_Endurance, " +
                    "Character_Dexterity, Character_Intelligence, " +
                    "Character_Tools, Character_Accessories, Character_Clothes, " +
                    "Character_FaceShape, Character_EyeShape, Character_EyeColor, Character_EyebrowShape, Character_NoseShape, " +
                    "Character_MouthShape, Character_EarShape, Character_FacialHair, Character_Hairstyle, Character_Accessory, " +
                    "Character_BodyType, Character_SkinTone, " +
                    "Character_Title, Character_TitleDescription, Character_EmotionalState) " +
                    "VALUES (@Id, @Name, @Age, @Gender, @Race, @FarmerType, @PositiveEffect, @NegativeEffect, " +
                    "@Strength, @Luck, @Speed, @Endurance, @Dexterity, @Intelligence, " +
                    "@Tools, @Accessories, @Clothes, " +
                    "@FaceShape, @EyeShape, @EyeColor, @EyebrowShape, @NoseShape, @MouthShape, " +
                    "@EarShape, @FacialHair, @Hairstyle, @Accessory, @BodyType, @SkinTone, @Title, @TitleDescription, @EmotionalState)";

                SqlCommand insertCommand = new SqlCommand(insertQueryString, MainMenu.con);

                insertCommand.Parameters.AddWithValue("@Id", chardetails.id);
                insertCommand.Parameters.AddWithValue("@Name", chardetails.name);
                insertCommand.Parameters.AddWithValue("@Age", chardetails.age);
                insertCommand.Parameters.AddWithValue("@Gender", chardetails.gender);
                insertCommand.Parameters.AddWithValue("@Race", chardetails.race);
                insertCommand.Parameters.AddWithValue("@FarmerType", chardetails.farmerType);
                insertCommand.Parameters.AddWithValue("@PositiveEffect", chardetails.positiveEffect);
                insertCommand.Parameters.AddWithValue("@NegativeEffect", chardetails.negativeEffect);
                insertCommand.Parameters.AddWithValue("@Tools", chardetails.tools);
                insertCommand.Parameters.AddWithValue("@Accessories", chardetails.accessories);
                insertCommand.Parameters.AddWithValue("@Clothes", chardetails.clothes);
                insertCommand.Parameters.AddWithValue("@Strength", chardetails.strength);
                insertCommand.Parameters.AddWithValue("@Luck", chardetails.luck);
                insertCommand.Parameters.AddWithValue("@Speed", chardetails.speed);
                insertCommand.Parameters.AddWithValue("@Endurance", chardetails.endurance);
                insertCommand.Parameters.AddWithValue("@Dexterity", chardetails.dexterity);
                insertCommand.Parameters.AddWithValue("@Intelligence", chardetails.intelligence);
                insertCommand.Parameters.AddWithValue("@FaceShape", chardetails.faceshape);
                insertCommand.Parameters.AddWithValue("@EyeShape", chardetails.eyeshape);
                insertCommand.Parameters.AddWithValue("@EyeColor", chardetails.eyecolor);
                insertCommand.Parameters.AddWithValue("@EyebrowShape", chardetails.eyebrowshape);
                insertCommand.Parameters.AddWithValue("@NoseShape", chardetails.noseshape);
                insertCommand.Parameters.AddWithValue("@MouthShape", chardetails.mouthshape);
                insertCommand.Parameters.AddWithValue("@EarShape", chardetails.earshape);
                insertCommand.Parameters.AddWithValue("@FacialHair", chardetails.facialhair);
                insertCommand.Parameters.AddWithValue("@Hairstyle", chardetails.hairstyle);
                insertCommand.Parameters.AddWithValue("@Accessory", chardetails.accessory);
                insertCommand.Parameters.AddWithValue("@BodyType", chardetails.bodytype);
                insertCommand.Parameters.AddWithValue("@SkinTone", chardetails.skintone);
                insertCommand.Parameters.AddWithValue("@Title", chardetails.title);
                insertCommand.Parameters.AddWithValue("@TitleDescription", chardetails.titleDescription);
                insertCommand.Parameters.AddWithValue("@EmotionalState",
    chardetails.emotionalState.HasValue ? (object)chardetails.emotionalState.Value : DBNull.Value);

                insertCommand.ExecuteNonQuery();
                //Console.WriteLine("--Added to Database");
            }
            catch (Exception ex) { Console.WriteLine("==Error inserting character into database: " + ex.Message); }


            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n\t===== Character Summary =====");
            Console.ResetColor();
            showCharacterDetail();


            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\t=== Character Stats ===");
            Console.ResetColor();
            showCharacterDetail(chardetails.strength, chardetails.luck, chardetails.speed, chardetails.endurance, chardetails.dexterity, chardetails.intelligence,
                chardetails.positiveEffect, chardetails.negativeEffect, chardetails.tools);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\t=== Appearance Details ===");
            Console.ResetColor();
            customAppearance.showDetailAppearance();
            showCharacterDetail(chardetails.accessories, chardetails.clothes);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\n\t=== Character Emotional State ===");
            Console.ResetColor();
            if (chardetails.emotionalState.HasValue)
            {
                if (chardetails.emotionalState.Value)
                { Console.WriteLine("Your emotional state is: Good"); }
                else { Console.WriteLine("Your emotional state is: Evil"); }
            }
            else { Console.WriteLine("Your emotional state is: Neutral"); }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\t=== Character Title ===");
            Console.ResetColor();
            Console.WriteLine($"{"Title:",-20} {chardetails.title}");
            Console.WriteLine($"{"Description:",-20} {chardetails.titleDescription}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();

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

            Console.WriteLine("===== NEW GAME: Create Your Character =====");
        }
    }
}
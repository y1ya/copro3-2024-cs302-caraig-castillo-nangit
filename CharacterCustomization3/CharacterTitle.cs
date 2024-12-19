using CharacterCustomization;
using System;
using System.Data.SqlClient;

namespace CharacterCreationSystem
{
    public class CharacterTitle
    {
        public void AssignTitle(ref CharacterDetails characterDetails)
        {
            if (characterDetails.farmerType == "Grain Farmer" || characterDetails.farmerType == "Vegetable Farmer")
            {
                if (characterDetails.strength >= 2 || characterDetails.intelligence >= 2)
                {
                    characterDetails.title = "Crop Master";
                    characterDetails.titleDescription = "A master cultivator recognized for their unmatched efficiency in crop growth and harvesting.";
                    return;
                }
            }
            else if (characterDetails.farmerType == "Livestock Farmer")
            {
                if (characterDetails.endurance >= 2 || characterDetails.luck >= 2)
                {
                    characterDetails.title = "Animal Caretaker";
                    characterDetails.titleDescription = "Renowned for an extraordinary connection with animals, ensuring their happiness and productivity.";
                    return;
                }
            }
            else if (characterDetails.farmerType == "Fruit Farmer" && (characterDetails.luck >= 2 || characterDetails.speed >= 2))
            {
                characterDetails.title = "Trailblazer";
                characterDetails.titleDescription = "A pioneering farmer who seeks untapped opportunities in agriculture.";
                return;
            }
            else if (characterDetails.tools == "Harvest Gloves" || characterDetails.clothes == "Farmer's Vest")
            {
                characterDetails.title = "Harvest Master";
                characterDetails.titleDescription = "A prominent figure in the farming world, celebrated for record-breaking harvests.";
                return;
            }           
            characterDetails.title = "Farmer";
            characterDetails.titleDescription = "A hardworking and dedicated farmer, committed to cultivating the land.";
        }
    }
}

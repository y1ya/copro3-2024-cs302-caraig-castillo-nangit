using System;

namespace CharacterCreationSystem
{
    public class CharacterTitle
    {
        private string title;
        private string description;


        public string AssignTitle(CharacterDetails characterDetails)
        {
            if (characterDetails.farmerType == "Grain Farmer" || characterDetails.farmerType == "Vegetable Farmer")
            {
                if (characterDetails.strength >= 2 || characterDetails.intelligence >= 2)
                {
                    title = "Crop Master";
                    description = "A master cultivator recognized for their unmatched efficiency in crop growth and harvesting.";
                }
            }
            else if (characterDetails.farmerType == "Livestock Farmer" || characterDetails.farmerType == "Animal Care Skills")
            {
                if (characterDetails.endurance >= 2 || characterDetails.luck >= 2)
                {
                    title = "Animal Caretaker";
                    description = "Renowned for an extraordinary connection with animals, ensuring their happiness and productivity.";
                }
            }
            else if (characterDetails.farmerType == "Harvesting Expertise" && characterDetails.tools == "Lucky Hoe")
            {
                title = "Harvest Master";
                description = "A prominent figure in the farming world, celebrated for record-breaking harvests.";
            }
            else if (characterDetails.farmerType == "Fruit Farmer" && (characterDetails.luck >= 2 || characterDetails.speed >= 2))
            {
                title = "Trailblazer";
                description = "A pioneering farmer who seeks untapped opportunities in agriculture.";
            }
            else if (characterDetails.farmerType == "Soil Management" && (characterDetails.intelligence >= 2 || characterDetails.strength >= 2))
            {
                title = "Soil Engineer";
                description = "Known for optimizing soil conditions for maximum productivity.";
            }
            else
            {
                title = "Farmer";
                description = "A hardworking and dedicated farmer, committed to cultivating the land.";
            }

            return $"{"Title: ", -20}{title} \n{"Description:", -19} {description}";
        }
    }
}

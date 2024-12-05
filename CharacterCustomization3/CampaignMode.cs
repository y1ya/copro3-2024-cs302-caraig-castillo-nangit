using System;
namespace CharacterCreationSystem
{
    public class CampaignMode
    {
        public void DisplayStory()
        {
            Console.Clear();
            Console.WriteLine("=== CAMPAIGN MODE: The Harvest of Legacy ===\n");
            string[] story = {
                            "\nIn a world where lush farmlands stretch as far as the eye can see, you step into the role of an aspiring farmer in the enchanting land of Striya.",
                            "    As your journey begins, your character—customizable in every detail from name to appearance—arrives in this tranquil yet vibrant countryside,",
                            "    ready to build their legacy. Striya is a land of diverse regions and traditions, shaped by the unique traits of its settlers.",
                            "    Each character race brings distinct advantages, influencing your farming experience. Will you master the fields of fruits and vegetables,",
                            "    aathrive in livestock cultivation, or pursue the arid lands with unwavering resolve?\n",
                            "    As you plant your roots in the community, every decision carves your story.",
                            "    Will you be a Mixed Farmer, exploring all trades, or a Livestock Specialist nurturing productive animals?",
                            "    Perhaps you’ll become a Grain Master or Fruit Farmer with unparalleled yields.",
                            "    Your specialization determines not only your skills but your standing within the village ecosystem.",
                            "    Equip powerful tools like the Crop Analyzer or Lucky Hoe to gain productivity while overcoming challenges.\n",
                            "    Life in Striya isn’t without trials.",
                            "    Positive effects like Enhanced Harvest offer advantages, while managing Negative Effects like Fatigue and Soil Degradation requires strategy.",
                            "    Emotional states shift based on your actions: will you gain fame as a benevolent community hero or infamy as a cunning profit-driven farmer?",
                            "    As you progress, unlock new skills, master irrigation, animal care, or crafting innovative tools.",
                            "    Will your legacy be one of community and goodwill, or dominance and ambition? The harvest in Striya isn’t just crops; it’s the story you sow.\n"
                        };
            foreach (string line in story)
            {
                effect(line, 10);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
        private void effect(string line, int delay)
        {
            foreach (char c in line)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
    }
}
using System;
using System.Threading;

namespace CharacterCreationSystem
{
    public class CampaignMode
    {
        public void DisplayStory()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Campaign Mode started...");
            Thread.Sleep(1000);
            Console.ResetColor();
            Console.Clear();

            string[] paragraph1 = {
                "  In a world where lush farmlands stretch as far as the eye can see, you step into the role of an aspiring farmer in the enchanting land of Striya.",
                "    As your journey begins, your character—customizable in every detail from name to appearance—arrives in this tranquil yet vibrant countryside,",
                "    ready to build their legacy. Striya is a land of diverse regions and traditions, shaped by the unique traits of its settlers.",
                "    Each character race brings distinct advantages, influencing your farming experience. Will you master the fields of fruits and vegetables,",
                "    and thrive in livestock cultivation, or pursue the arid lands with unwavering resolve?\n"
            };

            string[] paragraph2 = {
                "    As you plant your roots in the community, every decision carves your story.",
                "    Will you be a Mixed Farmer, exploring all trades, or a Livestock Specialist nurturing productive animals?",
                "    Perhaps you’ll become a Grain Master or Fruit Farmer with unparalleled yields.",
                "    Your specialization determines not only your skills but your standing within the village ecosystem.",
                "    Equip powerful tools like the Crop Analyzer or Lucky Hoe to gain productivity while overcoming challenges.\n"
            };

            string[] paragraph3 = {
                "    Life in Striya isn’t without trials.",
                "    Positive effects like Enhanced Harvest offer advantages, while managing Negative Effects like Fatigue and Soil Degradation requires strategy.",
                "    Emotional states shift based on your actions: will you gain fame as a benevolent community hero or infamy as a cunning profit-driven farmer?",
                "    As you progress, unlock new skills, master irrigation, animal care, or crafting innovative tools.",
                "    Will your legacy be one of community and goodwill, or dominance and ambition? The harvest in Striya isn’t just crops; it’s the story you sow.\n"
            };

            DisplayStoryWithChoice(paragraph1,paragraph2,paragraph3);
        }        

        private bool AskToSkipOrContinue()
        {
            int selectedOption = 0;
            string[] options = { 
                "Continue displaying the story line-by-line.", 
                "Skip the rest of the story and display the full text at once.\n" 
            };
            string space = "===";
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.Write(space);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CAMPAIGN MODE: The Harvest of Legacy ");
                Console.ResetColor();
                Console.WriteLine(space);
                Console.WriteLine("\nUse the arrow keys to navigate and press Enter to select an option:");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"  >> {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]}");
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedOption = (selectedOption == 0) ? options.Length - 1 : selectedOption - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedOption = (selectedOption == options.Length - 1) ? 0 : selectedOption + 1;
                }

            } while (key != ConsoleKey.Enter);

            return selectedOption == 0;
        }

        public void DisplayStoryWithChoice(string[] paragraph1, string[] paragraph2, string[] paragraph3)
        {
            string space = "----------------------------------------------------------------------------------------------------------------------\n";
            Console.Clear();

            if (AskToSkipOrContinue())
            {
                Console.WriteLine(space);
                Thread.Sleep(300);
                // Continue mode - display paragraph 1 line-by-line
                Console.ForegroundColor = ConsoleColor.Yellow;
                DisplayParagraph(paragraph1);
                Console.ResetColor();

                if (AskToSkipOrContinue())
                {
                    Console.WriteLine(space);
                    Thread.Sleep(250);
                    // Continue mode - display paragraph 2 line-by-line
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    DisplayParagraph(paragraph2);
                    Console.ResetColor();

                    if (AskToSkipOrContinue())
                    {
                        Console.WriteLine(space);
                        Thread.Sleep(250);
                        // Continue mode - display paragraph3 line-by-line
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        DisplayParagraph(paragraph3);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(space);
                        Thread.Sleep(250);
                        // Skip to full paragraph 3
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        DisplayFullParagraph(paragraph3);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine(space);
                    Thread.Sleep(250);
                    // Skip to full paragraphs 2 and 3
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    DisplayFullParagraph(paragraph2);
                    DisplayFullParagraph(paragraph3);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine(space);
                Thread.Sleep(250);
                // Skip mode - display all paragraphs at once
                Console.ForegroundColor = ConsoleColor.Yellow;
                DisplayFullParagraph(paragraph1);
                DisplayFullParagraph(paragraph2);
                DisplayFullParagraph(paragraph3);
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n    The story is complete, but your adventure is only starting. How will your legacy unfold in the land of Striya?\n");
            Console.ResetColor();

            Console.WriteLine(space);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ResetColor();
            Console.ReadKey();
        }

        private void DisplayParagraph(string[] paragraph)
        {
            foreach (string line in paragraph)
            {
                effect(line, 1);
                Console.WriteLine();
            }
        }

        private void DisplayFullParagraph(string[] paragraph)
        {
            foreach (string line in paragraph)
            {
                Console.WriteLine(line);
            }
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

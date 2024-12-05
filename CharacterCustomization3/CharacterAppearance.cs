using System;

namespace CharacterCustomization
{
    public interface IShowOps
    {
        void showFaceShapeOps();
        void showEyeShapeOps();
        void showEyeColorOps();
        void showEyebrowShapeOps();
        void showNoseShapeOps();
        void showMouthShapeOps();
        void showEarShapeOps();
        void showFacialHairOps();
        void showHairstyleOps1();
        void showHairstyleOps2();
        void showHairstyleOps3();
        void showHairstyleOps4();
        void showAccessoryOps();
        void showBodyTypeOps();
        void showSkinToneOps();
    }
    public class Appearance
    {
        private string faceShape;
        private string eyeShape;
        private string eyeColor;
        private string eyebrowShape;
        private string noseShape;
        private string mouthShape;
        private string earShape;
        private string facialHair;
        private string hairstyle;
        private string accessory;
        private string bodyType;
        private string skinTone;

        public Appearance(string faceshape, string eyeshape, string eyecolor, string eyebrowshape, string noseshape, string mouthshape,
            string earshape, string facialhair, string hairstyle, string accessory, string bodytype, string skintone)
        {
            this.faceShape = faceshape;
            this.eyeShape = eyeshape;
            this.eyeColor = eyecolor;
            this.eyebrowShape = eyebrowshape;
            this.noseShape = noseshape;
            this.mouthShape = mouthshape;
            this.earShape = earshape;
            this.facialHair = facialhair;
            this.hairstyle = hairstyle;
            this.accessory = accessory;
            this.bodyType = bodytype;
            this.skinTone = skintone;
        }

        public void setFaceShape(string faceshape) { this.faceShape = faceshape; }
        public void setEyeShape(string eyeshape) { this.eyeShape = eyeshape; }
        public void setEyeColor(string eyecolor) { this.eyeColor = eyecolor; }
        public void setEyebrowShape(string eyebrowshape) { this.eyebrowShape = eyebrowshape; }
        public void setNoseShape(string noseshape) {  this.noseShape = noseshape;   }
        public void setMouthShape(string mouthshape) {  this.mouthShape = mouthshape;   }
        public void setEarShape(string earshape) { this.earShape = earshape;    }
        public void setFacialHair(string facialhair) { this.facialHair = facialhair;    }
        public void setHairstyle(string hairstyle) { this.hairstyle += $"{hairstyle} ";    }
        public void setAccessory(string accessory) {  this.accessory = accessory; }
        public void setBodyType(string bodytype) { this.bodyType = bodytype; }
        public void setSkinTone(string skintone) { this.skinTone = skintone; }


        public string getFaceShape() { return faceShape; }
        public string getEyeShape() { return eyeShape; }
        public string getEyeColor() { return eyeColor; }
        public string getEyebrowShape() { return eyebrowShape; }
        public string getNoseShape() { return noseShape; }
        public string getMouthShape() { return mouthShape; }
        public string getEarShape() { return earShape; }
        public string getFacialHair() { return facialHair; }
        public string getHairstyle() { return hairstyle; }
        public string getAccessory() { return accessory; }
        public string getBodyType() { return bodyType; }
        public string getSkinTone() { return skinTone; }
    }
    public class CustomAppearance : CheckForErrors, IShowOps
    {
        private Appearance appearance;
        public CustomAppearance() { appearance = new Appearance("", "", "", "", "", "", "", "", "", "", "", ""); }
        public void CustomizeAppearance()
        {
            string hairstyle11 = "", hairstyle22 = "", hairstyle33 = "", hairstyle44 = "", input;

            bool loop = true;
            Console.WriteLine("\n=== Character Custom Apperance ===");
            while (loop)
            {
                try
                {
                    if (string.IsNullOrEmpty(appearance.getFaceShape()))
                    {
                        Console.WriteLine("\n=== Character Face Shape ===");
                        Console.WriteLine("Choose a Face Shape:");
                        showFaceShapeOps();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        appearance.setFaceShape(checkInput(input, new[] { "Oval", "Round", "Square", "Diamond", "Heart" }));
                    }

                    if (string.IsNullOrEmpty(appearance.getEyeShape()))
                    {
                        Console.WriteLine("\n=== Character Eye Shape ===");
                        Console.WriteLine("Choose an Eye Shape:");
                        showEyeShapeOps();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        appearance.setEyeShape(checkInput(input, new[] { "Almond", "Round", "Monoloid", "Droopy", "Upturned" }));
                    }

                    if (string.IsNullOrEmpty(appearance.getEyeColor()))
                    {
                        Console.WriteLine("\n=== Character Eye Color ===");
                        Console.WriteLine("Choose an Eye Color:");
                        showEyeColorOps();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        appearance.setEyeColor(checkInput(input, new[] { "Brown", "Blue", "Green", "Black", "Hazel" }));
                    }

                    if (string.IsNullOrEmpty(appearance.getEyebrowShape()))
                    {
                        Console.WriteLine("\n=== Character Eyebrow Shape ===");
                        Console.WriteLine("Choose an Eyebrow Shape:");
                        showEyebrowShapeOps();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        appearance.setEyebrowShape(checkInput(input, new[] { "Arch", "Straight", "Thick", "Thin", "Bushy", "Fine" }));
                    }

                    if (string.IsNullOrEmpty(appearance.getNoseShape()))
                    {
                        Console.WriteLine("\n=== Character Nose Shape ===");
                        Console.WriteLine("Choose a Nose Shape:");
                        showNoseShapeOps();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        appearance.setNoseShape(checkInput(input, new[] { "Button", "Aqualine", "Flat", "Long", "Short", "Roman" }));
                    }

                    if (string.IsNullOrEmpty(appearance.getMouthShape()))
                    {
                        Console.WriteLine("\n=== Character Mouth Shape ===");
                        Console.WriteLine("Choose a Mouth Shape:");
                        showMouthShapeOps();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        appearance.setMouthShape(checkInput(input, new[] { "Full Lips", "Thin Lips", "Wide", "Small", "Downturned" }));
                    }

                    if (string.IsNullOrEmpty(appearance.getEarShape()))
                    {
                        Console.WriteLine("\n=== Character Ear Shape ===");
                        Console.WriteLine("Choose an Ear Shape:");
                        showEarShapeOps();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        appearance.setEarShape(checkInput(input, new[] { "Small", "Pointed", "Rounded", "Elongated", "Wide" }));
                    }

                    if (string.IsNullOrEmpty(appearance.getFacialHair()))
                    {
                        Console.WriteLine("\n=== Choose a Facial Hair ===");
                        Console.WriteLine("Choose a Facial Hair:");
                        showFacialHairOps();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        appearance.setFacialHair(checkInput(input, new[] { "Stubble", "Full Beard", "Goatee", "Mustache", "Clean-Shaven", "None" }));
                    }

                    if (hairstyle11.Equals(""))
                    {
                        Console.WriteLine("\n=== Character Hairstyle ===");
                        Console.WriteLine("Choose a Hairstyle(Style):");
                        showHairstyleOps1();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        hairstyle11 = checkInput(input, new[] { "Curly", "Straight", "Braided", "Tied-Up", "Wavy", "Layered" });
                    }

                    if (hairstyle22.Equals(""))
                    {
                        Console.WriteLine("\nChoose a Hairstyle(Length):");
                        showHairstyleOps2();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        hairstyle22 = checkInput(input, new[] { "Short", "Medium", "Long", "Very Long", "Bald" });
                    }

                    if (hairstyle33.Equals(""))
                    {
                        Console.WriteLine("\nChoose a Hairstyle(Color):");
                        showHairstyleOps3();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        hairstyle33 = checkInput(input, new[] { "Black", "Brown", "Red", "Blonde", "Gray", "Platinum", "Pink" });
                    }

                    if (hairstyle44.Equals(""))
                    {
                        Console.WriteLine("\nChoose a Hairstyle(Texture):");
                        showHairstyleOps4();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        hairstyle44 = checkInput(input, new[] { "Silky", "Frizzy", "Thick", "Thin", "Coarse" });
                    }
                    appearance.setHairstyle($"{hairstyle11} {hairstyle22} {hairstyle33} {hairstyle33} {hairstyle44}");

                    if (string.IsNullOrEmpty(appearance.getAccessory()))
                    {
                        Console.WriteLine("\nChoose a Hairstyle(Accessory):");
                        showAccessoryOps();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        appearance.setAccessory(checkInput(input, new[] { "Headband", "Hair Clips", "Ribbon", "Beads", "Hats", "None" }));
                    }

                    if (string.IsNullOrEmpty(appearance.getBodyType()))
                    {
                        Console.WriteLine("\n=== Character Body Type ===");
                        Console.WriteLine("Choose a Body Type");
                        showBodyTypeOps();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        appearance.setBodyType(checkInput(input, new[] { "Slim", "Average", "Athletic", "Curvy", "Bulk", "Tall" }));
                    }

                    if (string.IsNullOrEmpty(appearance.getSkinTone()))
                    {
                        Console.WriteLine("\n=== Character Skin Tone ===");
                        Console.WriteLine("Choose a Skin Tone");
                        showSkinToneOps();
                        Console.Write("Enter Choice: ");
                        input = Console.ReadLine();
                        appearance.setSkinTone(checkInput(input, new[] { "Warm", "Cool", "Neutral", "Olive", "Deep" }));
                    }
                    break;
                }
                catch (OnlyOneCharacter ex) { Console.WriteLine("Error: " + ex.Message); }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("Error: " + ex.Message); }
            }
        }

        public void showDetailAppearance()
        {
            Console.WriteLine($"{"Face Shape:",-20} {appearance.getFaceShape()}");
            Console.WriteLine($"{"Eye Shape:",-20} {appearance.getEyeShape()}");
            Console.WriteLine($"{"Eye Color:",-20} {appearance.getEyeColor()}");
            Console.WriteLine($"{"Eyebrow Shape:",-20} {appearance.getEyebrowShape()}");
            Console.WriteLine($"{"Nose Shape:",-20} {appearance.getNoseShape()}");
            Console.WriteLine($"{"Mouth Shape:",-20} {appearance.getMouthShape()}");
            Console.WriteLine($"{"Ear Shape:",-20} {appearance.getEarShape()}");
            Console.WriteLine($"{"Facial Hair:",-20} {appearance.getFacialHair()}");
            Console.WriteLine($"{"Hairstyle:",-20} {appearance.getHairstyle()}");
            Console.WriteLine($"{"Accessory:",-20} {appearance.getAccessory()}");
            Console.WriteLine($"{"Body Type:",-20} {appearance.getBodyType()}");
            Console.WriteLine($"{"Skin Tone:",-20} {appearance.getSkinTone()}");
        }

        public void showFaceShapeOps()
        {
            Console.WriteLine("(a) Oval");
            Console.WriteLine("(b) Round");
            Console.WriteLine("(c) Square");
            Console.WriteLine("(d) Diamond");
            Console.WriteLine("(e) Heart");
        }
        public void showEyeShapeOps()
        {
            Console.WriteLine("(a) Almond");
            Console.WriteLine("(b) Round");
            Console.WriteLine("(c) Monoloid");
            Console.WriteLine("(d) Droopy");
            Console.WriteLine("(e) Upturned");
        }
        public void showEyeColorOps()
        {
            Console.WriteLine("(a) Brown");
            Console.WriteLine("(b) Blue");
            Console.WriteLine("(c) Green");
            Console.WriteLine("(d) Black");
            Console.WriteLine("(e) Hazel");
        }
        public void showEyebrowShapeOps()
        {
            Console.WriteLine("(a) Arch");
            Console.WriteLine("(b) Straight");
            Console.WriteLine("(c) Thick");
            Console.WriteLine("(d) Thin");
            Console.WriteLine("(e) Bushy");
            Console.WriteLine("(f) Fine");
        }
        public void showNoseShapeOps()
        {
            Console.WriteLine("(a) Button");
            Console.WriteLine("(b) Aquiline");
            Console.WriteLine("(c) Flat");
            Console.WriteLine("(d) Long");
            Console.WriteLine("(e) Short");
            Console.WriteLine("(f) Roman");
        }
        public void showMouthShapeOps()
        {
            Console.WriteLine("(a) Full Lips");
            Console.WriteLine("(b) Thin Lips");
            Console.WriteLine("(c) Wide");
            Console.WriteLine("(d) Small");
            Console.WriteLine("(e) Downturned");
        }
        public void showEarShapeOps()
        {
            Console.WriteLine("(a) Small");
            Console.WriteLine("(b) Pointed");
            Console.WriteLine("(c) Rounded");
            Console.WriteLine("(d) Elongated");
            Console.WriteLine("(e) Wide");
        }
        public void showFacialHairOps()
        {
            Console.WriteLine("(a) Stubble");
            Console.WriteLine("(b) Full Beard");
            Console.WriteLine("(c) Goatee");
            Console.WriteLine("(d) Mustache");
            Console.WriteLine("(e) Clean-Shaven");
            Console.WriteLine("(f) None");
        }
        public void showHairstyleOps1()
        {
            Console.WriteLine("(a) Curly");
            Console.WriteLine("(b) Straight");
            Console.WriteLine("(c) Braided");
            Console.WriteLine("(d) Tied-Up");
            Console.WriteLine("(e) Wavy");
            Console.WriteLine("(f) Layered");
        }
        public void showHairstyleOps2()
        {
            Console.WriteLine("(a) Short");
            Console.WriteLine("(b) Medium");
            Console.WriteLine("(c) Long");
            Console.WriteLine("(d) Very Long");
            Console.WriteLine("(e) Bald");
        }
        public void showHairstyleOps3()
        {
            Console.WriteLine("(a) Black");
            Console.WriteLine("(b) Brown");
            Console.WriteLine("(c) Red");
            Console.WriteLine("(d) Blonde");
            Console.WriteLine("(e) Gray");
            Console.WriteLine("(f) Platinum");
            Console.WriteLine("(g) Pink");
        }
        public void showHairstyleOps4()
        {
            Console.WriteLine("(a) Silky");
            Console.WriteLine("(b) Frizzy");
            Console.WriteLine("(c) Thick");
            Console.WriteLine("(d) Thin");
            Console.WriteLine("(e) Coarse");
        }
        public void showBodyTypeOps()
        {
            Console.WriteLine("(a) Slim");
            Console.WriteLine("(b) Average");
            Console.WriteLine("(c) Athletic");
            Console.WriteLine("(d) Curvy");
            Console.WriteLine("(e) Bulk");
            Console.WriteLine("(f) Tall");
        }
        public void showAccessoryOps()
        {
            Console.WriteLine("(a) Headband");
            Console.WriteLine("(b) Hair Clips");
            Console.WriteLine("(c) Ribbon");
            Console.WriteLine("(d) Beads");
            Console.WriteLine("(e) Hats");
            Console.WriteLine("(f) None");
        }
        public void showSkinToneOps()
        {
            Console.WriteLine("(a) Warm");
            Console.WriteLine("(b) Cool");
            Console.WriteLine("(c) Neutral");
            Console.WriteLine("(d) Olive");
            Console.WriteLine("(e) Deep");
        }
    }

    public class CheckForErrors
    {
        public static string checkInput(string input, string[] choose)
        {
            if (input.Length == 1)
            {
                return chosenOps(Char.Parse(input.ToLower()), choose);
            }
            else { throw new OnlyOneCharacter("Must be one character only"); }
        }

        public static string chosenOps(char letter, string[] choose)
        {
            string[] shapess = choose;

            switch (letter)
            {
                case 'a': return shapess[0];
                case 'b': return shapess[1];
                case 'c': return shapess[2];
                case 'd': return shapess[3];
                case 'e': return shapess[4];
                case 'f': return shapess[5];
                case 'g': return shapess[6];
                default: throw new IndexOutOfRangeException();
            }
        }
    }

    public class OnlyOneCharacter : Exception
    {
        public OnlyOneCharacter(string message) : base(message) { }
    }
}
using System;

namespace CharacterCustomization
{
    /*public interface IShowOps
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
    }*/
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
    public class CustomAppearance : CheckForErrors
    {
        private Appearance appearance;
        public CustomAppearance() { appearance = new Appearance("", "", "", "", "", "", "", "", "", "", "", ""); }
        public void CustomizeAppearance()
        {
            showFaceOps showfaceops = new showFaceOps();
            showEyeShapeOps showeyeshapeops = new showEyeShapeOps();
            showEyeColorOps showeyecolorops = new showEyeColorOps();
            showEyebrowOps showeyebrowshapeops = new showEyebrowOps();
            showNoseShapeOps shownoseshapeops = new showNoseShapeOps();
            showMouthShapeOps showmouthshapeops = new showMouthShapeOps();
            showEarShapeOps showearshapeops = new showEarShapeOps();
            showFacialHairOps showfacialhairops = new showFacialHairOps();
            showBodyTypeOps showbodytypeops = new showBodyTypeOps();
            showAccessoryOps showaccessoryops = new showAccessoryOps();
            showSkinToneOps showskintoneops = new showSkinToneOps();

            string hairstyle11 = "", hairstyle22 = "", hairstyle33 = "", hairstyle44 = "";

            Console.WriteLine("\n=== Character Custom Apperance ===");
            if (string.IsNullOrEmpty(appearance.getFaceShape()))
            {
                GetValidatedInput(
                    "Character Face Shape",
                    new[] { "Oval", "Round", "Square", "Diamond", "Heart" },
                    appearance.setFaceShape,
                    showfaceops.showOps
                );
            }

            if (string.IsNullOrEmpty(appearance.getEyeShape()))
            {
                GetValidatedInput(
                    "Character Eye Shape",
                    new[] { "Almond", "Round", "Monoloid", "Droopy", "Upturned" },
                    appearance.setEyeShape,
                    showeyeshapeops.showOps
                );
            }

            if (string.IsNullOrEmpty(appearance.getEyeColor()))
            {
                GetValidatedInput(
                    "Character Eye Color",
                    new[] { "Brown", "Blue", "Green", "Black", "Hazel" },
                    appearance.setEyeColor,
                    showeyecolorops.showOps
                );
            }

            if (string.IsNullOrEmpty(appearance.getEyebrowShape()))
            {
                GetValidatedInput(
                    "Character Eyebrow Shape",
                    new[] { "Arch", "Straight", "Thick", "Thin", "Bushy", "Fine" },
                    appearance.setEyebrowShape,
                    showeyebrowshapeops.showOps
                );
            }

            if (string.IsNullOrEmpty(appearance.getNoseShape()))
            {
                GetValidatedInput(
                    "Character Nose Shape",
                    new[] { "Button", "Aqualine", "Flat", "Long", "Short", "Roman" },
                    appearance.setNoseShape,
                    shownoseshapeops.showOps
                );
            }

            if (string.IsNullOrEmpty(appearance.getMouthShape()))
            {
                GetValidatedInput(
                    "Character Mouth Shape",
                    new[] { "Full Lips", "Thin Lips", "Wide", "Small", "Downturned" },
                    appearance.setMouthShape,
                    showmouthshapeops.showOps
                );
            }

            if (string.IsNullOrEmpty(appearance.getEarShape()))
            {
                GetValidatedInput(
                    "Character Ear Shape",
                    new[] { "Small", "Pointed", "Rounded", "Elongated", "Wide" },
                    appearance.setEarShape,
                    showearshapeops.showOps
                );
            }

            if (string.IsNullOrEmpty(appearance.getFacialHair()))
            {
                GetValidatedInput(
                    "Character Facial Hair",
                    new[] { "Stubble", "Full Beard", "Goatee", "Mustache", "Clean-Shaven", "None" },
                    appearance.setFacialHair,
                    showfacialhairops.showOps
                );
            }

            if (hairstyle11.Equals(""))
            {
                GetValidatedInput(
                    "Character Hairstyle(Style)",
                    new[] { "Curly", "Straight", "Braided", "Tied-Up", "Wavy", "Layered" },
                    appearance.setHairstyle,
                    showHairstyleOps1
                );
            }

            if (hairstyle22.Equals(""))
            {
                GetValidatedInput(
                    "Character Hairstyle(Color)",
                    new[] { "Black", "Brown", "Red", "Blonde", "Gray", "Platinum", "Pink" },
                    appearance.setHairstyle,
                    showHairstyleOps2
                );
            }

            if (hairstyle33.Equals(""))
            {
                GetValidatedInput(
                    "Character Hairstyle(Color)",
                    new[] { "Black", "Brown", "Red", "Blonde", "Gray", "Platinum", "Pink" },
                    appearance.setHairstyle,
                    showHairstyleOps3
                );
            }

            if (hairstyle44.Equals(""))
            {
                GetValidatedInput(
                    "Character Hairstyle(Texture)",
                    new[] { "Silky", "Frizzy", "Thick", "Thin", "Coarse" },
                    appearance.setHairstyle,
                    showHairstyleOps4
                );
            }

            if (string.IsNullOrEmpty(appearance.getAccessory()))
            {
                GetValidatedInput(
                    "Character Hairstyle(Accessory)",
                    new[] { "Headband", "Hair Clips", "Ribbon", "Beads", "Hats", "None" },
                    appearance.setAccessory,
                    showaccessoryops.showOps
                );
            }

            if (string.IsNullOrEmpty(appearance.getBodyType()))
            {
                GetValidatedInput(
                    "Character Body Type",
                    new[] { "Slim", "Average", "Athletic", "Curvy", "Bulk", "Tall" },
                    appearance.setBodyType,
                    showbodytypeops.showOps
                );
            }

            if (string.IsNullOrEmpty(appearance.getSkinTone()))
            {
                GetValidatedInput(
                    "Character Skin Tone",
                    new[] { "Warm", "Cool", "Neutral", "Olive", "Deep" },
                    appearance.setSkinTone,
                    showskintoneops.showOps
                );
            }
        }

        public void GetValidatedInput(string prompt, string[] options, Action<string> setAction, Action showOptions)
        {
            bool valid = false;
            while (!valid)
            {
                try
                {
                    Console.WriteLine($"\n=== {prompt} ===");
                    showOptions.Invoke();
                    Console.Write("Enter Choice: ");
                    string input = Console.ReadLine();
                    setAction.Invoke(checkInput(input, options));
                    break;
                }
                catch (OnlyOneCharacter ex) { Console.WriteLine("Error: " + ex.Message); }
                catch (IndexOutOfRangeException ex) { Console.WriteLine("Error: " + ex.Message); }
                catch (OnlyLetterException ex) { Console.WriteLine("Error: " + ex.Message); }
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
    }

    public class showFaceOps : IShowOps
    {
        public override void showOps()
        {
            Console.WriteLine("(a) Oval");
            Console.WriteLine("(b) Round");
            Console.WriteLine("(c) Square");
            Console.WriteLine("(d) Diamond");
            Console.WriteLine("(e) Heart");
        }
    }
    public class showEyeShapeOps : IShowOps
    {
        public override void showOps()
        {
            Console.WriteLine("(a) Almond");
            Console.WriteLine("(b) Round");
            Console.WriteLine("(c) Monolid");
            Console.WriteLine("(d) Droopy");
            Console.WriteLine("(e) Upturned");
        }
    }
    public class showEyeColorOps : IShowOps
    {
        public override void showOps()
        {
            Console.WriteLine("(a) Brown");
            Console.WriteLine("(b) Blue");
            Console.WriteLine("(c) Green");
            Console.WriteLine("(d) Black");
            Console.WriteLine("(e) Hazel");
        }
    }
    public class showEyebrowOps : IShowOps
    {
        public override void showOps()
        {
            Console.WriteLine("(a) Arch");
            Console.WriteLine("(b) Straight");
            Console.WriteLine("(c) Thick");
            Console.WriteLine("(d) Thin");
            Console.WriteLine("(e) Bushy");
            Console.WriteLine("(f) Fine");
        }
    }
    public class showNoseShapeOps : IShowOps
    {
        public override void showOps()
        {
            Console.WriteLine("(a) Button");
            Console.WriteLine("(b) Aquiline");
            Console.WriteLine("(c) Flat");
            Console.WriteLine("(d) Long");
            Console.WriteLine("(e) Short");
            Console.WriteLine("(f) Roman");
        }
    }
    public class showMouthShapeOps : IShowOps
    {
        public override void showOps()
        {
            Console.WriteLine("(a) Full Lips");
            Console.WriteLine("(b) Thin Lips");
            Console.WriteLine("(c) Wide");
            Console.WriteLine("(d) Small");
            Console.WriteLine("(e) Downturned");
        }
    }
    public class showEarShapeOps : IShowOps
    {
        public override void showOps()
        {
            Console.WriteLine("(a) Small");
            Console.WriteLine("(b) Pointed");
            Console.WriteLine("(c) Rounded");
            Console.WriteLine("(d) Elongated");
            Console.WriteLine("(e) Wide");
        }
    }
    public class showFacialHairOps : IShowOps
    {
        public override void showOps()
        {
            Console.WriteLine("(a) Stubble");
            Console.WriteLine("(b) Full Beard");
            Console.WriteLine("(c) Goatee");
            Console.WriteLine("(d) Mustache");
            Console.WriteLine("(e) Clean-Shaven");
            Console.WriteLine("(f) None");
        }
    }
    public class showBodyTypeOps : IShowOps
    {
        public override void showOps()
        {
            Console.WriteLine("(a) Slim");
            Console.WriteLine("(b) Average");
            Console.WriteLine("(c) Athletic");
            Console.WriteLine("(d) Curvy");
            Console.WriteLine("(e) Bulk");
            Console.WriteLine("(f) Tall");
        }
    }
    public class showAccessoryOps : IShowOps
    {
        public override void showOps()
        {
            Console.WriteLine("(a) Headband");
            Console.WriteLine("(b) Hair Clips");
            Console.WriteLine("(c) Ribbon");
            Console.WriteLine("(d) Beads");
            Console.WriteLine("(e) Hats");
            Console.WriteLine("(f) None");
        }
    }
    public class showSkinToneOps : IShowOps
    {
        public override void showOps()
        {
            Console.WriteLine("(a) Warm");
            Console.WriteLine("(b) Cool");
            Console.WriteLine("(c) Neutral");
            Console.WriteLine("(d) Olive");
            Console.WriteLine("(e) Deep");
        }
    }
}
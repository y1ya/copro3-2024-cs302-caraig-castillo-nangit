using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CharacterCustomization
{
    public abstract class IShowOps
    {
        public abstract void showOps();
    }

    public abstract class IntroduceGame
    {
        public virtual void Introduce()
        {
            Console.WriteLine("Welcome to the Character Creation Menu!\n");
        }
    }

    public class CheckForErrors
    {
        public static string checkInput(string input, string[] choose)
        {
            if (!Regex.IsMatch(input, @"^[a-zA-Z\s]+$")) { throw new OnlyLetterException("Must be One Letter"); }

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

    public class OnlyLetterException : Exception
    {
        public OnlyLetterException(string message) : base(message) { }
    }

    public class InvalidResponseException : Exception
    {
        public InvalidResponseException(string message) : base(message) { }
    }
}

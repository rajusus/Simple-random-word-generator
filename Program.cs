using System;

namespace Generator_slov
{
    class Program
    {
        public static void randomWordGenerator(int wordCount, bool structuredWord, bool specialChars) 
        {
            Console.WriteLine("\n");
            Random random = new Random();
            char[] output = new char[wordCount];

            if (structuredWord)
            {
                string vowels = "aeiouy";
                string consonants = "bcdfghjklmnpqrstvwxz";

                bool vowelTime = true;
                if (random.Next(0, 2) == 0) vowelTime = false;

                for (int j = 0; j < wordCount; j++)
                {
                    if (vowelTime)
                    {
                        output[j] = vowels[random.Next(0, vowels.Length)];
                        vowelTime = false;
                    }
                    else
                    {
                        output[j] = consonants[random.Next(0, consonants.Length)];
                        vowelTime = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < wordCount; i++)
                {
                    int code = 0;
                    if (specialChars) code = random.Next(33, 127);
                    else
                    {
                        byte rnd = (byte)random.Next(1, 4);
                        switch (rnd)
                        {
                            case 1: // Numbers
                                code = random.Next(48, 58);
                                break;
                            case 2: // Capital letters
                                code = random.Next(65, 91);
                                break;
                            case 3: // small letters
                                code = random.Next(97, 123);
                                break;
                        }
                    }
                    output[i] = Convert.ToChar(code);
                }
            }
            Console.WriteLine(output);
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            while (true)
            {
                Console.WriteLine("How many words do you want to generate?");
                var wordCount = Console.ReadLine();
                Console.WriteLine("Should the length of a word be fixed? (Y/N)");
                var theLengthShouldBeFixed = Console.ReadLine();
                Console.WriteLine("Should the word be readable? (Y/N)");
                var structuredWord = Console.ReadLine();
                bool wordIsStructured = true;
                bool specialChars = false;
                if (structuredWord == "N" || structuredWord == "n")
                {
                    wordIsStructured = false;
                    Console.WriteLine("Can the word contain special characters? (Y/N)");
                    var specialCharsYes = Console.ReadLine();
                    if (specialCharsYes == "Y" || specialCharsYes == "y")
                    {
                        specialChars = true;
                    }
                }

                if (theLengthShouldBeFixed == "Y" || theLengthShouldBeFixed == "y")
                {
                    Console.WriteLine("How many characters should a word have?");
                    var charCount = Console.ReadLine();
                    for (int i = 0; i < Convert.ToInt32(wordCount); i++)
                        randomWordGenerator(Convert.ToInt32(charCount), wordIsStructured, specialChars);
                }
                else if (theLengthShouldBeFixed == "N" || theLengthShouldBeFixed == "n")
                {
                    Console.WriteLine("What is the minimal length a word should have?");
                    var minimalLength = Console.ReadLine();
                    Console.WriteLine("What is the maximal length a word should have?");
                    var maxLength = Console.ReadLine();
                    for (int i = 0; i < Convert.ToInt32(wordCount); i++)
                        randomWordGenerator(random.Next(Convert.ToInt32(minimalLength), Convert.ToInt32(maxLength) + 1), wordIsStructured, specialChars);
                }
                else
                {
                    Console.WriteLine("Your inputs were wrong, please answer Y or N");
                }
                
                Console.WriteLine("\n\n");
            }
        }
    }
}

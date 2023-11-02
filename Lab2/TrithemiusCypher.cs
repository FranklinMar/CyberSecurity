using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1;

namespace Lab2
{
    public class TrithemiusCypher: ICypher
    {
        public string Name { get; set; }
        protected string ALPHABET;
        public string Alphabet
        {
            get
            {
                return ALPHABET;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException(nameof(Alphabet)); // "Empty string"
                }
                ALPHABET = value;
                ASCENDING = ALPHABET;
                DESCENDING = new string(ALPHABET.ToCharArray().Reverse().ToArray());
            }
        }

        public string ASCENDING { get; private set; }
        public string DESCENDING { get; private set; }

        protected string KEY;
        public string Key
        {
            get
            {
                return KEY;
            }
            set
            {
                /*if (value.Length > Alphabet.Length)
                {
                    throw new ArgumentOutOfRangeException("Key is bigger than the alphabet");
                }*/
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentException("Null or empty string as a key");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!ALPHABET.Contains(char.ToLower(value[i])))
                    {
                        throw new ArgumentException("Non-alphabet character detected in the key");
                    }
                }
                KEY = value.ToLower();
            }
        }

        public TrithemiusCypher(string Alphabet, string Key = null)
        {
            this.Alphabet = Alphabet;
            if (Key == null)
            {
                this.Key = ASCENDING;
            } else
            {
                this.Key = Key;
            }
            //this.Key = Key;
        }

        public string Encrypt(string Text)
        {
            //throw new NotImplementedException();
            int Counter = 0;
            StringBuilder Result = new();
            char EncryptedChar;
            bool Upper;
            for (int i = 0; i < Text.Length; i++)
            {
                if (Alphabet.Contains(char.ToLower(Text[i])))
                {
                    Upper = char.IsUpper(Text[i]);
                    //Console.WriteLine(Counter % Key.Length);
                    EncryptedChar = Alphabet[(Alphabet.IndexOf(char.ToLower(Text[i])) + Alphabet.IndexOf(Key[Counter % Key.Length])) % Alphabet.Length];
                    EncryptedChar = Upper ? char.ToUpper(EncryptedChar) : EncryptedChar;
                    Counter++;
                }
                else
                {
                    EncryptedChar = Text[i];
                }
                Result.Append(EncryptedChar);
            }
            return Result.ToString();
        }

        public string Decrypt(string Text)
        {
            //throw new NotImplementedException();
            int Counter = 0;
            StringBuilder Result = new();
            char DecryptedChar;
            bool Upper;
            for (int i = 0; i < Text.Length; i++)
            {
                if (Alphabet.Contains(char.ToLower(Text[i])))
                {
                    Upper = char.IsUpper(Text[i]);
                    //Console.WriteLine((Alphabet.IndexOf(char.ToLower(Text[i])) - Alphabet.IndexOf(Key[Counter % Key.Length]) + Alphabet.Length) % Alphabet.Length);
                    DecryptedChar = Alphabet[(Alphabet.IndexOf(char.ToLower(Text[i])) - Alphabet.IndexOf(Key[Counter % Key.Length]) + Alphabet.Length) % Alphabet.Length];
                    DecryptedChar = Upper ? char.ToUpper(DecryptedChar) : DecryptedChar;
                    Counter++;
                }
                else
                {
                    DecryptedChar = Text[i];
                }
                Result.Append(DecryptedChar);
            }
            return Result.ToString();
        }
    }
}

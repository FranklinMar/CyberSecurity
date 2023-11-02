using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Cypher: ICypher
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
                /*for (int i = 0; i < value.Length - 1; i++)
                {
                    if (value[i] < value[i + 1])
                    {
                        throw new ArgumentException("Alphabet not sorted");
                    }
                }*/
                ALPHABET = value;
            }
        }
        protected string KEY;
        //private string KEY;
        public string Key
        {
            get
            {
                return KEY;
            }
            set
            {
                if (int.Parse(value) <= 0 || int.Parse(value) > Alphabet.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(Key)); // "Out of range of alphabet"
                }
                if (!value.All(Char => char.IsLower(Char)))
                {
                    throw new ArgumentException("Key must be lowercase");
                }

                KEY = value;
            }
        }
        public int KeyInt
        {
            get
            {
                return int.Parse(KEY);
            }
            set
            {
                if (value <= 0 || value > Alphabet.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(KeyInt)); // "Out of range of alphabet"
                }
                KEY = value.ToString();
            }
        }

        public Cypher(string Alphabet, int Key = 1)
        {
            this.Alphabet = Alphabet;
            this.KeyInt = Key;
        }

        public string Encrypt(string Text)
        {
            StringBuilder Result = new();
            char EncryptedChar;
            bool Upper;
            for (int i = 0; i < Text.Length; i++)
            {
                if (Alphabet.Contains(char.ToLower(Text[i])))
                {
                    Upper = char.IsUpper(Text[i]);
                    //EncryptedChar = (char)(((char.ToLower(Text[i]) + Key - Alphabet[0]) % Alphabet.Length) + Alphabet[0]);
                    EncryptedChar = Alphabet[(Alphabet.IndexOf(char.ToLower(Text[i])) + KeyInt) % Alphabet.Length];
                    EncryptedChar = Upper ? char.ToUpper(EncryptedChar) : EncryptedChar;
                } else {
                    EncryptedChar = Text[i];
                }
                Result.Append(EncryptedChar);
            }
            //Console.WriteLine(Result.ToString());
            return Result.ToString();
        }

        public string Decrypt(string Text)
        {
            StringBuilder Result = new();
            char DecryptedChar;
            bool Upper;
            for (int i = 0; i < Text.Length; i++)
            {
                if (Alphabet.Contains(char.ToLower(Text[i])))
                {
                    Upper = char.IsUpper(Text[i]);
                    //DecryptedChar = (char)(((char.ToLower(Text[i]) - Key - Alphabet[0]) % Alphabet.Length) + Alphabet[0]);
                    DecryptedChar = Alphabet[(Alphabet.IndexOf(char.ToLower(Text[i])) - KeyInt + Alphabet.Length) % Alphabet.Length];
                    DecryptedChar = Upper ? char.ToUpper(DecryptedChar) : DecryptedChar;
                } else {
                    DecryptedChar = Text[i];
                }
                Result.Append(DecryptedChar);
            }
            //Console.WriteLine(Result.ToString());
            return Result.ToString();
        }
    }
}

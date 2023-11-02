using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class BruteCracker : ICracker
    {
        private Cypher CYPHER { get; set; }
        public ICypher Cypher {
            get
            {
                return CYPHER;
            }
            set
            {
                if (!(value is Cypher))
                {
                    throw new ArgumentException("Invalid type of Cypher property");
                }
                CYPHER = value as Cypher;
            }
        }
        public string Key { 
            get
            {
                return Cypher.Key;
            }
            set
            {
                Cypher.Key = value;
            }
        }
        private string[] Dictionary;
        public BruteCracker(Cypher Cypher, string Dictionary)
        {
            this.Cypher = Cypher;
            List<string> ListDict = new();
            using (StreamReader reader = new(
                new FileStream(Dictionary, FileMode.Open), new UTF8Encoding()))
            {
                while (!reader.EndOfStream) { 
                    ListDict.Add(reader.ReadLine().ToLower());
                }
            }
            this.Dictionary = ListDict.ToArray();
        }

        public string Crack(string Text)
        {
            int Key = 0;
            int MatchingWords;
            string[] Words = Text.Split(' ');
            for (int i = 1; i <= Cypher.Alphabet.Length; i++)
            {
                CYPHER.KeyInt = i;
                MatchingWords = 0;
                for (int j = 0; j < Words.Length; j++)
                {
                    string Word = Cypher.Decrypt(Words[j]);
                    Word = new string(Word.Where(c => !char.IsPunctuation(c)).ToArray());
                    Word = Word.ToLower();
                    if (Dictionary.Contains(Word))
                    {
                        MatchingWords++;
                    }
                }
                if (MatchingWords / Words.Length >= 0.5)
                {
                    Key = i;
                    break;
                }
            }
            try
            {
                CYPHER.KeyInt = Key;
                return Cypher.Decrypt(Text);
            } catch (ArgumentOutOfRangeException)
            {
                throw new Exception("Unable to crack the cypher.");
            }
        }
        
        public string Crack(string PlainText, string EncryptedText)
        {
            return Crack(EncryptedText);
        }
   }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using NetSpell.SpellChecker.Dictionary;
// using NetSpell.SpellChecker; 

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
        //private WordDictionary Dictionary { get; set; } = new();
        //private string Dictionary;
        //public Spelling Spelling { get; private set; }
        public BruteCracker(Cypher Cypher, string Dictionary)
        {
            this.Cypher = Cypher;
            // this.Dictionary.DictionaryFile = Dictionary;
            // this.Dictionary.Initialize();
            // Spelling = new();
            //StringBuilder Reader = new();
            List<string> ListDict = new();
            using (StreamReader reader = new(
                new FileStream(Dictionary, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
            {
                while (!reader.EndOfStream) { 
                    ListDict.Add(reader.ReadLine().ToLower());
                }
                // ...
            }
            this.Dictionary = ListDict.ToArray();
            //this.Dictionary = Reader.ToString().Split('\n');
        }

        public string Crack(string Text)
        {
            //Console.WriteLine();
            int Key = 0;
            int MatchingWords;
            string[] Words = Text.Split(' ');
            for (int i = 1; i <= Cypher.Alphabet.Length; i++)
            {
                CYPHER.KeyInt = i;
                MatchingWords = 0;
                for (int j = 0; j < Words.Length; j++)
                {
                    //if (Spelling.TestWord(Cypher.Decrypt(Words[j])))
                    // Console.WriteLine($"'{Dictionary[0]}'");
                    // Console.WriteLine($"'{Cypher.Decrypt(Words[j])}'");
                    string Word = Cypher.Decrypt(Words[j]);
                    Word = new string(Word.Where(c => !char.IsPunctuation(c)).ToArray());
                    Word = Word.ToLower();
                    // Console.WriteLine($"'{Word}'");
                    // Console.WriteLine(Array.Exists(Dictionary, word => word == Word));
                    // Console.WriteLine();
                    if (Dictionary.Contains(Word))
                    {
                        MatchingWords++;
                        // Key = i;
                        // break;
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

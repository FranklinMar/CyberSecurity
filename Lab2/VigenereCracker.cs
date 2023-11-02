using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Lab1;
using System.IO;

namespace Lab2
{
    public class VigenereCracker: ICracker
    {
        private TrithemiusCypher CYPHER { get; set; }
        public ICypher Cypher
        {
            get
            {
                return CYPHER;
            }
            set
            {
                if (!(value is TrithemiusCypher))
                {
                    throw new ArgumentException("Invalid type of Cypher property");
                }
                CYPHER = value as TrithemiusCypher;
                _Regex = $"[^{CYPHER.Alphabet[0]}-{CYPHER.Alphabet[CYPHER.Alphabet.Length - 1]}]";
            }
        }
        public string Key
        {
            get
            {
                return Cypher.Key;
            }
            set
            {
                Cypher.Key = value;
            }
        }
        //private string[] Dictionary;
        private string _Regex;
        public VigenereCracker(TrithemiusCypher Cypher/*, string Dictionary*/)
        {
            this.Cypher = Cypher;
            /*List<string> ListDict = new();
            using (StreamReader reader = new(
                new FileStream(Dictionary, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
            {
                while (!reader.EndOfStream)
                {
                    ListDict.Add(reader.ReadLine().ToLower());
                }
                // ...
            }
            this.Dictionary = ListDict.ToArray();*/
        }

        public string Crack(string Text)
        {
            throw new NotImplementedException();
        }
        
        public string Crack(string PlainText, string EncryptedText)
        {
            var KeysLengths = KasiskiExamination(EncryptedText);
            var Keys = KeysExamination(PlainText, EncryptedText, KeysLengths);
            if (PlainText.Length != EncryptedText.Length)
            {
                throw new ArgumentException("Encrypted and decrypted texts have different lengths");
            }

            try
            {
                Cypher.Key = Keys.First(Pair => Pair.Value.Equals(Keys.Values.Max())).Key;
                return Cypher.Key;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new Exception("Unable to crack the cypher.");
            }
        }

        public Dictionary<string, int> KeysExamination(string PlainText, string EncryptedText, List<int> KeysLengths)
        {
            // int MatchingWords;
            PlainText = new string(PlainText.Where(c => char.IsLetter(c)).ToArray());
            EncryptedText = new string(EncryptedText.Where(c => char.IsLetter(c)).ToArray());
            string[] PlainWords = PlainText.Split(' ');
            string[] EncryptedWords = EncryptedText.Split(' ');
            StringBuilder Key;
            Dictionary<string, int> Result = new();
            if (PlainWords.Length != EncryptedWords.Length)
            {
                throw new ArgumentException("Encrypted and decrypted don't match by lengths");
            }
            /*int MaxIndex = 0;
            int Max = PlainWords[0].Length;*/
            for (int i = 0; i < PlainWords.Length; i++)
            {
                if (PlainWords[i].Length != EncryptedWords[i].Length)
                {
                    throw new ArgumentException("Encrypted and decrypted don't match by word lengths");
                }
                /*if (PlainWords[i].Length > Max)
                {
                    Max = PlainWords[i].Length;
                    MaxIndex = i;
                }*/
            }
            string WholePlainText = Regex.Replace(PlainText, _Regex, "");
            string WholeEncryptedText = Regex.Replace(EncryptedText, _Regex, "");
            //string PlainWord;
            //string EncryptedWord;
            for (int i = 0; i < KeysLengths.Count; i++)
            {
                //MatchingWords = 0;
                Key = new();
                for (int j = 0; j < KeysLengths[i]; j++)
                {
                    int Index = (Cypher.Alphabet.IndexOf(WholeEncryptedText[j]) - Cypher.Alphabet.IndexOf(WholePlainText[j]) + Cypher.Alphabet.Length) % Cypher.Alphabet.Length;
                    Key.Append(Cypher.Alphabet[Index]);
                }
                Cypher.Key = Key.ToString();
                Result[Cypher.Key] = 0;
                EncryptedWords = Cypher.Decrypt(EncryptedText).Split(" ");
                
                for (int j = 0; j < EncryptedWords.Length; j++)
                {
                    if (EncryptedWords[j] == PlainWords[j])
                    {
                        Result[Cypher.Key]++;
                    }
                }
            }
            return Result;
        }

        public List<int> KasiskiExamination(string Text)
        {
            var SequenceSpacing = FindRepeatedSequencesSpacings(Text);
            var SequenceList = (from Sequence in SequenceSpacing.Values from Spacing in Sequence select GetUsefulFactors(Spacing)).ToList();

            var LikelyKeyLengths = GetMostCommonFactors(SequenceList);
            var SortedFactors = (from entry in LikelyKeyLengths orderby entry.Value descending select entry)
                     .Take(3)
                     .ToDictionary(pair => pair.Key, pair => pair.Value);

            return SortedFactors.Keys.ToList();
        }

        public Dictionary<string, List<int>> FindRepeatedSequencesSpacings(string message)
        {
            Dictionary<string, List<int>> Result = new();

            string FilteredMessage = Regex.Replace(message.ToLower(), _Regex, "");
            string CurrentSequence;
            int SequencePos;
            int LengthApart;
            for (int i = 1; i < FilteredMessage.Length; i++)
            {
                for (int j = 0; j < FilteredMessage.Length - i; j++)
                {
                    CurrentSequence = FilteredMessage.Substring(j, i);
                    SequencePos = FilteredMessage.IndexOf(CurrentSequence, j + 1, StringComparison.Ordinal);
                    while (SequencePos > 0)
                    {
                        LengthApart = (SequencePos + i) - (j - i);
                        if (!Result.ContainsKey(CurrentSequence))
                        {
                            Result.Add(CurrentSequence, new List<int>());
                        }
                        if (!Result[CurrentSequence].Contains(LengthApart))
                        {
                            Result[CurrentSequence].Add(LengthApart);
                        }
                        SequencePos = FilteredMessage.IndexOf(CurrentSequence, SequencePos + 1, StringComparison.Ordinal);
                    }
                }
            }
            return Result;
        }

        public List<int> GetUsefulFactors(int number)
        {
            List<int> Result = new();

            for (int i = 2; i <= number; i++)
            {
                if (number % i == 0)
                {
                    Result.Add(i);
                }
            }
            return Result;
        }

        public Dictionary<int, int> GetMostCommonFactors(List<List<int>> SequenceFactors)
        {
            Dictionary<int, int> Result = new();
            foreach(var Factor in SequenceFactors.SelectMany(factor => factor))
            {
                if (!Result.ContainsKey(Factor))
                {
                    Result.Add(Factor, 1);
                } 
                else
                {
                    Result[Factor]++;
                }
            }
            return Result;
        }
    }
}

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
    public class TrithemiusCracker: ICracker;
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
        private string[] Dictionary;
        public TrithemiusCracker(TrithemiusCypher Cypher, string Dictionary)
        {
            this.Cypher = Cypher;
            List<string> ListDict = new();
            using (StreamReader reader = new(
                new FileStream(Dictionary, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
            {
                while (!reader.EndOfStream)
                {
                    ListDict.Add(reader.ReadLine().ToLower());
                }
                // ...
            }
            this.Dictionary = ListDict.ToArray();
        }

        public string Crack(string Text)
        {
            /*int Key = 0;
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
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new Exception("Unable to crack the cypher.");
            }*/
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

            string FilteredMessage = Regex.Replace(message.ToLower(), $"[^{Cypher.Alphabet[0]}-{Cypher.Alphabet[Cypher.Alphabet.Length - 1]}]", "");
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

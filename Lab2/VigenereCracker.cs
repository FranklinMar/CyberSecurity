using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Lab1;

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
                _Regex = $"[^{CYPHER.Alphabet}]";
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
        private string _Regex;
        public VigenereCracker(TrithemiusCypher Cypher)
        {
            this.Cypher = Cypher;
        }

        public string Crack(string Text)
        {
            throw new NotImplementedException();
        }
        
        public string Crack(string PlainText, string EncryptedText)
        {
            //var KeysLengths = KasiskiExamination(EncryptedText);
            //KeysLengths.ForEach(item => Console.WriteLine($"\t{item}"));
            var KeysLengths = GenerateKeys(EncryptedText);
            var Keys = KeysExamination(PlainText, EncryptedText/*);*/, KeysLengths);
            //Keys.ToList().ForEach(item => Console.WriteLine($"\t{item.Key} - {item.Value}"));
            if (PlainText.Length != EncryptedText.Length)
            {
                throw new ArgumentException($"Encrypted and decrypted texts have different lengths\n" +
                    $"Plain: {PlainText.Length}\nEncrypted: {EncryptedText.Length}");
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

        public List<int> GenerateKeys(string EncryptedText)
        {
            List<int> Result = new();
            string Text = new string(EncryptedText.Trim().Where(c => char.IsLetter(c)).ToArray());
            Text = Regex.Replace(Text, _Regex, "");
            for (int i = 1; i <= Text.Length; i++)
            {
                Result.Add(i);
            }
            return Result;
        }

        public Dictionary<string, double> KeysExamination(string PlainText, string EncryptedText/*)*/, List<int> KeysLengths)
        {
            PlainText = new string(PlainText.Trim().Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray()).ToLower();
            EncryptedText = new string(EncryptedText.Trim().Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray()).ToLower();
            if (PlainText.Length != EncryptedText.Length)
            {
                throw new ArgumentException("Encrypted and decrypted texts don't match by lengths\n" +
                    $"Plain: {PlainText.Length}\nEncrypted: {EncryptedText.Length}"); ;
            }
            string[] PlainWords = PlainText.Split(' ');
            string[] EncryptedWords = EncryptedText.Split(' ');
            string[] DecryptedWords;
            StringBuilder Key;
            Dictionary<string, double> Result = new();
            if (PlainWords.Length != EncryptedWords.Length)
            {
                throw new ArgumentException("Encrypted and decrypted wordlists don't match by lengths\n" +
                    $"Plain: {PlainWords.Length}\nEncrypted: {EncryptedWords.Length}");
            }
            for (int i = 0; i < PlainWords.Length; i++)
            {
                if (PlainWords[i].Length != EncryptedWords[i].Length)
                {
                    throw new ArgumentException("Encrypted and decrypted don't match by word lengths");
                }
            }
            string WholePlainText = Regex.Replace(PlainText, _Regex, "");
            string WholeEncryptedText = Regex.Replace(EncryptedText, _Regex, "");
            //List<int> KeysLengths = new();
            //Console.WriteLine(WholePlainText);
            //Console.WriteLine();
            //Console.WriteLine(WholeEncryptedText);
            //Console.WriteLine();
            /*for (int i = 1; i <= WholePlainText.Length; i++)
            {
                KeysLengths.Add(i);
            }*/
            for (int i = 0; i < KeysLengths.Count; i++)
            {
                Key = new();
                for (int j = 0; j < KeysLengths[i]; j++)
                {
                    //Console.WriteLine($"Encrypted char: {WholeEncryptedText[j]}| Index: {Cypher.Alphabet.IndexOf(WholeEncryptedText[j])}");
                    //Console.WriteLine($"Decrypted char: {WholePlainText[j]}| Index: {Cypher.Alphabet.IndexOf(WholePlainText[j])}");
                    int Index = (Cypher.Alphabet.IndexOf(WholeEncryptedText[j]) - Cypher.Alphabet.IndexOf(WholePlainText[j]) + Cypher.Alphabet.Length) % Cypher.Alphabet.Length;
                    //Console.WriteLine($"Key char: {Cypher.Alphabet[Index]}| Index: {Index}");
                    //Alphabet[(Alphabet.IndexOf(char.ToLower(Text[i])) - Alphabet.IndexOf(Key[Counter % Key.Length]) + Alphabet.Length) % Alphabet.Length]
                    Key.Append(Cypher.Alphabet[Index]);
                }
                // Якщо є підстрока (більше 1 символа), що повторюється постійно
                // If substring exists inside a substring, that repeatsitself all the time
                if (Regex.IsMatch(Key.ToString(), @".*(.{2,}).*\1.*\1.*"))
                {
                    continue;
                }
                Cypher.Key = Key.ToString();
                Result[Cypher.Key] = 0;
                DecryptedWords = Cypher.Decrypt(EncryptedText).Split(" ");
                //Console.WriteLine($"\tKey: {Cypher.Key}");
                for (int j = 0; j < EncryptedWords.Length; j++)
                {
                    //Console.WriteLine($"Encrypted Word: {DecryptedWords[j]}");
                    //Console.WriteLine($"Decrypted Word: {PlainWords[j]}");
                    if (DecryptedWords[j] == PlainWords[j])
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
                     .Take(7)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab3
{
    public class BookCypher
    {
        private char[][] KEY;
        public char[][] Key 
        { 
            get
            {
                return KEY;
            }
            set
            {
                if (value != null && value.Length != 0)
                {
                    int LineLength = value[0].Length;

                    if (!value.All(Line => Line.Length == LineLength))
                    {
                        throw new ArgumentException("Lines must be of the same length");
                    }
                }
                KEY = value;
            }
        }
        public string KeyString
        {
            get
            {
                StringBuilder Builder = new();
                Array.ForEach(KEY, Line => Builder.Append(new string(Line)));
                return Builder.ToString();
            }
            set
            {
                if (value == null)
                {
                    KEY = null;
                    return;
                }
                string Text = new string(value.Trim().Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                Text = Regex.Replace(Text, "[ \t]+", "");

                string[] Lines = Text.Split("\n");
                List<   char[]> List = new();
                if (value != null && Lines.Length > 0)
                {
                    int LineLength = Lines[0].Length;
                    if (!Lines.All(Line => Line.Length == LineLength))
                    {
                        throw new ArgumentException("Lines must be of the same length");
                    }
                    if (Lines.Length == 1 && Text.Length != 1)
                    {
                        LineLength = (int)Math.Floor(Math.Sqrt(Text.Length));
                        Lines = Enumerable.Range(0, Text.Length / LineLength)
                            .Select(i => Text.Substring(i * LineLength, LineLength))
                            //(i * LineLength + LineLength) > Text.Length ? Text.Length - i * LineLength : LineLength))
                            .ToArray();
                    }
                    foreach (string Line in Lines)
                    {
                        List.Add(Line.ToCharArray());
                    }
                }
                KEY = List.ToArray();
                Console.WriteLine(new string('-', KEY[0].Length * 2 + 1));
                for (int i = 0; i < KEY.Length; i++)
                {
                    for (int j = 0; j < KEY[i].Length; j++)
                    {
                        Console.Write($"|{KEY[i][j]}");
                    }
                    Console.WriteLine('|');
                }
            }
        }

        public BookCypher(char[][] Key)
        {
            this.Key = Key;
        }

        public string Encrypt(string Text)
        {
            Text = new string(Text.Where(c => char.IsLetter(c)).ToArray());
            //Text = Regex.Replace(Text, "\\s+", "");
            StringBuilder Result = new();
            Random Generator = new();
            int RandomInt;
            string Key = KeyString;
            string EncryptedStr;
            List<int> FoundIndexes;
            for (int i = 0; i < Text.Length; i++)
            {
                if (Key.Contains(Text[i]))
                {
                    FoundIndexes = new List<int>();
                    for (int j = Key.IndexOf(Text[i]); j > -1; j = Key.IndexOf(Text[i], j + 1))
                    {
                        // for loop end when i=-1 ('a' not found)
                        FoundIndexes.Add(j);
                    }
                    RandomInt = Generator.Next(0, FoundIndexes.Count);
                    int Row = (int)(FoundIndexes[RandomInt] / (decimal)this.Key.Length);
                    int Col = FoundIndexes[RandomInt] % this.Key[Row].Length;
                    Console.WriteLine($"Index: {FoundIndexes[RandomInt]}");
                    Console.WriteLine($"Row: {Row}");
                    Console.WriteLine($"Col: {Col}");
                    EncryptedStr = $"{Row}|{Col}";
                }
                else
                {
                    throw new ArgumentException("Letter is not present inside the Key");
                }
                Result.Append(EncryptedStr + " ");
            }
            return Result.ToString().Trim();
        }
            
        public string Decrypt(string Text)
        {
            StringBuilder Result = new();
            string[] Indexes = Text.Split(" ");
            string[] Pair;
            for (int i = 0; i < Indexes.Length; i++)
            {
                Pair = Indexes[i].Split("|");
                Result.Append(Key[int.Parse(Pair[0])][int.Parse(Pair[1])]);
            }
            return Result.ToString();
        }
    }
}

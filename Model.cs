using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TILAb2
{
    class Model
    {
        private static readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static readonly string str = ReadFromFile().ToUpper();
        public static string encStr = String.Empty;

        public static Dictionary<char, int> FindOccuranses(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            Dictionary<char, int> dict = new Dictionary<char, int>();

            str = str.ToUpper();
            foreach (var elem in str)
            {
                if (char.IsLetter(elem))
                {
                    if (!dict.ContainsKey(elem) && alphabet.Contains(elem))
                    {
                        dict.Add(elem, 1);
                    }
                    else
                    {
                        dict[elem]++;
                    }
                }
            }

            return dict;
        }

        public static string Encrypt(int key)
        {
            if (str is null)
            {
                return null;
            }

            if (key < 0)
            {
                return null;
            }

            if (key > 26)
            {
                key = key % 26;
            }

            StringBuilder enc = new StringBuilder();

            foreach (var elem in str)
            {
                enc.Append(char.IsLetter(elem) ? alphabet[(elem % 65 + key) % 26] : elem);
            }

            encStr = enc.ToString();

            return enc.ToString();
        }

        public static string ReadFromFile()
        {
            string path = "C:\\Users\\Max\\source\\repos\\TILAb2\\Source\\text.txt";
            string result;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return result;
        }

        public static int FindCount(string str)
        {
            if (str is null)
            {
                return 0;
            }

            int count = 0;
            foreach (var elem in str)
            {
                if (alphabet.Contains(elem))
                {
                    count++;
                }
            }

            return count;
        }
    }
}

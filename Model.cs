using System.Collections.Generic;

namespace TILAb2
{
    class Model
    {
        public static Dictionary<char, int> FindOccuranses(string str)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            str = str.ToUpper();
            foreach (var elem in str)
            {
                if (char.IsLetter(elem))
                {
                    if (!dict.ContainsKey(elem))
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
    }
}

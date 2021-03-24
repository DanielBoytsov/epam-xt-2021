using System;
using System.Collections.Generic;

namespace CustomExtensions
{
    public class StringExtended
    {
        private char[] CharArray { get; set; }

        public StringExtended()
        {
            CharArray = new char[0];
        }
        public StringExtended(string name)
        {
            if (name != null)
                CharArray = name.ToCharArray();
        }

        public char this[int index]
        {
            get => CharArray[index];
            set => CharArray[index] = value;
        }
        /// <summary>
        /// Character-by-character string comparison
        /// </summary>
        /// <param name="str"></param>
        /// <returns> Returns "true" if all characters in all positions match, otherwise returns "false" </returns>
        public bool Equals(string str)
        {
            if ((CharArray != null) && (str != null))
            {
                if ((CharArray.Length != str.Length))
                {
                    return false;
                }

                for (int i = 0; i < CharArray.Length; i++)
                {
                    if (CharArray[i] != str[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds string variables
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Returns a new string</returns>
        public string Concatenate(string str)
        {
            List<char> newString = new List<char>(CharArray);
            for (int i = 0; i < str.Length; i++)
            {
                newString.Add(str[i]);
            }

            return new string(newString.ToArray());
        }

        /// <summary>
        /// Checks if a character is contained
        /// </summary>
        /// <param name="s"></param>
        /// <returns> Returns true if the character is contained in the string, otherwise returns "false"</returns>
        public bool Contains(char s)
        {
            foreach (var item in CharArray)
            {
                if (item == s)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Searches for the position of the first occurrence of a character in a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns> Returns the position of the first occurrence of a character in a string</returns>
        public int IndexOf(char s)
        {
            if (Contains(s))
                for (int i = 0; i < CharArray.Length; i++)
                {
                    if (CharArray[i] == s)
                    {
                        return i;
                    }
                }

            return -1;
        }

        /// <summary>
        /// Searches for all occurrences of a character in a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns> Returns a collection containing all occurrences of a character in a string</returns>
        public List<int> IndexOfAll(char s)
        {
            List<int> pos = new List<int>();
            if (Contains(s))
            {
                for (int i = 0; i < CharArray.Length; i++)
                {
                    if (CharArray[i] == s)
                    {
                        pos.Add(i);
                    }
                }
            }

            return pos;
        }

        public override bool Equals(object str)
        {
            var tmp = str as string;
            if (tmp == null) return false;
            var temp = (string)str;
            return this.Equals(temp);
        }
        public char[] ConvertToCharArray()
        {
            return CharArray;
        }

        public override string ToString()
        {
            return new string(CharArray);
        }

        public static string operator +(StringExtended strEx, string str)
        {
            StringExtended plus = new StringExtended(strEx.Concatenate(str));
            string result = plus.ToString();
            return result;
        }
        public static bool operator ==(StringExtended strEx, string str)
        {
            if (!object.Equals(strEx, null))
                return strEx.Equals(str);
            throw new ArgumentNullException(nameof(strEx));
        }

        public static bool operator !=(StringExtended strEx, string str)
        {
            if (object.Equals(strEx, null))
                throw new ArgumentNullException(nameof(strEx));
            return !strEx.Equals(str);
        }
        public override int GetHashCode()
        {
            return CharArray.GetHashCode();
        }
    }
}

using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Gouw.Common
{
    /// <summary>
    /// TODO
    /// </summary>
    public enum Position
    {
        /// <summary>
        /// TODO
        /// </summary>
        Before,
        /// <summary>
        /// TODO
        /// </summary>
        After
    };


    /// <summary>
    /// Miscellaneous string helper utilities.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Appends the text to end of the value of this instance.
        /// </summary>
        public static string Append(this string str, string text)
        {
            if (str.IsNullOrEmpty() && text.IsNullOrEmpty())
            {
                return String.Empty;
            }

            if (str.IsNullOrEmpty())
            {
                return text;
            }

            if (text.IsNullOrEmpty())
            {
                return str;
            }

            return str + Constants.SPACE + text;
        }

        /// <summary>
        /// Capitalizes every word of this instance.
        /// </summary>
        public static string Capitalize(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        /// <summary>
        /// Decodes the value of this instance.
        /// </summary>
        public static string Decode(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return String.Empty;
            }

            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }

        /// <summary>
        /// Decrypts the value of this instance.
        /// </summary>
        public static string Decrypt(this string str)
        {
            return Decode(str);
        }

        /// <summary>
        /// Encodes the value of this instance.
        /// </summary>
        public static string Encode(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return String.Empty;
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        /// <summary>
        /// Encrypts the value of this instance.
        /// </summary>
        public static string Encrypt(this string str)
        {
            return Encode(str);
        }

        /// <summary>
        /// Hashes and encodes the value of this instance.
        /// </summary>
        public static string HashAndEncode(this string str)
        {
            SHA1Managed sha1Managed = new SHA1Managed();

            return Convert.ToBase64String(sha1Managed.ComputeHash(Encoding.UTF8.GetBytes(str)));
        }

        /// <summary>
        /// Returns a true if the value of this instance is alphabetic.
        /// </summary>
        public static bool IsAlphabetic(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                foreach (int chr in str)
                {
                    if (chr < 0x41 || chr > 0x5A && chr < 0x61 || chr > 0x7A)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Returns a true if the value of this instance is alphanumeric.
        /// </summary>
        public static bool IsAlphanumeric(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(str, @"^[A-Za-z0-9]+$", RegexOptions.None);
            }
        }

        /// <summary>
        /// Returns a true if the value of this instance is alphanumeric (including blank).
        /// </summary>
        public static bool IsAlphanumericBlank(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(str, @"^[A-Za-z0-9 ]+$", RegexOptions.None);
            }
        }

        /// <summary>
        /// Returns a true if the value of this instance is capitalized.
        /// </summary>
        public static bool IsCapitalized(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                return Char.IsUpper(str[0]);
            }
        }

        /// <summary>
        /// Returns a true if the value of this instance is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this string str)
        {
            return String.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Returns a true if the value of this instance is numeric.
        /// </summary>
        public static bool IsNumeric(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                int result;
                foreach (char ch in str)
                {
                    if (!int.TryParse(Convert.ToString(ch), out result))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Returns a true if the value of this instance consists of blank(s).
        /// </summary>
        public static bool IsWhiteSpace(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                foreach (char ch in str)
                {
                    if (!Char.IsWhiteSpace(ch))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Reverses the order of the characters of this instance.
        /// </summary>
        public static string Reverse(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return String.Empty;
            }

            char[] array = str.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        /// <summary>
        /// Retrieves a substring from this instance of a specified length starting at the end of this instance.
        /// </summary>
        public static string Right(this string str, int count)
        {
            if (str.IsNullOrEmpty() || count <= 0)
            {
                return String.Empty;
            }

            int startIndex = str.Length - count;
            if (startIndex > 0)
            {
                str = str.Substring(startIndex, count);
            }
            return str;
        }

        /// <summary>
        /// Converts the value of this instance into a double value.
        /// </summary>
        public static double ToDouble(this string str)
        {
            double value;
            try
            {
                value = Double.Parse(str);
            }
            catch (OverflowException)
            {
                value = (str[0] == '-') ? Constants.MIN_DOUBLE : Constants.MAX_DOUBLE;
            }
            catch
            {
                value = 0.0;
            }
            return value;
        }

        /// <summary>
        /// Converts the value of this instance into an integer value.
        /// </summary>
        public static int ToInt(this string str)
        {
            if (str.Contains("."))
            {
                str = str.Remove(str.IndexOf("."), str.Length - str.IndexOf("."));
            }

            int value;
            try
            {
                value = Int32.Parse(str);
            }
            catch (OverflowException)
            {
                value = (str[0] == '-') ? Constants.MIN_INT : Constants.MAX_INT;
            }
            catch
            {
                value = 0;
            }
            return value;
        }

        /// <summary>
        /// Trims the value of this instance upto the occurence of the given text.
        /// </summary>
        public static string Trim(this string str, string text, Position position)
        {
            if (str.Contains(text))
            {
                return (position == Position.Before) ?
                       str.Substring(0, str.IndexOf(text)) :
                       str.Substring(str.IndexOf(text) + text.Length, str.Length - str.IndexOf(text) - text.Length);
            }
            return str;
        }
    }
}
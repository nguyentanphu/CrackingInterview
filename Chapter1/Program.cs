using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter1
{
	class Program
	{
		static void Main(string[] args)
		{

			//Console.WriteLine(IsUniqueCharString("aabc"));
			//Console.WriteLine(IsPermutation("abcdxd", "ayddbc"));

		}

		// Without hash table
		static bool IsUniqueCharString(string str)
		{
			if (str.Length > 128 || str.Length == 0)
			{
				return false;
			}
			var charSetArr = new bool[128];
			foreach (var c in str)
			{
				if (charSetArr[c])
				{
					return false;
				}

				charSetArr[c] = true;
			}

			return true;
		}

		static bool IsPermutation(string str1, string str2)
		{
			var str2Dict = new Dictionary<char, int>();
			foreach (var c in str2)
			{
				if (str2Dict.ContainsKey(c))
				{
					str2Dict[c]++;
				}
				else
				{
					str2Dict[c] = 1;
				}
			}

			foreach (var c in str1)
			{
				if (!str2Dict.ContainsKey(c))
				{
					return false;
				}
				else
				{
					str2Dict[c]--;
				}
			}

			return str2Dict.Values.All(v => v == 0);
		}
		private static void PrintPermute(string str, int l, int r)
		{
			if (l == r)
				Console.WriteLine(str);
			else
			{
				for (int i = l; i <= r; i++)
				{
					str = Swap(str, l, i);
					PrintPermute(str, l + 1, r);
					str = Swap(str, l, i);
				}
			}
		}

		public static string Swap(string a, int i, int j)
		{
			char temp;
			char[] charArray = a.ToCharArray();
			temp = charArray[i];
			charArray[i] = charArray[j];
			charArray[j] = temp;
			string s = new string(charArray);
			return s;
		}
	}
}

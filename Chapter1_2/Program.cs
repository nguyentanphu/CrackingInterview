using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter1_2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(StringCompression("abbbbbccccc"));
		}

		static bool OneEditAway(string str1, string str2)
		{
			var longer = str1.Length > str2.Length ? str1 : str2;
			var shorter = str1.Length <= str2.Length ? str1 : str2;

			if (longer.Length - shorter.Length > 1)
			{
				return false;
			}
			var differentStep = 0;
			for (int i = 0; i < longer.Length; i++)
			{
				if (i + differentStep >= longer.Length)
				{
					return differentStep <= 1;
				}
				if (shorter.ElementAtOrDefault(i) == default(char) || longer[i + differentStep] != shorter[i])
				{
					differentStep++;
				}

				if (differentStep > 1)
				{
					return false;
				}
			}

			return true;
		}

		static string StringCompression(string str)
		{
			var originalString = str;
			var index = 0;
			while (index < str.Length)
			{
				var currentChar = str[index];
				var charCount = 0;
				for (var i = index + 1; i <= str.Length; i++)
				{
					charCount++;

					if (i == str.Length || str[i] != currentChar)
					{
						str = SwapCompression(str, index, charCount);
						index = index + 2;
						break;
					}
					
				}
			}

			return str.Length > originalString.Length ? originalString : str;
		}

		static string SwapCompression(string str, int start, int count)
		{
			var c = str[start];
			str = str.Remove(start, count);
			return str.Insert(start, $"{c}{count}");
		}
	}
}

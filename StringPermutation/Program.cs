using System;

namespace StringPermutation
{
	class Program
	{
		static void Main(string[] args)
		{
			permute("", "abc");
		}

		public static int Count = 0;
		public static void permute(string soFar, string strLeft)
		{

			if (strLeft.Length == 1)
			{
				soFar += strLeft;
				Console.WriteLine(++Count + " :: " + soFar);
			}
			else
			{
				for (int i = 0; i < strLeft.Length; i++)
				{
					permute(soFar + strLeft[i], strLeft.Substring(0, i) + strLeft.Substring(i + 1));
				}
			}
		}
    }
}

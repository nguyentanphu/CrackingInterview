using System;
using System.Diagnostics.CodeAnalysis;

namespace CrackingInterview
{
	class Program
	{
		static void Main(string[] args)
		{
			AllFib(5);
		}

		static void AllFib(int n)
		{
			var memo = new int[n + 1];
			for (int i = 0; i < n; i++)
			{
				Console.WriteLine(CalFib(i, memo));
			}
		}

		static int CalFib(int n, int[] memo)
		{
			if (n <= 0) return 0;
			if (n == 1) return 1;
			if (memo[n] > 0) return memo[n];

			memo[n] = CalFib(n - 1, memo) + CalFib(n - 2, memo);
			return memo[n];
		}
	}
}

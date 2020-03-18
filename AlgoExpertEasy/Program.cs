using System;
using System.Collections.Generic;

namespace AlgoExpertEasy
{
	class Program
	{
		static void Main(string[] args)
		{
			var arr = new int[] {1, 3, 5, 8, 2, 13, 7};
			var sum = 100;

			var result = FindSum(arr, sum);

			if (result.HasValue)
			{
				Console.WriteLine($"{result.Value.Item1}, {result.Value.Item2}");
			}
			else
			{
				Console.WriteLine("Not found");
			}
		}

		static (int, int)? FindSum(int[] arr, int sum)
		{
			var hash = new HashSet<int>();
			foreach (var i in arr)
			{
				var remainder = sum - i;
				if (hash.Contains(remainder))
				{
					return (i, remainder);
				}

				hash.Add(i);
			}

			return null;
		}
	}
}

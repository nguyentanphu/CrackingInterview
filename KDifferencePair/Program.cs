using System;
using System.Collections.Generic;

namespace KDifferencePair
{
	class Program
	{
		/*
		 * Example: Given an array of distinct integer values, count the number of pairs of integers that
			have difference k. For example, given the array { 1, 7, 5, 9, 2, 12, 3} and the difference
			k = 2,there are four pairs with difference2: (1, 3), (3, 5), (5, 7), (7, 9). 
		 */
		static void Main(string[] args)
		{
			var input = new int[] {1, 7, 5, 9, 2, 12, 3};
			PrintPairWithK(input, 2);

		}

		static void PrintPairWithK(int[] arr, int k)
		{
			var hashSet = new HashSet<int>();
			foreach (var i in arr)
			{
				hashSet.Add(i);
			}


			foreach (var i in hashSet)
			{
				if (hashSet.Contains(i + k))
				{
					Console.WriteLine($"{i}--{i+k}");
				}
			}
		}
	}
}

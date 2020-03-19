using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;

namespace AlgoExpertEasy
{
	class Program
	{
		static void Main(string[] args)
		{
			//var arr = new int[] {1, 3, 5, 8, 2, 13, 7};
			//var sum = 100;

			//var result = FindSum(arr, sum);

			//if (result.HasValue)
			//{
			//	Console.WriteLine($"{result.Value.Item1}, {result.Value.Item2}");
			//}
			//else
			//{
			//	Console.WriteLine("Not found");
			//}

			//var arr = new int[] { 141, 1, 17, 8, 2, 13, 7 };
			//var result = Find3Largest(arr);

			//var arr = new int[] {1, 5, 6, 8, 10, 20, 50, 67};
			//Console.WriteLine(BinarySearch(arr, 9));

			//Console.WriteLine(CeasarCipher("abcxyz", 27));

			var arr = new int[] { -8, -6, 1, 2, 3, 5, 6, 12 };
			var result = ThreeNumSumSort(arr, 0);
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

		static List<int[]> ThreeNumSum(int[] arr, int target)
		{
			var result = new List<int[]>();
			for (int i = 0; i < arr.Length; i++)
			{
				var remainder = target - arr[i];
				var twoSum = FindSum(arr[(i + 1)..], remainder);
				if (twoSum.HasValue)
				{
					result.Add(new []{arr[i], twoSum.Value.Item1, twoSum.Value.Item2});
				}
			}

			return result;
		}

		static List<int[]> ThreeNumSumSort(int[] arr, int target)
		{
			var sortedArr = arr.OrderBy(i => i);
			var result = new List<int[]>();
			for (int i = 0; i < arr.Length; i++)
			{
				var left = i + 1;
				var right = arr.Length - 1;

				while (left < right)
				{
					var totalSum = arr[i] + arr[left] + arr[right];
					if (totalSum == target)
					{
						result.Add(new []{arr[i], arr[left], arr[right]});
						left++;
						right--;
					} 
					else if (totalSum > target)
					{
						right--;
					}
					else
					{
						left++;
					}
				}
			}

			return result;
		}
		static int[] Find3Largest(int[] arr)
		{
			var result = new int[3];
			foreach (var num in arr)
			{
				for (int j = result.Length-1; j >= 0; j--)
				{
					if (num > result[j])
					{
						ShiftLeft(result, j, num);
						break;
					}
				}
			}

			return result;
		}

		private static void ShiftLeft(int[] arr, int index, int newValue)
		{
			var temp = arr[index];
			arr[index] = newValue;
			if (index > 0)
			{
				arr[index - 1] = temp;
			}
		}

		static bool BinarySearch(int[] arr, int target)
		{
			var left = 0;
			var right = arr.Length - 1;
			while (left <= right)
			{
				var middle = (left + right) / 2;
				if (arr[middle] == target)
				{
					return true;
				}
				else if (arr[middle] > target)
				{
					right = middle - 1;
				}
				else
				{
					left = middle + 1;
				}
			}

			return false;
		}

		static string CeasarCipher(string input, int step)
		{
			var result = new char[input.Length];
			for (int i = 0; i < input.Length; i++)
			{
				int newCharCode = input[i] + step;
				if (newCharCode > 122)
				{
					result[i] = (char) (newCharCode%122 + 96);
				}
				else
				{
					result[i] = (char)(input[i] + step);
				}
			}

			return new string(result);
		}
	}
}

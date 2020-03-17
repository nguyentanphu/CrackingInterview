using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
	class Program
	{
		static void Main(string[] args)
		{
			var inputArr = new int[] {1,30,4,5,6,7,59,39,35,100};

			QuickSort(inputArr, 0, inputArr.Length-1);
			Print(inputArr);

		}

		public static void QuickSort(int[] arr, int left, int right)
		{
			if (left < right)
			{
				int pivotIndex = Partition(arr, left, right);
				if (pivotIndex > 1)
				{
					QuickSort(arr, left, pivotIndex-1);
				}

				if (pivotIndex + 1 < right)
				{
					QuickSort(arr, pivotIndex + 1, right);
				}
			}
		}

		public static int Partition(int[] arr, int left, int right)
		{
			var pivot = arr[left];
			while (true)
			{
				while (pivot > arr[left])
				{
					left++;
				}

				while (pivot < arr[right])
				{
					right--;
				}

				if (left < right)
				{
					if (arr[left] == arr[right])
					{
						return right;
					}

					Swap(arr, left, right);
				}
				else
				{
					return right;
				}
			}
		}

		public static int[] MergeSort(int[] arr)
		{
			if (arr.Length == 1)
			{
				return arr;
			}

			var middle = arr.Length / 2;
			var left = arr[..middle];
			var right = arr[middle..];

			return Merge(MergeSort(left), MergeSort(right));
		}

		public static int[] Merge(int[] left, int[] right)
		{
			var leftIndex = 0;
			var rightIndex = 0;
			var result = new List<int>(left.Length + right.Length);
			while (leftIndex < left.Length && rightIndex < right.Length)
			{
				if (left[leftIndex] < right[rightIndex])
				{
					result.Add(left[leftIndex]);
					leftIndex++;
				}
				else
				{
					result.Add(right[rightIndex]);
					rightIndex++;
				}
			}

			return result
				.Concat(left[leftIndex..])
				.Concat(right[rightIndex..])
				.ToArray();

		}

		public static void BubbleSort(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = 0; j < arr.Length-1; j++)
				{
					if (arr[j] > arr[j + 1])
					{
						Swap(arr, j, j + 1);
					}
				}
			}
		}

		public static void SelectionSort(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				var minIndex = i;
				for (int j = i + 1; j < arr.Length; j++)
				{
					if (arr[minIndex] > arr[j])
					{
						minIndex = j;
					}
				}

				if (minIndex != i)
				{
					Swap(arr, i, minIndex);
				}
			}
		}

		public static void InsertionSort(int[] arr)
		{
			for (var i = 1; i < arr.Length; i++)
			{
				var currentMin = arr[i];
				for (var j = i; j < arr.Length;)
				{
					if (j == 0 || currentMin >= arr[j-1])
					{
						break;
					}
					Swap(arr, j, j-1);
					j--;
				}
			}
		}

		private static void Swap(int[] arr, int index1, int index2)
		{
			var temp = arr[index1];
			arr[index1] = arr[index2];
			arr[index2] = temp;
		}

		private static void Print(int[] arr)
		{
			foreach (var i in arr)
			{
				Console.WriteLine($"{i} ");
			}
		}
	}
}

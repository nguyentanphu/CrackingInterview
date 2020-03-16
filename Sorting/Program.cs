using System;

namespace Sorting
{
	class Program
	{
		static void Main(string[] args)
		{
			var inputArr = new int[] {1, 30, 23, 4, 5, 6, 8, 19, 44};
			SelectionSort(inputArr);
			Print(inputArr);

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

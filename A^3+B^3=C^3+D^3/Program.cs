using System;
using System.Collections.Generic;

namespace A_3_B_3_C_3_D_3
{
	class Program
	{
		/*
		 * Example: Print all positive integer solutions to the equation a3 + b3 = c3 + d3
		 * where a, b, c and d are integers between 1 and 1000. 
		 */
		static void Main(string[] args)
		{
			PrintTypleOptimal();
		}

		static void PrintTupleOf4()
		{
			var n = 10;
			for (int a = 1; a <= n; a++)
			for (int b = 1; b <= n; b++)
			for (int c = 1; c <= n; c++)
			{
				var d = (int)Math.Pow(a * a * a + b * b * b - c * c * c, 1 / 3);
				if (d == a * a * a + b * b * b - c * c * c)
				{
					Console.WriteLine($"{a},{b},{c},{d}");
				}
			}
		}

		static void PrintTypleOptimal()
		{
			var n = 10;
			var dict = new Dictionary<int, List<(int, int)>>();
			for (int a = 1; a <= n; a++)
			for (int b = 1; b <= n; b++)
			{
				var result = a * a * a + b * b * b;
				if (dict.ContainsKey(result))
				{
					dict[result].Add((a, b));
				}
				else
				{
					dict[result] = new List<(int, int)>
					{
						(a, b)
					};
				}
			}

			foreach (var keyValuePair in dict)
			{
				foreach (var pair1 in keyValuePair.Value)
				{
					foreach (var pair2 in keyValuePair.Value)
					{
						Console.WriteLine($"{pair1.Item1},{pair1.Item2},{pair2.Item1},{pair2.Item2}");
					}
				}
			}
		}
	}
}

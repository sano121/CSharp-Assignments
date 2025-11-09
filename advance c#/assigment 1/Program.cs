using System;
using System.Collections;
using System.Collections.Generic;

namespace assigment_1
{
	public class Range<T> where T : IComparable<T>
	{
		public T Min { get; }
		public T Max { get; }

		public Range(T min, T max)
		{
			if (min.CompareTo(max) > 0)
				throw new ArgumentException("min must be less than or equal to max");

			Min = min;
			Max = max;
		}

		public bool IsInRange(T value)
		{
			return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
		}

	
		public dynamic Length()
		{
			object min = Min;
			object max = Max;

			if (min is int && max is int)
				return (int)max - (int)min;
			if (min is long && max is long)
				return (long)max - (long)min;
			if (min is float && max is float)
				return (float)max - (float)min;
			if (min is double && max is double)
				return (double)max - (double)min;
			if (min is decimal && max is decimal)
				return (decimal)max - (decimal)min;

			
			try
			{
				decimal dMin = Convert.ToDecimal(min);
				decimal dMax = Convert.ToDecimal(max);
				return dMax - dMin;
			}
			catch (Exception)
			{
				throw new InvalidOperationException("Length is not supported for this type T unless it is numeric");
			}
		}
	}

	public class FixedSizeList<T>
	{
		private readonly T[] _items;
		private int _count;

		public int Capacity => _items.Length;
		public int Count => _count;

		public FixedSizeList(int capacity)
		{
			if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be positive");
			_items = new T[capacity];
			_count = 0;
		}

		public void Add(T item)
		{
			if (_count >= _items.Length)
				throw new InvalidOperationException("List is full: cannot add more elements.");
			_items[_count++] = item;
		}

		public T Get(int index)
		{
			if (index < 0 || index >= _count)
				throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
			return _items[index];
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			

			var intRange = new Range<int>(2, 8);
			Console.WriteLine($"Range<int>: Min={intRange.Min}, Max={intRange.Max}, Length={intRange.Length()}");
			Console.WriteLine($"Is 5 in range? {intRange.IsInRange(5)}");
			Console.WriteLine($"Is 1 in range? {intRange.IsInRange(1)}");

			var doubleRange = new Range<double>(1.5, 4.2);
			Console.WriteLine($"Range<double> Length={doubleRange.Length()}");

			var al = new ArrayList() { 1, 2, 3, 4, 5 };
			Console.WriteLine("ArrayList before reverse: " + string.Join(",", al.ToArray()));
			ReverseArrayListInPlace(al);
			Console.WriteLine("ArrayList after reverse: " + string.Join(",", al.ToArray()));

			var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
			var evens = FilterEvens(nums);
			Console.WriteLine("Even numbers: " + string.Join(",", evens));

			var fList = new FixedSizeList<string>(2);
			Console.WriteLine($"FixedSizeList capacity={fList.Capacity}");
			fList.Add("Alice");
			fList.Add("Bob");
			try
			{
				fList.Add("Charlie");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Expected exception when adding beyond capacity: " + ex.Message);
			}
			Console.WriteLine($"Element 0: {fList.Get(0)}");
			try
			{
				Console.WriteLine(fList.Get(5));
			}
			catch (Exception ex)
			{
				Console.WriteLine("Expected exception when accessing invalid index: " + ex.Message);
			}

			string s1 = "swiss";
			string s2 = "aabbcc";
			Console.WriteLine($"First non-repeated in '{s1}' -> index {FirstNonRepeatedCharIndex(s1)}");
			Console.WriteLine($"First non-repeated in '{s2}' -> index {FirstNonRepeatedCharIndex(s2)}");

			
		}

		public static void ReverseArrayListInPlace(ArrayList list)
		{
			if (list == null) throw new ArgumentNullException(nameof(list));

			int i = 0, j = list.Count - 1;
			while (i < j)
			{
				var tmp = list[i];
				list[i] = list[j];
				list[j] = tmp;
				i++; j--;
			}
		}

		public static List<int> FilterEvens(List<int> input)
		{
			if (input == null) throw new ArgumentNullException(nameof(input));
			var res = new List<int>();
			foreach (var v in input)
				if (v % 2 == 0) res.Add(v);
			return res;
		}

		public static int FirstNonRepeatedCharIndex(string s)
		{
			if (string.IsNullOrEmpty(s)) return -1;
			var counts = new Dictionary<char, int>();
			foreach (var c in s)
			{
				counts.TryGetValue(c, out int ccount);
				counts[c] = ccount + 1;
			}
			for (int i = 0; i < s.Length; i++)
			{
				if (counts[s[i]] == 1) return i;
			}
			return -1;
		}
	}
}

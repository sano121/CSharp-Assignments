using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace assigmetn_2
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Problem1();
            Problem2();
            Problem3();
            Problem4();
            Problem5();
            Problem6();
            Problem7();
            Problem8();
            Problem9();
            Problem10();
            Problem11();

        }

        static void Problem1()
        {
            Console.WriteLine("Problem 1: Count numbers greater than X");
            int[] arr = { 11, 5, 3 };
            int[] queries = { 1, 5, 13 };

            foreach (int x in queries)
            {
                int count = arr.Count(num => num > x);
                Console.WriteLine($"Query {x}: {count}");
            }
            Console.WriteLine();
        }

        static void Problem2()
        {
            Console.WriteLine("Problem 2: Check if array is palindrome");
            int[] arr = { 1, 3, 2, 3, 1 };
            bool isPalindrome = IsPalindrome(arr);
            Console.WriteLine(isPalindrome ? "YES" : "NO");
            Console.WriteLine();
        }

        static bool IsPalindrome(int[] arr)
        {
            int left = 0, right = arr.Length - 1;
            while (left < right)
            {
                if (arr[left] != arr[right]) return false;
                left++;
                right--;
            }
            return true;
        }

        static void Problem3()
        {
            Console.WriteLine("Problem 3: Reverse queue using stack");
            Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            Console.WriteLine("Original queue: " + string.Join(", ", queue));
            ReverseQueue(queue);
            Console.WriteLine("Reversed queue: " + string.Join(", ", queue));
            Console.WriteLine();
        }

        static void ReverseQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0)
                stack.Push(queue.Dequeue());
            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());
        }

        static void Problem4()
        {
            Console.WriteLine("Problem 4: Check balanced parentheses");
            string input = "[()]{}";
            bool balanced = IsBalanced(input);
            Console.WriteLine($"Input: {input}");
            Console.WriteLine(balanced ? "Balanced" : "Not Balanced");
            Console.WriteLine();
        }

        static bool IsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> pairs = new Dictionary<char, char>
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' }
            };

            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                    stack.Push(c);
                else if (pairs.ContainsKey(c))
                {
                    if (stack.Count == 0 || stack.Pop() != pairs[c])
                        return false;
                }
            }
            return stack.Count == 0;
        }

        static void Problem5()
        {
            Console.WriteLine("Problem 5: Remove duplicates from array");
            int[] arr = { 1, 2, 2, 3, 3, 3, 4 };
            int[] result = RemoveDuplicates(arr);
            Console.WriteLine("Original: " + string.Join(", ", arr));
            Console.WriteLine("Without duplicates: " + string.Join(", ", result));
            Console.WriteLine();
        }

        static int[] RemoveDuplicates(int[] arr)
        {
            return arr.Distinct().ToArray();
        }

        static void Problem6()
        {
            Console.WriteLine("Problem 6: Remove odd numbers from ArrayList");
            ArrayList list = new ArrayList { 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine("Original: " + string.Join(", ", list.ToArray()));
            RemoveOdds(list);
            Console.WriteLine("After removing odds: " + string.Join(", ", list.ToArray()));
            Console.WriteLine();
        }

        static void RemoveOdds(ArrayList list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] is int num && num % 2 != 0)
                    list.RemoveAt(i);
            }
        }

        static void Problem7()
        {
            Console.WriteLine("Problem 7: Generic queue with mixed types");
            Queue<object> queue = new Queue<object>();
            queue.Enqueue(1);
            queue.Enqueue("Apple");
            queue.Enqueue(5.28);

            Console.WriteLine("Queue contents:");
            while (queue.Count > 0)
                Console.WriteLine(queue.Dequeue());
            Console.WriteLine();
        }

        static void Problem8()
        {
            Console.WriteLine("Problem 8: Stack search with count");
            Console.Write("Enter target integer: ");
            if (int.TryParse(Console.ReadLine(), out int target))
            {
                Stack<int> stack = new Stack<int>(new[] { 10, 20, 30, 40, 50 });
                int count = SearchInStack(stack, target);
                if (count > 0)
                    Console.WriteLine($"Target was found successfully and the count = {count}");
                else
                    Console.WriteLine("Target was not found");
            }
            Console.WriteLine();
        }

        static int SearchInStack(Stack<int> stack, int target)
        {
            int count = 0;
            while (stack.Count > 0)
            {
                count++;
                if (stack.Pop() == target)
                    return count;
            }
            return -1;
        }

        static void Problem9()
        {
            Console.WriteLine("Problem 9: Find array intersection");
            int[] arr1 = { 1, 2, 3, 4, 4 };
            int[] arr2 = { 10, 4, 4 };
            int[] intersection = FindIntersection(arr1, arr2);
            Console.WriteLine("Array 1: " + string.Join(", ", arr1));
            Console.WriteLine("Array 2: " + string.Join(", ", arr2));
            Console.WriteLine("Intersection: " + string.Join(", ", intersection));
            Console.WriteLine();
        }

        static int[] FindIntersection(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> count1 = new Dictionary<int, int>();
            foreach (int num in arr1)
            {
                count1.TryGetValue(num, out int cnt);
                count1[num] = cnt + 1;
            }

            List<int> result = new List<int>();
            foreach (int num in arr2)
            {
                if (count1.ContainsKey(num) && count1[num] > 0)
                {
                    result.Add(num);
                    count1[num]--;
                }
            }
            return result.ToArray();
        }

        static void Problem10()
        {
            Console.WriteLine("Problem 10: Find contiguous subarray with target sum");
            List<int> list = new List<int> { 1, 2, 3, 7, 5 };
            int target = 12;
            List<int> subarray = FindSubarraySum(list, target);
            Console.WriteLine("Array: " + string.Join(", ", list));
            Console.WriteLine("Target: " + target);
            if (subarray.Count > 0)
                Console.WriteLine("Subarray: [" + string.Join(", ", subarray) + "]");
            else
                Console.WriteLine("No subarray found");
            Console.WriteLine();
        }

        static List<int> FindSubarraySum(List<int> list, int target)
        {
            int n = list.Count;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = i; j < n; j++)
                {
                    sum += list[j];
                    if (sum == target)
                        return list.GetRange(i, j - i + 1);
                }
            }
            return new List<int>();
        }

        static void Problem11()
        {
            Console.WriteLine("Problem 11: Reverse first K elements of queue");
            Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            int k = 3;
            Console.WriteLine("Original queue: " + string.Join(", ", queue));
            ReverseFirstK(queue, k);
            Console.WriteLine("After reversing first " + k + ": " + string.Join(", ", queue));
        }

        static void ReverseFirstK(Queue<int> queue, int k)
        {
            Stack<int> stack = new Stack<int>();
            Queue<int> tempQueue = new Queue<int>();

            for (int i = 0; i < k && queue.Count > 0; i++)
                stack.Push(queue.Dequeue());

            while (stack.Count > 0)
                tempQueue.Enqueue(stack.Pop());

            while (queue.Count > 0)
                tempQueue.Enqueue(queue.Dequeue());

            foreach (int item in tempQueue)
                queue.Enqueue(item);
        }
    }
}

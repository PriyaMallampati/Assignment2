using System.Text;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */



        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums.Length == 0)
                    return 0;

                int uniqueIndex = 1;
                // Iterate through the array starting from the second element
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current element is not the same as the previous,
                    // it is unique and should be moved to the uniqueIndex position
                    if (nums[i] != nums[uniqueIndex - 1])
                    {
                        nums[uniqueIndex] = nums[i];
                        uniqueIndex++;
                    }
                }

                return uniqueIndex;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Self reflection: This problem reinforces the value of a two-pointer technique in array manipulation, especially for in-place operations.
         A key learning point is the efficiency of using minimal space to achieve the task. However, the current approach always iterates through 
         the entire array even if unnecessary. Future optimizations could include early termination if the rest of the array elements 
         are already unique, potentially improving performance for partially sorted arrays with unique elements towards the beginning. */
        /*

       Question 2:
       Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

       Note that you must do this in-place without making a copy of the array.

       Example 1:

       Input: nums = [0,1,0,3,12]
       Output: [1,3,12,0,0]
       Example 2:

       Input: nums = [0]
       Output: [0]

       Constraints:

       1 <= nums.length <= 104
       -231 <= nums[i] <= 231 - 1
       */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                int nonZeroIndex = 0;
                // First loop moves all non-zero elements to the beginning of the array
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        nums[nonZeroIndex] = nums[i];
                        nonZeroIndex++;
                    }
                }

                // Fill the rest of the array with zeros

                for (int i = nonZeroIndex; i < nums.Length; i++)
                {
                    nums[i] = 0;
                }

                return nums.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Self reflection:
           The process of segregating zeros from non-zeros is a practical demonstration of element reordering in arrays using two pointers. 
           The lesson here is balancing simplicity with efficiency. Recommendation: To optimize further,
           swapping zero and non-zero elements as soon as a non-zero element is encountered could reduce the total number of assignments, 
           enhancing runtime efficiency in scenarios with many zeros spread throughout the array.*/

        /*

       Question 3:
       Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

       Notice that the solution set must not contain duplicate triplets.



       Example 1:

       Input: nums = [-1,0,1,2,-1,-4]
       Output: [[-1,-1,2],[-1,0,1]]
       Explanation: 
       nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
       nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
       nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
       The distinct triplets are [-1,0,1] and [-1,-1,2].
       Notice that the order of the output and the order of the triplets does not matter.
       Example 2:

       Input: nums = [0,1,1]
       Output: []
       Explanation: The only possible triplet does not sum up to 0.
       Example 3:

       Input: nums = [0,0,0]
       Output: [[0,0,0]]
       Explanation: The only possible triplet sums up to 0.


       Constraints:

       3 <= nums.length <= 3000
       -105 <= nums[i] <= 105

       */
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                IList<IList<int>> result = new List<IList<int>>();
                if (nums.Length < 3)
                    return result;
                // Sort the array to use two-pointer technique effectively
               

                Array.Sort(nums);
                // Iterate through the array
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip duplicate elements to avoid duplicate triplets
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;
                    // Two pointers
                    int left = i + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];
                        if (sum == 0)
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;

                            // Move pointers after finding a valid triplet
                            left++;
                            right--;
                        }
                        else if (sum < 0)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Self reflection: Implementing the 3Sum problem highlights the importance of sorting as a pre-processing step in reducing problem complexity,
           especially for algorithms requiring element comparison. It also teaches the management of duplicates in solutions sets. 
         Investigating more sophisticated data structures like hash sets for tracking seen triplets could offer an alternative way to avoid duplicates,
          potentially simplifying the logic and reducing the need for multiple checks.*/

        /*

      Question 4:
      Given a binary array nums, return the maximum number of consecutive 1's in the array.

      Example 1:

      Input: nums = [1,1,0,1,1,1]
      Output: 3
      Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
      Example 2:

      Input: nums = [1,0,1,1,0,1]
      Output: 2

      Constraints:

      1 <= nums.length <= 105
      nums[i] is either 0 or 1.

      */
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int maxOnes = 0;
                int currentOnes = 0;
                // Iterate through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == 1)
                    {
                        currentOnes++;
                        // Update maxOnes if current streak is larger
                        maxOnes = Math.Max(maxOnes, currentOnes);
                    }
                    else
                    {
                        currentOnes = 0;
                    }
                }

                return maxOnes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Self reflection: Counting consecutive occurrences within an array underlines the effectiveness of simple iteration and condition checking. 
          This problem illustrates how straightforward solutions can effectively solve seemingly complex problems.
         While the current method is efficient, exploring parallel processing techniques for very large arrays could be an interesting
          avenue for handling massive datasets, dividing the array and combining results from parallel computations.*/


        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int decimal_value = 0;
                int base_value = 1;

                while (binary != 0)
                {
                    int remainder = binary % 10; // Get the last digit (rightmost)
                    decimal_value += remainder * base_value;
                    base_value *= 2; // Move to the next power of 2
                    binary /= 10; // Remove the last digit from binary number
                }

                return decimal_value;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Self reference: `The conversion method emphasizes understanding the fundamental principles of number systems and their conversions.
           It's a good exercise in applying mathematical concepts programmatically without relying on built-in functions. 
           Incorporating input validation to ensure that the provided number is indeed binary (contains only 0s and 1s) would make
           the program more robust and user-friendly.*/

        /*

       Question:6
       Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
       You must write an algorithm that runs in linear time and uses linear extra space.

       Example 1:

       Input: nums = [3,6,9,1]
       Output: 3
       Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
       Example 2:

       Input: nums = [10]
       Output: 0
       Explanation: The array contains less than 2 elements, therefore return 0.


       Constraints:

       1 <= nums.length <= 105
       0 <= nums[i] <= 109

       */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2)
                    return 0;
                // Initialize variables for the bucket sort method
                int min_value = nums.Min();
                int max_value = nums.Max();
                int bucket_size = Math.Max(1, (max_value - min_value) / (nums.Length - 1));
                int bucket_count = (max_value - min_value) / bucket_size + 1;

                int[] bucket_min = new int[bucket_count];
                int[] bucket_max = new int[bucket_count];

                Array.Fill(bucket_min, int.MaxValue);
                Array.Fill(bucket_max, int.MinValue);
                // Place each number in its corresponding bucket
                foreach (int num in nums)
                {
                    int bucket_index = (num - min_value) / bucket_size;
                    bucket_min[bucket_index] = Math.Min(bucket_min[bucket_index], num);
                    bucket_max[bucket_index] = Math.Max(bucket_max[bucket_index], num);
                }

                int max_gap = 0;
                int prev_max = min_value;

                for (int i = 0; i < bucket_count; i++)
                {
                    if (bucket_min[i] == int.MaxValue && bucket_max[i] == int.MinValue)
                        continue;

                    max_gap = Math.Max(max_gap, bucket_min[i] - prev_max);
                    prev_max = bucket_max[i];
                }

                return max_gap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Self reference:
         Applying a bucket sort concept to solve the Maximum Gap problem is an innovative approach that demonstrates the
          utility of sorting and partitioning strategies in optimizing performance. It also showcases how theoretical knowledge of sorting
         algorithms can be applied creatively. Further exploration into optimizing bucket size and count based on different input distributions 
          could yield even better performance, adapting the algorithm dynamically to the nature of the data.*/
        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */
        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                if (nums.Length < 3)
                    return 0;

                Array.Sort(nums);
                // Check from the largest elements to find a valid triangle
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    if (nums[i - 2] + nums[i - 1] > nums[i])
                        // These 3 sides form a valid triangle
                        return nums[i - 2] + nums[i - 1] + nums[i];
                }

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Self reference: This problem serves as a practical application of geometric principles and sorting algorithms. The approach taken illustrates how pre-sorting
         an array can simplify subsequent logical checks for specific conditions, like the triangle inequality theorem. 
        Considering the numerical stability and precision of calculations, especially when dealing with floating-point numbers or 
        very large integers, could enhance the solution's applicability to a wider range of problems, including those in computational geometry.*/

        /*

       Question:8

       Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

       Find the leftmost occurrence of the substring part and remove it from s.
       Return s after removing all occurrences of part.

       A substring is a contiguous sequence of characters in a string.



       Example 1:

       Input: s = "daabcbaabcbc", part = "abc"
       Output: "dab"
       Explanation: The following operations are done:
       - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
       - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
       - s = "dababc", remove "abc" starting at index 3, so s = "dab".
       Now s has no occurrences of "abc".
       Example 2:

       Input: s = "axxxxyyyyb", part = "xy"
       Output: "ab"
       Explanation: The following operations are done:
       - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
       - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
       - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
       - s = "axyb", remove "xy" starting at index 1 so s = "ab".
       Now s has no occurrences of "xy".

       Constraints:

       1 <= s.length <= 1000
       1 <= part.length <= 1000
       s​​​​​​ and part consists of lowercase English letters.

       */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Continue removing occurrences of 'part' until none are left
                while (s.Contains(part))
                {
                    int index = s.IndexOf(part);
                    s = s.Substring(0, index) + s.Substring(index + part.Length);
                }

                return s;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }

        /* Self reference:Solving this problem highlights the power and limitations of string manipulation techniques in programming. 
         The iterative search-and-remove approach is intuitive but might not be the most efficient for large strings or substrings.
          Exploring more efficient string manipulation techniques, such as using a StringBuilder in .NET or similar mutable string classes
         in other languages, could significantly improve performance by reducing the number of string copies created during the removal process.
         Additionally, implementing a more sophisticated algorithm like KMP (Knuth-Morris-Pratt) for substring search could reduce 
        the overall time complexity for large inputs */


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}

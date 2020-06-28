using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//task: count identical entries in a list/array, etc.
namespace Count_Identical
{
    class Program
    {
        private static IEnumerable<KeyValuePair<string, int>> FindDuplicates(string[] list) {
            Dictionary<string, int> stringSet = new Dictionary<string, int>();
            foreach (var item in list)
            {
                int count;
                if (stringSet.TryGetValue(item, out count))
                {
                    stringSet[item] = count + 1;
                }
                else
                {
                    stringSet[item] = 1;
                }
            }
            return stringSet.Where(p => p.Value >1);
        }


        public static int Count_Entries(string[] list)
        {
            HashSet<string> stringSet = new HashSet<string>();
            int count= 1;
            foreach (var item in list)
            {
                if (stringSet.Contains(item))
                {
                    count++;
                }
                else
                {
                    stringSet.Add(item);
                }               
            }
            return count;
        }

       

        static int sockMerchant(int n, int[] ar)
        {
            int result = 0;
            int value = 0;
            Array.Sort(ar);
            for (int i = 0; i < ar.Length - 1; i++)
            {
                value = ar[i];
                for (int j = i + 1; j < ar.Length; j++)
                {
                    if (ar[j] == value)
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        static int countingValleys(int n, string s)
        {
            int result = 0;
            int hike = 0;
            int[] values = new int[n];
            bool valley = false;

            for (int i = 0; i < n; i++)
            {
                if (s[i] == 'U')
                {
                    values[i] = 1;
                }
                else if (s[i] == 'D')
                {
                    values[i] = -1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (values[i] == -1)
                {
                    hike = hike + values[i];
                    if (hike < 0 && valley == false)
                    {
                        valley = true;
                    }

                }
                else if (values[i] == 1)
                {
                    hike = hike + values[i];
                }

                if (hike == 0 && valley)
                {
                    result++;
                    valley = false;
                }
            }
            return result;
        }


    // Complete the jumpingOnClouds function below.
    static int jumpingOnClouds(int[] c) {
        int result = 0;
        int n = c.Length;
        int count = 1;
        bool[] ar = new bool[n];

        for(int i = 0; i < n-3;)
        {
            if (c[i] == 0 && c[i+1] == 0 && c[i+2] == 0)
            {
                i = i + 2;
                count++;
            }
            else if (c[i] == 0 && c[i + 1] == 1 && c[i + 2] == 0)
            {
                i = i + 2;
                count++;
            }
            else if(c[i] == 0 && c[i + 1] == 0 && c[i + 2] == 1)
            {
                i++;
                count++;            
            }
            else if (c[i + 1] == 0 && c[i + 2] == 0)
            {
                i++;
                count++;
            }
        }
        result = count;
        return result;
    }

        static int hourglassSum(int[][] arr) {
        int result = 0;
        //n number of columns, m number of rows
        int m, n;
        int sum = 0;
        int max_sum = int.MinValue;
        
        m = arr.GetLength(0);
        n = arr.Length;

        for (int i = 0; i < m - 2; i++)
        {
            for (int j = 0; j < n - 2; j++)
            {
                // Considering mat[i][j] as top  
                // left cell of hour glass. 
                sum = (arr[i][j] + arr[i] [j + 1] +
                           arr[i][j + 2]) + (arr[i + 1][ j + 1]) +
                          (arr[i + 2][j] + arr[i + 2][j + 1] +
                           arr[i + 2][j + 2]);

                // If previous sum is less then  
                // current sum then update 
                // new sum in max_sum 
                max_sum = Math.Max(max_sum, sum);
            }
        }

        result = max_sum;      
        return result;
    }

    static int[] rotLeft(int[] a, int d) {
        int length = a.Length;
        int index;
        int place;
        int[] result = new int[length];
        
        
        for(int i = 0; i < length; i++){
            index = i - d;
            place = length + index;
            if (index >= 0)
            {
                result[index] = a[i];
            }
            else
            {
                result[place] = a[i];
            }
        }        
        return result;
    }

    // Complete the minimumBribes function below.
    static void minimumBribes(int[] q)
    {
        int length = q.Length;
        int bribes;
        int pos = 0;
        int swap = 0;
        bool print = true;

        for (int i = length - 1; i >= 0; i--)
        {
            bribes = q[pos] - pos;

            if (bribes > 2)
            {
                Console.WriteLine("Too chaotic");
                print = false;
            }
            int j = 0;

            if (q[i] - 2 > 0)
            {
                j = q[i] - 2;
            }
            while (j <= i)
            {
                if (q[j] > q[i])
                {
                    swap++;
                }
                j++;
            }
            pos++;

        }
        if (print)
        {
            Console.WriteLine(swap);
        }
    }


    static int[] CountingSort(int[] array)
    {
        int[] sortedArray = new int[array.Length];

        // find smallest and largest value
        int minVal = array[0];
        int maxVal = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < minVal) minVal = array[i];
            else if (array[i] > maxVal) maxVal = array[i];
        }

        // init array of frequencies
        int[] counts = new int[maxVal - minVal + 1];

        // init the frequencies
        for (int i = 0; i < array.Length; i++)
        {
            counts[array[i] - minVal]++;
        }

        // recalculate
        counts[0]--;
        for (int i = 1; i < counts.Length; i++)
        {
            counts[i] = counts[i] + counts[i - 1];
        }

        // Sort the array
        for (int i = array.Length - 1; i >= 0; i--)
        {
            sortedArray[counts[array[i] - minVal]--] = array[i];
        }

        return sortedArray;
    }

    static int minimumSwaps(int[] arr)
    {
        int result = 0;
        int n = arr.Length;
        
        Dictionary<int, int> arrPos = new Dictionary<int,int>(n);
        for (int i = 0; i < n; i++)
        {
            arrPos.Add(i,arr[i]);            
        }


        foreach (var v in arrPos)
        {         
            Console.WriteLine("{0} {1} ",v.Key, v.Value);
        }

        for (int i = 0; i < n - i; i++)
        {

        }

        return result;
    }
       static string twoStrings(string s1, string s2)
    {
        string ans = "";
        char[] string1 = s1.ToCharArray();
        char[] string2 = s2.ToCharArray();

        HashSet<char> str1 = new HashSet<char>(string1);
        HashSet<char> str2 = new HashSet<char>(string2);
        
        foreach (var v in str2)
        {
            if (str1.Contains(v))
            {
                ans = "YES";
                break;
            }
            else
            {
                ans = "NO";
            }
        }
        return ans;
    }

    public static int countCounterfeit(List<string> serialNumber)
    {
        int sum = 0;
        string[] arr = serialNumber.GetRange(0, serialNumber.Count).ToArray();
        char[] charact = new char[12];
        string[] firstThree = new string[serialNumber.Count];
        string[] year = new string[serialNumber.Count];
        string[] denom = new string[serialNumber.Count];
        string[] last = new string[serialNumber.Count];
        int[] denomInt = new int[serialNumber.Count];
        bool test;
        HashSet<int> value = new HashSet<int> { 10, 20, 50, 100, 200, 500, 1000 };
        //test1
        for (int i = 0; i < arr.Length; i++)
        {         
            firstThree[i] = arr[i].Substring(0,3);
            year[i] = arr[i].Substring(3, 4);
            denom[i] = arr[i].Substring(7, arr[i].Length - 7);
            last[i] = arr[i].Substring(arr[i].Length - 1);         
        }

        for(int i = 0; i < serialNumber.Count; i++){
            test = int.TryParse(denom[i].Substring(0, denom[i].Length - 1), out denomInt[i]);
            if (test)
            {              
                    if (value.Contains(denomInt[i])){
                    sum = sum + denomInt[i];              
                }
            }
        }
                

return sum;
    }
   
        
    static int minimumNumber(int n, string password) {
        // Return the minimum number of characters to make the password strong
        int result = 0;
        string numbers = "0123456789";
string lower_case = "abcdefghijklmnopqrstuvwxyz";
string upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
string special_characters = "!@#$%^&*()-+";
        if(n < 6){
            return result = 6 - n;            
        }
        foreach(var v in numbers){
            if (password.Contains(v))
            {
                break;
            }
            if (!password.Contains(v))
            {
                result++;
                break;
            }            
        }
        foreach (var v in lower_case)
        {
            if (password.Contains(v))
            {
                break;
            }
            if (!password.Contains(v))
            {
                result++;
                break;
            }
        }
        foreach (var v in upper_case)
        {
            if (password.Contains(v))
            {
                break;
            }
            if (!password.Contains(v))
            {
                result++;
                break;
            }

        }
        foreach (var v in special_characters)
        {
            if (password.Contains(v))
            {
                break;
            }
            if (!password.Contains(v))
            {
                result++;
                break;
            }
        }


        return result;
    }


    static int countWays(int n)
    {
        // Create the dp array 
        int[] dp = new int[n + 1];

        // Initialize the base cases 
        // as explained above 
        dp[0] = 0;
        dp[1] = 1;

        // (12) as the only possibility 
        dp[2] = 1;

        // Generate answer for greater values 
        for (int i = 3; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 3] + 1;
        }

        // dp[n] contains the desired answer 
        return dp[n];
    }
    static int marsExploration(string s)
    {
        int res = 0;
        int length = 26;
        string message = "SOS";
        int[] hmap = new int[length];

        for(int i = 0; i < s.Length; i++){
            if (s[i] != message[i%3])
            {
                res++;
            }
        }        
        return res;
    }
    static string checkIfIsHacker(string s)
    {

        string test = "hackerrank";
        if (s.Length < test.Length)
        {
            return "NO";
        }
        int j = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (j < test.Length && s[i] == test[j])
            {
                j++;
            }
        }
        return (j == test.Length ? "YES" : "NO");

    }
    static string superReducedString(string s)
    {
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                //int len = s.Length - 2;
                s = s.Remove(i-1,2);
                i = 0;
                //len = 0;
            }
        }
        if (s.Length == 0)
        {
            return "Empty string";
        }
        else
        {
            return s;
        }

    }
    static int diag()
    {
        int result = 0;
        int left = 0;
        int right = 0;
        int size = 3;
        int[,] arr = new[,]{{1,2,3},{4,5,6},{7,8,9}};
        int j = size - 1;
        for (int i = 0; i <= size - 1; i++)
        {
            left += arr[i,i];
            right += arr[i, j - i];
            
        }
        result = Math.Abs(left - right);
        return result;
    }
    public static long getWays(int n, List<long> c)
    {
        long[] table = new long[n+1];

        for (int j = 0; j < table.Length;j++)
        {
            table[j] = 0;
        }
        table[0] = 1;
        
        for (int i = 0; i < c.Count; i++)
        {
            for (long k = c[i]; k <= n; k++)
            {
                table[k] = table[k] + table[k - c[i]];
            }
        }


        return table[n];
     

    }
    static void insertionSort2(int n, int[] arr)
    {
        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j > 0 && arr[j] > key)
            {
                //int temp = arr[j+ 1];
                arr[j + 1] = arr[j];
                //arr[j] = temp;
                j = j - 1;
                for (int k = 0; k < n; k++)
                {
                    Console.Write(arr[k] + " ");
                }
                Console.WriteLine();
            }
            arr[j + 1] = key;
        }

    }
    static void countSort(List<int> numbers)
    {
        var arr = new int[100];
        foreach (var n in numbers)
        {
            ++arr[n];
        }
        var counter = 0;
        for (int i = 0; i < 100; i++)
        {
            counter += arr[i];
            Console.Write(counter + " ");
        }
    }

    static int no_of_chars = 256;

    static String findSubString(String str, String pat)
    {
        
        int len1 = str.Length;
        int len2 = pat.Length;

        // check if string's length is less than pattern's 
        // length. If yes then no such window can exist 
        if (len1 < len2)
        {
            Console.WriteLine("No such window exists");
            return "";
        }

        int[] hash_pat = new int[no_of_chars];
        int[] hash_str = new int[no_of_chars];

        // store occurrence ofs characters of pattern 
        for (int i = 0; i < len2; i++)
            hash_pat[pat[i]]++;

        int start = 0, start_index = -1, min_len = int.MaxValue;

        // start traversing the string 
        int count = 0; // count of characters 
        for (int j = 0; j < len1; j++)
        {
            // count occurrence of characters of string 
            hash_str[str[j]]++;

            // If string's char matches with pattern's char 
            // then increment count 
            if (hash_pat[str[j]] != 0 &&
                hash_str[str[j]] <= hash_pat[str[j]])
                count++;

            // if all the characters are matched 
            if (count == len2)
            {
                // Try to minimize the window i.e., check if 
                // any character is occurring more no. of times 
                // than its occurrence in pattern, if yes 
                // then remove it from starting and also remove 
                // the useless characters. 
                while (hash_str[str[start]] > hash_pat[str[start]]
                    || hash_pat[str[start]] == 0)
                {

                    if (hash_str[str[start]] > hash_pat[str[start]])
                        hash_str[str[start]]--;
                    start++;
                }

                // update window size 
                int len_window = j - start + 1;
                if (min_len > len_window)
                {
                    min_len = len_window;
                    start_index = start;
                }
            }
        }

        // If no window found 
        if (start_index == -1)
        {
            Console.WriteLine("No such window exists");
            return "";
        }

        // Return substring starting from start_index 
        // and length min_len 
        return str.Substring(start_index, min_len);
    }

        //given an array of values count ways to give change for that value
    static long countWaysNew(int[] S, int m, int n)
    {
        //Time complexity of this function: O(mn) 
        //Space Complexity of this function: O(n) 

        // table[i] will be storing the number of solutions 
        // for value i. We need n+1 rows as the table is 
        // constructed in bottom up manner using the base 
        // case (n = 0) 
        int[] table = new int[n + 1];

        // Initialize all table values as 0 
        for (int i = 0; i < table.Length; i++)
        {
            table[i] = 0;
        }

        // Base case (If given value is 0) 
        table[0] = 1;

        // Pick all coins one by one and update the table[] 
        // values after the index greater than or equal to 
        // the value of the picked coin 
        for (int i = 0; i < m; i++)
            for (int j = S[i]; j <= n; j++)
                table[j] += table[j - S[i]];

        return table[n];
    }

    static int[] reverseArray(int[] a)
    {
        int[] result = new int[a.Length];
        int j = 0;
        for (int i = a.Length - 1; i >= 0; i--)
        {
            result[j] = a[i];
            j++;
        }

        return result;
    }


    static int sherlockAndAnagrams(string s)
    {
        var dic = new Dictionary<string, int>();
        var count = 0;

        foreach (var substring in getSubstring(s))
        {
            Console.WriteLine(substring);

            if (dic.ContainsKey(substring))
            {
                var value = dic[substring];
                count += value;

                dic[substring] = value + 1;
            }
            else
            {
                dic.Add(substring, 1);
            }
        }

        return count;
    }

    static IEnumerable<string> getSubstring(string s)
    {
        for (var i = 0; i < s.Length; i++)
        {
            for (var j = 1; j <= s.Length - i; j++)
            {
                var substring = s.Substring(i, j);
                var chars = substring.ToCharArray();
                Array.Sort(chars);

                yield return new string(chars);
            }
        }
    }

    static long arrayManipulation(int n, int[][] queries)
    {
        long result = 0;
        long[] arr = new long[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = 0;
        }
        for (int j = 0; j < queries.Length;j++)
        {
            int a = queries[j][0];
            int b = queries[j][1];
            long k = queries[j][2];

            for (int l = a - 1; l < b - 1; l++)
            {
                arr[l] += k;               
            }
        }

        for (int m = 0; m < n; m++ )
        {
            if(arr[m] > result){
                result = arr[m];
            }
        }


        return result;
    }


        static void Main(string[] args)
        {
            int result;
            IEnumerable<KeyValuePair<string, int>> output = new Dictionary<string, int>();
            String[] list = { "abc", "adc", "adv", "abc", "acd" };
            List<string> test = new List<string>();
            test.Add("AVG190420T");
            test.Add("RTF20001000Z");
            test.Add("QWER201850G");
            test.Add("AFA199620E");
            int[] ar = {1, 4, 3, 2};

            int x = 4, b = 2;
            x -= b;
            x = x * b;
            Console.WriteLine(x + " " + b);

            Program.sherlockAndAnagrams("cdcd");

            Program.reverseArray(ar);
            String str = "this is a test string";
            String pat = "tist";

            Console.WriteLine("Smallest window is :\n " +
                            Program.findSubString(str, pat));

            //var length = 0;
            //length = Convert.ToInt32(Console.ReadLine());
            //var listNumber = new List<int>();

            //for (int i = 0; i < length; i++)
            //{
            //    string input = Console.ReadLine();
            //    int pos = input.IndexOf(' ');
            //    var number = input.Substring(0, pos);
            //    listNumber.Add(int.Parse(number));
            //}

            //countSort(listNumber);


            //result =  countCounterfeit(test);
            //output = FindDuplicates(list);
            //output.ToList().ForEach(x => Console.WriteLine(x.Key));
            string reduced = "aaabccddd";
            //Console.WriteLine(Program.superReducedString(reduced));
            int[] arr = {1, 4, 3, 5, 6, 2};
            int[] s = {1, 2, 3 };
            Program.countWaysNew(s, s.Length, 4);
            Program.insertionSort2(6, arr);
            int n = 6;
            List<long> ls = new List<long>();
            ls.Add(2);
            ls.Add(5);
            ls.Add(3);
            ls.Add(6);
            Console.WriteLine(Program.getWays(10, ls));
            //Console.WriteLine(countWays(n));
            //Program.findSubString("this is a test string", "tist");
            //Program.marsExploration("SOSSPSSQSSOR");
            //Program.diag();
            //Program.minimumSwaps(arr);
            //Program.minimumNumber(11, "#HackeRank");
            //result = Program.hourglassSum(arr, 2);
            //int[] arr = new int[10]{1, 5, 4, 11, 20, 8, 2, 98, 90, 16};

            //int[] sortedArray = Program.CountingSort(arr);
            //Console.WriteLine("Sorted Values:");
            //for (int i = 0; i < sortedArray.Length; i++)
            //    Console.WriteLine(sortedArray[i]);

            int[] c = new int[5];
            string answer = Program.twoStrings("hello", "world");
            //Console.WriteLine(answer);
            //c = Program.rotLeft(arr, 2);
            //Console.WriteLine(Program.minimumBribes(arr));


            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int n = Convert.ToInt32(Console.ReadLine());

            //int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            //int resultB = Program.sockMerchant(n, ar);

            //Console.WriteLine(resultB);
            //int n = 4;
            //String s = "DDUU";
            //int resultValley = Program.countingValleys(n, s);
            //Console.WriteLine(resultValley);
            Console.ReadKey();


        }
    }
}

 //public static long getWays(int n, List<long> c)
 //   {
 //       long result = 0;
 //       int[][] test = new int[n][];
 //       for (int i = 0; i < c.Count; i++)
 //       {
 //           for (int j = 0; j < n; j++)
 //           {
 //               if (i == 0 && j == 0)
 //               {
 //                   test[i][j] =1;
 //               }
 //               else
 //               {
 //                   if (i > j)
 //                   {
 //                       test[i][j] = test[i - 1][j];
 //                   }
 //                   else
 //                   {
 //                       test[i][j] = test[i - 1][j] + test[i][j - 1];
 //                   }
 //               }
 //           }
 //       }



 //       return result;

 //   }

//for (int k = 0; k < n -2; k++)
//        {
//            for (int l = 0; l < m - 2; l++)
//            {

//                for (int i = k; i < k + 3; i++)
//                {
//                    for (int j = l; j < l + 3; j++)
//                    {
//                        if (i == 1 && j == 0)
//                        {
//                            negate = negate + arr[i][j];
//                        }
//                        else if (i == 1 && j == 2)
//                        {
//                            negate = negate + arr[i][j];
//                        }
//                        sum = sum + arr[i][j] - negate;
//                        newArray[l][k] = sum;
//                    }
                   
//                }
//            }
//        }
//        for (int i = 0; i < newArray.GetLength(0) - 1; i++)
//        {
//            for (int j = 0; j < newArray.Length - 1; j++)
//            {
//                Console.Write(newArray[i][j] + " ");
//            }
//        }
        
         


//            //find maximum of the newArray
//            for (int i = 0; i < newArray.GetLength(0)-1; i++)
//            {
//                for (int j = 0; j < newArray.Length - 1; j++)
//                {                    
//                    max = newArray[i][j];
//                    if (newArray[i][j + 1] > max)
//                    {
//                        max = newArray[i][j+1];
//                    }

//                }
//            }

//            result = sum - negate;

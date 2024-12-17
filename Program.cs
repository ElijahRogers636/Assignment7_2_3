

namespace Assignment7_2_3
{
    internal class Program
    {
        //Given two strings s and t, return true if t is an anagram of s, and false otherwise.
        //An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
        static void Main(string[] args)
        {
            Console.WriteLine(ArrAnagramCheck("anagram", "nanaram"));
        }
        
        //Dictionary version (Mine) (Instead of two dictionaries, we could use one and just increment and decrement)
        static bool DictAnagramCheck(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;
            var dict = new Dictionary<char, int>();
            var dict2 = new Dictionary<char, int>();

            for (int i = 0; i < word1.Length; i++)
            {
                if (!dict.TryAdd(word1[i], 1))
                {
                    dict[word1[i]]++;
                }
                if(!dict2.TryAdd(word2[i], 1))
                {
                    dict2[word2[i]]++;
                }
            }
            foreach (var (key, value) in dict)
            {
                if(!dict2.ContainsKey(key) || value != dict2[key])
                {
                    return false;
                }
            }
            return true;
        }

        //Sort version
        static bool SortedAnagramCheck(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;
            char[] char1 = word1.ToArray();
            char[] char2 = word2.ToArray();
            Array.Sort(char1);
            Array.Sort(char2);

            return string.Join("", char1) == string.Join("", char2);
        }

        // Array version(Not my code)
        // Uses the integer value of char to keep count of letters(Frequency counter)
        static bool ArrAnagramCheck(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;
            int n = word1.Length;
            var charCounter = new int[128];

            for (int i = 0; i < n; i++)
            {
                charCounter[word1[i]]++;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"<=======================Iteration {i + 1}=======================>");
                charCounter[word2[i]]--;
                Print(charCounter);
                Console.WriteLine();

                if (charCounter[word2[i]] < 0)
                {
                    return false;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                if (charCounter[i] > 0)
                    return false;
            }

            return true;
        }

        static void Print(Dictionary<char, int> dict)
        {
            Console.Write("|");
            foreach (var (key, value) in dict)
            {
                Console.Write($" Key: {key}, Value: {value} |");
            }
            Console.WriteLine();
        }

        static void Print(int[] arr)
        {
            Console.Write("|");
            foreach (int i in arr)
            {
                Console.Write($" {i} |");
            }
            Console.WriteLine();
        }
    }
}

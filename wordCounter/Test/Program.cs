using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using wordCounter;

namespace wordCounter;

public class WordCounting
{

    public static void Main()
    {
        ListofWords a = new("test.txt");
        Console.WriteLine(a);

        Dictionary<string, int> dict = new Dictionary<string, int>();


        ListofWords result = new();
        foreach(KeyValuePair<string, Words> ab in ListofWords.wordClasses)
        {
            if(ListofWords.wordClasses[ab.Key].count >= 0)
            {
                if(Regex.IsMatch(ab.Key, @"^[A-Za-z_]*$"))
                {
                    dict.Add(ab.Key.ToLower(), ListofWords.wordClasses[ab.Key].count);
                }
                
            }
        }

        var sortedDict = from entry in dict orderby entry.Value descending select entry;

        Console.WriteLine("-------------WORDSTARTS-------------");
        foreach (KeyValuePair<string, int> ab in sortedDict)
        {
            if (ab.Key.Length > 0)
            {
                Console.WriteLine(ab.Key.ToUpper()[0] + ab.Key[1..]);
            }
        }

        Console.WriteLine("-------------COUNTSTARTS-------------");
        foreach (KeyValuePair<string, int> ab in sortedDict)
        {
            if (ab.Key.Length > 0)
            {
                Console.WriteLine(ab.Value);
            }
        }

    }
}


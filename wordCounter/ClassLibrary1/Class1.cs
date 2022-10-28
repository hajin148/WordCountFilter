using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace wordCounter
{
    public class Words
    {
        public string word;
        public int count = 0;

        public Words(string word)
        {
            this.word = word;
        }
    }

    public class ListofWords
    {
        public static Dictionary<string, Words> wordClasses = new();
        public static List<string> filter = new();
        public ListofWords()
        {

        }
        public ListofWords(string filename)
        {
            string jsonText = File.ReadAllText(filename);
            string filterFile = File.ReadAllText("filter.txt");
            string[] substrings = Regex.Split(jsonText, "(\\()|(\\))|(-)|(\\+)|(\\*)|(/)|(\\.)|(\\ )|(\\,)|(\\n)|(\\t)|(\\r)");
            string[] filterstrings = Regex.Split(filterFile, "(\\()|(\\))|(-)|(\\+)|(\\*)|(/)|(\\.)|(\\ )|(\\,)|(\\n)|(\\t)|(\\r)");

            foreach (string filterstring in filterstrings)
            {
                if(filterstring == ",")
                {
                    continue;
                }
                else
                {
                    filter.Add(filterstring.ToUpper());
                }
            }

            foreach (string strings in substrings)
            {
                string upperString = strings.ToUpper();
                if(filter.Contains(strings.ToUpper())|upperString == " " | upperString == "," | upperString == "." | upperString == "/" | upperString == "!" | upperString == "\"" | upperString == "\'" | upperString == "/" | upperString == "?" )
                {
                    continue;
                }

                else if (wordClasses.ContainsKey(upperString))
                {
                    wordClasses[upperString].count++;
                    
                    
                }
                else
                {
                    Words word = new Words(upperString);
                    word.count += 1;
                    if(!wordClasses.ContainsKey(upperString))
                    {
                        wordClasses.Add(upperString, word);
                    }
                    
                }

            }
        }
  

    }

    

}


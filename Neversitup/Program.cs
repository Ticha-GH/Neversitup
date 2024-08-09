using System;
using System.IO;
using System.Linq;


public class Program
{

    public string[] Shuffle(string word)
    {
        if (word.Length == 1)
        {
            return new string[] { word };
        }
        else
        {
            List<string> words = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                char parent = word[i];
                string child = $"{word.Substring(0, i)}{word.Substring(i + 1)}";
                string[] childs = Shuffle(child);
                for (int j = 0; j < childs.Length; j++)
                {
                    string newWord = $"{parent}{childs[j]}";
                    bool duplicate = words.Count > 0 && words.Any(x => words.Contains(newWord));
                    if (!duplicate)
                    {
                        words.Add(newWord);
                    }
                }
            }
            return words.ToArray();
        }
    }

    public string FindOdd(int[] numbers)
    {
        List<CountModel> counts = new List<CountModel>();

        foreach (int number in numbers)
        {
            CountModel model = counts.Where(x => x.Number == number).FirstOrDefault();
            if (model is not null)
            {
                model.Count++;
            }
            else
            {
                counts.Add(new CountModel() { Number = number, Count = 1 });
            }

        }

        counts = counts.Where(x => x.Count % 2 != 0).ToList();
        if (counts.Count != 1)
        {
            return "";
        }

        CountModel result = counts.FirstOrDefault();
        var str = $"{result.Number}, because ot occurs {result.Count} times (which is odd)";
        return str;
    }

    public int SmileyFaces(string[] faces)
    {
        List<string> smileFaces = new List<string> { };
        char[] eyes = new char[] { ':', ';' };
        char[] noses = new char[] { '-', '~' };
        char[] smailes = new char[] { ')', 'D' };

        foreach (var face in faces)
        {
            if (!string.IsNullOrEmpty(face))
            {
                int i = 0;
                if (eyes.Any(x => x == face[i]))
                {
                    i++;

                    if (noses.Any(x => x == face[i]))
                    {
                        i++;
                    }

                    if (smailes.Any(x => x == face[i]))
                    {
                        smileFaces.Add(face);
                    }
                }
            }
        }

        return smileFaces.Count;
    }

    public class CountModel
    {
        public int Number { get; set; }
        public int Count { get; set; }
    }

    public static void Main()
    {
    }

}


using codingtest;
using System.IO;
using System.Text;

namespace codetest;

public class AnagramFinder
{
    
    HashSet<string> uniqueWords = new HashSet<string>();
    List<string> anagrams = new List<string>(); 
    Dictionary<AnagramKey, int> anagramPosition = new Dictionary<AnagramKey, int>();

    public string[]? FindAnagrams(string filename)
    {
        using (var fileStream = File.OpenRead(filename))
        {
            using (var streamReader = new StreamReader(fileStream))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (uniqueWords.Contains(line)) { continue; }
                    uniqueWords.Add(line);

                    var charFrequency = new AnagramKey(line);
                    if(anagramPosition.ContainsKey(charFrequency))
                    {
                        anagrams[anagramPosition[charFrequency]] += "," + line;
                        continue;
                    }
                    
                    anagramPosition.Add(charFrequency, anagrams.Count);
                    anagrams.Add(line);
                }

            }
        }

        return anagrams.ToArray();
    }


}
﻿using codetest;

namespace codingtest;

public class Program
{
    public static void Main(string[] args)
    {
        if(args.Length == 0 || args.Length > 1 || string.IsNullOrWhiteSpace(args[0])) {
            Console.WriteLine("Please ensure that the input file is provided");
            return;
        }
        
        if(!File.Exists(args[0])){
            Console.WriteLine($"{args[0]} does not exist");
            return;
        }
        var anagramFinder = new AnagramFinder();

        foreach(string anagrams in anagramFinder.FindAnagrams(args[0])) 
        {
            Console.WriteLine(anagrams);
        }
        // Find anagrams ...
    }
}
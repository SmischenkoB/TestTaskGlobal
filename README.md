# Anagram Finder

## The Task
Write a program that takes as an argument the path to a file containing one word per line, groups the words that are anagrams to each other, and writes to the standard output of each of these groups.

The groups should be separated by newlines and the words inside each group by commas.

## The Data
You can make the following assumptions about the data in the files::

- The words in the input file are ordered by size
- The files may not fit into memory all at once (but all the words of the same size would)
- The words are not necessarily actual English words. For example, "ABC" and "CBA" are both considered words for the sake of this exercise.

The files `example1.txt` and `example2.txt` are just sample input data to help you reason about the problem. Production files will be much more significant.

If you make other assumptions, write them down in a readme in your submission.

## How much time do I have?
Try to spend 30-45 mins on this exercise. We have written some scaffolding that you can use: commercial-trading-net-techtest-master.zip. We ask you not to fork this repository instead just download the zip and push to your own public git repo.

## Our expectations
A solution implemented .NET

We expect testable code that's not only accomplishing the task, but is maintainable by anybody in the team.

## What should a good submission include?
- Full suite of automated tests covering the edge cases
- Exceptions handling
- Separation of concerns
- The resources (CPU, memory, disk...) efficiently used
- Big O analysis
- Reasons behind data structures chosen
- What would you do given more time
- The code should be easy to read, with well-named variables/functions/classes. We like Clean Code principles :)

## Important
- We expect your code to compute the anagrams without the help of any library.
- You are allowed to use any library for any other aspect functional to the task (e.g., handling the CLI, testing, I/O)
- The order of the groups in the output does not matte

---

## Software required to run this
* .NET 6.0 (https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* Visual Studio Code (https://code.visualstudio.com/download)
* Visual Studio Code C# Dev Kit Extension

## Building and Running the tests

- Open a command prompt
- Navigate to the folder where this code test has been deployed or cloned
- in the command prompt open Visual Studio Code by:
```
> code src
```
- Click on the Extensions icon (or [CTRL] + [SHIFT] + [X])
- In the search box enter:
```
C# Dev Kit
```
- Click the Install button
- Once this extension has installed, you will need to close and reopen Visual Studio Code
- On restart, you should now see a conical flask icon. Click this Icon (Testing)
- On the dialog, click the double play button (Run Tests). You will see 4 tests run, 3 pass and 1 fails. 

Part of your task to write a solution so that this last test passes!


# Editing Test Cases

- Select the Explorer icon on the left (or [CTRL] + [SHIFT] + [E])
- Under 'tests' are two files 'ProgramIntegrationTests.cs' and 'AnagramFinderTests.cs'
- These are the unit tests for this solution.
- You can run all or individual tests, together with debugging tests by either (a) clicking the right mouse button and selecting an option from the context menu, or (b) using the test explorer and selecting one of the icons next to the test you wish to run or debug.

## Running the program
```
dotnet src\codingtest\bin\Debug\net6.0\codingtest.dll example1.txt
```
where example1.txt is the text file that we want to search for anagrams

## Expected Output for the example1.txt file

```
abc,bac,cba
unf,fun
hello
```

## RESULTS

Thanks for test framework, running app should be done as described above - you push file as parameters. Example 2 took 123 megs.

I took 2 structures intitially:
    Dictionary, where key is processed string (take all chars and count them) and value is position of final line in the output array, this line is modied throughout running through file. By counting amount of letters (complexity of this approach is O(n), n number of letters in a word), searching of anagrams becomes O(1) in a dictionary, though custom hash function can be bad. 
    Output list - used to merge words found as anagrams, if word is not anagram - add to an end. Adding item to an end of the list - O(1), slowest operation here is merging strings because it creates new string, so string builder can be used to reduce memory and speed load. As we are using position from the dictionary, reaching correct item in this list is O(1).
But I run into issue with repeating words - so added HashSet to check if word is unique. Used this article to clarify it's possible - https://learn.microsoft.com/en-us/dotnet/api/system.string.gethashcode?view=net-8.0, though can be issues with string's hash code, this code can be reviewed. 

More time - decouple code more, so it's easier to cover with tests, because for now - it's coupled and AnagramFinder violates SOLID. Would like to make this code asyncronious, this'll make it more exception tolerate. Discuss string builder usufulness in anagrams list. Reading file in async mode will be nice:). Make AnagramFinder static.

Noticed Note about order of groups, though tests will fail in this scenario
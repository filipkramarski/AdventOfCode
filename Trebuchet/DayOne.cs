using System;
using System.Collections.Generic;
using System.IO;

class DayOne
{
    static void Main()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "input.txt");

        if (File.Exists(filePath))
        {
            try
            {
                string input = File.ReadAllText(filePath);

                int sum = CalculateSumOfFirstAndLastDigits(input);

                Console.WriteLine($"Sum of first and last digits: {sum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("File not found on the desktop.");
        }
    }

    static int CalculateSumOfFirstAndLastDigits(string input)
    {
        int sum = 0;

        string[] lines = input.Split('\n');

        foreach (string line in lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                string lineWithDigits = ConvertWordDigitsToActualDigits(line);
                Console.WriteLine(lineWithDigits);

                char firstDigit = FindFirstDigit(lineWithDigits);
                char lastDigit = FindLastDigit(lineWithDigits);

                if (char.IsDigit(firstDigit) && char.IsDigit(lastDigit))
                {
                    int number = (firstDigit - '0') * 10 + (lastDigit - '0');
                    sum += number;
                }
            }
        }

        return sum;
    }

    static char FindFirstDigit(string line)
    {
        foreach (char c in line)
        {
            if (char.IsDigit(c))
            {
                return c;
            }
        }
        return '\0';
    }

    static char FindLastDigit(string line)
    {
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(line[i]))
            {
                return line[i];
            }
        }
        return '\0';
    }

    static string ConvertWordDigitsToActualDigits(string line)
    {
        Dictionary<string, string> wordToDigitMap = new Dictionary<string, string>
    {
        {"one", "1"},
        {"two", "2"},
        {"three", "3"},
        {"four", "4"},
        {"five", "5"},
        {"six", "6"},
        {"seven", "7"},
        {"eight", "8"},
        {"nine", "9"},
        {"zero", "0"}
    };

        foreach (var entry in wordToDigitMap)
        {
            line = line.Replace(entry.Key, entry.Key + entry.Value);
        }

        return line;
    }

}

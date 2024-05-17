using System.Text;
using System.Text.RegularExpressions;

namespace Crypto1;

public static partial class CesarShift
{
    public static string Apply(string clearMessage, int shiftRightToApply)
    {
        Console.WriteLine($"Applying Cesar shift.\nInitial message : {clearMessage}\nShifting {shiftRightToApply}");
        
        StringBuilder stringBuilder = new();
        
        foreach(var c in clearMessage.ToLower())
        {
            var charToAdd = c;
            if (MyRegex().IsMatch(c.ToString()))
            {
                var asciiIndex = (int)charToAdd;
                if (asciiIndex is >= 'a' and <= 'z')
                {
                    var shiftedAsciiIndex = asciiIndex + shiftRightToApply;
                    var newAsciiIndex = shiftedAsciiIndex;
                    if (newAsciiIndex > 'z')
                    {
                        newAsciiIndex -= 'z'-'a' + 1;
                    } 
                    charToAdd = (char)newAsciiIndex;
                }
            }

            stringBuilder.Append(charToAdd);
        }

        var result = stringBuilder.ToString();
        Console.WriteLine($"Cesar applied.\nCrypted message : {result}");
        return result;
    }

    public static IEnumerable<string> Revert(string cryptedMessage)
    {
        Console.WriteLine($"Reverting message : {cryptedMessage}");
        var frequencyDic = new Dictionary<char, double>();
        foreach (var c in cryptedMessage.Where(c => MyRegex().IsMatch(c.ToString())))
        {
            var countInMessage = (double)cryptedMessage.Count(charInMessage => charInMessage == c);
            frequencyDic.TryAdd(c, countInMessage / cryptedMessage.Length);
        }
        
        Console.WriteLine("Frequencies :");
        foreach (var pair in frequencyDic.OrderByDescending(pair => pair.Value))
        {
            Console.WriteLine($"{pair.Key} : {pair.Value}");
        }

        var revertedStrings = new List<string>();
        foreach (var pair in frequencyDic.OrderByDescending(pair => pair.Value).Take(5))
        {
            var mostFrequentLetter = pair.Key;
            Console.WriteLine($"Chosing \'{mostFrequentLetter}\' as equivalent of \'e\'.");

            var shiftLeftToApply = int.Abs('e' - mostFrequentLetter) ;

            var revertedMessage = Apply(cryptedMessage, shiftLeftToApply * -1);
            Console.WriteLine($"Reverted message : {revertedMessage}");
            revertedStrings.Add(revertedMessage);
        }
        return revertedStrings;
    }

    [GeneratedRegex("[a-zA-Z]")]
    private static partial Regex MyRegex();
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using N2W.CORE.Handlers;

namespace N2W.CORE.Services
{
  public class NumberToWordsService : INumberToWordsService
  {
    private readonly IDecompositionService _service;
    private readonly IRangeHandler _handler;
    private const string And = "and";

    public NumberToWordsService(IDecompositionService service, IRangeHandler handler)
    {
      _service = service;
      _handler = handler;
    }
    public string GetWords(int number)
    {
      if (number == 0)
        return "zero";

      var decomposition = _service.GetDecomposition(number);

      var words = string.Empty;
      foreach (var powerOfTen in decomposition.OrderByDescending(e => e.Key))
      {
        foreach (var numberPart in powerOfTen.Value)
        {
          words = string.Format("{0} {1}", words, _handler.GetWord(numberPart));
        }

        words = AddAndIfNeeded(words);

        if (powerOfTen.Key == 1)
          words = string.Format("{0} thousand", words);
        if (powerOfTen.Key == 2)
          words = string.Format("{0} million", words);
      }

      words = RemoveDuplicatesAnd(words);

      return words;
    }

    private static string RemoveDuplicatesAnd(string words)
    {
      return words.Replace(string.Format("{0} {1}", And, And), And);
    }

    private static string AddAndIfNeeded(string words)
    {
      var andAlready = false;

      AddAndIfNeeded(ref words, ref andAlready, Constants.TwentyToNinety);

      AddAndIfNeeded(ref words, ref andAlready, Constants.TenToNineteen);

      AddAndIfNeeded(ref words, ref andAlready, Constants.OneToNine);

      words = RemoveAndsAtTheVeryBeginning(words);

      return words.Trim();
    }

    private static string RemoveAndsAtTheVeryBeginning(string words)
    {
      words = words.Trim();

      if (words.Substring(0, 3) == And)
      {
        words = words.Substring(3);
        return RemoveAndsAtTheVeryBeginning(words);
      }
      return words;
    }

    private static void AddAndIfNeeded(ref string words, ref bool andAlready, IEnumerable<KeyValuePair<int, string>> collection)
    {
      if (!andAlready)
      {
        foreach (var item in collection)
        {
          if (words.Contains(item.Value))
          {
            words = words.Replace(item.Value, string.Format("{0} {1}", And, item.Value));
            andAlready = true;
          }
        }
      }
    }
  }
}
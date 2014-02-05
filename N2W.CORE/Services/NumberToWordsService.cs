using System.Collections.Generic;
using System.Linq;
using N2W.CORE.Handlers;

namespace N2W.CORE.Services
{
  public class NumberToWordsService : INumberToWordsService
  {
    private readonly IDecompositionService _service;
    private readonly IRangeHandler _handler;
    public NumberToWordsService(IDecompositionService service, IRangeHandler handler)
    {
      _service = service;
      _handler = handler;
    }
    public string GetWords(int number)
    {
      if (number == 0)
        return Constants.Zero;

      var decomposition = _service.GetDecomposition(number);

      var words = string.Empty;
      foreach (var powerOfTen in decomposition.OrderByDescending(e => e.Key))
      {
        var innerWords = string.Empty;
        foreach (var numberPart in powerOfTen.Value)
        {
          innerWords = string.Format("{0} {1}", innerWords, _handler.GetWord(numberPart));
          innerWords = innerWords.Trim();
        }

        innerWords = AddAndIfNeeded(innerWords);

        if (powerOfTen.Key == 1 && !string.IsNullOrEmpty(innerWords))
          innerWords = string.Format("{0} {1}", innerWords, Constants.Thousand);
        if (powerOfTen.Key == 2 && !string.IsNullOrEmpty(innerWords))
          innerWords = string.Format("{0} {1}", innerWords, Constants.Million);

        words = string.Format("{0} {1}", words, innerWords);
      }

      words = RemoveAndsAtTheVeryBeginning(words);

      return words.Trim();
    }
    private static string AddAndIfNeeded(string words)
    {
      var andAlready = false;

      AddAndIfNeeded(ref words, ref andAlready, Constants.TwentyToNinety);

      AddAndIfNeeded(ref words, ref andAlready, Constants.TenToNineteen);

      AddAndIfNeeded(ref words, ref andAlready, Constants.OneToNine);

      return words.Trim();
    }
    private static string RemoveAndsAtTheVeryBeginning(string words)
    {
      words = words.Trim();

      if (words.Substring(0, 3) == Constants.And)
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
            words = words.Replace(item.Value, string.Format("{0} {1}", Constants.And, item.Value));
            andAlready = true;
          }
        }
      }
    }
  }
}
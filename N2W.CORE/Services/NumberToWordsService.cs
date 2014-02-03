using System;
using System.Collections.Generic;
using System.Linq;

namespace N2W.CORE.Services
{
  public class NumberToWordsService : INumberToWordsService
  {
    private readonly IDecompositionService _service;
    private readonly Dictionary<int, string> _parts = GetParts();

    public NumberToWordsService(IDecompositionService service)
    {
      _service = service;
    }

    private static Dictionary<int, string> GetParts()
    {
      return new Dictionary<int, string>
      {
        { 0, "zero" },
        { 1, "one" },
        { 2, "two" },
        { 3, "three" },
        { 4, "four" },
        { 5, "five" },
        { 6, "six" },
        { 7, "seven" },
        { 8, "eight" },
        { 9, "nine" },
        { 10, "ten" },
        { 20, "twenty" },
        { 100, "hundred" },
        { 1000, "thousand" },
        { 1000000, "million" },
      };
    }

    public string GetWords(int number)
    {
      var decomposition = _service.GetDecomposition(number);
      var words = string.Empty;

      foreach (var item in decomposition)
      {
        var word = GetWord(item);

        words = string.Format("{0} {1}", words, word);
      }
      return words.Trim();
    }

    private string GetWord(int item)
    {
      var pow = Math.Log10(item);

      return _parts.First(e => e.Key == item).Value;
    }
  }
}
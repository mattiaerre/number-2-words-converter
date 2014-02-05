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
        return "zero";

      var decomposition = _service.GetDecomposition(number);

      var words = string.Empty;
      foreach (var powerOfTen in decomposition.OrderByDescending(e => e.Key))
      {
        foreach (var numberPart in powerOfTen.Value)
        {
          words = string.Format("{0} {1}", words, _handler.GetWord(numberPart));
        }
        if (powerOfTen.Key == 1)
          words = string.Format("{0} thousand", words);
        if (powerOfTen.Key == 2)
          words = string.Format("{0} million", words);
      }

      words = AddAndIfNeeded(words);

      return words;
    }

    private static string AddAndIfNeeded(string words)
    {
      //const string and = "and";

      //if (words.Contains(Constants.Hundred))
      //  words = words.Replace(Constants.Hundred, string.Format("{0} {1}", Constants.Hundred, and));

      //words = words.Trim();

      //if (words.Substring(words.Length - 4) == string.Format(" {0}", and))
      //  words = words.Substring(0, words.Length - 3);

      //return words.Trim();

      // todo: and management

      return words.Trim();
    }
  }
}
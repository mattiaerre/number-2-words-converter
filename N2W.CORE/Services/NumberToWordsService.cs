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

      foreach (var item in decomposition)
      {
        var word = _handler.GetWord(item);
        if (word != string.Empty)
          words = string.Format("{0} {1}", words, word);
      }

      words = AddAndIfNeeded(words);

      return words.Trim();
    }

    private static string AddAndIfNeeded(string words)
    {
      if (words.Contains(Constants.Hundred))
        words = words.Replace(Constants.Hundred, string.Format("{0} and", Constants.Hundred));
      return words;
    }
  }
}
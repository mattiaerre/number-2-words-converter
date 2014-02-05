using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace N2W.CORE.Services
{
  public class DecompositionService : IDecompositionService
  {
    public IDictionary<int, IEnumerable<int>> GetDecomposition(int number)
    {
      var chunks = Split(number.ToString(CultureInfo.InvariantCulture));

      var decomposition = new Dictionary<int, IEnumerable<int>>();

      var i = 0;
      foreach (var chunk in chunks)
      {
        decomposition.Add(i, GetNumbers(chunk));
        i++;
      }

      return decomposition;
    }

    private static IEnumerable<int> GetNumbers(string chunk)
    {
      var digits = chunk.ToCharArray().Select(e => Convert.ToInt32(e.ToString(CultureInfo.InvariantCulture))).ToArray();

      var length = digits.Length;

      if (length == 1)
        return digits;
      if (length == 2 && digits[0] == 1)
        return new[] { digits[0] * 10 + digits[1] };
      if (length == 2 && digits[0] > 1)
        return new[] { digits[0] * 10, digits[1] };
      if (length == 3 && digits[1] == 0)
        return new[] { digits[0] * 100, digits[2] };
      if (length == 3 && digits[1] == 1)
        return new[] { digits[0] * 100, digits[1] * 10 + digits[2] };
      if (length == 3 && digits[1] > 1)
        return new[] { digits[0] * 100, digits[1] * 10, digits[2] };
      return Enumerable.Empty<int>();
    }

    private static IEnumerable<string> Split(string source)
    {
      var length = source.Length;
      if (length <= 3)
        return new[] { source };
      if (length > 3 && length <= 6)
        return new[] { source.Substring(length - 3, 3), source.Substring(0, length - 3) };
      if (length > 6 && length <= 9)
        return new[] { source.Substring(length - 3, 3), source.Substring(length - 6, 3), source.Substring(0, length - 6) };
      return Enumerable.Empty<string>();
    }
  }
}
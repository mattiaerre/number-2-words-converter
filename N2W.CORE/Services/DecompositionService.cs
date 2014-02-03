using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace N2W.CORE.Services
{
  public class DecompositionService : IDecompositionService
  {
    public IEnumerable<int> GetDecomposition(int number)
    {
      var parts = number.ToString(CultureInfo.InvariantCulture).ToCharArray().Select(e => Convert.ToInt32(e.ToString(CultureInfo.InvariantCulture))).ToArray();

      for (var i = 0; i < parts.Length; i++)
      {
        yield return (int)(parts[i] * Math.Pow(10, parts.Length - 1 - i));
      }
    }
  }
}
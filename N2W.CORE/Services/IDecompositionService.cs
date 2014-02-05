using System.Collections.Generic;

namespace N2W.CORE.Services
{
  public interface IDecompositionService
  {
    IDictionary<int, IEnumerable<int>> GetDecomposition(int number);
  }
}
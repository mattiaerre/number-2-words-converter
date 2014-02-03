using System.Collections.Generic;

namespace N2W.CORE.Services
{
  public interface IDecompositionService
  {
    IEnumerable<int> GetDecomposition(int number);
  }
}
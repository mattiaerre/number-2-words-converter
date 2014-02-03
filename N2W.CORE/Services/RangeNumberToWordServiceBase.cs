using System.Collections.Generic;

namespace N2W.CORE.Services
{
  public abstract class RangeNumberToWordServiceBase : IRangeNumberToWordService
  {
    protected IDictionary<int, string> OneToNine = new Dictionary<int, string>
    {
      { 1, "one" }, 
      { 2, "two" }, 
      { 3, "three" }, 
      { 4, "four" }, 
      { 5, "five" }, 
      { 6, "six" }, 
      { 7, "seven" }, 
      { 8, "eight" }, 
      { 9, "nine" },
    };
  }
}
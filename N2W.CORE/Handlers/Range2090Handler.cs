using System.Collections.Generic;
using System.Linq;

namespace N2W.CORE.Handlers
{
  public class Range2090Handler : RangeHandlerBase
  {
    private readonly IDictionary<int, string> _twentyToNinety = new Dictionary<int, string>
      {
        { 20, "twenty" },
        { 30, "thirty" },
        { 40, "forty" },
        { 50, "fifty" },
        { 60, "sixty" },
        { 70, "seventy" },
        { 80, "eighty" },
        { 90, "ninety" },
      };
    public Range2090Handler(IRangeHandler handler)
      : base(handler)
    {
    }
    public override string GetWord(int number)
    {
      if (number >= 20 && number <= 90)
      {
        return _twentyToNinety.First(e => e.Key == number).Value;
      }
      return Next.GetWord(number);
    }
  }
}
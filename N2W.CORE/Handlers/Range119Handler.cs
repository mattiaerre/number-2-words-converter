using System.Collections.Generic;
using System.Linq;

namespace N2W.CORE.Handlers
{
  public class Range119Handler : RangeHandlerBase
  {
    private readonly IDictionary<int, string> _tenToNineteen = new Dictionary<int, string>
      {
        { 10, "ten" },
        { 11, "eleven" },
        { 12, "twelve" },
        { 13, "thirteen" },
        { 14, "fourteen" },
        { 15, "fifteen" },
        { 16, "sixteen" },
        { 17, "seventeen" },
        { 18, "eighteen" },
        { 19, "nineteen" },
      };
    public Range119Handler(IRangeHandler handler)
      : base(handler)
    {
    }
    public override string GetWord(int number)
    {
      if (number > 0 && number <= 19)
      {
        if (number > 0 && number <= 9)
          return OneToNine.First(e => e.Key == number).Value;
        return _tenToNineteen.First(e => e.Key == number).Value;
      }
      return Next.GetWord(number);
    }
  }
}
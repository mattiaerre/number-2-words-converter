using System.Linq;

namespace N2W.CORE.Handlers
{
  public class Range2090Handler : RangeHandlerBase
  {
    public Range2090Handler(IRangeHandler handler)
      : base(handler)
    {
    }
    public override string GetWord(int number)
    {
      if (number >= 20 && number <= 90)
        return Constants.TwentyToNinety.First(e => e.Key == number).Value;
      return Next.GetWord(number);
    }
  }
}
using System.Linq;

namespace N2W.CORE.Handlers
{
  public class Range100900Handler : RangeHandlerBase
  {
    public Range100900Handler(IRangeHandler handler)
      : base(handler)
    {
    }
    public override string GetWord(int number)
    {
      if (number >= 100 && number <= 900)
      {
        return string.Format("{0} {1}", OneToNine.First(e => e.Key == (number / 100)).Value, Constants.Hundred);
      }
      return Next.GetWord(number);
    }
  }
}
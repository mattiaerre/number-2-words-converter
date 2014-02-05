using System.Linq;

namespace N2W.CORE.Handlers
{
  public class Range119Handler : RangeHandlerBase
  {
    public Range119Handler(IRangeHandler handler)
      : base(handler)
    {
    }
    public override string GetWord(int number)
    {
      if (number > 0 && number <= 19)
      {
        if (number > 0 && number <= 9)
          return Constants.OneToNine.First(e => e.Key == number).Value;
        return Constants.TenToNineteen.First(e => e.Key == number).Value;
      }
      return Next.GetWord(number);
    }
  }
}
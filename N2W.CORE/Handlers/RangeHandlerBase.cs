namespace N2W.CORE.Handlers
{
  public abstract class RangeHandlerBase : IRangeHandler
  {
    protected readonly IRangeHandler Next;
    protected RangeHandlerBase(IRangeHandler handler)
    {
      Next = handler;
    }
    public abstract string GetWord(int number);
  }
}
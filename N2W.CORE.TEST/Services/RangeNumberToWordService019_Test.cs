using N2W.CORE.Services;
using NUnit.Framework;

namespace N2W.CORE.TEST.Services
{
  public class RangeNumberToWordService019_Test
  {
    // todo: implement a CoR pattern

    [TestCase(1, "one")]
    [TestCase(10, "ten")]
    [TestCase(18, "ten")]
    public void Get_Word_From_Number(int number, string word)
    {
      var service = new RangeNumberToWordService019();

      var result = service.GetWord(number);

      Assert.AreEqual(word, result);
    }
  }
}

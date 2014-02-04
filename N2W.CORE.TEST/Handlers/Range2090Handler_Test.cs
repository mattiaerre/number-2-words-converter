using N2W.CORE.Handlers;
using NUnit.Framework;

namespace N2W.CORE.TEST.Handlers
{
  [TestFixture]
  public class Range2090Handler_Test : HandlersBase_Test
  {
    private IRangeHandler _handler;

    [SetUp]
    public void Given_A_Range119Handler()
    {
      _handler = new Range2090Handler(EndOfChainHandler);
    }

    [TestCase(20, "twenty")]
    [TestCase(30, "thirty")]
    [TestCase(40, "forty")]
    [TestCase(50, "fifty")]
    [TestCase(60, "sixty")]
    [TestCase(70, "seventy")]
    [TestCase(80, "eighty")]
    [TestCase(90, "ninety")]
    public void It_Should_Be_Able_To_Convert_Number_Into_Word(int number, string word)
    {
      var result = _handler.GetWord(number);

      Assert.AreEqual(word, result);
    }
  }
}
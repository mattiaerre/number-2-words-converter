using N2W.CORE.Handlers;
using NUnit.Framework;

namespace N2W.CORE.TEST.Handlers
{
  [TestFixture]
  public class Range119Handler_Test : HandlersBase_Test
  {
    private IRangeHandler _handler;

    [SetUp]
    public void Given_A_Range119Handler()
    {
      _handler = new Range119Handler(EndOfChainHandler);
    }

    [TestCase(1, "one")]
    [TestCase(2, "two")]
    [TestCase(3, "three")]
    [TestCase(4, "four")]
    [TestCase(5, "five")]
    [TestCase(6, "six")]
    [TestCase(7, "seven")]
    [TestCase(8, "eight")]
    [TestCase(9, "nine")]
    [TestCase(10, "ten")]
    [TestCase(11, "eleven")]
    [TestCase(12, "twelve")]
    [TestCase(13, "thirteen")]
    [TestCase(14, "fourteen")]
    [TestCase(15, "fifteen")]
    [TestCase(16, "sixteen")]
    [TestCase(17, "seventeen")]
    [TestCase(18, "eighteen")]
    [TestCase(19, "nineteen")]
    public void It_Should_Be_Able_To_Convert_Number_Into_Word(int number, string word)
    {
      var result = _handler.GetWord(number);

      Assert.AreEqual(word, result);
    }
  }
}

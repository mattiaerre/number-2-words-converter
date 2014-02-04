using N2W.CORE.Handlers;
using NUnit.Framework;

namespace N2W.CORE.TEST.Handlers
{
  [TestFixture]
  public class Range100900Handler_Test : HandlersBase_Test
  {
    private IRangeHandler _handler;

    [SetUp]
    public void Given_A_Range119Handler()
    {
      _handler = new Range100900Handler(EndOfChainHandler);
    }

    [TestCase(100, "one hundred")]
    [TestCase(200, "two hundred")]
    [TestCase(300, "three hundred")]
    [TestCase(400, "four hundred")]
    [TestCase(500, "five hundred")]
    [TestCase(600, "six hundred")]
    [TestCase(700, "seven hundred")]
    [TestCase(800, "eight hundred")]
    [TestCase(900, "nine hundred")]
    public void It_Should_Be_Able_To_Convert_Number_Into_Word(int number, string word)
    {
      var result = _handler.GetWord(number);

      Assert.AreEqual(word, result);
    }
  }
}
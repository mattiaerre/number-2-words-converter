using N2W.CORE.Handlers;
using N2W.CORE.Services;
using NUnit.Framework;

namespace N2W.CORE.TEST.Services
{
  [TestFixture]
  public class NumberToWordsService_Test
  {
    private INumberToWordsService _service;

    [SetUp]
    public void Given_A_NumberToWordsService()
    {
      var service = new DecompositionService();
      var handler = new Range119Handler(new Range2090Handler(new Range100900Handler(new EndOfChainHandler())));

      _service = new NumberToWordsService(service, handler);
    }

    [TestCase(0, "zero")]
    [TestCase(4, "four")]
    [TestCase(15, "fifteen")]
    [TestCase(21, "twenty one")]
    [TestCase(100, "one hundred")]
    [TestCase(105, "one hundred and five")]
    [TestCase(456, "four hundred and fifty six")]
    [TestCase(815, "eight hundred and fifteen")]
    [TestCase(1000, "one thousand")]
    [TestCase(1111, "one thousand one hundred and eleven")]
    [TestCase(1234, "one thousand two hundred and thirty four")]
    [TestCase(56945781, "fifty six million nine hundred and forty five thousand seven hundred and eighty one")]
    public void It_Should_Be_Able_To_Convert_Number_Into_Words(int number, string words)
    {
      var result = _service.GetWords(number);

      Assert.AreEqual(words, result);
    }
  }
}

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
    [TestCase(105, "one hundred and five")]
    [TestCase(456, "four hundred and fifty six")]
    [TestCase(815, "eight hundred and fifteen")]
    public void It_Should_Be_Able_To_Convert_Number_Into_Words(int number, string words)
    {
      var result = _service.GetWords(number);

      Assert.AreEqual(words, result);
    }
  }
}

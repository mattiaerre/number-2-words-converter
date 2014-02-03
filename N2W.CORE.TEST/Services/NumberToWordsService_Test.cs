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

      _service = new NumberToWordsService(service);
    }

    [TestCase(1, "one")]
    //[TestCase(2, "two")]
    //[TestCase(3, "three")]
    //[TestCase(4, "four")]
    //[TestCase(5, "five")]
    [TestCase(21, "twenty one")]
    [TestCase(105, "one hundred and five")]
    public void It_Should_Be_Able_To_Convert_Number_Into_Words(int number, string words)
    {
      var result = _service.GetWords(number);

      Assert.AreEqual(words, result);
    }
  }
}

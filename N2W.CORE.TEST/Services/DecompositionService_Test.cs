using N2W.CORE.Services;
using NUnit.Framework;

namespace N2W.CORE.TEST.Services
{
  [TestFixture]
  public class DecompositionService_Test
  {
    private IDecompositionService _service;

    [SetUp]
    public void Given_A_DecompositionService()
    {
      _service = new DecompositionService();
    }

    [TestCase(20, new[] { 20, 0 })]
    [TestCase(123, new[] { 100, 20, 3 })]
    [TestCase(815, new[] { 800, 15 })]
    [TestCase(987654321, new[] { 900000000, 80000000, 7000000, 600000, 50000, 4000, 300, 20, 1 })]
    public void It_Should_Be_Able_To_Decompose_A_Number(int number, int[] composition)
    {
      var result = _service.GetDecomposition(number);

      Assert.AreEqual(composition, result);
    }
  }
}

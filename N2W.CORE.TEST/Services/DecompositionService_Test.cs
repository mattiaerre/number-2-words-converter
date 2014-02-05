using N2W.CORE.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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

    [Test]
    public void It_Should_Be_Able_To_Decompose_1()
    {
      const int one = 1;

      var result = _service.GetDecomposition(one);

      Assert.AreEqual(new Dictionary<int, IEnumerable<int>> { { 0, new[] { 1 } } }, result);
    }

    [TestCase(1, 1, 1)]
    [TestCase(14, 1, 1)]
    [TestCase(22, 1, 2)]
    [TestCase(333, 1, 3)]
    [TestCase(704, 1, 2)]
    [TestCase(815, 1, 2)]
    public void Number_Of_Items_Inside_The_Dictionary_Level_One(int number, int howManyDictionaryItems, int howManyCollectionItems)
    {
      var result = _service.GetDecomposition(number);

      Assert.AreEqual(howManyDictionaryItems, result.Count());

      Assert.AreEqual(howManyCollectionItems, result.First().Value.Count());
    }

    [TestCase(1000, 2, 1)]
    public void Number_Of_Items_Inside_The_Dictionary_Level_Two(int number, int howManyDictionaryItems, int howManyCollectionItems)
    {
      var result = _service.GetDecomposition(number);

      Assert.AreEqual(howManyDictionaryItems, result.Count());

      Assert.AreEqual(howManyCollectionItems, result.Last().Value.Count());
    }
  }
}

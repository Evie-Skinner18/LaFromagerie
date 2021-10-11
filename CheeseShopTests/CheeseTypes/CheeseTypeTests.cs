using NUnit.Framework;

namespace CheeseShopTests.CheeseTypes;

public class CheeseTypeTests
{
    [Test]
    public void IsSmelly_WhenWeCreateACheeseWithStrengthOf0_ShouldReturnFalse()
    {
        CheeseType emmental = CheeseType.Create("Tastiest Emmental", "Suisse", 0);

        Assert.IsFalse(emmental.IsSmelly());
    }

    [Test]
    public void IsSmelly_WhenWeCreateACheeseWithStrengthOf4_ShouldReturnTrue()
    {
        CheeseType stinkingBishop = CheeseType.Create("Stinking Bishop", "UK", 4);

        Assert.IsTrue(stinkingBishop.IsSmelly());
    }

    [Test]
    public void SetPrice_WhenTheGivenCheeseIsSmellyAndNotFrench_ShouldReturn4()
    {
        CheeseType smokedSausage = CheeseType.Create("Smoky Sausage Shaped one", "Austria", 5);

        smokedSausage.SetPrice();
        decimal smokedSausagePrice = smokedSausage.GetPrice();

        Assert.AreEqual(4.0m, smokedSausagePrice);
    }
}
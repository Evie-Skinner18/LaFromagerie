namespace CheeseShopTests.CheeseTypes;

public class CheeseTypeTests
{
    [Test]
    public void IsSmelly_WhenWeCreateACheeseWithStrengthOf0_ShouldReturnFalse()
    {
        CheeseType emmental = CheeseType.Create("Tastiest Emmental", "Suisse", 0);

        emmental.IsSmelly().Should().BeFalse();
    }

    [Test]
    public void IsSmelly_WhenWeCreateACheeseWithStrengthOf4_ShouldReturnTrue()
    {
        CheeseType stinkingBishop = CheeseType.Create("Stinking Bishop", "UK", 4);

        stinkingBishop.IsSmelly().Should().BeTrue();
    }

    [Test]
    public void SetPrice_WhenTheGivenCheeseIsSmellyAndNotFrench_ShouldReturn4()
    {
        CheeseType smokedSausage = CheeseType.Create("Smoky Sausage Shaped one", "Austria", 5);

        smokedSausage.SetPrice();
        decimal smokedSausagePrice = smokedSausage.GetPrice();

        smokedSausagePrice.Should().Be(4.0m);
    }
}
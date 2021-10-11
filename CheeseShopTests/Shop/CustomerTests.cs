namespace CheeseShopTests.Shop;

public class CustomerTests
{
    [Test]
    public void AddCheeseToCart_WhenDaveAddsThreeStiltonsToHisCart_ShouldUpdateHisCartWithThreeStiltons()
    {
        CheeseType stilton = CheeseType.Create("Stilton", "UK", 5);
        Customer dave = new("Dave");

        dave.AddCheeseToCart(stilton, 3);

        dave.Cart.Cheeses.Should().HaveCount(3);

        dave.Cart.Cheeses.FirstOrDefault().Name
            .Should().Be("Stilton");
    }
}
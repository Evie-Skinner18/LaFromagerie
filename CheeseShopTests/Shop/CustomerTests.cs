using NUnit.Framework;

namespace CheeseShopTests.Shop;

public class CustomerTests
{
    [Test]
    public void AddCheeseToCart_WhenDaveAddsThreeStiltonsToHisCart_ShouldUpdateHisCartWithThreeStiltons()
    {
        CheeseType stilton = CheeseType.Create("Stilton", "UK", 5);
        Customer dave = new("Dave");

        dave.AddCheeseToCart(stilton, 3);

        Assert.AreEqual(3, dave.Cart.Cheeses.Count);
        Assert.AreEqual("Stilton", dave.Cart.Cheeses.FirstOrDefault().Name);
    }
}
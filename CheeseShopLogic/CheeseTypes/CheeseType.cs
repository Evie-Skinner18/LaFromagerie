﻿namespace CheeseShopLogic;

public class CheeseType
{
    private CheeseType(string name, string countryOfOrigin, int strength)
    {
        Name = name;
        CountryOfOrigin = countryOfOrigin;
        Strength = strength;
    }

    public string Name { get; set; }
    public string CountryOfOrigin { get; set; }
    public int Strength { get; set; }
    private decimal _price { get; set; }

    public static CheeseType Create(string name, string countryOfOrigin, int strength)
    {
        CheeseType cheeseType = new(name, countryOfOrigin, strength);
        return cheeseType;
    }

    public bool IsSmelly() => Strength > 3;
    public bool IsPremiumCheese() => _price > 4.0m;

    public void SetPrice()
    {
        if (CountryOfOrigin == "France")
        {
            _price = 3.0m;
        }
        else if (IsSmelly())
        {
            _price = 4.0m;
        }
        else
        {
            _price = 2.0m;
        }
    }

    public decimal GetPrice()
    {
        return _price;
    }
}
using System;

enum ClothingSize
{
    XXS,
    XS,
    S,
    M,
    L
}

class Shop
{
    public ClothingSize Size { get; }
    public int EuroSize { get; }

    public Shop(ClothingSize size, int euroSize)
    {
        Size = size;
        EuroSize = euroSize;
    }

    public string GetDescription()
    {
        if (Size == ClothingSize.XXS)
        {
            return "Дитячий розмір";
        }

        return "Дорослий розмір";
    }
}

interface IMensClothing
{
    void DressMan();
}

interface IWomensClothing
{
    void DressWoman();
}

abstract class Clothing
{
    public ClothingSize Size { get; }
    public double Price { get; }
    public string Color { get; }

    protected Clothing(ClothingSize size, double price, string color)
    {
        Size = size;
        Price = price;
        Color = color;
    }
}

class TShirt : Clothing, IMensClothing, IWomensClothing
{
    public TShirt(ClothingSize size, double price, string color) : base(size, price, color) { }

    public void DressMan()
    {
        Console.WriteLine($"Чоловік одягнув футболку (розмір: {Size}, ціна: {Price}, колір: {Color})");
    }

    public void DressWoman()
    {
        Console.WriteLine($"Жінка одягнула футболку (розмір: {Size}, ціна: {Price}, колір: {Color})");
    }
}

class Pants : Clothing, IMensClothing, IWomensClothing
{
    public Pants(ClothingSize size, double price, string color) : base(size, price, color) { }

    public void DressMan()
    {
        Console.WriteLine($"Чоловік одягнув штани (розмір: {Size}, ціна: {Price}, колір: {Color})");
    }

    public void DressWoman()
    {
        Console.WriteLine($"Жінка одягнула штани (розмір: {Size}, ціна: {Price}, колір: {Color})");
    }
}

class Skirt : Clothing, IWomensClothing
{
    public Skirt(ClothingSize size, double price, string color) : base(size, price, color) { }

    public void DressWoman()
    {
        Console.WriteLine($"Жінка одягнула спідницю (розмір: {Size}, ціна: {Price}, колір: {Color})");
    }
}

class Tie : Clothing, IMensClothing
{
    public Tie(ClothingSize size, double price, string color) : base(size, price, color) { }

    public void DressMan()
    {
        Console.WriteLine($"Чоловік одягнув краватку (розмір: {Size}, ціна: {Price}, колір: {Color})");
    }
}

class Atelier
{
    public static void DressWoman(Clothing[] clothes)
    {
        Console.WriteLine("Жінка одягнена:");
        foreach (var clothing in clothes)
        {
            if (clothing is IWomensClothing womensClothing)
            {
                womensClothing.DressWoman();
            }
        }
    }

    public static void DressMan(Clothing[] clothes)
    {
        Console.WriteLine("Чоловік одягнений:");
        foreach (var clothing in clothes)
        {
            if (clothing is IMensClothing mensClothing)
            {
                mensClothing.DressMan();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Clothing[] clothes = new Clothing[]
        {
            new TShirt(ClothingSize.M, 500, "Червоний"),
            new Pants(ClothingSize.L, 1200, "Синій"),
            new Skirt(ClothingSize.S, 800, "Зелений"),
            new Tie(ClothingSize.XS, 300, "Чорний")
        };

        Atelier.DressWoman(clothes);
        Console.WriteLine();
        Atelier.DressMan(clothes);
    }
}


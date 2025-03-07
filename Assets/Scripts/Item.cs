using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Category
{
    Armor,
    Boots,
    Helmet,
    Necklace,
    Ring,
    Weapon,

    //This is suppose to be property for me to tell how much categories are there
    Count
}
public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public class Item
{
    public string itemName { get; private set; }
    public Category category { get; private set; }
    public Rarity rarity { get; private set; }
    public Stats stats { get; private set; }

    public Item(string itemName, Category category, Rarity rarity, Stats stats)
    {
        this.itemName = itemName;
        this.category = category;
        this.rarity = rarity;
        this.stats = stats;
    }
}
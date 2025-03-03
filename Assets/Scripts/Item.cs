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
    Weapon
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
    public string itemName { get; set; }
    public Category category { get; set; }
    public Rarity rarity { get; set; }
    public int damage { get; set; }
    public int healthPoints { get; set; }
    public int defense { get; set; }
    public float lifeSteal { get; set; }
    public float criticalStrikeChance { get; set; }
    public float attackSpeed { get; set; }
    public float movementSpeed { get; set; }
    public float luck { get; set; }
}
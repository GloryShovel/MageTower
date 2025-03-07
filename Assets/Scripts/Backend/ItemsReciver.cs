using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// I made this here since Json data provided is in form of "Object with list"
/// </summary>
public class ItemsReciver
{
    public List<ItemReciver> items = new List<ItemReciver>();
}

public class ItemReciver
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


    public static explicit operator Item(ItemReciver item)
    {
        Stats outStats = new Stats();
        outStats.damage = item.damage;
        outStats.healthPoints = item.healthPoints;
        outStats.damage = item.damage;
        outStats.lifeSteal = item.lifeSteal;
        outStats.criticalStrikeChance = item.criticalStrikeChance;
        outStats.attackSpeed = item.attackSpeed;
        outStats.movementSpeed = item.movementSpeed;
        outStats.luck = item.luck;
        Item output = new Item(item.itemName, item.category, item.rarity, outStats);

        return output;
    }
}

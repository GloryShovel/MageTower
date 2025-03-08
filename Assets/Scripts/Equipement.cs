using System.Collections.Generic;
using UnityEngine;

public class Equipement
{
    public Dictionary<Category, Item> items { get; private set; }

    /// <summary>
    /// Initialize equipement with array, but remember that it will only take one item of each category and if you pass more then one it will take only first in array rest will be ommited
    /// </summary>
    /// <param name="toEquip">array of items to equip</param>
    public void Init(Item[] toEquip)
    {
        Dictionary<Category, int> isRepeatedCategory = new Dictionary<Category, int>();
#if UNITY_EDITOR
        try
        {
#endif
            for (int i = 0; i < toEquip.Length; i++)
            {
                if (isRepeatedCategory[toEquip[i].category] < 1)
                {
                    EquipItem(toEquip[i]);

                    isRepeatedCategory[toEquip[i].category]++;
                }
#if UNITY_EDITOR
                else
                {
                    throw new System.Exception();
                }
#endif
            }
#if UNITY_EDITOR
        }
        catch
        {
            Debug.LogError("Could not create Equipement");
        }
#endif

        //Fill empty with null
        foreach (KeyValuePair<Category, int> e in isRepeatedCategory)
        {
            if (e.Value <= 0)
            {
                items[e.Key] = null;
            }
        }
    }

    public Equipement()
    {
        items = new Dictionary<Category, Item>();
        for (int i = 0;i < (int)Category.Count; i++)
        {
            items.Add((Category)i, null);
        }
    }

    public void EquipItem(Item item)
    {

        if (items[item.category] == item)
        {
            items[item.category] = null;
        }
        else
        {
            items[item.category] = item;
        }
    }

    //public void UnequipItem(Category cat)
    //{
    //    switch (cat)
    //    {
    //        case Category.Armor:
    //            armor = null;
    //            break;
    //        case Category.Boots:
    //            boots = null;
    //            break;
    //        case Category.Helmet:
    //            helmet = null;
    //            break;
    //        case Category.Necklace:
    //            necklace = null;
    //            break;
    //        case Category.Ring:
    //            ring = null;
    //            break;
    //        case Category.Weapon:
    //            weapon = null;
    //            break;
    //    }
    //}

    public Stats CombinedStats()
    {
        Stats combinedStats = new Stats();

        foreach (KeyValuePair<Category, Item> e in items)
        {
            if(e.Value != null)
            {
                combinedStats.Add(e.Value.stats);
            }
        }

        return combinedStats;
    }
}
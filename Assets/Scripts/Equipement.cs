using System.Collections.Generic;
using UnityEngine;

public class Equipement
{
    public Item armor { get; private set; }
    public Item boots { get; private set; }
    public Item helmet { get; private set; }
    public Item necklace { get; private set; }
    public Item ring { get; private set; }
    public Item weapon { get; private set; }

    /// <summary>
    /// Initialize equipement with array, but remember that it will only take one item of each category and if you pass more then one it will take only first in array rest will be ommited
    /// </summary>
    /// <param name="items">array of items to equip</param>
    public void Init(Item[] items)
    {
        Dictionary<Category, int> isRepeatedCategory = new Dictionary<Category, int>();

        try
        {

            for (int i = 0; i < items.Length; i++)
            {
                if (isRepeatedCategory[items[i].category] < 1)
                {
                    SetItem(items[i]);

                    isRepeatedCategory[items[i].category]++;
                }
                else
                {
                    throw new System.Exception();
                }
            }
        }
        catch
        {
            Debug.LogError("Could not create Eq struct");
        }

        //Fill empty with null
        foreach (KeyValuePair<Category, int> e in isRepeatedCategory)
        {
            if (e.Value <= 0)
            {
                switch (e.Key)
                {
                    case Category.Armor:
                        armor = null;
                        break;
                    case Category.Boots:
                        boots = null;
                        break;
                    case Category.Helmet:
                        helmet = null;
                        break;
                    case Category.Necklace:
                        necklace = null;
                        break;
                    case Category.Ring:
                        ring = null;
                        break;
                    case Category.Weapon:
                        weapon = null;
                        break;
                }
            }
        }
    }

    public void SetItem(Item item)
    {
        switch (item.category)
        {
            case Category.Armor:
                armor = item;
                break;
            case Category.Boots:
                boots = item;
                break;
            case Category.Helmet:
                helmet = item;
                break;
            case Category.Necklace:
                necklace = item;
                break;
            case Category.Ring:
                ring = item;
                break;
            case Category.Weapon:
                weapon = item;
                break;
        }
    }

    public void UnequipItem(Category cat)
    {
        switch (cat)
        {
            case Category.Armor:
                armor = null;
                break;
            case Category.Boots:
                boots = null;
                break;
            case Category.Helmet:
                helmet = null;
                break;
            case Category.Necklace:
                necklace = null;
                break;
            case Category.Ring:
                ring = null;
                break;
            case Category.Weapon:
                weapon = null;
                break;
        }
    }

    public Stats CombinedStats()
    {
        Stats combinedStats = new Stats();

        combinedStats.Add(armor.stats);
        combinedStats.Add(boots.stats);
        combinedStats.Add(helmet.stats);
        combinedStats.Add(necklace.stats);
        combinedStats.Add(ring.stats);
        combinedStats.Add(weapon.stats);

        return combinedStats;
    }
}
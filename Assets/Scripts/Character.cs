using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Stats baseStats { get; private set; }

    private Stats calculatedStats;
    private Equipement eq;

    public void Init(Item[] items)
    {
        if(items != null)
        {
            eq.Init(items);
        }
    }

    /// <summary>
    /// Take damage and return is it still alive
    /// </summary>
    /// <param name="damage">damage taken</param>
    /// <returns></returns>
    public bool ReciveDamage(int damage)
    {
        calculatedStats.healthPoints -= damage;

        if(calculatedStats.healthPoints >0)
        {
            return false;
        }
        return true;
    }

    public void EquipItem(Item item)
    {
        if(item != null)
        {
            eq.SetItem(item);
            RecalculateStats();
        }
    }
    public void UnequipItem(Category cat)
    {
        eq.UnequipItem(cat);
        RecalculateStats();
    }

    public void RecalculateStats()
    {
        calculatedStats = eq.CombinedStats();
        calculatedStats.Add(baseStats);
    }

}
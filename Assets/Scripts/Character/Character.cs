using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float attacksPS;
    public Stats baseStats;
    public Stats calculatedStats { get; private set; }

    protected float attackTimer;
    protected Equipement m_eq;

    public void Init(Item[] items)
    {
        if(items != null)
        {
            m_eq.Init(items);
        }
        else
        {
            m_eq = new Equipement();
        }
        calculatedStats = new Stats();
        RecalculateStats();
        attackTimer = 0;
    }

    protected void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    public void EquipItem(Item item)
    {
        if(item != null)
        {
            m_eq.EquipItem(item);
            RecalculateStats();
        }
    }

    public void RecalculateStats()
    {
        calculatedStats = m_eq.CombinedStats();
        calculatedStats.Add(baseStats);
    }

    /// <summary>
    /// Take damage and return is it still alive
    /// </summary>
    /// <param name="damage">damage taken</param>
    /// <returns></returns>
    public bool RequestTakeDamage(int damage)
    {
        //Use of healt and defence stat
        calculatedStats.healthPoints -= Math.Max(damage - calculatedStats.defense, 0);

        if (calculatedStats.healthPoints > 0)
        {
            return false;
        }
        return true;
    }

    public void ResetAttackTimer()
    {
        //use of attack speed
        attackTimer = attacksPS * (calculatedStats.attackSpeed * 0.01f);
    }
}
using UnityEngine;

public class Character : MonoBehaviour
{
    public float attacksPS;
    public Stats baseStats;
    public Stats calculatedStats { get; private set; }

    private Equipement m_eq;

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
            m_eq.EquipItem(item);
            RecalculateStats();
        }
    }
    //public void UnequipItem(Category cat)
    //{
    //    eq.UnequipItem(cat);
    //    RecalculateStats();
    //}

    public void RecalculateStats()
    {
        calculatedStats = m_eq.CombinedStats();
        calculatedStats.Add(baseStats);

        UIController.instance.statisticsController.writer.Write(calculatedStats);
    }

}
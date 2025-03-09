using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Enemy m_target;

    public new void Init(Item[] items)
    {
        base.Init(items);

        SetTarget();
    }

    public void SetTarget()
    {
        var spawners = GameController.instance.spawners;
        Enemy result = spawners[0].enemies[0];

        for (int i = 0; i < spawners.Length; i++)
        {
            for (int j = 0; j < spawners[i].enemies.Count; j++)
            {
                if (spawners[i].enemies[j].isAlive && result.distanceToTarget.magnitude > spawners[i].enemies[j].distanceToTarget.magnitude)
                {
                    result = spawners[i].enemies[j];
                }
            }
        }

        m_target = result;
    }

    public new void EquipItem(Item item)
    {
        base.EquipItem(item);
        UIController.instance.statisticsController.writer.Write(calculatedStats);
    }

    public new void RecalculateStats()
    {
        base.RecalculateStats();
        UIController.instance.statisticsController.writer.Write(calculatedStats);
    }

    private new void Update()
    {
        base.Update();

        SetTarget();

        if (attackTimer <= 0 && m_target.isAlive)
        {
            int roll = Random.Range(1, 100);

            //usage of crit and damage stats
            if(roll <= calculatedStats.criticalStrikeChance)
            {
                GameController.instance.DamageEnemy(m_target, calculatedStats.damage * 2);
            }
            else
            {
                GameController.instance.DamageEnemy(m_target, calculatedStats.damage);
            }
            ResetAttackTimer();
        }
    }
}

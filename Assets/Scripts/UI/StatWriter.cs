using System;
using TMPro;
using UnityEngine;

[Serializable]
public class StatWriter
{
    public TextMeshProUGUI dmg, hp, def, ls, csc, at, mov, luck;

    public void Write(Stats stat)
    {
        dmg.text = "Damage: " + stat.damage;
        hp.text = "Health: " + stat.healthPoints;
        def.text = "Defense: " + stat.defense;
        ls.text = "LifeSteal: " + Mathf.Floor(stat.lifeSteal) + "%";
        csc.text = "CriticalChance: " + Mathf.Floor(stat.criticalStrikeChance) + "%";
        at.text = "AttackSpeed: " + Mathf.Floor(stat.attackSpeed) + "%";
        mov.text = "MovementSpeed: " + Mathf.Floor(stat.movementSpeed) + "%";
        luck.text = "Luck: " + Mathf.Floor(stat.luck) + "%";
    }
}
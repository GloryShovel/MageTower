using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabItem : MonoBehaviour
{

    public Image icon, background;
    public TextMeshProUGUI dmg, hp, def, ls, csc, at, mov, luck;

    public void Init(Item item, Sprite iconRef, Sprite backgroundRef)
    {
        icon.sprite = iconRef;
        background.sprite = backgroundRef;
        dmg.text = "Damage: " + item.stats.damage;
        hp.text = "Health: " + item.stats.healthPoints;
        def.text = "Defense: " + item.stats.defense;
        ls.text = "LifeSteal: " + Mathf.Floor(item.stats.lifeSteal) + "%";
        csc.text = "CriticalChance: " + Mathf.Floor(item.stats.criticalStrikeChance) + "%";
        at.text = "AttackSpeed: " + Mathf.Floor(item.stats.attackSpeed) + "%";
        mov.text = "MovementSpeed: " + Mathf.Floor(item.stats.movementSpeed) + "%";
        luck.text = "Luck: " + Mathf.Floor(item.stats.luck) + "%";
    }
}

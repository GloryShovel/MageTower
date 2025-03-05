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
        dmg.text = "Damage: " + item.damage;
        hp.text = "Health: " + item.healthPoints;
        def.text = "Defense: " + item.defense;
        ls.text = "LifeSteal: " + Mathf.Floor(item.lifeSteal) + "%";
        csc.text = "CriticalChance: " + Mathf.Floor(item.criticalStrikeChance) + "%";
        at.text = "AttackSpeed: " + Mathf.Floor(item.attackSpeed) + "%";
        mov.text = "MovementSpeed: " + Mathf.Floor(item.movementSpeed) + "%";
        luck.text = "Luck: " + Mathf.Floor(item.luck) + "%";
    }
}

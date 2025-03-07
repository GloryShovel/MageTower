using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats
{
    public int damage;
    public int healthPoints;
    public int defense;
    public float lifeSteal;
    public float criticalStrikeChance;
    public float attackSpeed;
    public float movementSpeed;
    public float luck;

    public Stats()
    {
        //I made it since I'm not trusting that automation will set 0 on all values
        //Just like memes "programmer panik / programmer kalm"
        damage = 0;
        healthPoints = 0;
        defense = 0;
        lifeSteal = 0;
        criticalStrikeChance = 0;
        attackSpeed = 0;
        movementSpeed = 0;
        luck = 0;
    }
    public Stats(int dmg, int h, int def, float lS, float c, float a, float m, float l)
    {
        damage = dmg;
        healthPoints = h;
        defense = def;
        lifeSteal = lS;
        criticalStrikeChance = c;
        attackSpeed = a;
        movementSpeed = m;
        luck = l;
    }

    public void Add(Stats stats)
    {
        damage += stats.damage;
        healthPoints += stats.healthPoints;
        defense += stats.defense;
        lifeSteal += stats.lifeSteal;
        criticalStrikeChance += stats.criticalStrikeChance;
        attackSpeed += stats.attackSpeed;
        movementSpeed += stats.movementSpeed;
        luck += stats.luck;
    }
}

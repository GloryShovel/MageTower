using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemyType;
    public float cooldownTime;

    public bool finished { get; private set; }
    public List<Enemy> enemies { get; private set; }

    private int sendEnemiesAmount;
    private float sendCooldown;

    public void Init(int amount)
    {
        enemies = new List<Enemy>();
        sendEnemiesAmount = 0;
        sendCooldown = 0;
        
        CreateEnemy(amount);

        finished = true;
    }

    private void Update()
    {
        if (sendEnemiesAmount > 0)
        {

            if (sendCooldown > 0)
            {
                sendCooldown -= Time.deltaTime;
            }else
            {
                sendCooldown = cooldownTime;
                sendEnemiesAmount--;
                SendEnemy();
            }
        }
        else
        {
            finished = true;
        }

    }

    private void CreateEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Enemy enemy = Instantiate(enemyType, transform);
            enemy.Init(null, transform);
            enemies.Add(enemy);
        }
    }

    public void SendEnemies(int ammount)
    {
        if(enemies.Count < ammount)
        {
            CreateEnemy(ammount - enemies.Count);
        }

        sendEnemiesAmount = ammount;
        finished = false;
    }
    public void SendEnemy()
    {
        enemies[sendEnemiesAmount].DeployMe();
    }

    public void KillAll()
    {
        for (int i = 0;i < enemies.Count; i++)
        {
            enemies[i].RestoreToPool();
        }
    }
}

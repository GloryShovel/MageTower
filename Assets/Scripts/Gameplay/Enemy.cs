using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Transform target;

    public bool isAlive {  get; private set; }
    public Vector3 direction {  get; private set; }
    public Vector3 distanceToTarget {  get; private set; }

    private Transform spawnLocation;

    public void Init(Item[] items, Transform location)
    {
        base.Init(items);

        target = GameController.instance.player.transform;
        spawnLocation = location;

        RestoreToPool();
    }

    /// <summary>
    /// Basicly death XD
    /// </summary>
    public void RestoreToPool()
    {
        gameObject.SetActive(false);
        isAlive = false;
        transform.position = spawnLocation.position;
        CalculateDistanceAndDirection();
        RecalculateStats();
    }

    public void DeployMe()
    {
        gameObject.SetActive(true);
        isAlive = true;
    }

    public void CalculateDistanceAndDirection()
    {
        distanceToTarget = target.position - transform.position;
        direction = distanceToTarget.normalized;
    }

    new void Update()
    {
        base.Update();

        CalculateDistanceAndDirection();
        transform.Translate(direction * (baseStats.movementSpeed * .01f) * 0.1f);

        if (distanceToTarget.magnitude <= 1 && attackTimer <= 0)
        {
            GameController.instance.DamagePlayer(baseStats.damage);
            ResetAttackTimer();
        }
    }
}

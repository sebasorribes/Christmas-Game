using Assets.Scripts.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : Tower, IAttarcker
{
    private DetectionArea detectionArea;

    protected override void Awake()
    {
        SetMaxHealth(100);
        base.Awake();
        detectionArea = gameObject.GetComponentInChildren<DetectionArea>();
        SetEffectPoints(10);
        SetEffectSpeed(1f);
        SetEffectRange(detectionArea.GetComponent<CircleCollider2D>().radius);
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            if (detectionArea.triggerOccuped)
            {
                GameObject enemy = detectionArea.GetDetectedObjects()[0];
                Attack(enemy.GetComponent<IAttackable>());
            }
            yield return new WaitForSeconds(GetEffectSpeed());
        }
    }

    public void Attack(IAttackable attackable)
    {
        attackable.Damage(GetEffectPoints());
    }

    public void FindNearTarget(List<GameObject> attackables)
    {
        
    }
}

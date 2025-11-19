using Assets.Scripts.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : Entity, IAttarcker
{
    private DetectionArea detectionArea;
    public void Attack(IAttackable attackable)
    {
        attackable.Damage(GetEffectPoints());
    }

    public void FindNearTarget(List<GameObject> attackables)
    {
        throw new System.NotImplementedException();
    }

    protected override void Awake()
    {
        SetMaxHealth(20);
        entityType = EntityType.Heroe;
        base.Awake();
        SetEffectPoints(10);
        SetEffectSpeed(1.2f);
        detectionArea = gameObject.GetComponentInChildren<DetectionArea>();
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
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
}

using Assets.Scripts.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinch : Entity , IAttarcker, IMove, IDebuffed
{
    protected float moveSpeed;
    protected float MaxSpeed;
    private DetectionArea detectionArea;

    protected override void Awake()
    {
        entityType = EntityType.Enemy;
        detectionArea = GetComponentInChildren<DetectionArea>();
        base.Awake();
        StartCoroutine(AttackRoutine());
    }

    public void FindNearTarget(List<GameObject> attackables)
    {
        throw new System.NotImplementedException();
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    private void Update()
    {
        if (detectionArea.GetDetectedObjects().Count < 1)
        {
            Move();
        }
        
    }

    public virtual void Move()
    {
        transform.position += Vector3.down * GetMoveSpeed() * Time.deltaTime;
    }

    public void SetMoveSpeed(float speed)
    {
        this.moveSpeed = speed;
    }

    public float GetMaxSpeed()
    {
        return MaxSpeed;
    }

    public void SetMaxSpeed(float speed)
    {
        MaxSpeed = speed;
    }

    public void Debuffed(float speedDebuffFactor)
    {
        if (GetMoveSpeed() == GetMaxSpeed())
        {
            SetMoveSpeed(GetMoveSpeed() * speedDebuffFactor);
        }
    }
    public void UnDebuffed()
    {
        SetMoveSpeed(GetMaxSpeed());
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

    public void Attack(IAttackable attackable)
    {
        attackable.Damage(GetEffectPoints());
    }
}

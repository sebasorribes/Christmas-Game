using Assets.Scripts.Interface;
using UnityEngine;

public class Entity : MonoBehaviour, IEntity, IAttackable
{
    protected int maxHealth;
    protected int currentHealth;
    protected int effectPoints;
    protected float effectRange;
    protected float effectSpeed;
    protected EntityType entityType;

    public EntityType GetEntityType() { return entityType; }
    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetEffectPoints()
    {
        return effectPoints;
    }

    public float GetEffectRange()
    {
        return effectRange;
    }

    public float GetEffectSpeed()
    {
        return effectSpeed;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetCurrentHealth(int currentHealth)
    {
        this.currentHealth = currentHealth <= maxHealth ? currentHealth : maxHealth;
    }

    public void SetEffectPoints(int effectPoints)
    {
        this.effectPoints = effectPoints;
    }

    public void SetEffectRange(float effectRange)
    {
        this.effectRange = effectRange;
    }

    public void SetEffectSpeed(float effectSpeed)
    {
        this.effectSpeed = effectSpeed;
    }

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void UpdateStats()
    {
        throw new System.NotImplementedException();
    }

    public void Damage(int damageAmount)
    {
        int currentHealthAux = GetCurrentHealth();
        currentHealthAux -= damageAmount;
        if (currentHealthAux <= 0)
        {
            Die();
        }
        else
        {
            SetCurrentHealth(currentHealthAux);
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}

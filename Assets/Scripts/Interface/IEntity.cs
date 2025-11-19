namespace Assets.Scripts.Interface
{
    public interface IEntity
    {
        public int GetMaxHealth();
        public int GetCurrentHealth();
        public int GetEffectPoints();
        public float GetEffectSpeed();
        public float GetEffectRange();

        public void SetMaxHealth(int maxHealth);
        public void SetCurrentHealth(int currentHealth);
        public void SetEffectPoints(int effectPoints);
        public void SetEffectSpeed(float effectSpeed);
        public void SetEffectRange(float effectRange);

        public void UpdateStats();

    }
}


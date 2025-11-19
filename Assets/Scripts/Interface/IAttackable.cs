namespace Assets.Scripts.Interface
{
    public interface IAttackable
    {
        public void Damage(int damageAmount);
        public void Die();
    }
}

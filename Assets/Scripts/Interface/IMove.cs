namespace Assets.Scripts.Interface
{
    public interface IMove
    {
        public float GetMoveSpeed();
        public void SetMoveSpeed(float speed);
        public void Move();
    }
}

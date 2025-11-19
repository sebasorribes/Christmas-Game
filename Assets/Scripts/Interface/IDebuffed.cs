using UnityEngine;

namespace Assets.Scripts.Interface
{
    public interface IDebuffed
    {
        public float GetMaxSpeed();
        public void SetMaxSpeed(float speed);
        public void Debuffed(float speedDebuffFactor);
        public void UnDebuffed();
    }
}

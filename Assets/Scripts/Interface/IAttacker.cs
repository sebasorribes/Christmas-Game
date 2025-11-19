using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public interface IAttarcker
    {
        public void Attack(IAttackable attackable);
        public void FindNearTarget(List<GameObject> attackables);
    }
}

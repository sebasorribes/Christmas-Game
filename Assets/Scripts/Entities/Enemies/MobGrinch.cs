using UnityEngine;

public class MobGrinch : Grinch
{
    protected override void Awake()
    {
        SetMaxHealth(20);
        base.Awake();
        SetEffectPoints(10);
        SetEffectSpeed(1f);
        SetMaxSpeed(6f);
        SetMoveSpeed(GetMaxSpeed());
    }
}

using Assets.Scripts.Interface;
using System.Collections;
using UnityEngine;

public class FreezingTower : Tower, IDebuff
{
    private DebuffDetectionArea detectionArea;

    protected override void Awake()
    {
        SetMaxHealth(100);
        base.Awake();
        detectionArea = gameObject.GetComponentInChildren<DebuffDetectionArea>();
        SetEffectPoints(25);
        SetEffectSpeed(1f);
        SetEffectRange(detectionArea.GetComponent<CircleCollider2D>().radius);
    }

    private void Start()
    {
        detectionArea.OnDebuffEnemy += Debuff;
    }


    public void Debuff(GameObject grinch)
    {
        IDebuffed auxGrinch = grinch.GetComponent<IDebuffed>();
        //arreglar lo del factor de debuff que es int
        auxGrinch.Debuffed(GetEffectPoints() / 100f);
    }
}

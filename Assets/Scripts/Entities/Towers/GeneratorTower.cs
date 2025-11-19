using Assets.Scripts.Interface;
using System.Collections;
using UnityEngine;

public class GeneratorTower : Tower , IGenerator
{
    public void GeneratePoints()
    {
        if(MatchManager.Instance != null)
        {
            MatchManager.Instance.AddPoints(GetEffectPoints());
        }
    }

    protected override void Awake()
    {
        SetMaxHealth(100);
        base.Awake();
        SetEffectPoints(10);
        SetEffectSpeed(2f);
        SetEffectRange(0f);
    }

    private void Start()
    {
        StartCoroutine(CorrutineGeneratePoints());
    }

    IEnumerator CorrutineGeneratePoints()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetEffectSpeed());
            GeneratePoints();
        }
    }
}

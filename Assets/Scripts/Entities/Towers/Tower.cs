using Assets.Scripts.Interface;
using UnityEngine;

public class Tower : Entity, IEvolve
{
    private int pointsToEvolve;

    protected override void Awake()
    {
        entityType = EntityType.Tower;
        base.Awake();
    }
    public bool CanEvolve(int points) { return points >= pointsToEvolve; }

    public void Evolve() { pointsToEvolve *= 2; }

    public int GetPointsToEvolve() { return pointsToEvolve; }

    public void SetPointsToEvolve(int points) { pointsToEvolve = points; }
}

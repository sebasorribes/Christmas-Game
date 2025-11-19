using Assets.Scripts.Interface;
using System.Collections;
using UnityEngine;

public class SpawnTower : Tower, ISpawn
{
    [SerializeField] private Heroe heroe;
    private GameObject spawnPoint;

    public void SetHeroe(Heroe heroe)
    {
        this.heroe = heroe;
    }
    public Heroe GetHeroe()
    {
        return heroe;
    }
    public void Spawn()
    {
        Instantiate(heroe, spawnPoint.transform.position, Quaternion.identity,spawnPoint.transform);
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetEffectSpeed());
            if (spawnPoint.transform.childCount < 1)
            {
                Spawn();
            }
        }
    }

    protected override void Awake()
    {
        SetMaxHealth(100);
        base.Awake();
        SetEffectPoints(0);
        SetEffectSpeed(10f);
        SetEffectRange(0f);
        spawnPoint = transform.GetChild(0).gameObject;
        StartCoroutine(SpawnRoutine());
        Spawn();
    }
}

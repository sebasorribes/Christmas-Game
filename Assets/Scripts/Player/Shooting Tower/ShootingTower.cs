using System.Collections;
using UnityEngine;

public class ShootingTower : MonoBehaviour
{
    private DetectionArea detectionArea;
    private int damage = 10;
    private float rate = 1f;

    private void Awake()
    {
        detectionArea = gameObject.GetComponentInChildren<DetectionArea>();
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            if (detectionArea.triggerOccuped)
            {
                GameObject enemy = detectionArea.GetDetectedObjects()[0];
                Shoot(enemy);
            }
            yield return new WaitForSeconds(rate);
        }
    }

    void Shoot(GameObject enemy)
    {
        enemy.GetComponent<TestEnemy>().TakeDamage(damage);
    }
}

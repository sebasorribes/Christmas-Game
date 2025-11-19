using System;
using UnityEngine;

public class DebuffDetectionArea : MonoBehaviour
{
    public event Action<GameObject> OnDebuffEnemy;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.transform.localScale = GetComponent<CircleCollider2D>().radius * 2 * Vector2.one;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            OnDebuffEnemy?.Invoke(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Grinch>().UnDebuffed();
        }
    }
}

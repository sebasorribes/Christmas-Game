using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    public bool triggerOccuped = false;
    private List<GameObject> detectedObjects = new List<GameObject>();
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
            detectedObjects.Add(collision.gameObject);
            triggerOccuped = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (detectedObjects.Contains(collision.gameObject))
        {
            detectedObjects.Remove(collision.gameObject);
        }
        if (detectedObjects.Count == 0)
        {
            triggerOccuped = false;
        }
    }
    public List<GameObject> GetDetectedObjects()
    {
        return detectedObjects;
    }
}

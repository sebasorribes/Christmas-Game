using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    public bool triggerOccuped = false;
    private List<GameObject> detectedObjects = new List<GameObject>();
    private SpriteRenderer sprite;
    [SerializeField] private EntityType entityType;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.transform.localScale = GetComponent<CircleCollider2D>().radius * 2 * Vector2.one;
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //funciona por el momento para que no tire error las cuando se tocan las areas de efecto entre si
        if (collision.GetComponent<Entity>() == null) return;
        if (collision.GetComponent<Entity>().GetEntityType() == entityType)
        {
            detectedObjects.Add(collision.gameObject);
            triggerOccuped = true;
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
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

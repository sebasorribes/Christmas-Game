using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance { get; private set; }

    private int pointsToInvoke = 0;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddPoints(int points)
    {
        pointsToInvoke += points;
        pointsToInvoke = Mathf.Min(99999, pointsToInvoke);
        UIManager.Instance.AddPoints(pointsToInvoke);
    }

    public void UsePoints(int points)
    {
        if(pointsToInvoke >= points)
        {
            pointsToInvoke = Mathf.Max(0, pointsToInvoke - points);
            UIManager.Instance.AddPoints(pointsToInvoke);
        }
    }
}

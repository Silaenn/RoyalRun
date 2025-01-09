using UnityEngine;

public class Coim : Pickup
{
    [SerializeField] int scoreAmount = 100;
    ScoreManager scoreManager;
    void Awake() {
        scoreManager = FindAnyObjectByType<ScoreManager>();    
    }
    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(scoreAmount);
    }
}

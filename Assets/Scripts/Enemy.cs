using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;
    
    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindFirstObjectByType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            scoreBoard.IncreaseScore(scoreValue);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
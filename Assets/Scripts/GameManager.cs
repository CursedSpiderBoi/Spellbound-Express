using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    private int score = 0;

    private void Awake()
    {
        // Enforce singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Only one GameManager should exist
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist between scenes
    }

    // Add score and log to console
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score Updated: " + score);
    }

    // Optional: Access current score
    public int GetScore()
    {
        return score;
    }
}

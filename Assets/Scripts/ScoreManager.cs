using UnityEngine;
using TMPro; // Add TextMeshPro namespace
using System.Collections; // Add for IEnumerator

public class ScoreManager : MonoBehaviour
{
    void Awake()
    {
        // Start the coroutine when the object is initialized
        StartCoroutine(AddPointsOverTime());
    }
    [SerializeField] private TextMeshProUGUI scoreText; // Change to TextMeshProUGUI
    
    void Start()
    {
        GameManager.Instance.AddScore(10); // Adds 10 points
    }

    void Update()
    {

        if (scoreText != null)
        {
            // Assuming GameManager has a GetScore() method, adjust if different
            scoreText.text = "Score: " + GameManager.Instance.GetScore().ToString();
        }
    }
    private IEnumerator AddPointsOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.AddScore(1);
        }
    }

}

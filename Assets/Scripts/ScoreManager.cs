/*using UnityEngine;
using TMPro; 
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component

    private void Start()
    {
        UpdateScoreText(0); // Initialize the score display with 0 coins
    }

    // Method to update the score display
    public void UpdateScoreText(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = $"Coins: {score}";
        }
        else
        {
            Debug.LogError("ScoreText is not assigned in the inspector!");
        }
    }
}*/

using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("ScoreText is not assigned in the ScoreManager.");
        }
        UpdateScoreText(0); // Initialize with 0
    }

    public void UpdateScoreText(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = $" COINS: {score}";
        }
        else
        {
            Debug.LogError("ScoreText is not assigned in the inspector!");
        }
    }
}


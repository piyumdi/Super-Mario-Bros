/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int world { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set; }
    public int coins { get; private set; }

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        //Application.targetFrameRate = 60;
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        coins = 0;

        LoadLevel(1, 1);
    }

    private void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void NextLevel()
    {
        LoadLevel(world, stage + 1);
    }

    public void ResetLevel(float delay)
    {
        //CancelInvoke(nameof(ResetLevel));
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0)
        {
            LoadLevel(world, stage);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        NewGame();
    }

    public void AddCoin()
    {
        coins++;
        Debug.Log("Coin Collected. Total Coins: " + coins);

        if (coins == 100)
        {
            AddLife();
            coins = 0;
        }
        UpdateScoreText();
    }

    public void AddLife()
    {
        lives++;
    }

    private void UpdateScoreText()
    {
        Debug.Log("Updating Score Text: Coins = " + coins);
        scoreText.text = $"SCORE: {coins}";
    }
}
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int world { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set; }
    public int coins { get; private set; }

    private ScoreManager scoreManager;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional, if you plan to switch scenes later
        }
    }

    private void Start()
    {
        // Find the ScoreManager in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene. Please make sure ScoreManagerObject exists.");
        }
        else
        {
            UpdateScore(); // Initialize the score display
        }
    }

    public void AddCoin()
    {
        coins++;
        UpdateScore();

        if (coins == 100)
        {
            AddLife();
            coins = 0;
            UpdateScore(); // Reset the score to 0 after gaining an extra life
        }
    }

    private void AddLife()
    {
        lives++;
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0)
        {
            LoadLevel(world, stage);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        NewGame();
    }

    private void UpdateScore()
    {
        if (scoreManager != null)
        {
            scoreManager.UpdateScoreText(coins);
        }
        else
        {
            Debug.LogError("ScoreManager not found when updating the score!");
        }
    }

    private void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;
        SceneManager.LoadScene($"{world}-{stage}");
    }

    private void NewGame()
    {
        lives = 3;
        coins = 0;
        UpdateScore(); // Initialize the score display
        LoadLevel(1, 1); // Your level loading logic
    }
}

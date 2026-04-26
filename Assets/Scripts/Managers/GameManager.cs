using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Oyun Ayarlarý")]
    public float levelTime = 120f;

    [Header("Oyun Durumu")]
    public float currentTime;
    public int score;
    public bool isGameOver = false;

    void Awake()
    {
        // Singleton pattern — sahnede tek GameManager olsun
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        currentTime = levelTime;
    }

    void Update()
    {
        if (isGameOver) return;

        // Geri sayým
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameOver();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Skor: " + score);
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Oyun Bitti! Final Skor: " + score);
    }
}
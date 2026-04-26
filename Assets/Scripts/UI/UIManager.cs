using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Elemanlarý")]
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (GameManager.Instance == null) return;

        // Süreyi güncelle
        int kalan = Mathf.CeilToInt(GameManager.Instance.currentTime);
        timeText.text = "Süre: " + kalan;

        // Skoru güncelle
        scoreText.text = "Skor: " + GameManager.Instance.score;
    }
}
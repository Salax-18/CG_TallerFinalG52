using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI")]
    public TextMeshProUGUI textoScore;

    private int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreUI();
        Debug.Log(""+ score);
    }

    
    public void SubtractPoints(int points)
    {
        score -= points;

       
        if (score < 0) score = 0;

        UpdateScoreUI();
        Debug.Log("Has perdido " + points + " puntos. Total: " + score);
    }

    private void UpdateScoreUI()
    {
        if (textoScore != null)
            textoScore.text = "" + score;
    }
}

using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("UI Elements")]
    public TMP_Text tValue;

    [Header("Score Values")]
    public int currentScore = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddPoints(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }

    public void SubtractPoints(int amount)
    {
        currentScore -= amount;
        if (currentScore < 0) currentScore = 0; 
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (tValue != null)
            tValue.text = "Score: " + currentScore.ToString();
    }
}

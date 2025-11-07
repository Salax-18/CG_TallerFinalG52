using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI")]
    public TextMeshProUGUI textoScore;

    private int score = 0;
    public int fallCount = 0;
    public float elapsedTime = 0f;
    private bool timerRunning = false;
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

 

    void Update()
    {
        if (timerRunning)
            elapsedTime += Time.deltaTime;
    }

    
    public void StartTimer()
    {
        timerRunning = true;
        elapsedTime = 0f;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void AddFall()
    {
        fallCount++;
    }

    
    public void ShowFinalPanel(GameObject panel)
    {
        if (panel == null)
        {
            Debug.LogWarning(" No se asignó un panel final en GoalTrigger.");
            return;
        }

        panel.SetActive(true);

        TMP_Text scoreT = panel.transform.Find("FinalScoreText").GetComponent<TMP_Text>();
        TMP_Text fallsT = panel.transform.Find("FinalFallsText").GetComponent<TMP_Text>();
        TMP_Text timeT = panel.transform.Find("FinalTimeText").GetComponent<TMP_Text>();

        scoreT.text = "Score: " + textoScore.text;
        fallsT.text = "Caídas: " + fallCount;
        timeT.text = "Tiempo: " + FormatTime(elapsedTime);
    }

    private string FormatTime(float t)
    {
        int minutes = Mathf.FloorToInt(t / 60f);
        int seconds = Mathf.FloorToInt(t % 60f);
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

}

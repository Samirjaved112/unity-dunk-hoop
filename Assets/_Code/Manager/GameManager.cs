using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int playerScore;
    public  int streakCount;
    [SerializeField]
    private GameObject streakprefab;
    public GameObject hoop;
    public GameObject streak;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    public int scoreCheck;
    [SerializeField]
    private TextMeshProUGUI streakText;
    public GameObject streakPanel;
    public GameObject streakBg;
    public Camera mainCamera;
    public float ballSpeed;
    public float spawnDelay;
    public static bool isgameOver;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 0;
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        
    }
    public void ScoreCount(int score)
    {
        if (score == 3)
        {
            streakCount++;
        }
        else
        {
            Debug.Log("else working");
            streakCount = 0;
        }
        playerScore += score;
        setingBallProperty();
    }
    private void setingBallProperty()
    {
        if (ballSpeed <= 12)
        {
            if (playerScore >= scoreCheck)
            {
                ballSpeed += 1f;
                spawnDelay -= 0.3f;
                scoreCheck += 20;
            }
        }
        scoreText.text = "Score " + playerScore.ToString();
        if (streakCount >= 2)
        {
            mainCamera.backgroundColor = new Color(0.490566f, 0.03008189f, 0.03008189f, 1f);
            streakBg.SetActive(true);
            streakPanel.SetActive(true);
            streakText.text = "Streak  " + streakCount.ToString();
            streak = Instantiate(streakprefab, hoop.transform);
        }
        else
        {
            streakPanel.SetActive(false);
            streakBg.SetActive(false);
            mainCamera.backgroundColor = new Color(0.90f, 0.90f, 0.90f, 1f);
        }
    }
    
    
}

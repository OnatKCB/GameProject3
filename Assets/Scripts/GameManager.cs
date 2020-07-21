using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text bestScoreText;

    public GameObject gameOverPanel;
    
    public int Score;
    public int BestScore;

    void Awake()
    {
        if (PlayerPrefs.HasKey("BestScore") == false)
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();
        scoreText.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + PlayerPrefs.GetInt("Score");
        bestScoreText.text = "Best Score : " + PlayerPrefs.GetInt("BestScore");
        CalculateBestScore();
    }
    void CalculateBestScore()
    {
        if (PlayerPrefs.GetInt("BestScore") < Score)
        {
            PlayerPrefs.SetInt("BestScore", Score);
        }
    }

    public void GameOver() 
    {
        gameOverPanel.SetActive(true);
        bestScoreText.IsActive();
        bestScoreText.text = "Best Score : " + BestScore;
        bestScoreText.text = BestScore.ToString();
    }
    public void AddScore() 
    {
        Score++;
        scoreText.text = "Score : " + Score;
        PlayerPrefs.SetInt("Score", Score);
        scoreText.text = Score.ToString();
        Debug.Log(Score);
    }
    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public MouthScript mouth;
    public AppleSpawner appleSpawner;
    public int gameTime = 60;
    public Text highScoreText;
    public Text timerText;
    public GameObject gameOverScreen;
    public Text finalScoreText;
    public Text finalHighScoreText;

    private void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        StartCoroutine(countDown());
    }

    void OnGameOver()
    {
        appleSpawner.gameOver = true;

        int highScore = PlayerPrefs.GetInt("HighScore");
        if (highScore<MouthScript.score)
        {
            PlayerPrefs.SetInt("HighScore", MouthScript.score);
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }

        finalScoreText.text = "Score: " + MouthScript.score;
        finalHighScoreText.text = "High Score " + PlayerPrefs.GetInt("HighScore");

        gameOverScreen.SetActive(true);
    }

    IEnumerator countDown()
    {
        for (int i = gameTime; i >= 0; i--)
        {
            string minutes = Mathf.Floor(gameTime / 60).ToString("00");
            string seconds = (gameTime % 60).ToString("00");

            gameTime = i;
            timerText.text = minutes + ":" + seconds;

            yield return new WaitForSeconds(1);
        }
        OnGameOver();
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

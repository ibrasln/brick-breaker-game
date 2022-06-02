using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int lives, score;
    public Text livesText, scoreText;
    public bool gameOver;

    [SerializeField]
    GameObject gameOverPanel;

    void Start()
    {
        livesText.text = "Lives: " + lives.ToString();
        scoreText.text = "Score: " + score.ToString();

        gameOverPanel.GetComponent<RectTransform>().localScale = Vector3.zero; // Boyutlarini 0 yaptik.
        gameOverPanel.GetComponent<CanvasGroup>().alpha = 0; // Alpha degerini 0 yaptik ve gorunmez hale getirdik.

    }

    // Update is called once per frame
    public void UpdateLives(int countLive)
    {
        lives += countLive;

        if(lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives.ToString();
    }

    public void UpdateScore(int _score)
    {
        this.score += _score; // Scriptin icerisindeki score disaridan gonderdigimiz score'a esittir.
        scoreText.text = "Score: " + score.ToString();
    }

    void GameOver()
    {
        gameOver = true;

        gameOverPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f); // Alpha degerini 0.5 saniye icerisinde 1 yapar.
        gameOverPanel.GetComponent<RectTransform>().DOScale(1, 0.5f); // Scale degerini 0.5 saniye icerisinde 1 yapar.
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game"); // Girilen sahne ismini yukler.
    }

    public void Exit()
    {
        Application.Quit(); // Apk ciktisinda calisir. .exe modunda calismaz.
    }

}

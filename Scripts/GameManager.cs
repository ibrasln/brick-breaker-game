using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int lives, score;
    public Text livesText, scoreText;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives.ToString();
        scoreText.text = "Score: " + score.ToString();

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
    }

}

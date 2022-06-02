using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBrickController : MonoBehaviour
{

    [SerializeField]
    Sprite brokenImage;

    [SerializeField]
    GameObject brickBrokenEffect;

    int count; // Topun tuglaya kac kere carptigini sayar.

    GameManager gameManager;

    [SerializeField]
    GameObject scoreUpBall;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Start()
    {
        count = 0;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Ball"))
        {
            count++;

            if(count == 1) // Eger 1 kere carptiysa
            {
                GetComponent<SpriteRenderer>().sprite = brokenImage; // Resmimizi kirilmis hali ile degistiriyoruz.
                gameManager.UpdateScore(5); // Ilk vurusta 5 puan kazandirir.
            }
            else if(count == 2)
            {
                Instantiate(brickBrokenEffect, transform.position, transform.rotation);
                gameManager.UpdateScore(10); // Ikinci vurusta 10 puan kazandirir.

                int rand = Random.Range(1, 101);

                if(rand > 50)
                {
                    Instantiate(scoreUpBall, transform.position, transform.rotation);
                }

                Destroy(gameObject);
            }

        }
    }
}

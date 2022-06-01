using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{

    [SerializeField]
    GameObject brickEffect;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Ball")) // Carpisma yasadigimiz objenin tag'i Ball ise
        {
            gameManager.UpdateScore(5); // Tuglayi yokettigimizde 5 puan kazandirir.
            Instantiate(brickEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            
            
        }
    }

}

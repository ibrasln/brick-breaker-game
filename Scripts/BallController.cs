using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField]
    float speed;

    public bool inPlay; // Default hali false'dir.

    [SerializeField]
    Transform ballStartPos;

    GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameManager.gameOver) // Eger gameOver bool degiskeni true ise
        {
            return; // Direkt update fonksiyonundan cikar.
        }

        // Edit -> Project Settings -> Input Manager'dan tuslari ogrenebiliriz. (Jump -> Space)
        if (Input.GetButtonDown("Jump") && !inPlay) // Space tusuna basildiginda ve inPlay false oldugunda
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }

        if (!inPlay) // Eger inPlay false ise
        {
            transform.position = ballStartPos.position; // Topun pozisyonunu BallHolder'in pozisyonuna getir. (Paddle'in bi tik ustu)
        }

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Bottom"))
        {
            rb.velocity = Vector2.zero; // Topun hizi 0 olacak.
            gameManager.UpdateLives(-1); // Cani guncelleyen fonksiyona eristik ve her oluste cani azalttik.
            inPlay = false; // Boylece direkt paddle'in ustune gelecek.
        }
    }

}

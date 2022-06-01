using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    float speed;

    // Sahnenin disina cikmamasi icin sinirlari belirttik.
    float leftTarget = -7.65f;
    float rightTarget = 7.65f;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Update()
    {

        if (gameManager.gameOver) return; // Eger game over degiskeni true ise Update'den cik.

        #region Hareket
        float h = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * h * speed * Time.deltaTime);
        #endregion

        #region Ekrani Sinirlandirma
        //if(transform.position.x < leftTarget) // Eger paddle'in x degeri sol sinirdan kucukse
        //{
        //    transform.position = new Vector2(leftTarget, transform.position.y); // paddle'in x degerini sol sinira esitle, y degerini sabit tut. Boylece sol siniri asamayacak.
        //}

        //if(transform.position.x > rightTarget)
        //{
        //    transform.position = new Vector2(rightTarget, transform.position.y); // paddle'in x degerini sag sinira esitle, y degerini sabit tut. Boylece sag siniri asamayacak.
        //}
        
        // Yukaridaki sekilde de yapilabilir, asagidaki sekilde de yapilabilir.

        Vector2 temp = transform.position;
        temp.x = Mathf.Clamp(temp.x, leftTarget, rightTarget);
        transform.position = temp;
        #endregion
    }
}

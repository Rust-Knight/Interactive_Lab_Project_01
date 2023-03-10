using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    
    private ScoreManager scoreManager;


    public int coins;

    void Start()
    {
        scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();

        
    }

    private void Update()
    {

       
        DestroyCoinObjectDelayed();

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            scoreManager.score += 1f;


            Destroy(gameObject);
        }
    }


    void DestroyCoinObjectDelayed()
    {
        // Kills the game object in 3 seconds after loading the object
        Destroy(gameObject, 3);
    }

   
}

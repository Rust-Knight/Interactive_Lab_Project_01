using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObjectDelayed();
    }
    private void OnTriggerEnter2D(Collider2D other) // added for destroy obect when colliding with player
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }


    void DestroyObjectDelayed()
    {
        // Kills the game object in 3 seconds after loading the object
        Destroy(gameObject, 3);
    }

}

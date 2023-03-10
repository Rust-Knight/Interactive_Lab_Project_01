using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawnPoints : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] hazard;

    private int randome;
    private int randomePosition;


    public float startTimeBtwSpawns;
    private float timeBtwSpawns;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns < 0.3)
        {
            randome = Random.Range(0, hazard.Length);
            randomePosition = Random.Range(0, spawnPoints.Length);
            Instantiate(hazard[randome], spawnPoints[randomePosition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
            
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

    
}

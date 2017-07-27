﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject car;
    public GameObject[] spawns;

    public float startWait = 1f;
    public float spawnWait = 3f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnCars()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            int carDirection = 1;
            int spawnNumber = Random.Range(0, 2);
            Transform spawnPosition = spawns[spawnNumber].transform;
            carDirection = spawnNumber > 0 ? -1 : 1;

            GameObject carSpawned = Instantiate(car, spawnPosition);
            carSpawned.gameObject.GetComponent<Rigidbody2D>().gravityScale = carDirection;
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
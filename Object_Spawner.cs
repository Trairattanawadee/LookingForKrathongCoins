using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spawner : MonoBehaviour
{
    public GameObject[] icePrefab = new GameObject[0];
    public GameObject bombPrefab, boosterPrefab, shieldPrefab, teleporterPrefab;
    public Transform[] spawnPoints = new Transform[0];
    public float mintime, maxtime, timer, 
        bombtimer, bombmintime, bombmaxtime,
        boostertimer, boostermintime, boostermaxtime,
        shieldtimer, shieldmaxtime,
        teleportertimer, teleportermaxtime;
    public int Difficult = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Score_System.gamestart)
        { if (timer <= 0)
            {
                int index = Random.Range(0, spawnPoints.Length);
                int objindex = Random.Range(0, icePrefab.Length);
                Transform target = spawnPoints[index];
                Instantiate(icePrefab[objindex], target.position, target.rotation);
                timer = Random.Range(mintime, maxtime);
            }
            timer -= Time.deltaTime;
            if (!Player_Control.booster)
            {
                if (boostertimer <= 0)
                {
                    int index = Random.Range(0, spawnPoints.Length);
                    Transform target = spawnPoints[index];
                    Instantiate(boosterPrefab, target.position, target.rotation);
                    boostertimer = Random.Range(boostermintime, boostermaxtime);
                }
                boostertimer -= Time.deltaTime;
            }

            if (Score_System.instance.scores >= 10)
            {
                if (bombtimer <= 0)
                {
                    int index = Random.Range(0, spawnPoints.Length);
                    Transform target = spawnPoints[index];
                    Instantiate(bombPrefab, target.position, target.rotation);
                    bombtimer = Random.Range(bombmintime, bombmaxtime);
                }
                bombtimer -= Time.deltaTime;

            }
            else
            {
                return;
            }
            if (Score_System.instance.scores >= 5000)
            {
                bombmintime = 0.5f; bombmaxtime = 1.5f; mintime = 0.4f; maxtime = 0.8f;
                Debug.Log("It's Chaos");
            }
            else if (Score_System.instance.scores >= 3000)
            {
                bombmintime = 0.5f; bombmaxtime = 2f; mintime = 0.5f; maxtime = 0.8f;
                Debug.Log("It's Getting Really Hard");
            }
            else if (Score_System.instance.scores >= 2000)
            {
                bombmintime = 1; bombmaxtime = 2f; mintime = 0.5f; maxtime = 1;
                Debug.Log("It's Getting More Harder");
            }
            else if (Score_System.instance.scores >= 1000)
            {
                bombmintime = 2; bombmaxtime = 2.5f; mintime = 0.5f; maxtime = 2;
                Debug.Log("It's Getting Harder");
            }
            /*for (int i = 0; i < Difficult; i++)
            {
                if (Score_System.scoreDif >= 1000)
                {
                    bombmintime -= 0.1f; bombmaxtime -= 0.2f; maxtime -= -0.2f;
                    Score_System.scoreDif = 0;

                }
            }*/
            if (!Player_Control.shield)
            {
                if (shieldtimer <= 0)
                {
                    int index = Random.Range(0, spawnPoints.Length);
                    Transform target = spawnPoints[index];
                    Instantiate(shieldPrefab, target.position, target.rotation);
                    shieldtimer = shieldmaxtime;
                }
                shieldtimer -= Time.deltaTime;
            }
            if (!Player_Control.teleporter)
            {
                if (teleportertimer <= 0)
                {
                    int index = Random.Range(0, spawnPoints.Length);
                    Transform target = spawnPoints[index];
                    Instantiate(teleporterPrefab, target.position, target.rotation);
                    teleportertimer = teleportermaxtime;
                }
                teleportertimer -= Time.deltaTime;
            }
            
        }
    
    }
}

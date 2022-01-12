using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float spawnTimer;
    float spawnRate = 3f;
    public GameObject obj;
    public static bool gameover;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
            if (spawnTimer >= spawnRate)
            {
                spawnTimer -= spawnRate;
                Vector2 spawnPos = new Vector2(2f, Random.Range(-0.8f, 10f));
                Instantiate(obj, spawnPos, Quaternion.identity);
            }
        }
}


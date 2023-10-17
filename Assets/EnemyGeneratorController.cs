using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] enemyCars;
    [SerializeField] float spawnDelay = 3f;
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnDelay)
        {
            //continue here and instatiate cars
            timer = 0;
        }
    }
}

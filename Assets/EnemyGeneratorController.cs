using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] enemyCars;
    [SerializeField] GameObject playerCar;
    [SerializeField] float spawnDelay = 3f;
    [SerializeField] float zDistanceFromCar = 50f;
    float timer = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnDelay)
        {
            GameObject carInstans = Instantiate(enemyCars[Random.Range(0, enemyCars.Length - 1)],transform);
            carInstans.transform.position = new Vector3(playerCar.transform.position.x-zDistanceFromCar,playerCar.transform.position.y,Random.Range(-20,19));
            carInstans.AddComponent<EnemyCarController>();
            carInstans.transform.localScale = playerCar.transform.localScale;
            timer = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    //a set of cars to choose from and spawn
    [SerializeField] GameObject[] enemyCars;
    [SerializeField] GameObject playerCar;
    //the Explosion Effect for cars when they explode
    [SerializeField] GameObject explosionEffect;
    //Time between Spawns
    [SerializeField] float spawnDelay = 3f;
    //How far away will the enemycar spawn in x axis from the player
    [SerializeField] float xDistanceFromCar = 50f;
    //a timer for spawn delay
    float timer = 0;


    void Update()
    {
        timer += Time.deltaTime;
        // if the timer is bigger than spawndelay then instantiate a car
        if (timer > spawnDelay)
        {
            InstantiateCar();
        }
    }
    
    void InstantiateCar()
    {
        //instatiate a car by picking a random car from enemyCars array 
        GameObject carInstans = Instantiate(enemyCars[Random.Range(0, enemyCars.Length - 1)], transform);
        //assign explosion effect;
        EnemyCarController.explosionEffect = explosionEffect;
        //setting the distance for the car from the player + giving the car a random position on the zAxis
        carInstans.transform.position = new Vector3(playerCar.transform.position.x - xDistanceFromCar, playerCar.transform.position.y, Random.Range(-20, 19));
        //adds The Controller Script for enemyCars to make the car move etc.
        carInstans.AddComponent<EnemyCarController>();
        //scale the car so that it's as big as the players car.
        carInstans.transform.localScale = playerCar.transform.localScale;
        //reset the timer
        timer = 0;
    }
}

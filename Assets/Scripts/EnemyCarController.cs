using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCarController : MonoBehaviour
{
    //the speed of enemy cars
    float speed = 100;
    //the counter for cars destroyed
    public static int ammounCarsDestroyed { get; set; } = 0;
   
    void Start()
    {
        //rotates the car so that it faces the player
        transform.localEulerAngles = new Vector3(0, 90,0);
    }

    // Update is called once per frame
    void Update()
    {
        //Move the car forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //rotates the wheels
        AnimateWheels();
        //if the enemy cars position is larger than the player position then destroy after 2 seconds
        if(transform.position.x > CarController.position.x)
        {
            Destroy(gameObject,2);
        } 
    }
    

    private void OnCollisionEnter(Collision collision)
    {
          
       // if collisions tag is ball then destroy the ball and the car and increase the cars Destoryed counter
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ammounCarsDestroyed++;
        }
        //if collision is player then destroy car and increase the cars destroyed counter and load the game over scene
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            ammounCarsDestroyed++;
            SceneManager.LoadSceneAsync("GameOver");
        }
    }

    void AnimateWheels()
    {
        
        foreach (GameObject wheel in GetWheels())
        {
            //rotate every wheel forward in the wheel list
            wheel.transform.Rotate(Vector3.right, Space.Self);
        }
        //A function returning a list of gamobject (wheels)
        List<GameObject> GetWheels()
        {
            //create the list of objects
            List<GameObject> wheels = new List<GameObject>();
            //find the mesh transform in the car body
            Transform wheelMeshTransform = transform.Find("Wheels").Find("Meshes");
            //get the wheels and assign them to the list to later return them
            for (int i = 0; i < wheelMeshTransform.childCount; i++)
            {
                wheels.Add(wheelMeshTransform.GetChild(i).gameObject);
            }
            return wheels;

        }
    }
}

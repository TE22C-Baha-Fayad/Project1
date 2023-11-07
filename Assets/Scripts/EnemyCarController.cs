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

        AnimateWheels();
        //if the enemy cars position is larger than the player position then destroy after 2 seconds
        if(transform.position.x > CarController.position.x)
        {
            Destroy(gameObject,2);
        } 
    }
    

    private void OnCollisionEnter(Collision collision)
    {
          
       
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(gameObject);
            ammounCarsDestroyed++;
        }
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
            wheel.transform.Rotate(Vector3.right, Space.Self);
        }
        List<GameObject> GetWheels()
        {
            List<GameObject> wheels = new List<GameObject>();
            Transform wheelMeshTransform = transform.Find("Wheels").Find("Meshes");
            for (int i = 0; i < wheelMeshTransform.childCount; i++)
            {
                wheels.Add(wheelMeshTransform.GetChild(i).gameObject);
            }
            return wheels;

        }
    }
}

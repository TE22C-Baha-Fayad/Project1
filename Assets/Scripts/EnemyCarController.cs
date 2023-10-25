using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;

public class EnemyCarController : MonoBehaviour
{
    float speed = 30;
    public static int ammounCarsDestroyed { get; private set; } = 0;
   
    void Start()
    {
        
        transform.localEulerAngles = new Vector3(0, 90,0);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        foreach(GameObject wheel in GetWheels())
        {
            wheel.transform.Rotate(Vector3.right,Space.Self);
        }

        if(transform.position.x > CarController.position.x)
        {
            Destroy(gameObject,2);
        } 
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

    private void OnCollisionEnter(Collision collision)
    {
          
       
        if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ammounCarsDestroyed++;
        }
    }
}

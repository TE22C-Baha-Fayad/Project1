using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //nuvarande positionen för bilen 
    [HideInInspector]
    public static Vector3 position;
    public static float speed { get; set; }
    //accelerations konstanten
    [SerializeField] float acceleration = 5;
    [SerializeField] float topSpeed = 70;
    [SerializeField] float minimumSpeed = 5;
    //hastigheten för när bilen flyttar horizontelt
    [SerializeField] float horizontalSpeed = 50;
    [SerializeField] GameObject brakeLights;
    //bilens ljud
    AudioSource audioSource;
    float accelerationTimer = 0;
    void Start()
    {
        //hämta audiosource komponenten från gameobjektet
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //sound pitch depending on speed
        audioSource.pitch = speed / 25;
        accelerationTimer += Time.deltaTime;
        //refresh the position 
        position = transform.position;

        VerticalMovement();
        HorizontalMovement();
        AnimateWheels();


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
    void HorizontalMovement()
    {
        //get the horizontal input
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float roadBorderSize = 20;
        //if the car goes outside the border on the right side and input is negative then make the car get back
        if (transform.position.z > roadBorderSize && inputHorizontal < 0)
        {

            transform.Translate(new Vector3(inputHorizontal, 0, 0) * horizontalSpeed * Time.deltaTime);
        }//else if the car goes outside the border on the left side and input is positive then make the car get back
        else if (transform.position.z < -roadBorderSize && inputHorizontal > 0)
        {
            transform.Translate(new Vector3(inputHorizontal, 0, 0) * horizontalSpeed * Time.deltaTime);
        }//else if the is in between the road size then allow the player to move freely on both sides
        else if (transform.position.z > -roadBorderSize && transform.position.z < roadBorderSize)
        {
            transform.Translate(new Vector3(inputHorizontal, 0, 0) * horizontalSpeed * Time.deltaTime);
        }
    }
    /// <summary>
    /// Vertical Movement also includes brake lights 
    /// </summary>
    void VerticalMovement()
    {
        // get the vertical input
        float inputVertical = Input.GetAxisRaw("Vertical");
        //if the current speed is less than top speed and there is no vertical input then the speed will be affected acceleration
        if (speed < topSpeed && inputVertical == 0)
        {
            speed = acceleration * accelerationTimer;

        }
        //if the vertical input is larger than 0 and speed is less than top speed then accelerate faster 
        if (inputVertical > 0 && speed < topSpeed)
        {
            speed += speed * Time.deltaTime;
        }
        //if input is negative and speed is larger than minimum speed then break
        if (inputVertical < 0 && speed > minimumSpeed)
        {
            speed -= speed * Time.deltaTime;
        }
        
       

        if (inputVertical < 0)
        {
            //if vertical input is negative then enable break lights and set the acceleration timer relation to be speed / acceleration which gives time (m/s)/(m/s^2) = s
            brakeLights.SetActive(true);
            accelerationTimer = speed / acceleration;
        }
        else
        {
            //break lights disabled
            brakeLights.SetActive(false);
        }
        if (inputVertical > 0)
        {
            // if the car is accelerating then set the timer to match the speed current speed and acceleration, same as in inputVertical<0
            accelerationTimer = speed / acceleration;
        }
        //move the car forward affecting it by speed and delta time.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

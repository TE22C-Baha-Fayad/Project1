using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public static Vector3 position;
    public static float speed { get; private set; }
    [SerializeField] float acceleration = 5;
    [SerializeField] float topSpeed = 70;
    [SerializeField] float minimumSpeed = 5;
    [SerializeField] float horizontalSpeed = 50;
    [SerializeField] GameObject brakeLights;
    AudioSource audioSource;
    float accelerationTimer = 0;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //todo list
        //game menu/ gameover overlay
        //ability to shoot cars and possibly count score

        audioSource.pitch = speed / 25;
        accelerationTimer += Time.deltaTime;
        float inputVertical = Input.GetAxisRaw("Vertical");
        if (speed < topSpeed && inputVertical == 0)
        {
            speed = acceleration * accelerationTimer;

        }


        position = transform.position;
        foreach (GameObject wheel in GetWheels())
        {
            wheel.transform.Rotate(Vector3.right, Space.Self);
        }
        if (inputVertical > 0 && speed < topSpeed)
        {
            speed += speed * Time.deltaTime;
        }
        if (inputVertical < 0 && speed > minimumSpeed)
        {
            speed -= speed * Time.deltaTime;
        }
        brakeLights.SetActive(false);
        if (inputVertical < 0)
        {
            brakeLights.SetActive(true);
            accelerationTimer = speed / acceleration;
        }
        if (inputVertical > 0)
        {

            accelerationTimer = speed / acceleration;
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (transform.position.z > 20 && inputHorizontal < 0)
        {

            transform.Translate(new Vector3(inputHorizontal, 0, 0) * horizontalSpeed * Time.deltaTime);
        }
        else if (transform.position.z < -20 && inputHorizontal > 0)
        {
            transform.Translate(new Vector3(inputHorizontal, 0, 0) * horizontalSpeed * Time.deltaTime);
        }
        else if (transform.position.z > -20 && transform.position.z < 20)
        {
            transform.Translate(new Vector3(inputHorizontal, 0, 0) * horizontalSpeed * Time.deltaTime);
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
}

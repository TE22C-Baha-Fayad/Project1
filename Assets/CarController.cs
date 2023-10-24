using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public static Vector3 position;
    private float speed;
    [SerializeField] float acceleration = 5;
    [SerializeField] float topSpeed = 70;
    [SerializeField] float minimumSpeed = 5;
    AudioSource audioSource;
    float accelerationTimer = 0;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        audioSource.pitch = speed / 100;
        accelerationTimer += Time.deltaTime;
        if(speed < topSpeed && Input.GetAxisRaw("Vertical") == 0)
            speed = acceleration * accelerationTimer;

        
        position = transform.position;
        foreach(GameObject wheel in GetWheels())
        {
            wheel.transform.Rotate(Vector3.right,Space.Self);
        }
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            speed += acceleration * 4 * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Vertical") < 0 && speed > minimumSpeed)
        {
            accelerationTimer = minimumSpeed/acceleration; //kolla så att acceleration time matchar så att man får perfekt acceleration beroende på hastigheten och bromsningen
            speed -= speed * Time.deltaTime;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * speed * Time.deltaTime);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public static Vector3 position;
    [SerializeField] float speed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        position = transform.position;
        foreach(GameObject wheel in GetWheels())
        {
            wheel.transform.Rotate(Vector3.right,Space.Self);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0).normalized * speed * Time.deltaTime);

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

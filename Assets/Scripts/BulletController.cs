using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 100;
   
    // Update is called once per frame
    void Update()
    {
        //makes the bullet travel forward from the players pov and destroyes the bullet after 15 seconds.
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
        Destroy(gameObject, 15);
    }
}

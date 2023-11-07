using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
   
    void Update()
    {
        //on space down then shoot a bullet
        if(Input.GetKeyDown(KeyCode.Space))
        ShootBullet();
    }
    void ShootBullet()
    {
       Instantiate(bullet, transform.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if the collider gameobject tag is equal to Player then Load Win Scene.
        if(other.tag == "Player")
        {
            SceneManager.LoadSceneAsync("Win");
        }
    }
}

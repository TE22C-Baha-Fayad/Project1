using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    
    public void DirectScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
        //reset static values 
        CarController.speed = 0;
        EnemyCarController.ammounCarsDestroyed = 0; 
    }
}

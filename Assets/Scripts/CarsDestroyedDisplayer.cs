using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarsDestroyedDisplayer : MonoBehaviour
{
    TextMeshProUGUI ammountCarsLabel; // the ui text mesh pro label
   
    void Start()
    {
        ammountCarsLabel = GetComponent<TextMeshProUGUI>(); //gets the component
        
    }

    
    void Update()
    {
        //assign the ui label with value from enemycarcontroller.
        ammountCarsLabel.text = EnemyCarController.ammounCarsDestroyed.ToString(); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarSpeedDisplayer : MonoBehaviour
{
    TextMeshProUGUI ammountCarsLabel;
    // Start is called before the first frame update
    void Start()
    {
        ammountCarsLabel = GetComponent<TextMeshProUGUI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        // assign the speed value from carcontroller to the ui displayer.
        ammountCarsLabel.text = (CarController.speed*3.6).ToString("0") + " km/h";
    }
}

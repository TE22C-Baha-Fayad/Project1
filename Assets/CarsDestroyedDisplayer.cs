using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarsDestroyedDisplayer : MonoBehaviour
{
    TextMeshProUGUI AmmountCarsLabel;
    // Start is called before the first frame update
    void Start()
    {
        AmmountCarsLabel = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        AmmountCarsLabel.text = EnemyCarController.ammounCarsDestroyed.ToString();
    }
}

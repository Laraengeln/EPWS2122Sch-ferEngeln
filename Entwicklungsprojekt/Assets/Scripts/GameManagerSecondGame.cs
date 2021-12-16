using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSecondGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Um das aktuelle Level zu speichern, wird der Progress-PlayerPref auf 2 gesetzt
        PlayerPrefs.SetInt("Progress", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

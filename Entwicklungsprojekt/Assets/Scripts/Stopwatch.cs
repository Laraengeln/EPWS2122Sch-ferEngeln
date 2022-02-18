using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Stopwatch : MonoBehaviour
{
    GameManager gameManager;

    bool stopWatchActive = false;
    float currentTime;
    public Text currentTimeText;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        currentTime = 0;        //Der Anfang wird in Sekunden agezeigt
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            stopWatchActive = true;
        }

       if (stopWatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
            if (currentTime <= 0)
            {
                stopWatchActive = false;
            }
        }
       TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");

        if (gameManager.questionCounter == gameManager.questions.Length) stopWatchActive = false;

    
    }
}

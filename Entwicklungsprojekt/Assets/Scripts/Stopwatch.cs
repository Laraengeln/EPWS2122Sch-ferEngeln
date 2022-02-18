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
<<<<<<< HEAD
    
=======
    float highscore;
>>>>>>> 8f3edf295dab486ef59e3a2f6b98357fde6cdb47

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Highscore vor Spiel: " + highscore);
        Debug.Log("Highscore in PlayerPrefs: " + PlayerPrefs.GetFloat("Highscore", 0));
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

<<<<<<< HEAD
        if (gameManager.questionCounter == gameManager.questions.Length) stopWatchActive = false;

    
=======

        if (gameManager.questionCounter == gameManager.questions.Length)
        {
            stopWatchActive = false;
            highscore = currentTime;
            Debug.Log("Highscore nach Spiel: " + highscore);

            if (highscore <= PlayerPrefs.GetFloat("Highscore", 0) || PlayerPrefs.GetFloat("Highscore", 0) == 0)
            {
                PlayerPrefs.SetFloat("Highscore", highscore);
                Debug.Log("Highscore in PlayerPrefs nach Spiel: " + PlayerPrefs.GetFloat("Highscore", 0));
            }
        }


>>>>>>> 8f3edf295dab486ef59e3a2f6b98357fde6cdb47
    }
}

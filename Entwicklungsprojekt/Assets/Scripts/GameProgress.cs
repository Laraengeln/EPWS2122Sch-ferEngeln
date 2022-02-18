using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgress : MonoBehaviour
{
    // Initialisierung der privaten Variablen
    string progressKey;
    int progress;
    string highscoreKey;
    float highscore;

    // Start is called before the first frame update
    void Start()
    {
        // progressKey und progress definieren PlayerPrefs um Spielstand zu speichern
        // Bei Start des Spiels wird durch den in den PlayerPrefs gespeicherten Int-Wert die Szene geladen, die zuletzt geoeffnet war
        progressKey = "Progress";
        progress = PlayerPrefs.GetInt(progressKey, 0);
        if(progress > 0)
        {
            SceneManager.LoadSceneAsync(progress);
        }

        highscoreKey = "Highscore";
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextGame : MonoBehaviour
{
    // Initialisierung der privaten Variablen
    Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        // Button zuweisen
        startButton = GetComponent<Button>();

        // Bei Drücken des Buttons wird StartGameOnButton ausgeführt
        startButton.onClick.AddListener(StartNextGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Methode um Szene des Spiels zu laden und somit Spiel zu starten
    void StartNextGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

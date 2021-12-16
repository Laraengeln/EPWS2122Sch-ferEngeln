using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    // Initialisierung der privaten Variablen
    Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        backButton = GetComponent<Button>();

        backButton.onClick.AddListener(BackToMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Methode um bei Drücken des Buttons zurück zum Hauptmenu zu kommen und den PlayerPref dementsprechend auch auf 0 zu setzen
    void BackToMainMenu()
    {
        Debug.Log(backButton.gameObject.name + " was clicked");
        PlayerPrefs.SetInt("Progress", 0);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}

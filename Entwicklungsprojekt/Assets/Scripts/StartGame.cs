using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    Button startButton;
    string sceneNameToStart = "SampleScene";

    // Start is called before the first frame update
    void Start()
    {
        startButton = GetComponent<Button>();

        startButton.onClick.AddListener(StartGameOnButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGameOnButton()
    {
        SceneManager.LoadScene(sceneNameToStart);
    }
}

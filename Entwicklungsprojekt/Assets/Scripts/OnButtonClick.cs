using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour
{

    Button button;
    GameManager gameManager;

    public Image buttonImage;

    // Start is called before the first frame update
    void Start()
    {
        // button und gameManager bekommen die jeweiligen Komponenten zugeordnet
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Wenn mit der Maus auf den Button geklickt wird, wird ShowImage() ausgeführt
        button.onClick.AddListener(ShowImage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Wenn buttonImage inaktiv ist, wird es aktiv oder andersrum
    void ShowImage()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        if (!buttonImage.gameObject.activeInHierarchy)
            buttonImage.gameObject.SetActive(true);
        else buttonImage.gameObject.SetActive(false);
    }
}

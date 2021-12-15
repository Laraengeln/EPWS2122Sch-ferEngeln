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
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button.onClick.AddListener(ShowTip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowTip()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        if (!buttonImage.gameObject.activeInHierarchy)
            buttonImage.gameObject.SetActive(true);
        else buttonImage.gameObject.SetActive(false);
    }
}

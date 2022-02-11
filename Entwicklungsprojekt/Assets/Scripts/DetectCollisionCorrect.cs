using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DetectCollisionCorrect : MonoBehaviour
{
    PlayerController player;
    GameManager gameManager;
    TextMeshProUGUI questionText;

    int[] order;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        questionText = GameObject.Find("Question Text").GetComponent<TextMeshProUGUI>();

        order = gameManager.order;

        questionText.text = gameManager.questions[order[0]];
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Wenn der Player vom Sprung aufkommt und auf einem Feld landet, wird dieses geloescht
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.transform.localScale.x == player.startScale)
        //{
            Debug.Log("counter: " + gameManager.questionCounter + "order[counter]" + order[gameManager.questionCounter] + "questions.length" + gameManager.questions.Length);
            gameManager.questionCounter++;
            questionText.text = gameManager.questions[order[gameManager.questionCounter]];
        //}
    }
}

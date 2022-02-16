using System;
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
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    // Wenn der Player vom Sprung aufkommt und auf einem Feld landet, wird dieses geloescht
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            gameManager.questionCounter++;
            questionText.text = gameManager.questions[order[gameManager.questionCounter]];
            Destroy(gameManager.speechBubbleCorrectAnswers[gameManager.questionCounter - 1]);
            Destroy(gameManager.speechBubbleWrongAnswers[gameManager.questionCounter - 1]);
            gameManager.speechBubbleCorrectAnswers[gameManager.questionCounter].SetActive(true);
            gameManager.speechBubbleWrongAnswers[gameManager.questionCounter].SetActive(true);
        } catch (Exception)
        {
            questionText.text = "Geschafft!";
            Destroy(gameManager.speechBubbleCorrectAnswers[gameManager.questionCounter - 1]);
            Destroy(gameManager.speechBubbleWrongAnswers[gameManager.questionCounter - 1]);
        }
    }
}
